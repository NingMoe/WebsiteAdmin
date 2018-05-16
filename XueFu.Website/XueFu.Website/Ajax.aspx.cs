using System;
using XueFu.EntLib;
using XueFu.Common;
using XueFu.Model;
using XueFu.BLL;
using System.Collections.Generic;
using System.Text;

namespace XueFu.Website
{
    public partial class Ajax : System.Web.UI.Page
    {
        protected int pageSize = 20;
        protected int userID = Cookies.User.GetUserID(true);

        protected void Page_Load(object sender, EventArgs e)
        {
            string action = RequestHelper.GetQueryString<string>("Action");
            switch (action)
            {
                case "Login":
                    Login();
                    break;

                case "CheckUserName":
                    this.CheckUserName();
                    break;

                case "AddUserRecord":
                    this.AddUserRecord();
                    break;

                case "BonusRecord":
                    this.BonusRecord();
                    break;

                case "IntroduceRecord":
                    this.IntroduceRecord();
                    break;

                case "TransferRecord":
                    this.TransferRecord();
                    break;

                case "Notice":
                    this.Notice();
                    break;

                case "CheckIDCard":
                    this.CheckIDCard();
                    break;

                case "CheckTransferMoney":
                    this.CheckTransferMoney();
                    break;
            }
        }

        private void CheckTransferMoney()
        {
            int money = RequestHelper.GetForm<int>("Money");
            int transferBase = Config.ReadConfigInfo().TransferBase * Config.ReadConfigInfo().TransferMultiple;
            string errMsg = string.Empty;
            bool result = true;

            if (money >= transferBase && (money % transferBase == 0))
            {
                UserInfo user = UserBLL.ReadUser(this.userID);

                if (user.Money < money)
                {
                    errMsg = Language.ReadLanguage("AccountMoneyLessTips");
                    result = false;
                }
            }
            else
            {
                errMsg = Language.ReadLanguage("NoTransferMoneyRuleTips").Replace("$Money", transferBase.ToString());
                result = false;
            }
            ResponseHelper.Write("{\"result\":\"" + result + "\",\"error\":\"" + errMsg + "\"}");
        }

        private void CheckIDCard()
        {
            string idCard = StringHelper.SearchSafe(RequestHelper.GetForm<string>("IDCard"));
            string resultData = "{";
            UserSearchInfo userSearch = new UserSearchInfo();
            userSearch.IDCard = idCard;
            userSearch.NotInUserID = this.userID.ToString();
            if (UserBLL.ReadUserList(userSearch).Count >= Config.ReadConfigInfo().MaxUserNum)
            {
                resultData += "\"result\":\"false\"";
            }
            else
            {
                resultData += "\"result\":\"true\"";
            }
            resultData += "}";
            ResponseHelper.Write(resultData);
        }

        protected void Notice()
        {
            int currentPage = RequestHelper.GetQueryString<int>("Page");
            int count = 0;
            StringBuilder resultData = new StringBuilder();

            ArticleSearchInfo articleSearch = new ArticleSearchInfo();
            articleSearch.ClassID = "|2|";
            List<ArticleInfo> articleList = ArticleBLL.SearchArticleList(currentPage, this.pageSize, articleSearch, ref count);
            foreach (ArticleInfo info in articleList)
            {
                resultData.AppendLine("<tr>");
                resultData.AppendLine("<td class=\"text-left\"><a href=\"NoticeDetail.aspx?ID=" + info.ID + "\">" + info.Title + "</a></td>");
                resultData.AppendLine("<td>" + info.Date.ToString("d") + "</td>");
                resultData.AppendLine("</tr>");
            }
            ResponseHelper.Write(resultData.ToString());
        }

        protected void TransferRecord()
        {
            int currentPage = RequestHelper.GetQueryString<int>("Page");
            int count = 0;
            int i = pageSize * (currentPage - 1);
            StringBuilder resultData = new StringBuilder();

            TransferInfo transfer = new TransferInfo();
            transfer.Condition = "([InID]=" + this.userID + " or [OutID]=" + this.userID + ")";
            List<TransferInfo> transferList = TransferBLL.ReadTransferList(transfer, currentPage, this.pageSize, ref count);
            foreach (TransferInfo info in transferList)
            {
                i++;
                resultData.AppendLine("<tr>");
                resultData.AppendLine("<td>" + info.OutName + "</td>");
                resultData.AppendLine("<td>" + info.InName + "</td>");
                resultData.AppendLine("<td>" + info.Money + "</td>");
                resultData.AppendLine("<td>" + info.CreateDate.ToString("d") + "</td>");
                resultData.AppendLine("</tr>");
            }
            ResponseHelper.Write(resultData.ToString());
        }

