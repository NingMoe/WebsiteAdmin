using System;
using XueFu.EntLib;
using XueFu.Common;
using XueFu.BLL;

namespace XueFu.Admin
{
    public partial class ChangePassword : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Name.Text = Cookies.Admin.GetAdminName(false);
        }

        protected void SubmitButton_Click(object sender, EventArgs E)
        {
            string oldPassword = StringHelper.Password(this.Password.Text, (PasswordType)Config.ReadConfigInfo().PasswordType);
            string newPassword = StringHelper.Password(this.NewPassword.Text, (PasswordType)Config.ReadConfigInfo().PasswordType);
            if (AdminBLL.ReadAdmin(Cookies.Admin.GetAdminID(false)).Password == oldPassword)
            {
                AdminBLL.ChangePassword(Cookies.Admin.GetAdminID(false), oldPassword, newPassword);
                ScriptHelper.Alert(Language.ReadLanguage("UpdateOK"), RequestHelper.RawUrl);
            }
            else
            {
                ScriptHelper.Alert(Language.ReadLanguage("OldPasswordError"), RequestHelper.RawUrl);
            }
        }
    }
}
