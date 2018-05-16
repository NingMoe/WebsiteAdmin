using System;
using XueFu.EntLib;
using XueFu.Model;
using XueFu.BLL;
using System.Web.Security;
using XueFu.Common;

namespace XueFu.Web.Admin
{
    public partial class Ajax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = RequestHelper.GetQueryString<string>("Action");
            switch (action)
            {
                case "Login":
                    Login();
                    break;

                case "CheckUserName":
                    this.CheckUserName();
                    break;

                case "CheckIDCard":
                    this.CheckIDCard();
                    break;
            }
        }

        private void CheckIDCard()
        {
            string idCard = StringHelper.SearchSafe(RequestHelper.GetQueryString<string>("IDCard"));
            string resultData = "{";
            UserSearchInfo userSearch = new UserSearchInfo();
            userSearch.IDCard = idCard;
            if (UserBLL.ReadUserList(userSearch).Count >= Config.ReadConfigInfo().MaxUserNum)
            {
                resultData += "\"result\":\"false\"";
            }
            else
            {
                resultData += "\"result\":\"true\"";
            } 
            resultData += "}";
            ResponseHelper.Write(resultData);
        }

        private void CheckUserName()
        {
            string content = "ok";
            if (UserBLL.CheckUserName(RequestHelper.GetQueryString<string>("UserName")) > 0)
            {
                content = "error";
            }
            ResponseHelper.Write(content);
            ResponseHelper.End();
        }

        protected void Login()
        {
            string resultData = "{";
            string loginName = StringHelper.SearchSafe(RequestHelper.GetForm<string>("UserName"));
            string loginPass = StringHelper.Password(RequestHelper.GetForm<string>("Password"), (PasswordType)Config.ReadConfigInfo().PasswordType);
            AdminInfo info = AdminBLL.CheckAdminLogin(loginName, loginPass);
            if (info.ID > 0)
            {
                string str4 = Guid.NewGuid().ToString();
                string str5 = EncryptHelper.MD5(info.ID.ToString() + info.Name + info.GroupID.ToString() + str4 + Config.ReadConfigInfo().SecureKey + ClientHelper.Agent);
                string str6 = str5 + "|" + info.ID.ToString() + "|" + info.Name + "|" + info.GroupID.ToString() + "|" + str4;
                //if (flag)
                //{
                //    CookiesHelper.AddCookie(Config.ReadConfigInfo().AdminCookies, str6, 1, TimeType.Year);
                //}
                //else
                {
                    CookiesHelper.AddCookie(Config.ReadConfigInfo().AdminCookies, str6);
                }
                resultData += "\"result\":\"true\"";
            }
            else
            {
                resultData += "\"result\":\"false\"";
            }
            resultData += "}";
            ResponseHelper.Write(resultData);
        }
    }
}
