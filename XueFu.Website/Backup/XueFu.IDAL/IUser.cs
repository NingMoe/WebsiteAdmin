using System;
using System.Collections.Generic;
using System.Text;
using XueFu.Model;

namespace XueFu.IDAL
{
    public interface IUser
    {
        int AddUser(UserInfo model);
        void UpdateUser(UserInfo model);
        void UpdateMoney(int userID, int money);
        void UpdatePoint(int userID, int point);
        void DeleteUser(string idString);
        void ChangePassword(int id, string newPassword);
        int ChangeUserState(int userID, int state);
        UserInfo CheckUserLogin(string loginName, string loginPass);
        UserInfo ReadUser(int id);
        UserInfo ReadUser(string name);
        List<UserInfo> ReadUserList(UserSearchInfo model);
        List<UserInfo> ReadUserList(UserSearchInfo model, int currentPage, int pageSize, ref int count);
        List<UserInfo> ReadUserList(int currentPage, int pageSize, ref int count);
    }
}
