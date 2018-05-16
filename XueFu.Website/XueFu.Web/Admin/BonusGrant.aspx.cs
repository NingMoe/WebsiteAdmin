using System;
using XueFu.Common;
using XueFu.Model;
using System.Collections.Generic;
using XueFu.BLL;
using XueFu.EntLib;

namespace XueFu.Web.Admin
{
    public partial class BonusGrant : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BonusButton_Click(object sender, EventArgs e)
        {
            int money = 0;
            if (!string.IsNullOrEmpty(this.Money.Text))
                money = int.Parse(this.Money.Text);
            if (money <= 0)
                ScriptHelper.Alert(Language.ReadLanguage("BonusEmptyTips"));
            UserSearchInfo userSearch = new UserSearchInfo();
            userSearch.State = (int)UserState.Normal;
            List<UserInfo> userList = UserBLL.ReadUserList(userSearch);
            foreach (UserInfo info in userList)
            {
                //分红总额超过限制，冻结帐户
                if (BonusBLL.ReadBonusReport(info.ID).BonusMoney < Config.ReadConfigInfo().MaxBonus)
                {
                    BonusBLL.Bonus(info.ID, info.Name, (int)MoneyType.Bonus, money);
                }
                else
                {
                    UserBLL.ChangeUserState(info.ID, (int)UserState.Frozen);
                }
            }
            ScriptHelper.Alert(Language.ReadLanguage("BonusCompleteTips"), RequestHelper.RawUrl);
        }

        protected void TeamMoneyButton_Click(object sender, EventArgs e)
        {
            UserSearchInfo userSearch = new UserSearchInfo();
            userSearch.State = (int)UserState.Normal;
            List<UserInfo> userList = UserBLL.ReadUserList(userSearch);
            foreach (UserInfo info in userList)
            {
                int teamUserNum = TeamUserNum(info.ID, Config.ReadConfigInfo().LevelNum);
                if (teamUserNum > 0)
                    BonusBLL.Bonus(info.ID, info.Name, (int)MoneyType.Team, (teamUserNum * Config.ReadConfigInfo().PerUserScore * Config.ReadConfigInfo().TeamPercent / 100));
            }
            ScriptHelper.Alert(Language.ReadLanguage("TeamMoneyCompleteTips"), RequestHelper.RawUrl);
        }

        protected int TeamUserNum(int introducerID, int levelNum)
        {
            int userNum = 0;

            UserSearchInfo userSearch = new UserSearchInfo();
            userSearch.IntroducerID = introducerID;
            userSearch.State = (int)UserState.Normal;
            List<UserInfo> userList = UserBLL.ReadUserList(userSearch);
            userNum = userList.Count;
            if (userNum > 0)
            {
                levelNum--;
                foreach (UserInfo user in userList)
                {
                    if (levelNum > 0)
                        userNum += TeamUserNum(user.ID, levelNum);
                }
            }

            return userNum;
        }
    }
}
