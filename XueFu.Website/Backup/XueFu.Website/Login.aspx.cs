using System;
using XueFu.Model;
using System.Collections.Generic;
using XueFu.BLL;

namespace XueFu.Website
{
    public partial class Login : System.Web.UI.Page
    {
        protected ArticleInfo article = new ArticleInfo();
        protected string pageTitle =  "会员登陆";

        protected void Page_Load(object sender, EventArgs e)
        {
            ArticleSearchInfo articleSearch = new ArticleSearchInfo();
            articleSearch.ClassID = "|1|";
            articleSearch.IsTop = 1;
            articleSearch.Condition = "Order by [ID] desc";
            List<ArticleInfo> articleList = ArticleBLL.SearchArticleList(articleSearch);
            if (articleList.Count > 0)
            {
                article = articleList[0];
                pageTitle = "系统公告";
            }
        }
    }
}
