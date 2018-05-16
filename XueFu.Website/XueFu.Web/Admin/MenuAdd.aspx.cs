using System;
using System.Web.UI.WebControls;
using XueFu.EntLib;
using XueFu.Common;
using XueFu.BLL;
using XueFu.Model;

namespace XueFu.Web.Admin
{
    public partial class MenuAdd : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                int id = 0;
                id = RequestHelper.GetQueryString<int>("FatherID");
                if (id == -2147483648)
                {
                    id = 1;
                }
                MenuInfo info = MenuBLL.ReadMenuCache(id);
                this.FatherID.DataSource = MenuBLL.ReadMenuAllNamedChildList(id);
                this.FatherID.DataTextField = "MenuName";
                this.FatherID.DataValueField = "ID";
                this.FatherID.DataBind();
                this.FatherID.Items.Insert(0, new ListItem(info.MenuName, info.ID.ToString()));
                for (int i = 1; i <= 60; i++)
                {
                    this.MenuImage.Items.Add(new ListItem("<img src=\"images/icon/" + i + "-icon.gif\"/>", i.ToString()));
                }
                this.MenuImage.SelectedIndex = 0;
                int queryString = RequestHelper.GetQueryString<int>("ID");
                if (queryString != -2147483648)
                {
                    MenuInfo info2 = MenuBLL.ReadMenuCache(queryString);
                    this.FatherID.Text = info2.FatherID.ToString();
                    this.OrderID.Text = info2.OrderID.ToString();
                    this.MenuName.Text = info2.MenuName;
                    this.MenuImage.SelectedValue = info2.MenuImage.ToString();
                    this.URL.Text = info2.URL;
                }
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            MenuInfo menu = new MenuInfo();
            menu.ID = RequestHelper.GetQueryString<int>("ID");
            menu.FatherID = Convert.ToInt32(this.FatherID.Text);
            menu.OrderID = Convert.ToInt32(this.OrderID.Text);
            menu.MenuName = this.MenuName.Text;
            menu.MenuImage = Convert.ToInt32(this.MenuImage.Text);
            menu.URL = this.URL.Text;
            menu.Date = RequestHelper.DateNow;
            menu.IP = ClientHelper.IP;
            string alertMessage = Language.ReadLanguage("AddOK");
            if (menu.ID == -2147483648)
            {
                int id = MenuBLL.AddMenu(menu);
            }
            else
            {
                MenuBLL.UpdateMenu(menu);
                alertMessage = Language.ReadLanguage("UpdateOK");
            }
            AdminBasePage.Alert(alertMessage, RequestHelper.RawUrl);
        }
    }
}
