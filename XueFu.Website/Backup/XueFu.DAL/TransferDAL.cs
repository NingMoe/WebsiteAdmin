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
    public sealed class TransferDAL : ITransfer
    {
        public int AddTransfer(TransferInfo model)
        {
            List<string> sqlList = new List<string>();
            sqlList.Add("Update [" + DbSQLHelper.TablePrefix + "User] Set [Money]=([Money] - " + model.Money + ") Where ID=" + model.OutID);
            sqlList.Add("Update [" + DbSQLHelper.TablePrefix + "User] Set [Money]=([Money] + " + model.Money + ") Where ID=" + model.InID);
            sqlList.Add("Insert into [" + DbSQLHelper.TablePrefix + "Transfer] ([OutID],[OutName],[InID],[InName],[Money]) values(" + model.OutID + ",'" + model.OutName + "'," + model.InID + ",'" + model.InName + "'," + model.Money + ")");
            int result= DbSQLHelper.ExecuteSqlTran(sqlList);
            return result;
        }

        public void DeleteTransfer(string idString)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Delete from [" + DbSQLHelper.TablePrefix + "Transfer] where [ID] in (" + idString + ")");
            DbSQLHelper.ExecuteSql(sql.ToString());
        }

        public TransferInfo ReadTransfer(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select * from [" + DbSQLHelper.TablePrefix + "Transfer] where [ID]=" + id);
            using (SqlDataReader dr = DbSQLHelper.ExecuteReader(sql.ToString()))
            {
                TransferInfo model = new TransferInfo();
                if (dr.Read())
                {
                    model.ID = int.Parse(dr["ID"].ToString());
                    model.OutID = int.Parse(dr["OutID"].ToString());
                    model.OutName = dr["OutName"].ToString();
                    model.InID = int.Parse(dr["InID"].ToString());
                    model.InName = dr["InName"].ToString();
                    model.Money = int.Parse(dr["Money"].ToString());
                    model.CreateDate = Convert.ToDateTime(dr["CreateDate"]);
                }
                return model;
            }
        }

        public List<TransferInfo> ReadTransferList(TransferInfo model)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select * from [" + DbSQLHelper.TablePrefix + "Transfer] ");
            List<TransferInfo> transferList = new List<TransferInfo>();
            MssqlCondition mssqlCondition = new MssqlCondition();
            this.PrepareCondition(mssqlCondition, model);

            if (mssqlCondition.ToString() != string.Empty)
            {
                sql.Append("where " + mssqlCondition.ToString());
            }
            using (SqlDataReader reader = DbSQLHelper.ExecuteReader(sql.ToString()))
            {
                this.PrepareModel(reader, transferList);
            }
            return transferList;
        }

        public List<TransferInfo> ReadTransferList(TransferInfo model, int currentPage, int pageSize, ref int count)
        {
            List<TransferInfo> transferList = new List<TransferInfo>();
            CommonMssqlPagerClass class2 = new CommonMssqlPagerClass();
            class2.TableName = "[" + ShopMssqlHelper.TablePrefix + "Transfer]";
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
                this.PrepareModel(reader, transferList);
            }
            return transferList;
        }

        public List<TransferInfo> ReadTransferList(int currentPage, int pageSize, ref int count)
        {
            List<TransferInfo> transferList = new List<TransferInfo>();
            CommonMssqlPagerClass class2 = new CommonMssqlPagerClass();
            class2.TableName = "[" + ShopMssqlHelper.TablePrefix + "Transfer]";
            class2.Fields = "*";
            class2.CurrentPage = currentPage;
            class2.PageSize = pageSize;
            class2.OrderField = "[ID]";
            class2.OrderType = OrderType.Desc;
            class2.Count = count;
            count = class2.Count;
            using (SqlDataReader reader = class2.ExecuteReader())
            {
                this.PrepareModel(reader, transferList);
            }
            return transferList;
        }

        public void PrepareCondition(MssqlCondition mssqlCondition, TransferInfo model)
        {
            mssqlCondition.Add("[InID]", model.InID, ConditionType.Equal);
            mssqlCondition.Add("[InName]", model.InName, ConditionType.Equal);
            mssqlCondition.Add("[OutID]", model.OutID, ConditionType.Equal);
            mssqlCondition.Add("[OutName]", model.OutName, ConditionType.Equal);
            mssqlCondition.Add(model.Condition);
        }

        public void PrepareModel(SqlDataReader dr, List<TransferInfo> transferList)
        {
            while (dr.Read())
            {
                TransferInfo model = new TransferInfo();
                {
                    model.ID = int.Parse(dr["ID"].ToString());
                    model.OutID = int.Parse(dr["OutID"].ToString());
                    model.OutName = dr["OutName"].ToString();
                    model.InID = int.Parse(dr["InID"].ToString());
                    model.InName = dr["InName"].ToString();
                    model.Money = int.Parse(dr["Money"].ToString());
                    model.CreateDate = Convert.ToDateTime(dr["CreateDate"]);
                }
                transferList.Add(model);
            }
        }
    }


}
