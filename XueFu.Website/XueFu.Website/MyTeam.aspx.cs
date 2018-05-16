using System;
using XueFu.Model;
using XueFu.BLL;
using XueFu.Common;
using System.Collections.Generic;
using System.Text;
using XueFu.EntLib;

namespace XueFu.Website
{
    public partial class MyTeam : UserBasePage
    {
        protected UserInfo myself = new UserInfo();

        protected void Page_Load(object sender, EventArgs e)
        {
            ((Master)Master).Title = "我的团队";

            myself = UserBLL.ReadUser(base.UserID);
        }

        protected string createLevevHtml(int introducerID, int levelNum)
        {
            StringBuilder createHtml = new StringBuilder();

            UserSearchInfo userSearch = new UserSearchInfo();
            userSearch.IntroducerID = introducerID;
            userSearch.StateNoEqueal = (int)UserState.NoCheck;
            List<UserInfo> userList = UserBLL.ReadUserList(userSearch);
            if (userList.Count > 0)
            {
                levelNum--;
                createHtml.AppendLine("<div class=\"line-v\"><span></span></div>");
                createHtml.AppendLine("<div class=\"strt-block\">");
                int i = 0;
                foreach (UserInfo user in userList)
                {
                    i++;
                    createHtml.AppendLine("<div class=\"strt-part\">");
                    if (userList.Count > 1)
                    {
                        createHtml.AppendLine("<span class=\"line-h" + (i == 1 ? " line-h-r" : (i == userList.Count) ? " line-h-l" : " line-h-c") + "\"></span>");
                        createHtml.AppendLine("<div class=\"line-v\"><span></span></div>");
                    }
                    createHtml.AppendLine("<span class=\"strt-name\">" + user.RealName + "</span>");

                    if (levelNum > 0)
                        createHtml.AppendLine(createLevevHtml(user.ID, levelNum));

                    createHtml.AppendLine("</div>");
                }

                createHtml.AppendLine("</div>");
            }
            return createHtml.ToString();
        }
    }
}
