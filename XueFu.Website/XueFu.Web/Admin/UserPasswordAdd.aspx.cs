using System;
using XueFu.EntLib;
using XueFu.Common;
using XueFu.BLL;

namespace XueFu.Web.Admin
{
    public partial class UserPasswordAdd : AdminBasePage
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            int queryString = RequestHelper.GetQueryString<int>("ID");
            if (queryString != -2147483648)
            {
                this.Name.Text = UserBLL.ReadUser(queryString).Name;
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs E)
        {
            int queryString = RequestHelper.GetQueryString<int>("ID");
            if (queryString != -2147483648)
            {
                string newPassword = StringHelper.Password(this.NewPassword.Text, (PasswordType)Config.ReadConfigInfo().PasswordType);
                UserBLL.ChangePassword(queryString, newPassword);
                AdminBasePage.Alert(Language.ReadLanguage("UpdateOK"), RequestHelper.RawUrl);
            }
        }
    }
}
