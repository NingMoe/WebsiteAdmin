using System;
using XueFu.Common;
using XueFu.Model;
using XueFu.BLL;

namespace XueFu.Website
{
    public partial class BonusRecord : UserBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Master)Master).Title = "�ֺ��¼";

            //BonusInfo bonusSearch = new BonusInfo();
            //bonusSearch.UserID = base.UserID;
            //bonusSearch.Type = 0;
            //base.BindControl(BonusBLL.ReadBonusList(bonusSearch, base.CurrentPage, base.PageSize, ref base.Count), RecordList);
        }
    }
}
