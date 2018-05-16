using System;
using XueFu.EntLib;
using XueFu.Common;
using XueFu.BLL;

namespace XueFu.Admin
{
    public partial class Menu : AdminBasePage
    {
        protected int fatherID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string queryString = RequestHelper.GetQueryString<string>("Action");
            int id = RequestHelper.GetQueryString<int>("ID");
            this.fatherID = RequestHelper.GetQueryString<int>("FatherID");
            if (this.fatherID == -2147483648)
            {
                this.fatherID = 1;
            }
            if ((queryString != string.Empty) && (id != -2147483648))
            {
                string str2 = queryString;
                if (str2 != null)
                {
                    if (!(str2 == "Up"))
                    {
                        if (str2 == "Down")
                        {
                            MenuBLL.MoveDownMenu(id);
                        }
                        else if (str2 == "Delete")
                        {
                            MenuBLL.DeleteMenu(id);
                        }
                    }
                    else
                    {
                        MenuBLL.MoveUpMenu(id);
                    }
                }
            }
            base.BindControl(MenuBLL.ReadMenuAllNamedChildList(this.fatherID), this.RecordList);
        }
    }
}
