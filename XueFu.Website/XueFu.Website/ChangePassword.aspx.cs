using System;
using System.Data;
using XueFu.Common;
using XueFu.EntLib;
using XueFu.Model;
using XueFu.BLL;

namespace XueFu.Website
{
    public partial class ChangePassword : UserBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Master)Master).Title = "ÐÞ¸ÄÃÜÂë";
            string action = RequestHelper.GetForm<string>("Action");
            if (!string.IsNullOrEmpty(action))
            {
                string oldPassword = RequestHelper.GetForm<string>("oldpassword");
                string password1 = RequestHelper.GetForm<string>("password1");
                string passwrod2 = RequestHelper.GetForm<string>("password2");

                if (string.IsNullOrEmpty(password1) || string.IsNullOrEmpty(passwrod2))
                {
                    ScriptHelper.Alert(Language.ReadLanguage("PasswordEmptyTips"));
                }
                if (password1 != passwrod2) ScriptHelper.Alert(Language.ReadLanguage("PasswordNoEqualTips"));
                string str = StringHelper.Password(oldPassword, (PasswordType)Config.ReadConfigInfo().PasswordType);
                string newPassword = StringHelper.Password(password1, (PasswordType)Config.ReadConfigInfo().PasswordType);
                UserInfo info = UserBLL.ReadUser(base.UserID);
                if (str == info.Password)
                {
                    UserBLL.ChangePassword(base.UserID, newPassword);
                    ScriptHelper.Alert(Language.ReadLanguage("UpdateOK"), "/Logout.aspx");
                }
                else
                {
                    ScriptHelper.Alert(Language.ReadLanguage("OldPasswordError"), RequestHelper.RawUrl);
                }
            }
        }
    }
}
