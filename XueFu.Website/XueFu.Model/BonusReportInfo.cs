using System;
using System.Collections.Generic;
using System.Text;

namespace XueFu.Model
{
    public sealed class BonusReportInfo
    {
        private int userID;
        private int bonusMoney;
        private int introduceMoney;
        private int reportMoney;
        private decimal teamMoney;

        public int UserID
        {
            get { return this.userID; }
            set { this.userID = value; }
        }

        public int BonusMoney
        {
            get { return this.bonusMoney; }
            set { this.bonusMoney = value; }
        }

        public int IntroduceMoney
        {
            get { return this.introduceMoney; }
            set { this.introduceMoney = value; }
        }

        public int ReportMoney
        {
            get { return this.reportMoney; }
            set { this.reportMoney = value; }
        }

        public decimal TeamMoney
        {
            get { return this.teamMoney; }
            set { this.teamMoney = value; }
        }
    }
}
