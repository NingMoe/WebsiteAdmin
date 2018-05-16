using System;
using System.Web.UI;
using XueFu.EntLib;
using XueFu.Common;

namespace XueFu.Web.Admin
{
    public partial class Logout : Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            CookiesHelper.DeleteCookie(Config.ReadConfigInfo().AdminCookies);
            ResponseHelper.Redirect("Default.aspx");
        }
    }
}
