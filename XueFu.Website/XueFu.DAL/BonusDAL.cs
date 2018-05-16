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
    public sealed class BonusDAL : IBonus
    {
        public int AddBonus(BonusInfo model)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Insert into [" + DbSQLHelper.TablePrefix + "Bonus] ([UserID],[UserName],[Type],[Money]) values(@userID,@userName,@type,@money)");
            SqlParameter[] par ={
                new SqlParameter ("@userID",SqlDbType.Int),
                new SqlParameter ("@userName",SqlDbType.NVarChar),
                new SqlParameter ("@money",SqlDbType.Decimal),
                new SqlParameter ("@type",SqlDbType.Int)
            };
            par[0].Value = model.UserID;
            par[1].Value = model.UserName;
            par[2].Value = model.Money;
            par[2].Value = model.Type;
            return DbSQLHelper.ExecuteSql(sql.ToString(), par);
        }

        public void DeleteBonus(string idString)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Delete from [" + DbSQLHelper.TablePrefix + "Bonus] where [ID] in (" + idString + ")");
            DbSQLHelper.ExecuteSql(sql.ToString());
        }

        public BonusInfo ReadBonus(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select * from [" + DbSQLHelper.TablePrefix + "Bonus] where [ID]=" + id);
            using (SqlDataReader dr = DbSQLHelper.ExecuteReader(sql.ToString()))
            {
                BonusInfo model = new BonusInfo();
                if (dr.Read())
                {
                    model.ID = int.Parse(dr["ID"].ToString());
                    model.UserID = int.Parse(dr["UserID"].ToString());
                    model.UserName = dr["UserName"].ToString();
                    model.Type = int.Parse(dr["Type"].ToString());
                    model.Money = decimal.Parse(dr["Money"].ToString());
                    model.CreateDate = Convert.ToDateTime(dr["CreateDate"]);
                }
                return model;
            }
        }

        public int ChangeBonusState(int userID, int state)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Update [" + DbSQLHelper.TablePrefix + "Bonus] Set [State]=" + state + " Where [userID]=" + userID);
            return DbSQLHelper.ExecuteSql(sql.ToString());
        }

        public int Bonus(int userID, string userName, int type, decimal money)
        {
            List<string> sqlList = new List<string>();
            sqlList.Add("Update [" + DbSQLHelper.TablePrefix + "User] Set [Money]=([Money] +" + money + ") Where [ID]=" + userID);
            sqlList.Add("Insert into [" + DbSQLHelper.TablePrefix + "Bonus] ([UserID],[UserName],[Type],[Money]) values(" + userID + ",'" + userName + "'," + type + "," + money + ")");
            return DbSQLHelper.ExecuteSqlTran(sqlList);
        }

        public BonusReportInfo ReadBonusReport(int userID)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" select isnull(sum(case when [type]=" + ((int)MoneyType.Bonus).ToString() + " then [money] else 0 end),0) as [BonusMoney],isnull(sum(case when [type]=" + ((int)MoneyType.Introduce).ToString() + " then [money] else 0 end),0) as [IntroduceMoney],isnull(sum(case when [type]=" + ((int)MoneyType.Report).ToString() + " then [money] else 0 end),0) as [ReportMoney],isnull(sum(case when [type]=" + ((int)MoneyType.Team).ToString() + " then [money] else 0 end),0) as [TeamMoney] from bonus where [State] = 0 and userid=" + userID);
            using (SqlDataReader dr = DbSQLHelper.ExecuteReader(sql.ToString()))
            {
                BonusReportInfo bonusReport = new BonusReportInfo();
                if (dr.Read())
                {
                    bonusReport.UserID = userID;
                    bonusReport.BonusMoney = int.Parse(dr["BonusMoney"].ToString());
                    bonusReport.IntroduceMoney = int.Parse(dr["IntroduceMoney"].ToString());
                    bonusReport.ReportMoney = int.Parse(dr["ReportMoney"].ToString());
                    bonusReport.TeamMoney = decimal.Parse(dr["TeamMoney"].ToString());
                }
                return bonusReport;
            }
        }

        public List<BonusInfo> ReadBonusList(BonusInfo model)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select * from [" + DbSQLHelper.TablePrefix + "Bonus] ");
            List<BonusInfo> bonusList = new List<BonusInfo>();
            MssqlCondition mssqlCondition = new MssqlCondition();
            this.PrepareCondition(mssqlCondition, model);

            if (mssqlCondition.ToString() != string.Empty)
            {
                sql.Append("where " + mssqlCondition.ToString());
            }
            using (SqlDataReader reader = DbSQLHelper.ExecuteReader(sql.ToString()))
            {
                this.PrepareModel(reader, bonusList);
            }
            return bonusList;
        }

        public List<BonusInfo> ReadBonusList(BonusInfo model, int currentPage, int pageSize, ref int count)
        {
            List<BonusInfo> bonusList = new List<BonusInfo>();
            CommonMssqlPagerClass class2 = new CommonMssqlPagerClass();
            class2.TableName = "[" + ShopMssqlHelper.TablePrefix + "Bonus]";
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
                this.PrepareModel(reader, bonusList);
            }
            return bonusList;
        }

        public List<BonusInfo> ReadBonusList(int currentPage, int pageSize, ref int count)
        {
            List<BonusInfo> bonusList = new List<BonusInfo>();
            CommonMssqlPagerClass class2 = new CommonMssqlPagerClass();
            class2.TableName = "[" + ShopMssqlHelper.TablePrefix + "Bonus]";
            class2.Fields = "*";
            class2.CurrentPage = currentPage;
            class2.PageSize = pageSize;
            class2.OrderField = "[ID]";
            class2.OrderType = OrderType.Desc;
            class2.Count = count;
            count = class2.Count;
            using (SqlDataReader reader = class2.ExecuteReader())
            {
                this.PrepareModel(reader, bonusList);
            }
            return bonusList;
        }

        public void PrepareCondition(MssqlCondition mssqlCondition, BonusInfo model)
        {
            mssqlCondition.Add("[UserID]", model.UserID, ConditionType.Equal);
            mssqlCondition.Add("[UserName]", model.UserName, ConditionType.Equal);
            mssqlCondition.Add("[Money]", model.Money, ConditionType.Equal);
            mssqlCondition.Add("[Type]", model.Type, ConditionType.Equal);
            mssqlCondition.Add("[State]", model.State, ConditionType.Equal);
        }

        public void PrepareModel(SqlDataReader dr, List<BonusInfo> bonusList)
        {
            while (dr.Read())
            {
                BonusInfo model = new BonusInfo();
                {
                    model.ID = int.Parse(dr["ID"].ToString());
                    model.UserID = int.Parse(dr["UserID"].ToString());
                    model.UserName = dr["UserName"].ToString();
                    model.Type = int.Parse(dr["Type"].ToString());
                    model.Money = decimal.Parse(dr["Money"].ToString());
                    model.CreateDate = Convert.ToDateTime(dr["CreateDate"]);
                }
                bonusList.Add(model);
            }
        }
    }
}
