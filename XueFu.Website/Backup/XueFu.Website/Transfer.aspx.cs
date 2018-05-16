using System;
using XueFu.Common;
using XueFu.EntLib;
using XueFu.Model;
using XueFu.BLL;

namespace XueFu.Website
{
    public partial class Transfer : UserBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Master)Master).Title = "×ªÕÊ";

            string action = RequestHelper.GetForm<string>("Action");
            if (!string.IsNullOrEmpty(action))
            {
                int money = RequestHelper.GetForm<int>("money");
                string inName = StringHelper.SearchSafe(RequestHelper.GetForm<string>("username"));

                UserInfo user = UserBLL.ReadUser(base.UserID);
                if (user.Name != inName)
                {
                    UserInfo transferInUser = UserBLL.ReadUser(inName);
                    if (transferInUser != null && transferInUser.ID > 0)
                    {
                        int transferBase = Config.ReadConfigInfo().TransferBase * Config.ReadConfigInfo().TransferMultiple;
                        if (money >= transferBase && (money % transferBase == 0))
                        {
                            if (user.Money >= money)
                            {
                                TransferInfo transfer = new TransferInfo();
                                transfer.InName = inName;
                                transfer.InID = transferInUser.ID;
                                transfer.Money = money;
                                transfer.OutID = user.ID;
                                transfer.OutName = user.Name;
                                if (TransferBLL.AddTransfer(transfer) > 0)
                                    ScriptHelper.Alert(Language.ReadLanguage("TransferCompleteTips"));
                            }
                            else
                            {
                                ScriptHelper.Alert(Language.ReadLanguage("AccountMoneyLessTips"));
                            }
                        }
                        else
                        {
                            ScriptHelper.Alert(Language.ReadLanguage("NoTransferMoneyRuleTips").Replace("$Money", transferBase.ToString()));
                        }
                    }
                    else
                    {
                        ScriptHelper.Alert(Language.ReadLanguage("TransferAccountNoExistTips"));
                    }
                }
                else
                {
                    ScriptHelper.Alert(Language.ReadLanguage("TransferAccountEqualTips"));
                }
            }
        }
    }
}
