using System;
using XueFu.Common;
using XueFu.EntLib;

namespace XueFu.Website
{
    public partial class Record : UserBasePage
    {
        protected string action = RequestHelper.GetQueryString<string>("Action");

        protected void Page_Load(object sender, EventArgs e)
        {
            string pageTitle = string.Empty;
            switch (action)
            { 
                case "Bonus":
                    pageTitle = "分红记录";
                    break;

                case "AddUser":
                    pageTitle = "报单记录";
                    break;

                case "Introduce":
                    pageTitle = "推荐记录";
                    break;

                case "Transfer":
                    pageTitle = "转帐记录";
                    break;

                case "Notice":
                    pageTitle = "会员公告";
                    break;
            }

            ((Master)Master).Title = pageTitle;
        }
    }
}
