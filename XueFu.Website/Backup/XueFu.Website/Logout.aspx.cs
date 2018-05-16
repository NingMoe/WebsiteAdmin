using System;
using XueFu.Common;
using XueFu.EntLib;

namespace XueFu.Website
{
    public partial class Logout : UserBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CookiesHelper.DeleteCookie(Config.ReadConfigInfo().UserCookies);
            ResponseHelper.Redirect("/");
        }
    }
}
