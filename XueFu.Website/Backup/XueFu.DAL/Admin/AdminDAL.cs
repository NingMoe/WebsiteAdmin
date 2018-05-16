using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using XueFu.EntLib;
using XueFu.IDAL;
using XueFu.Model;
using System.Text;
using XueFu.Common;

namespace XueFu.DAL
{
    public sealed class AdminDAL : IAdmin
    {

        public int AddAdmin(AdminInfo admin)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Insert into [" + DbSQLHelper.TablePrefix + "Admin] ([Name],[Password],[RealName],[State],[GroupID]) values(@name,@password,@realName,@state,@groupID)");
            SqlParameter[] par ={
                new SqlParameter ("@name",SqlDbType.NVarChar),
                new SqlParameter ("@password",SqlDbType.NVarChar),
                new SqlParameter ("@realName",SqlDbType.NVarChar),
                new SqlParameter ("@state",SqlDbType.Int),
                new SqlParameter ("@groupID",SqlDbType.Int)
            };
            par[0].Value = admin.Name;
            par[1].Value = admin.Password;
            par[2].Value = admin.RealName;
            par[3].Value = admin.State;
            par[4].Value = admin.GroupID;
            return DbSQLHelper.ExecuteSql(sql.ToString(), par);
        }

        public void UpdateAdmin(AdminInfo admin)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Update [" + DbSQLHelper.TablePrefix + "Admin] set [Name]=@name,[Password]=@password,[RealName]=@realName,[State]=@state,[GroupID]=@groupID where [ID]=@id");
            SqlParameter[] par ={
                new SqlParameter ("@id",SqlDbType.Int),
                new SqlParameter ("@name",SqlDbType.NVarChar),
                new SqlParameter ("@password",SqlDbType.NVarChar),
                new SqlParameter ("@realName",SqlDbType.NVarChar),
                new SqlParameter ("@state",SqlDbType.Int),
                new SqlParameter ("@groupID",SqlDbType.Int)
            };
            par[0].Value = admin.ID;
            par[1].Value = admin.Name;
            par[2].Value = admin.Password;
            par[3].Value = admin.RealName;
            par[4].Value = admin.State;
            par[5].Value = admin.GroupID;
            DbSQLHelper.ExecuteSql(sql.ToString(), par);
        }

        public void DeleteAdmin(string strID)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Delete from [" + DbSQLHelper.TablePrefix + "Admin] where [ID] in (" + strID + ")");
            DbSQLHelper.ExecuteSql(sql.ToString());
        }

        public void ChangePassword(int id, string password)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE [" + DbSQLHelper.TablePrefix + "Admin] Set [Password]=@password WHERE [ID]=@id");
            SqlParameter[] pt = new SqlParameter[] {
                new SqlParameter("@id", SqlDbType.Int),
                new SqlParameter("@password", SqlDbType.NVarChar)
            };
            pt[0].Value = id;
            pt[1].Value = password;
            DbSQLHelper.ExecuteSql(sql.ToString(), pt);
        }

        public void ChangePassword(int id, string oldPassword, string newPassword)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE [" + DbSQLHelper.TablePrefix + "Admin] SET [Password]=@newPassword WHERE [ID]=@id AND [Password]=@oldPassword");
            SqlParameter[] pt = new SqlParameter[] { new SqlParameter("@id", SqlDbType.Int), new SqlParameter("@oldPassword", SqlDbType.NVarChar), new SqlParameter("@newPassword", SqlDbType.NVarChar) };
            pt[0].Value = id;
            pt[1].Value = oldPassword;
            pt[2].Value = newPassword;
            DbSQLHelper.ExecuteSql(sql.ToString(), pt);
        }

        public AdminInfo CheckAdminLogin(string loginName, string loginPass)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * FROM [" + DbSQLHelper.TablePrefix + "Admin] WHERE [Name]=@loginName AND [Password]=@loginPass");
            SqlParameter[] pt = new SqlParameter[] {
                new SqlParameter("@loginName", SqlDbType.NVarChar),
                new SqlParameter("@loginPass", SqlDbType.NVarChar)
            };
            pt[0].Value = loginName;
            pt[1].Value = loginPass;
            using (SqlDataReader reader = DbSQLHelper.ExecuteReader(sql.ToString(), pt))
            {
                return GetModel(reader);
            }
        }

        public AdminInfo ReadAdmin(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select * from [" + DbSQLHelper.TablePrefix + "Admin] where [ID]=" + id);
            using (SqlDataReader reader = DbSQLHelper.ExecuteReader(sql.ToString()))
            {
                return GetModel(reader);
            }
        }

        public List<AdminInfo> ReadAdminList(int currentPage, int pageSize, ref int count)
        {
            List<AdminInfo> adminList = new List<AdminInfo>();
            CommonMssqlPagerClass class2 = new CommonMssqlPagerClass();
            class2.TableName = "["+ShopMssqlHelper.TablePrefix + "Admin]";
            class2.Fields = "*";
            class2.CurrentPage = currentPage;
            class2.PageSize = pageSize;
            class2.OrderField = "[ID]";
            class2.OrderType = OrderType.Desc;
            class2.Count = count;
            count = class2.Count;
            using (SqlDataReader reader = class2.ExecuteReader())
            {
                this.PrepareAdminModel(reader, adminList);
            }
            return adminList;
        }

        public List<AdminInfo> ReadAdminList(int groupID, int currentPage, int pageSize, ref int count)
        {
            List<AdminInfo> adminList = new List<AdminInfo>();
            CommonMssqlPagerClass class2 = new CommonMssqlPagerClass();
            class2.TableName = "[" + ShopMssqlHelper.TablePrefix + "Admin]";
            class2.Fields = "*";
            class2.CurrentPage = currentPage;
            class2.PageSize = pageSize;
            class2.OrderField = "[ID]";
            class2.OrderType = OrderType.Desc;
            class2.MssqlCondition.Add("[GroupID]", groupID, ConditionType.Equal);
            class2.Count = count;
            count = class2.Count;
            using (SqlDataReader reader = class2.ExecuteReader())
            {
                this.PrepareAdminModel(reader, adminList);
            }
            return adminList;
        }

        public void PrepareAdminModel(SqlDataReader dr, List<AdminInfo> adminList)
        {
            while (dr.Read())
            {
                AdminInfo item = new AdminInfo();
                {
                    item.ID = int.Parse(dr["ID"].ToString());
                    item.Name = dr["Name"].ToString();
                    item.Password = dr["Password"].ToString();
                    item.RealName = dr["RealName"].ToString();
                    item.GroupID = int.Parse(dr["GroupID"].ToString());
                    item.State = int.Parse(dr["State"].ToString());
                    item.CreateDate = Convert.ToDateTime(dr["CreateDate"]);
                }
                adminList.Add(item);
            }
        }

        public AdminInfo GetModel(SqlDataReader dr)
        {
            AdminInfo model = new AdminInfo();
            if (dr.Read())
            {
                model.ID = int.Parse(dr["ID"].ToString());
                model.Name = dr["Name"].ToString();
                model.Password = dr["Password"].ToString();
                model.RealName = dr["RealName"].ToString();
                model.GroupID = int.Parse(dr["GroupID"].ToString());
                model.State = int.Parse(dr["State"].ToString());
                model.CreateDate = Convert.ToDateTime(dr["CreateDate"]);
            }
            return model;
        }
    }
}
