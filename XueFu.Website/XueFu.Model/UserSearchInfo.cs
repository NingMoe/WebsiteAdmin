using System;
using System.Collections.Generic;
using System.Text;

namespace XueFu.Model
{
    public sealed class UserSearchInfo
    {
        private string name = string.Empty;
        private string inUserID = string.Empty;
        private string notInUserID = string.Empty;
        private string realNameEqual=string.Empty;
        private string realNameLike = string.Empty;
        private string condition = string.Empty;
        private int state = int.MinValue;
        private int stateNoEqueal = int.MinValue;
        private int sex = int.MinValue;
        private int introducerID = int.MinValue;
        private int operatorID = int.MinValue;
        private DateTime startRegisterDate = DateTime.MinValue;
        private DateTime endRegisterDate = DateTime.MinValue;
        private string idCard = string.Empty;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string InUserID
        {
            get { return this.inUserID; }
            set { this.inUserID = value; }
        }

        public string NotInUserID
        {
            get { return this.notInUserID; }
            set { this.notInUserID = value; }
        }

        public string RealNameEqual
        {
            get { return this.realNameEqual; }
            set { this.realNameEqual = value; }
        }

        public string RealNameLike
        {
            get { return this.realNameLike; }
            set { this.realNameLike = value; }
        }

        public string Condition
        {
            get { return this.condition; }
            set { this.condition = value; }
        }

        public int State
        {
            get { return this.state; }
            set { this.state = value; }
        }

        public int StateNoEqueal
        {
            get { return this.stateNoEqueal; }
            set { this.stateNoEqueal = value; }
        }

        public int Sex
        {
            get { return this.sex; }
            set { this.sex = value; }
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

        public DateTime StartRegisterDate
        {
            get { return this.startRegisterDate; }
            set { this.startRegisterDate = value; }
        }

        public DateTime EndRegisterDate
        {
            get { return this.endRegisterDate; }
            set { this.endRegisterDate = value; }
        }

        public string IDCard
        {
            get { return this.idCard; }
            set { this.idCard = value; }
        }
    }
}
