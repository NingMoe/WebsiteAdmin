using System.Collections.Generic;
using XueFu.Model;

namespace XueFu.IDAL
{
    public interface IAdminLog
    {        
        void AddAdminLog(AdminLogInfo adminLog);
        void DeleteAdminLog(string strID, int adminID);
        void DeleteAdminLogByAdminID(string strAdminID);
        void DeleteAdminLogByGroupID(string strGroupID);
        AdminLogInfo ReadAdminLog(int id, int adminID);
        List<AdminLogInfo> ReadAdminLogList(int currentPage, int pageSize, ref int count, int adminID);
        void UpdateAdminLog(AdminLogInfo adminLog);
    }
}
