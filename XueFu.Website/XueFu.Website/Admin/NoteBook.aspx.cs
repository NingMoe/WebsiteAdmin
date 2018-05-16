using System;
using XueFu.EntLib;
using XueFu.Common;
using XueFu.BLL;
using XueFu.Model;

namespace XueFu.Admin
{
    public partial class NoteBook : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                AdminInfo info = AdminBLL.ReadAdmin(Cookies.Admin.GetAdminID(false));
                this.NoteBookContent.Text = info.NoteBook;
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            AdminInfo admin = AdminBLL.ReadAdmin(Cookies.Admin.GetAdminID(false));
            admin.NoteBook = this.NoteBookContent.Text;
            AdminBLL.UpdateAdmin(admin);
            AdminBasePage.Alert(Language.ReadLanguage("UpdateOK"), RequestHelper.RawUrl);
        }
    }
}
