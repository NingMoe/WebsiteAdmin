using System;
using XueFu.Common;
using XueFu.Model;
using XueFu.BLL;
using XueFu.EntLib;
using XueFu.EntLib.MethodExtend;

namespace XueFu.Web.Admin
{
    public partial class Bonus : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BonusType.DataSource = EnumHelper<MoneyType>.GetSelectList();
                BonusType.DataTextField = "Key";
                BonusType.DataValueField = "Value";
                BonusType.DataBind();

                string name = StringHelper.SearchSafe(RequestHelper.GetQueryString<string>("Name"));
                decimal money = RequestHelper.GetQueryString<decimal>("Money");
                BonusInfo bonusSearch = new BonusInfo();
                bonusSearch.UserName = name;
                bonusSearch.Money = money;
                bonusSearch.Type = RequestHelper.GetQueryString<int>("BonusType");
                base.BindControl(BonusBLL.ReadBonusList(bonusSearch, base.CurrentPage, base.PageSize, ref base.Count), RecordList, this.MyPager);
                this.Name.Text = name;
                if (money > 0) this.Money.Text = money.ToString();
            }
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            ResponseHelper.Redirect("Bonus.aspx?Action=search&" + "Money=" + this.Money.Text + "&Name=" + this.Name.Text + "&BonusType=" + this.BonusType.SelectedValue);
        }
    }
}
