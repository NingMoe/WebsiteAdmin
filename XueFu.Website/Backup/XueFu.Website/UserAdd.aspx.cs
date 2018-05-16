using System;
using XueFu.Common;
using XueFu.EntLib;
using XueFu.Model;
using XueFu.BLL;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace XueFu.Website
{
    public partial class UserAdd : UserBasePage
    {
        protected string action = RequestHelper.GetQueryString<string>("Action");
        protected UserInfo user = new UserInfo();
        protected bool canReport = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            ((Master)Master).Title = "报单中心";
            if (!string.IsNullOrEmpty(RequestHelper.GetForm<string>("Action"))) action = RequestHelper.GetForm<string>("Action");
            if (!string.IsNullOrEmpty(action))
            {
                if (action == "UpdateLoad")
                {
                    ((Master)Master).Title = "修改资料";
                    user = UserBLL.ReadUser(base.UserID);
                    action = "Update";
                }
                else
                {
                    if (action == "Update")
                    {
                        user = UserBLL.ReadUser(base.UserID);
                        user.RealName = StringHelper.SearchSafe(RequestHelper.GetForm<string>("realname"));
                        user.Sex = RequestHelper.GetForm<int>("sex");
                        if (string.IsNullOrEmpty(user.IDCard))
                            user.IDCard = StringHelper.SearchSafe(RequestHelper.GetForm<string>("idcard"));
                        user.Address = StringHelper.SearchSafe(RequestHelper.GetForm<string>("address"));
                        user.WeChat = StringHelper.SearchSafe(RequestHelper.GetForm<string>("wechat"));
                        user.State = (int)UserState.Normal;

                        if (!string.IsNullOrEmpty(user.IDCard))
                        {
                            UserSearchInfo userSearch = new UserSearchInfo();
                            userSearch.IDCard = user.IDCard;
                            userSearch.NotInUserID = user.ID.ToString();
                            List<UserInfo> userList = UserBLL.ReadUserList(userSearch);
                            //每个人只能10个帐号
                            if (userList.Count >= Config.ReadConfigInfo().MaxUserNum)
                            {
                                ScriptHelper.Alert(Language.ReadLanguage("IDCardOverflow").Replace("$MaxUserNum", Config.ReadConfigInfo().MaxUserNum.ToString()));
                            }
                        }
                        UserBLL.UpdateUser(user);
                        ScriptHelper.Alert(Language.ReadLanguage("UpdateOK"), "Default.aspx");
                    }
                    else if (action == "Add")
                    {
                        if (Cookies.User.GetGroupID(true) != (int)GroupType.Report) ScriptHelper.Alert(Language.ReadLanguage("NoReportPower"));

                        string introducerUserName = StringHelper.SearchSafe(RequestHelper.GetForm<string>("introducer"));
                        UserInfo introducer = UserBLL.ReadUser(introducerUserName);
                        if (introducer.ID > 0)
                            user.IntroducerID = introducer.ID;
                        else
                            ScriptHelper.Alert(Language.ReadLanguage("NoIntroducerID"));

                        UserInfo operatorUser = UserBLL.ReadUser(base.UserID);
                        if (operatorUser.Money < Config.ReadConfigInfo().PerUserScore)
                        {
                            ScriptHelper.Alert(Language.ReadLanguage("OperatorPointLess"));
                        }
                        else
                        {
                            operatorUser.Money = operatorUser.Money - Config.ReadConfigInfo().PerUserScore;
                        }
                        user.OperatorID = operatorUser.ID;// Cookies.User.GetUserID(true);

                        user.Name = StringHelper.SearchSafe(RequestHelper.GetForm<string>("username"));
                        user.Password = StringHelper.SearchSafe(RequestHelper.GetForm<string>("password"));
                        if (string.IsNullOrEmpty(user.Name)) ScriptHelper.Alert(Language.ReadLanguage("UserNameEmptyTips"));
                        UserInfo userSearch = UserBLL.ReadUser(user.Name);
                        if (userSearch.ID > 0) ScriptHelper.Alert(Language.ReadLanguage("UserNameExistTips"));
                        if (string.IsNullOrEmpty(user.Password)) ScriptHelper.Alert(Language.ReadLanguage("PasswordEmptyTips"));
                        Regex regex = new Regex("(?=^[0-9a-zA-Z._@#]{6,16}$)((?=.*[0-9])(?=.*[^0-9])|(?=.*[a-zA-Z])(?=.*[^a-zA-Z]))");
                        if (!regex.IsMatch(user.Password)) ScriptHelper.Alert(Language.ReadLanguage("NoPasswordRuleTips"));
                        user.Password = StringHelper.Password(user.Password, (PasswordType)Config.ReadConfigInfo().PasswordType);

                        UserBLL.AddUser(user);

                        //更新报单人积分
                        UserBLL.UpdateMoney(operatorUser.ID, operatorUser.Money);

                        //推荐奖
                        BonusBLL.Bonus(user.IntroducerID, introducer.Name, (int)MoneyType.Introduce, Config.ReadConfigInfo().IntroduceMoney);

                        //报单奖
                        BonusBLL.Bonus(operatorUser.ID, operatorUser.Name, (int)MoneyType.Report, Config.ReadConfigInfo().ReportMoney);
                                                
                        ScriptHelper.Alert(Language.ReadLanguage("AddOK"), "UserAdd.aspx");
                    }
                }
            }
            else
            {
                action = "Add";
                user = UserBLL.ReadUser(base.UserID);
                if (user.Money < Config.ReadConfigInfo().PerUserScore)
                    canReport = false;
            }
        }
    }
}