        protected void IntroduceRecord()
        {
            int currentPage = RequestHelper.GetQueryString<int>("Page");
            int count = 0;
            int i = pageSize * (currentPage - 1);
            StringBuilder resultData = new StringBuilder();

            UserSearchInfo userSearch = new UserSearchInfo();
            userSearch.IntroducerID = this.userID;
            List<UserInfo> userList = UserBLL.ReadUserList(userSearch, currentPage, this.pageSize, ref count);
            foreach (UserInfo info in userList)
            {
                i++;
                resultData.AppendLine("<tr>");
                resultData.AppendLine("<td>" + i + "</td>");
                resultData.AppendLine("<td>" + info.Name + "</td>");
                resultData.AppendLine("<td>" + info.RealName + "</td>");
                resultData.AppendLine("<td>" + info.CreateDate.ToString("d") + "</td>");
                resultData.AppendLine("</tr>");
            }
            ResponseHelper.Write(resultData.ToString());
        }

        protected void BonusRecord()
        {
            int currentPage = RequestHelper.GetQueryString<int>("Page");
            int count = 0;
            int i = pageSize * (currentPage - 1);
            StringBuilder resultData = new StringBuilder();

            BonusInfo bonusSearch = new BonusInfo();
            bonusSearch.UserID = this.userID;
            bonusSearch.Type = 0;
            List<BonusInfo> bonusList = BonusBLL.ReadBonusList(bonusSearch, currentPage, this.pageSize, ref count);
            foreach (BonusInfo info in bonusList)
            {
                i++;
                resultData.AppendLine("<tr>");
                resultData.AppendLine("<td>" + i + "</td>");
                resultData.AppendLine("<td>" + info.Money + "</td>");
                resultData.AppendLine("<td>" + info.CreateDate.ToString("d") + "</td>");
                resultData.AppendLine("</tr>");
            }
            ResponseHelper.Write(resultData.ToString());
        }

        protected void AddUserRecord()
        {
            int currentPage = RequestHelper.GetQueryString<int>("Page");
            int count = 0;
            int i = pageSize * (currentPage - 1);
            StringBuilder resultData = new StringBuilder();

            UserSearchInfo userSearch = new UserSearchInfo();
            userSearch.OperatorID = this.userID;
            List<UserInfo> userList = UserBLL.ReadUserList(userSearch, currentPage, this.pageSize, ref count);
            foreach (UserInfo info in userList)
            {
                i++;
                resultData.AppendLine("<tr>");
                resultData.AppendLine("<td>" + i + "</td>");
                resultData.AppendLine("<td>" + UserBLL.ReadUser(info.OperatorID).Name + "</td>");
                resultData.AppendLine("<td>" + info.Name + "</td>");
                resultData.AppendLine("<td>" + info.CreateDate.ToString("d") + "</td>");
                resultData.AppendLine("</tr>");
            }
            ResponseHelper.Write(resultData.ToString());
        }

        protected void CheckUserName()
        {
            string resultData = "{";
            int num = 0;
            string userName = StringHelper.SearchSafe(RequestHelper.GetQueryString<string>("UserName"));
            if (userName != string.Empty)
            {
                UserInfo user = UserBLL.ReadUser(userName);
                if (user != null && user.ID > 0)
                {
                    resultData += "\"result\":\"true\", \"state\":\"" + user.State + "\"";
                    if (user.Money >= Config.ReadConfigInfo().PerUserScore)
                        resultData += ", \"canIntroduce\":\"true\"";
                    else
                        resultData += ", \"canIntroduce\":\"false\"";
                }
                else
                {
                    resultData += "\"result\":\"false\"";
                }
            }
            else
            {
                resultData += "\"result\":\"false\"";
            }
            resultData += "}";
            ResponseHelper.Write(resultData);
        }

        protected void Login()
        {
            string resultData = "{";
            string loginName = StringHelper.SearchSafe(RequestHelper.GetForm<string>("UserName"));
            string loginPass = StringHelper.Password(RequestHelper.GetForm<string>("Password"), (PasswordType)Config.ReadConfigInfo().PasswordType);
            UserInfo user = UserBLL.CheckUserLogin(loginName, loginPass);
            if (user.ID > 0)
            {
                if (user.State != (int)UserState.Frozen)
                    UserBLL.UserLoginInit(user);
                resultData += "\"result\":\"true\", \"state\":" + user.State;
            }
            else
            {
                resultData += "\"result\":\"false\"";
            }
            resultData += "}";
            ResponseHelper.Write(resultData);
        }
    }
}
