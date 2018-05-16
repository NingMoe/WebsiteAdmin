using System;
using XueFu.Common;
using XueFu.Model;
using XueFu.BLL;

namespace XueFu.Website
{
    public partial class AddUserRecord : UserBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Master)Master).Title = "±¨µ¥¼ÇÂ¼";

            //UserSearchInfo userSearch = new UserSearchInfo();
            //userSearch.OperatorID = base.UserID;
            //base.BindControl(UserBLL.ReadUserList(userSearch, base.CurrentPage, base.PageSize, ref base.Count), RecordList);
        }
    }
}
