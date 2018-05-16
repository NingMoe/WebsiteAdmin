using System;
using System.Collections.Generic;
using XueFu.EntLib;
using XueFu.Common;
using XueFu.Model;
using XueFu.BLL;

namespace XueFu.Web.Admin
{
    public partial class Left : AdminBasePage
    {
        protected List<MenuInfo> menuList = new List<MenuInfo>();

        protected void Page_Load(object sender, EventArgs e)
        {
            int queryString = RequestHelper.GetQueryString<int>("ID");
            if (queryString == -2147483648)
            {
                queryString = 1;
            }
            this.menuList = MenuBLL.ReadMenuChildList(queryString);
        }
    }
}
