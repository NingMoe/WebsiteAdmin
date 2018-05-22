using System;
using XueFu.BLL;
using XueFu.Common;
using XueFu.EntLib;

namespace XueFu.Web.Admin
{
    public partial class ArticleClass : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //base.CheckAdminPower("ReadArticleClass", PowerCheckType.Single);
            string queryString = RequestHelper.GetQueryString<string>("Action");
            int id = RequestHelper.GetQueryString<int>("ID");
            if ((queryString != string.Empty) && (id != -2147483648))
            {
                string str2 = queryString;
                if (str2 != null)
                {
                    if (!(str2 == "Up"))
                    {
                        if (str2 == "Down")
                        {
                            //base.CheckAdminPower("UpdateArticleClass", PowerCheckType.Single);
                            ArticleClassBLL.MoveDownArticleClass(id);
                            AdminLogBLL.AddAdminLog(Language.ReadLanguage("MoveRecord"), Language.ReadLanguage("ArticleClass"), id);
                        }
                        else if (str2 == "Delete")
                        {
                            //base.CheckAdminPower("DeleteArticleClass", PowerCheckType.Single);
                            if (ArticleClassBLL.ReadArticleClassCache(id).IsSystem == 0)
                            {
                                ArticleClassBLL.DeleteArticleClass(id);
                                AdminLogBLL.AddAdminLog(Language.ReadLanguage("DeleteRecord"), Language.ReadLanguage("ArticleClass"), id);
                            }
                            else
                            {
                                ScriptHelper.Alert(Language.ReadLanguage("CannotDeleteSystemClass"));
                            }
                        }
                    }
                    else
                    {
                        //base.CheckAdminPower("UpdateArticleClass", PowerCheckType.Single);
                        ArticleClassBLL.MoveUpArticleClass(id);
                        AdminLogBLL.AddAdminLog(Language.ReadLanguage("MoveRecord"), Language.ReadLanguage("ArticleClass"), id);
                    }
                }
            }
            base.BindControl(ArticleClassBLL.ReadArticleClassNamedList(), this.RecordList);
        }
    }
}
