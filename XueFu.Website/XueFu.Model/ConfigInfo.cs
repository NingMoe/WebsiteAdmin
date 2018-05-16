using System;
using System.Collections.Generic;
using System.Text;

namespace XueFu.Model
{
    public sealed class ConfigInfo
    {
        private string title = string.Empty;
        private string copyright = string.Empty;
        private string author = string.Empty;
        private string keywords = string.Empty;
        private string description = string.Empty;
        private string secureKey = string.Empty;
        private int codeDot;
        private int codeLength;
        private int codeType;
        private int passwordType;
        private string adminCookies = string.Empty;
        private string userCookies = string.Empty;
        private string idPrefix = string.Empty;
        private string namePrefix = string.Empty;
        private int popCloseRefresh;
        private int saveAutoClosePop;
        private int maxUserNum;
        private int totalScore;
        private int perUserScore;
        private int transferBase;
        private int transferMultiple;
        private int introduceMoney;
        private int reportMoney;
        private decimal teamPercent;
        private int maxBonus;
        private int levelNum;


        public string AdminCookies
        {
            get { return this.adminCookies; }
            set { this.adminCookies = value; }
        }

        public string Author
        {
            get { return this.author; }
            set { this.author = value; }
        }

        public int CodeDot
        {
            get { return this.codeDot; }
            set { this.codeDot = value; }
        }

        public int CodeLength
        {
            get { return this.codeLength; }
            set { this.codeLength = value; }
        }

        public int CodeType
        {
            get { return this.codeType; }
            set { this.codeType = value; }
        }

        public string Copyright
        {
            get { return this.copyright; }
            set { this.copyright = value; }
        }

        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        public string IDPrefix
        {
            get { return this.idPrefix; }
            set { this.idPrefix = value; }
        }

        public string Keywords
        {
            get { return this.keywords; }
            set { this.keywords = value; }
        }

        public string NamePrefix
        {
            get { return this.namePrefix; }
            set { this.namePrefix = value; }
        }

        public int PasswordType
        {
            get { return this.passwordType; }
            set { this.passwordType = value; }
        }

        public string SecureKey
        {
            get { return this.secureKey; }
            set { this.secureKey = value; }
        }

        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }

        public string UserCookies
        {
            get { return this.userCookies; }
            set { this.userCookies = value; }
        }

        public int PopCloseRefresh
        {
            get { return this.popCloseRefresh; }
            set { this.popCloseRefresh = value; }
        }

        public int SaveAutoClosePop
        {
            get { return this.saveAutoClosePop; }
            set { this.saveAutoClosePop = value; }
        }

        public int MaxUserNum
        {
            get { return this.maxUserNum; }
            set { maxUserNum = value; }
        }

        public int TotalScore
        {
            get { return this.totalScore; }
            set { totalScore = value; }
        }

        public int PerUserScore
        {
            get { return this.perUserScore; }
            set { perUserScore = value; }
        }

        public int TransferBase
        {
            get { return this.transferBase; }
            set { transferBase = value; }
        }

        public int TransferMultiple
        {
            get { return this.transferMultiple; }
            set { this.transferMultiple = value; }
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

        public decimal TeamPercent
        {
            get { return this.teamPercent; }
            set { this.teamPercent = value; }
        }

        public int MaxBonus
        {
            get { return this.maxBonus; }
            set { this.maxBonus = value; }
        }

        public int LevelNum
        {
            get { return this.levelNum; }
            set { this.levelNum = value; }
        }

        public string PowerKey { get; set; }
    }
}
