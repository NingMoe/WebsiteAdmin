using System;
using System.Collections.Generic;
using XueFu.Model;

namespace XueFu.IDAL
{
    public interface IArticleClass
    {        
        int AddArticleClass(ArticleClassInfo articleClass);
        void DeleteArticleClass(int id);
        void MoveDownArticleClass(int id);
        void MoveUpArticleClass(int id);
        List<ArticleClassInfo> ReadArticleClassAllList();
        void UpdateArticleClass(ArticleClassInfo articleClass);
    }
}
