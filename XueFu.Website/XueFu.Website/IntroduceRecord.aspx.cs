using System;
using XueFu.Common;
using XueFu.Model;
using XueFu.BLL;

namespace XueFu.Website
{
    public partial class IntroduceRecord : UserBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Master)Master).Title = "ÍÆ¼ö¼ÇÂ¼";
            //UserFriendSearchInfo userFriendSearch = new UserFriendSearchInfo();
            //userFriendSearch.UserID = base.UserID;
            //base.BindControl(UserFriendBLL.SearchUserFriendList(base.CurrentPage, base.PageSize, userFriendSearch, ref base.Count), RecordList);

            //UserSearchInfo userSearch = new UserSearchInfo();
            //userSearch.IntroducerID = base.UserID;
            //base.BindControl(UserBLL.ReadUserList(userSearch, base.CurrentPage, base.PageSize, ref base.Count), RecordList);
        }
    }
}
