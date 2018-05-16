using System;

namespace XueFu.Model
{
    public sealed class UserInfo : AccoutBaseInfo
    {
        private int sex;
        private string idCard = string.Empty;
        private string mobile = string.Empty;
        private string address = string.Empty;
        private string weChat = string.Empty;
        private int introducerID = 0;
        private int operatorID = 0;
        private int money = 0;
        private int point = 0;

        public int Sex
        {
            get { return this.sex; }
            set { this.sex = value; }
        }

        public string IDCard
        {
            get { return this.idCard; }
            set { this.idCard = value; }
        }

        public string Mobile
        {
            get { return this.mobile; }
            set { this.mobile = value; }
        }

        public string Address
        {
            get { return this.address; }
            set { this.address = value; }
        }

        public string WeChat
        {
            get { return this.weChat; }
            set { this.weChat = value; }
        }

        public int IntroducerID
        {
            get { return this.introducerID; }
            set { this.introducerID = value; }
        }

        public int OperatorID
        {
            get { return this.operatorID; }
            set { this.operatorID = value; }
        }

        public int Money
        {
            get { return this.money; }
            set { this.money = value; }
        }

        public int Point
        {
            get { return this.point; }
            set { this.point = value; }
        }
    }
}
