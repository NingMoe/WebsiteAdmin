using System;
using System.Collections.Generic;
using System.Text;
using XueFu.EntLib;
using XueFu.Common;
using XueFu.Model;
using XueFu.IDAL;

namespace XueFu.BLL
{
    public sealed class BonusBLL
    {
        private static readonly IBonus dal = FactoryHelper.Instance<IBonus>(Global.DataProvider, "BonusDAL");

        public static int AddBonus(BonusInfo model)
        {
            return dal.AddBonus(model);
        }

        public static void DeleteBonus(string idString)
        {
            dal.DeleteBonus(idString);
        }

        public static BonusInfo ReadBonus(int id)
        {
            return dal.ReadBonus(id);
        }

        public static int ChangeBonusState(int userID, int state)
        {
            return dal.ChangeBonusState(userID, state);
        }

        public static int Bonus(int userID, string userName, int type, decimal money)
        {
            return dal.Bonus(userID, userName, type, Math.Abs(money));
        }

        public static BonusReportInfo ReadBonusReport(int userID)
        {
            return dal.ReadBonusReport(userID);
        }

        public static List<BonusInfo> ReadBonusList(BonusInfo model)
        {
            return dal.ReadBonusList(model);
        }

        public static List<BonusInfo> ReadBonusList(BonusInfo model, int currentPage, int pageSize, ref int count)
        {
            return dal.ReadBonusList(model, currentPage, pageSize, ref count);
        }

        public static List<BonusInfo> ReadBonusList(int currentPage, int pageSize, ref int count)
        {
            return dal.ReadBonusList(currentPage, pageSize, ref count);
        }
    }
}
