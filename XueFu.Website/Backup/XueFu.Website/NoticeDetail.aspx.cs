using System;
using XueFu.EntLib;
using XueFu.BLL;
using XueFu.Common;
using XueFu.Model;

namespace XueFu.Website
{
    public partial class NoticeDetail : UserBasePage
    {
        protected ArticleInfo article = new ArticleInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Master)Master).Title = "��Ա����";
            int id = RequestHelper.GetQueryString<int>("ID");

            article = ArticleBLL.ReadArticle(id);
        }
    }
}