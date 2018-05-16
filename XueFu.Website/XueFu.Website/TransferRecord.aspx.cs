using System;
using XueFu.Common;
using XueFu.Model;
using XueFu.BLL;

namespace XueFu.Website
{
    public partial class TransferRecord : UserBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Master)Master).Title = "×ªÕÊ¼ÇÂ¼";

            //TransferInfo transfer = new TransferInfo();
            //transfer.Condition = "([InID]=" + base.UserID + " or [OutID]=" + base.UserID + ")";
            //base.BindControl(TransferBLL.ReadTransferList(transfer, base.CurrentPage, base.PageSize, ref base.Count), RecordList);
        }
    }
}
