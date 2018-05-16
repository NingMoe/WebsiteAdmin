using System;
using System.Collections.Generic;
using System.Text;
using XueFu.EntLib;

namespace XueFu.Model
{
    public class AccoutBaseInfo
    {
        private int id;
        private string name = string.Empty;
        private string password = string.Empty;
        private string realName;
        private int groupID = (int)GroupType.User;
        private int state = (int)UserState.NoCheck;
        private DateTime createDate;

        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        public string RealName
        {
            get { return this.realName; }
            set { this.realName = value; }
        }

        public int GroupID
        {
            get { return this.groupID; }
            set { this.groupID = value; }
        }

        public int State
        {
            get { return this.state; }
            set { this.state = value; }
        }

        public DateTime CreateDate
        {
            get { return this.createDate; }
            set { this.createDate = value; }
        }
    }
}
