using System;
using System.Collections.Generic;
using System.Text;

namespace XueFu.Model
{
    public sealed class TransferInfo
    {
        private int id;
        private int outID = int.MinValue;
        private string outName = string.Empty;
        private int inID = int.MinValue;
        private string inName = string.Empty;
        private int money;
        private DateTime createDate;
        private string condition = string.Empty;

        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public int OutID
        {
            get { return this.outID; }
            set { this.outID = value; }
        }

        public string OutName
        {
            get { return this.outName; }
            set { this.outName = value; }
        }

        public int InID
        {
            get { return this.inID; }
            set { this.inID = value; }
        }

        public string InName
        {
            get { return this.inName; }
            set { this.inName = value; }
        }

        public int Money
        {
            get { return this.money; }
            set { this.money = value; }
        }

        public DateTime CreateDate
        {
            get { return this.createDate; }
            set { this.createDate = value; }
        }

        public string Condition
        {
            get { return this.condition; }
            set { this.condition = value; }
        }
    }
}
