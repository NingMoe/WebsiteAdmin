using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Security;
using XueFu.EntLib;
using XueFu.IDAL;
using XueFu.Model;
using XueFu.Common;

namespace XueFu.BLL
{
    public sealed class UserBLL
    {
        private static readonly IUser dal = FactoryHelper.Instance<IUser>(Global.DataProvider, "UserDAL");

        public static int AddUser(UserInfo model)
        {
            return dal.AddUser(model);
        }

        public static void UpdateUser(UserInfo model)
        {
            dal.UpdateUser(model);
        }

        public static void UpdateMoney(int userID, int money)
        {
            dal.UpdateMoney(userID, money);
        }

        public static void UpdatePoint(int userID, int point)
        {
            dal.UpdatePoint(userID, point);
        }

        public static void DeleteUser(string idString)
        {
            dal.DeleteUser(idString);
        }

        public static void ChangePassword(int id, string newPassword)
        {
            dal.ChangePassword(id, newPassword);
        }

        public static int ChangeUserState(int userID, int state)
        {
            return dal.ChangeUserState(userID, state);
        }

        public static UserInfo CheckUserLogin(string loginName, string loginPass)
        {
            return dal.CheckUserLogin(loginName, loginPass);
        }

        public static int CheckUserName(string userName)
        {
            int userID = 0;
            UserInfo user = UserBLL.ReadUser(userName);
            if (user != null)
            {
                userID = user.ID;
            }
            return userID;
        }

        public static UserInfo ReadUser(int id)
        {
            return dal.ReadUser(id);
        }

        public static UserInfo ReadUser(string name)
        {
            return dal.ReadUser(name);
        }

        public static List<UserInfo> ReadUserList(UserSearchInfo model)
        {
            return dal.ReadUserList(model);
        }

        public static List<UserInfo> ReadUserList(UserSearchInfo model, int currentPage, int pageSize, ref int count)
        {
            return dal.ReadUserList(model, currentPage, pageSize, ref count);
        }

        public static List<UserInfo> ReadUserList(int currentPage, int pageSize, ref int count)
        {
            return dal.ReadUserList(currentPage, pageSize, ref count);
        }

        public static void UserLoginInit(UserInfo user)
        {
            string str = FormsAuthentication.HashPasswordForStoringInConfigFile(user.ID.ToString() + HttpContext.Current.Server.UrlEncode(user.Name) + HttpContext.Current.Server.UrlEncode(user.RealName) + user.GroupID.ToString() + Config.ReadConfigInfo().SecureKey + ClientHelper.Agent, "MD5");
            string str2 = string.Concat(new object[] { str, "|", user.ID.ToString(), "|", HttpContext.Current.Server.UrlEncode(user.Name), "|", HttpContext.Current.Server.UrlEncode(user.RealName), "|", user.GroupID.ToString() });
            CookiesHelper.AddCookie(Config.ReadConfigInfo().UserCookies, str2, 1, TimeType.Month);

            //UserFriendSearchInfo userFriendModel = new UserFriendSearchInfo();
            //userFriendModel.UserID = user.ID;
            //CookiesHelper.AddCookie("FriendNum", UserFriendBLL.SearchUserFriendList(userFriendModel).Count.ToString(), 1, TimeType.Month);
        }
    }
}