using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using XueFu.EntLib;
using XueFu.Common;
using XueFu.Model;
using XueFu.BLL;
using XueFu.EntLib.MethodExtend;

namespace XueFu.Web.Admin
{
    public partial class UserAdd : AdminBasePage
    {
        protected int city = 0;
        protected int country = 0;
        protected int district = 0;
        protected int province = 0;
        protected int companyID = int.MinValue;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                UserName.CustomErr = Language.ReadLanguage("NoUserNameRuleTips");
                UserPassword.CustomErr = UserPassword2.CustomErr = Language.ReadLanguage("NoPasswordRuleTips");
                int queryString = RequestHelper.GetQueryString<int>("ID");

                State.DataSource = EnumHelper<UserState>.GetSelectList();
                State.DataTextField = "Key";
                State.DataValueField = "Value";
                State.DataBind();
                State.SelectedValue = ((int)UserState.NoCheck).ToString();

                GroupID.DataSource = EnumHelper<GroupType>.GetSelectList();
                GroupID.DataTextField = "Key";
                GroupID.DataValueField = "Value";
                GroupID.DataBind();
                GroupID.SelectedValue = ((int)GroupType.User).ToString();

                if (queryString != -2147483648)
                {
                    UserInfo info = UserBLL.ReadUser(queryString);

                    this.UserName.Text = info.Name;
                    this.RealName.Text = info.RealName;
                    this.GroupID.SelectedValue = info.GroupID.ToString();
                    this.Point.Text = info.Point.ToString();
                    this.Sex.Text = info.Sex.ToString();
                    this.Mobile.Text = info.Mobile;
                    this.IDCard.Text = info.IDCard;
                    this.WeChat.Text = info.WeChat;
                    this.State.Text = info.State.ToString();
                    this.UserName.Enabled = false;
                    this.Add.Visible = false;
                }
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            int originalState = int.MinValue;
            int point = 0;
            string name = this.UserName.Text;
            int queryString = RequestHelper.GetQueryString<int>("ID");
            UserInfo user = new UserInfo();
            if (queryString > 0)
            {
                user = UserBLL.ReadUser(queryString);
                originalState = user.State;
            }
            else
            {
                Regex regex = new Regex("^[a-zA-Z0-9_.@]{5,16}$");
                if (!regex.IsMatch(name))
                {
                    ScriptHelper.Alert(Language.ReadLanguage("NoUserNameRuleTips"), RequestHelper.RawUrl);
                }
                user.Password = StringHelper.Password(this.UserPassword.Text, (PasswordType)Config.ReadConfigInfo().PasswordType);
            }
            user.ID = queryString;
            user.Name = name;
            user.RealName = RealName.Text;
            user.Sex = Convert.ToInt32(this.Sex.Text);
            user.GroupID = Convert.ToInt32(this.GroupID.SelectedValue);
            if (user.GroupID <= 0) ScriptHelper.Alert(Language.ReadLanguage("GroupEmptyTips"));
            if (user.GroupID == 1)
            {
                if (!string.IsNullOrEmpty(this.Point.Text))
                {
                    point = Math.Abs(Convert.ToInt32(Point.Text));
                    if (Config.ReadConfigInfo().TotalScore < point)
                        ScriptHelper.Alert(Language.ReadLanguage("TotalScoreLessTips"));
                    user.Money += point;
                }
                else
                    ScriptHelper.Alert(Language.ReadLanguage("PointEmptyTips"));
            }
            user.Mobile = this.Mobile.Text;
            user.IDCard = this.IDCard.Text;
            if (!string.IsNullOrEmpty(user.IDCard))
            {
                UserSearchInfo userSearch = new UserSearchInfo();
                userSearch.IDCard = user.IDCard;
                userSearch.NotInUserID = user.ID.ToString();
                if (UserBLL.ReadUserList(userSearch).Count >= Config.ReadConfigInfo().MaxUserNum)
                    ScriptHelper.Alert(Language.ReadLanguage("IDCardOverflow").Replace("$MaxUserNum", Config.ReadConfigInfo().MaxUserNum.ToString()));
            }
            user.WeChat = this.WeChat.Text;
            user.State = Convert.ToInt32(this.State.Text);
            string alertMessage = Language.ReadLanguage("AddOK");
            if (user.ID == -2147483648)
            {
                int id = UserBLL.AddUser(user);
            }
            else
            {
                //从冻结状态转出时，需要逻辑处理
                if (originalState == (int)UserState.Frozen && user.State != (int)UserState.Frozen)
                {
                    //如果分红总额大于限额的会员要重置于0
                    if (BonusBLL.ReadBonusReport(user.ID).BonusMoney >= Config.ReadConfigInfo().MaxBonus)
                    {
                        user.Money = 0;
                        BonusBLL.ChangeBonusState(user.ID, 1);
                    }
                }
                UserBLL.UpdateUser(user);
                alertMessage = Language.ReadLanguage("UpdateOK");
            }
            //扣总分
            if (user.GroupID == 1 && point > 0)
            {
                ConfigInfo config = Config.ReadConfigInfo();
                if (config.TotalScore < point)
                    ScriptHelper.Alert(Language.ReadLanguage("TotalScoreLessTips"));
                else
                {
                    config.TotalScore = config.TotalScore - point;
                    Config.UpdateConfigInfo(config);
                }
            }

            AdminBasePage.Alert(alertMessage, RequestHelper.RawUrl);
        }
    }
}
