using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XueFu.BLL;
using XueFu.Model;

namespace XueFu.Web.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        [HttpGet]
        public ActionResult Show(int id)
        {
            ArticleInfo article = ArticleBLL.ReadArticle(id);
            return View(article);
        }
    }
}