using System;
using System.Collections.Generic;
using System.Text;
using XueFu.Model;

namespace XueFu.IDAL
{
    public interface ITransfer
    {
        int AddTransfer(TransferInfo model);
        void DeleteTransfer(string idString);
        TransferInfo ReadTransfer(int id);
        List<TransferInfo> ReadTransferList(TransferInfo model);
        List<TransferInfo> ReadTransferList(TransferInfo model, int currentPage, int pageSize, ref int count);
        List<TransferInfo> ReadTransferList(int currentPage, int pageSize, ref int count);
    }
}
