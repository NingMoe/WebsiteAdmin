using System;
using System.Collections.Generic;
using XueFu.Model;

namespace XueFu.IDAL
{    
    public interface IAdmin
    {        
        int AddAdmin(AdminInfo admin);
        void ChangePassword(int id, string newPassword);
        void ChangePassword(int id, string oldPassword, string newPassword);
        AdminInfo CheckAdminLogin(string loginName, string loginPass);
        void DeleteAdmin(string strID);
        AdminInfo ReadAdmin(int id);
        List<AdminInfo> ReadAdminList(int currentPage, int pageSize, ref int count);
        List<AdminInfo> ReadAdminList(int groupID, int currentPage, int pageSize, ref int count);
        void UpdateAdmin(AdminInfo admin);
    }
}
