using System;
using XueFu.Common;
using XueFu.Model;
using XueFu.BLL;

namespace XueFu.Website
{
    public partial class Default : UserBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Master)Master).Title = "Ê×Ò³";

            UserInfo user = UserBLL.ReadUser(base.UserID);
            this.TotalMoney.Text = user.Money.ToString();

            BonusReportInfo bonusReport = BonusBLL.ReadBonusReport(user.ID);
            this.BonusMoney.Text = bonusReport.BonusMoney.ToString();
            this.IntroduceMoney.Text = bonusReport.IntroduceMoney.ToString();
            this.ReportMoney.Text = bonusReport.ReportMoney.ToString();
            this.TeamMoney.Text = bonusReport.TeamMoney.ToString();
        }
    }
}
