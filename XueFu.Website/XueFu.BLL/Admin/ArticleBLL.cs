using System;
using System.Collections.Generic;
using XueFu.EntLib;
using XueFu.IDAL;
using XueFu.Model;
using XueFu.Common;

namespace XueFu.BLL
{
    public sealed class ArticleBLL
    {

        private static readonly string cacheKey = CacheKey.ReadCacheKey("BottomList");
        private static readonly IArticle dal = FactoryHelper.Instance<IArticle>(Global.DataProvider, "ArticleDAL");


        public static int AddArticle(ArticleInfo article)
        {
            article.ID = dal.AddArticle(article);
            if (article.ClassID.IndexOf("|" + 2 + "|") > -1)
            {
                CacheHelper.Remove(cacheKey);
            }
            return article.ID;
        }

        public static void DeleteArticle(string strID)
        {
            dal.DeleteArticle(strID);
            CacheHelper.Remove(cacheKey);
        }

        public static ArticleInfo ReadArticle(int id)
        {
            return dal.ReadArticle(id);
        }

        public static List<ArticleInfo> ReadBottomList()
        {
            if (CacheHelper.Read(cacheKey) == null)
            {
                ArticleSearchInfo articleSearch = new ArticleSearchInfo();
                articleSearch.ClassID = "|" + 2 + "|";
                CacheHelper.Write(cacheKey, dal.SearchArticleList(articleSearch));
            }
            return (List<ArticleInfo>)CacheHelper.Read(cacheKey);
        }

        public static List<ArticleInfo> SearchArticleList(ArticleSearchInfo articleSearch)
        {
            return dal.SearchArticleList(articleSearch);
        }

        public static List<ArticleInfo> SearchArticleList(int currentPage, int pageSize, ArticleSearchInfo article, ref int count)
        {
            return dal.SearchArticleList(currentPage, pageSize, article, ref count);
        }

        public static void UpdateArticle(ArticleInfo article)
        {
            dal.UpdateArticle(article);
            CacheHelper.Remove(cacheKey);
        }
    }
}
