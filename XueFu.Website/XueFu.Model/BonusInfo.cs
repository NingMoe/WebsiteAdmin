using System;
using System.Collections.Generic;
using System.Text;

namespace XueFu.Model
{
    public sealed class BonusInfo
    {
        private int id;
        private int userID = int.MinValue;
        private string userName = string.Empty;
        private decimal money = decimal.MinValue;
        private int type = int.MinValue;
        private DateTime createDate;
        private int state = 0;

        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public int UserID
        {
            get { return this.userID; }
            set { this.userID = value; }
        }

        public string UserName
        {
            get { return this.userName; }
            set { this.userName = value; }
        }

        public int Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        public decimal Money
        {
            get { return this.money; }
            set { this.money = value; }
        }

        public DateTime CreateDate
        {
            get { return this.createDate; }
            set { this.createDate = value; }
        }

        public int State
        {
            get { return this.state; }
            set { this.state = value; }
        }
    }
}
