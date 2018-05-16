using System;
using System.Web.Security;
using XueFu.EntLib;
using XueFu.BLL;
using XueFu.Common;
using XueFu.Model;

namespace XueFu.Web.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            string loginName = StringHelper.SearchSafe(this.AdminName.Text);
            string content = StringHelper.SearchSafe(this.Password.Text);
            string text = this.SafeCode.Text;
            bool flag = this.Remember.Checked;
            if (!Cookies.Common.checkcode.ToLower().Equals(text.ToLower()))
            {
                ScriptHelper.Alert(Language.ReadLanguage("SafeCodeError"), RequestHelper.RawUrl);
            }
            content = StringHelper.Password(content, (PasswordType)Config.ReadConfigInfo().PasswordType);
            AdminInfo info = AdminBLL.CheckAdminLogin(loginName, content);
            if (info.ID > 0)
            {
                string str4 = Guid.NewGuid().ToString();
                string str5 = EncryptHelper.MD5(info.ID.ToString() + info.Name + info.GroupID.ToString() + str4 + Config.ReadConfigInfo().SecureKey + ClientHelper.Agent);
                string str6 = str5 + "|" + info.ID.ToString() + "|" + info.Name + "|" + info.GroupID.ToString() + "|" + str4;
                if (flag)
                {
                    CookiesHelper.AddCookie(Config.ReadConfigInfo().AdminCookies, str6, 1, TimeType.Year);
                }
                else
                {
                    CookiesHelper.AddCookie(Config.ReadConfigInfo().AdminCookies, str6);
                }
                ResponseHelper.Redirect("Default.aspx");
            }
            else
            {
                ScriptHelper.Alert(Language.ReadLanguage("LoginFaild"), RequestHelper.RawUrl);
            }
        }
    }
}
