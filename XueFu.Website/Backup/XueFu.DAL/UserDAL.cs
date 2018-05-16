using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using XueFu.EntLib;
using XueFu.Common;
using XueFu.Model;
using XueFu.IDAL;

namespace XueFu.DAL
{
    public sealed class UserDAL : IUser
    {
        public int AddUser(UserInfo model)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Insert into [" + DbSQLHelper.TablePrefix + "User] ([Name],[Password],[RealName],[Sex],[IDCard],[Mobile],[Address],[WeChat],[IntroducerID],[OperatorID],[Money],[Point],[State],[GroupID]) values(@name,@password,@realName,@sex,@idCard,@mobile,@address,@weChat,@introducerID,@operatorID,@money,@point,@state,@groupID)");
            SqlParameter[] par = (SqlParameter[])this.ValueParas(model);
            return DbSQLHelper.ExecuteSql(sql.ToString(), par);
        }

        public void UpdateUser(UserInfo model)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Update [" + DbSQLHelper.TablePrefix + "User] set [Name]=@name,[Password]=@password,[RealName]=@realName,[Sex]=@sex,[IDCard]=@idCard,[Mobile]=@mobile,[Address]=@address,[WeChat]=@weChat,[IntroducerID]=@introducerID,[OperatorID]=@operatorID,[Money]=@money,[Point]=@point,[State]=@state,[GroupID]=@groupID where [ID]=@id");
            SqlParameter[] par = (SqlParameter[])this.ValueParas(model);
            DbSQLHelper.ExecuteSql(sql.ToString(), par);
        }

        public void UpdateMoney(int userID, int money)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Update [" + DbSQLHelper.TablePrefix + "User] set [Money]=@money where [ID]=@userID");
            SqlParameter[] pt = new SqlParameter[] {
                new SqlParameter("@userID", SqlDbType.Int),
                new SqlParameter("@money", SqlDbType.Int)
            };
            pt[0].Value = userID;
            pt[1].Value = money;
            DbSQLHelper.ExecuteSql(sql.ToString(), pt);
        }

        public void UpdatePoint(int userID, int point)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Update [" + DbSQLHelper.TablePrefix + "User] set [Point]=@point where [ID]=@userID");
            SqlParameter[] pt = new SqlParameter[] {
                new SqlParameter("@userID", SqlDbType.Int),
                new SqlParameter("@point", SqlDbType.Int)
            };
            pt[0].Value = userID;
            pt[1].Value = point;
            DbSQLHelper.ExecuteSql(sql.ToString(), pt);
        }

        public void DeleteUser(string idString)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Delete from [" + DbSQLHelper.TablePrefix + "User] where [ID] in (" + idString + ")");
            DbSQLHelper.ExecuteSql(sql.ToString());
        }

        public void ChangePassword(int id, string newPassword)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE [" + DbSQLHelper.TablePrefix + "User] Set [Password]=@password WHERE [ID]=@id");
            SqlParameter[] pt = new SqlParameter[] {
                new SqlParameter("@id", SqlDbType.Int),
                new SqlParameter("@password", SqlDbType.NVarChar)
            };
            pt[0].Value = id;
            pt[1].Value = newPassword;
            DbSQLHelper.ExecuteSql(sql.ToString(), pt);
        }

        public int ChangeUserState(int userID, int state)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Update [" + DbSQLHelper.TablePrefix + "User] set [State]=@state where [ID]=@userID");
            SqlParameter[] pt = new SqlParameter[] {
                new SqlParameter("@userID", SqlDbType.Int),
                new SqlParameter("@state", SqlDbType.Int)
            };
            pt[0].Value = userID;
            pt[1].Value = state;
            return DbSQLHelper.ExecuteSql(sql.ToString(), pt);
        }

        public UserInfo CheckUserLogin(string loginName, string loginPass)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * FROM [" + DbSQLHelper.TablePrefix + "User] WHERE [Name]=@loginName AND [Password]=@loginPass");
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

        public UserInfo ReadUser(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select * from [" + DbSQLHelper.TablePrefix + "User] where [ID]=" + id);
            using (SqlDataReader reader = DbSQLHelper.ExecuteReader(sql.ToString()))
            {
                return GetModel(reader);
            }
        }

        public UserInfo ReadUser(string name)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select * from [" + DbSQLHelper.TablePrefix + "User] where [Name]='" + name + "'");
            using (SqlDataReader reader = DbSQLHelper.ExecuteReader(sql.ToString()))
            {
                return GetModel(reader);
            }
        }

        public List<UserInfo> ReadUserList(UserSearchInfo model)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select * from [" + DbSQLHelper.TablePrefix + "User] ");
            List<UserInfo> userList = new List<UserInfo>();
            MssqlCondition mssqlCondition = new MssqlCondition();
            this.PrepareCondition(mssqlCondition, model);

            if (mssqlCondition.ToString() != string.Empty)
            {
                sql.Append("where " + mssqlCondition.ToString());
            }
            using (SqlDataReader reader = DbSQLHelper.ExecuteReader(sql.ToString()))
            {
                this.PrepareModel(reader, userList);
            }


            return userList;
        }

        public List<UserInfo> ReadUserList(UserSearchInfo model, int currentPage, int pageSize, ref int count)
        {
            List<UserInfo> userList = new List<UserInfo>();
            CommonMssqlPagerClass class2 = new CommonMssqlPagerClass();
            class2.TableName = "[" + ShopMssqlHelper.TablePrefix + "User]";
            class2.Fields = "*";
            class2.CurrentPage = currentPage;
            class2.PageSize = pageSize;
            class2.OrderField = "[ID]";
            class2.OrderType = OrderType.Desc;
            this.PrepareCondition(class2.MssqlCondition, model);
            class2.Count = count;
            count = class2.Count;
            using (SqlDataReader reader = class2.ExecuteReader())
            {
                this.PrepareModel(reader, userList);
            }
            return userList;
        }

        public List<UserInfo> ReadUserList(int currentPage, int pageSize, ref int count)
        {
            List<UserInfo> userList = new List<UserInfo>();
            CommonMssqlPagerClass class2 = new CommonMssqlPagerClass();
            class2.TableName = "[" + ShopMssqlHelper.TablePrefix + "User]";
            class2.Fields = "*";
            class2.CurrentPage = currentPage;
            class2.PageSize = pageSize;
            class2.OrderField = "[ID]";
            class2.OrderType = OrderType.Desc;
            class2.Count = count;
            count = class2.Count;
            using (SqlDataReader reader = class2.ExecuteReader())
            {
                this.PrepareModel(reader, userList);
            }
            return userList;
        }

        /// <summary>
        /// 该数据访问对象的属性值装载到数据库更新参数数组
        /// </summary>
        /// <remarks></remarks>
        protected IDbDataParameter[] ValueParas(UserInfo model)
        {
            SqlParameter[] par ={
                                    new SqlParameter ("@name",SqlDbType.NVarChar),
                                    new SqlParameter ("@password",SqlDbType.NVarChar),
                                    new SqlParameter ("@realName",SqlDbType.NVarChar),
                                    new SqlParameter ("@sex",SqlDbType.Int),
                                    new SqlParameter ("@idCard",SqlDbType.VarChar),
                                    new SqlParameter ("@mobile",SqlDbType.VarChar),
                                    new SqlParameter ("@address",SqlDbType.NVarChar),
                                    new SqlParameter ("@weChat",SqlDbType.NVarChar),
                                    new SqlParameter ("@introducerID",SqlDbType.Int),
                                    new SqlParameter ("@operatorID",SqlDbType.Int),
                                    new SqlParameter ("@money",SqlDbType.Int),
                                    new SqlParameter ("@point",SqlDbType.Int),
                                    new SqlParameter ("@state",SqlDbType.Int),
                                    new SqlParameter ("@groupID",SqlDbType.Int),
                                    new SqlParameter ("@id",SqlDbType.Int)
                                };
            par[0].Value = model.Name;
            par[1].Value = model.Password;
            par[2].Value = model.RealName;
            par[3].Value = model.Sex;
            par[4].Value = model.IDCard;
            par[5].Value = model.Mobile;
            par[6].Value = model.Address;
            par[7].Value = model.WeChat;
            par[8].Value = model.IntroducerID;
            par[9].Value = model.OperatorID;
            par[10].Value = model.Money;
            par[11].Value = model.Point;
            par[12].Value = model.State;
            par[13].Value = model.GroupID;
            par[14].Value = model.ID;
            return par;
        }

        public void PrepareCondition(MssqlCondition mssqlCondition, UserSearchInfo userSearch)
        {
            mssqlCondition.Add("[Name]", userSearch.Name, ConditionType.Like);
            mssqlCondition.Add("[RealName]", userSearch.RealNameEqual, ConditionType.Equal);
            mssqlCondition.Add("[RealName]", userSearch.RealNameLike, ConditionType.Like);
            mssqlCondition.Add("[ID]", userSearch.InUserID, ConditionType.In);
            mssqlCondition.Add("[ID]", userSearch.NotInUserID, ConditionType.NotIn);
            mssqlCondition.Add("[IntroducerID]", userSearch.IntroducerID, ConditionType.Equal);
            mssqlCondition.Add("[OperatorID]", userSearch.OperatorID, ConditionType.Equal);
            mssqlCondition.Add("[Sex]", userSearch.Sex, ConditionType.Equal);
            mssqlCondition.Add("[CreateDate]", userSearch.StartRegisterDate, ConditionType.MoreOrEqual);
            mssqlCondition.Add("[CreateDate]", userSearch.EndRegisterDate, ConditionType.Less);
            mssqlCondition.Add("[State]", userSearch.State, ConditionType.Equal);
            mssqlCondition.Add("[State]", userSearch.StateNoEqueal, ConditionType.NoEqual);
            mssqlCondition.Add("[IDCard]", userSearch.IDCard, ConditionType.Equal);
            mssqlCondition.Add(userSearch.Condition);
        }

        public void PrepareModel(SqlDataReader dr, List<UserInfo> userList)
        {
            while (dr.Read())
            {
                UserInfo model = new UserInfo();
                {
                    model.ID = int.Parse(dr["ID"].ToString());
                    model.Name = dr["Name"].ToString();
                    model.Password = dr["Password"].ToString();
                    model.RealName = dr["RealName"].ToString();
                    model.Sex = int.Parse(dr["Sex"].ToString());
                    model.IDCard = dr["IDCard"].ToString();
                    model.Mobile = dr["Mobile"].ToString();
                    model.Address = dr["Address"].ToString();
                    model.WeChat = dr["WeChat"].ToString();
                    model.GroupID = int.Parse(dr["GroupID"].ToString());
                    model.IntroducerID = int.Parse(dr["IntroducerID"].ToString());
                    model.OperatorID = int.Parse(dr["OperatorID"].ToString());
                    model.Money = int.Parse(dr["Money"].ToString());
                    model.Point = int.Parse(dr["Point"].ToString());
                    model.State = int.Parse(dr["State"].ToString());
                    model.CreateDate = Convert.ToDateTime(dr["CreateDate"]);
                }
                userList.Add(model);
            }
        }


        /// <summary>
        /// 返回数据
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public UserInfo GetModel(SqlDataReader dr)
        {
            UserInfo model = new UserInfo();
            if (dr.Read())
            {
                model.ID = int.Parse(dr["ID"].ToString());
                model.Name = dr["Name"].ToString();
                model.Password = dr["Password"].ToString();
                model.RealName = dr["RealName"].ToString();
                model.Sex = int.Parse(dr["Sex"].ToString());
                model.IDCard = dr["IDCard"].ToString();
                model.Mobile = dr["Mobile"].ToString();
                model.Address = dr["Address"].ToString();
                model.WeChat = dr["WeChat"].ToString();
                model.GroupID = int.Parse(dr["GroupID"].ToString());
                model.IntroducerID = int.Parse(dr["IntroducerID"].ToString());
                model.OperatorID = int.Parse(dr["OperatorID"].ToString());
                model.Money = int.Parse(dr["Money"].ToString());
                model.Point = int.Parse(dr["Point"].ToString());
                model.State = int.Parse(dr["State"].ToString());
                model.CreateDate = Convert.ToDateTime(dr["CreateDate"]);
            }
            return model;
        }
    }
}
