using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XueFu.BLL;
using XueFu.Model;

namespace XueFu.Web.Controllers
{
    public class APIController : Controller
    {
        [HttpGet]
        public ActionResult GetArticleList(int pageSize = 20)
        {
            int count = 0;
            ArticleSearchInfo articleSearch = new ArticleSearchInfo();
            articleSearch.ClassID = "|1|";
            List<ArticleInfo> list = ArticleBLL.SearchArticleList(1, pageSize, articleSearch, ref count);
            return Json(list.Select(m => new
            {
                Title = m.Title,
                ID = m.ID,
                CID = m.ClassID,
                Url = m.Url,
                Content = m.Content
            }),JsonRequestBehavior.AllowGet);
        }
    }
}