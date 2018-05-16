using System;
using System.Collections.Generic;
using System.Text;
using XueFu.EntLib;
using XueFu.Common;
using XueFu.Model;
using XueFu.IDAL;

namespace XueFu.BLL
{
    public sealed class TransferBLL
    {
        private static readonly ITransfer dal = FactoryHelper.Instance<ITransfer>(Global.DataProvider, "TransferDAL");

        public static int AddTransfer(TransferInfo model)
        {
            return dal.AddTransfer(model);
        }

        public static void DeleteTransfer(string idString)
        {
            dal.DeleteTransfer(idString);
        }

        public static TransferInfo ReadTransfer(int id)
        {
            return dal.ReadTransfer(id);
        }

        public static List<TransferInfo> ReadTransferList(TransferInfo model)
        {
            return dal.ReadTransferList(model);
        }

        public static List<TransferInfo> ReadTransferList(TransferInfo model, int currentPage, int pageSize, ref int count)
        {
            return dal.ReadTransferList(model, currentPage, pageSize, ref count);
        }

        public static List<TransferInfo> ReadTransferList(int currentPage, int pageSize, ref int count)
        {
            return dal.ReadTransferList(currentPage, pageSize, ref count);
        }
    }
}
