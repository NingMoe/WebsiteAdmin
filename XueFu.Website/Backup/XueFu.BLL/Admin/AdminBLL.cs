using System;
using System.Collections.Generic;
using XueFu.EntLib;
using XueFu.Model;
using XueFu.IDAL;
using XueFu.Common;

namespace XueFu.BLL
{
    public sealed class AdminBLL
    {
        private static readonly IAdmin dal = FactoryHelper.Instance<IAdmin>(Global.DataProvider, "AdminDAL");

        public static int AddAdmin(AdminInfo admin)
        {
            return dal.AddAdmin(admin);
        }

        public static void ChangePassword(int id, string newPassword)
        {
            dal.ChangePassword(id, newPassword);
        }

        public static void ChangePassword(int id, string oldPassword, string newPassword)
        {
            dal.ChangePassword(id, oldPassword, newPassword);
        }

        public static AdminInfo CheckAdminLogin(string loginName, string loginPass)
        {
            return dal.CheckAdminLogin(loginName, loginPass);
        }

        public static void DeleteAdmin(string strID)
        {
            dal.DeleteAdmin(strID);
        }

        public static string NoDelete(object isCreater, object id)
        {
            int num = Convert.ToInt32(isCreater);
            int num2 = Convert.ToInt32(id);
            string str = string.Empty;
            if ((num != 1) && (num2 != Cookies.Admin.GetAdminID(false)))
            {
                str = "<input type=\"checkbox\" name=\"SelectID\" value=\"" + id.ToString() + "\" />";
            }
            return str;
        }

        public static string NoPasswordAdd(object id)
        {
            int num = Convert.ToInt32(id);
            string str = string.Empty;
            if (num != Cookies.Admin.GetAdminID(false))
            {
                str = "<a href=\"javascript:pop('PasswordAdd.aspx?ID=" + id.ToString() + "',600,250,'ÐÞ¸ÄÃÜÂë','PasswordAdd" + id.ToString() + "')\"><img src=\"Style/Images/password.gif\" alt=\"ÐÞ¸ÄÃÜÂë\" title=\"ÐÞ¸ÄÃÜÂë\" /></a>";
            }
            return str;
        }

        public static AdminInfo ReadAdmin(int id)
        {
            return dal.ReadAdmin(id);
        }

        public static List<AdminInfo> ReadAdminList(int currentPage, int pageSize, ref int count)
        {
            return dal.ReadAdminList(currentPage, pageSize, ref count);
        }

        public static List<AdminInfo> ReadAdminList(int groupID, int currentPage, int pageSize, ref int count)
        {
            return dal.ReadAdminList(groupID, currentPage, pageSize, ref count);
        }

        public static void UpdateAdmin(AdminInfo admin)
        {
            dal.UpdateAdmin(admin);
        }
    }
}
