using System;
using XueFu.Common;
using XueFu.Model;
using XueFu.BLL;
using XueFu.EntLib;

namespace XueFu.Website.Admin
{
    public partial class Transfer : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string name = StringHelper.SearchSafe(RequestHelper.GetQueryString<string>("Name"));
                string action = RequestHelper.GetQueryString<string>("Action");
                if (!string.IsNullOrEmpty(action) && !string.IsNullOrEmpty(name))
                {
                    int type = RequestHelper.GetQueryString<int>("Type");
                    this.Type.SelectedValue = type.ToString();
                    this.Name.Text = name;
                    TransferInfo transfer = new TransferInfo();
                    switch (type)
                    {
                        case 1:
                            transfer.InName = name;
                            break;

                        case 2:
                            transfer.OutName = name;
                            break;

                        default:
                            transfer.Condition = "([InName]='" + name + "' or [OutName]='" + name + "')";
                            break;
                    }
                    base.BindControl(TransferBLL.ReadTransferList(transfer, base.CurrentPage, base.PageSize, ref base.Count), RecordList, this.MyPager);
                }
                else
                {
                    base.BindControl(TransferBLL.ReadTransferList(base.CurrentPage, base.PageSize, ref base.Count), this.RecordList, this.MyPager);
                }
            }
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            ResponseHelper.Redirect(("Transfer.aspx?Action=search&" + "Type=" + this.Type.SelectedValue + "&") + "Name=" + this.Name.Text);
        }
    }
}
