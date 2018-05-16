using System;
using System.Collections.Generic;
using System.Text;
using XueFu.Model;

namespace XueFu.IDAL
{
    public interface IBonus
    {
        int AddBonus(BonusInfo model);
        void DeleteBonus(string idString);
        BonusInfo ReadBonus(int id);
        int ChangeBonusState(int userID, int state);
        int Bonus(int userID, string userName, int type, decimal money);
        BonusReportInfo ReadBonusReport(int userID);
        List<BonusInfo> ReadBonusList(BonusInfo model);
        List<BonusInfo> ReadBonusList(BonusInfo model, int currentPage, int pageSize, ref int count);
        List<BonusInfo> ReadBonusList(int currentPage, int pageSize, ref int count);
    }
}
