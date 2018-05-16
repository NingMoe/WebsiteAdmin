using System;
using XueFu.Common;
using XueFu.EntLib;
using XueFu.Model;
using XueFu.BLL;

namespace XueFu.Website
{
    public partial class Master : System.Web.UI.MasterPage
    {
        public string Title = string.Empty;
        protected UserInfo user = new UserInfo();
        protected int querystring = RequestHelper.GetQueryString<int>("ID");

        protected void Page_Load(object sender, EventArgs e)
        {
            int userID = Cookies.User.GetUserID(true);
            user = UserBLL.ReadUser(userID);
        }
    }
}
