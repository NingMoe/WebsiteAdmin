using System;
using XueFu.Common;
using XueFu.Model;
using XueFu.BLL;

namespace XueFu.Website
{
    public partial class Notice : UserBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Master)Master).Title = "会员公告";

            //ArticleSearchInfo articleSearch = new ArticleSearchInfo();
            //articleSearch.ClassID = "|2|";
            //base.BindControl(ArticleBLL.SearchArticleList(base.CurrentPage, base.PageSize, articleSearch, ref base.Count), this.RecordList);
        }
    }
}
