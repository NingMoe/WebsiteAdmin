using System;
using XueFu.EntLib;
using XueFu.Common;
using XueFu.Model;
using XueFu.BLL;
using System.Web.UI.WebControls;

namespace XueFu.Web.Admin
{
    public partial class ArticleAdd : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                foreach (ArticleClassInfo info in ArticleClassBLL.ReadArticleClassNamedList())
                {
                    this.ClassID.Items.Add(new ListItem(info.ClassName, info.ID.ToString()));
                }
                int queryString = RequestHelper.GetQueryString<int>("ID");
                if (queryString != -2147483648)
                {
                    ArticleInfo info2 = ArticleBLL.ReadArticle(queryString);
                    this.Title.Text = info2.Title;
                    string classID = info2.ClassID;
                    if (classID != string.Empty)
                    {
                        classID = classID.Substring(1, classID.Length - 2);
                        if (classID.IndexOf('|') > -1)
                        {
                            classID = classID.Substring(classID.LastIndexOf('|') + 1);
                        }
                    }
                    this.ClassID.Text = classID;
                    this.Summary.Text = info2.Summary;
                    this.IsTop.Text = info2.IsTop.ToString();
                }
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            ArticleInfo article = new ArticleInfo();
            article.ID = RequestHelper.GetQueryString<int>("ID");
            article.Title = this.Title.Text;
            article.ClassID = ArticleClassBLL.ReadArticleClassFullFatherID(Convert.ToInt32(this.ClassID.Text));
            article.Summary = this.Summary.Text;
            article.IsTop = int.Parse(this.IsTop.Text);
            article.Date = RequestHelper.DateNow;
            string alertMessage = Language.ReadLanguage("AddOK");
            if (article.ID == -2147483648)
            {
                int id = ArticleBLL.AddArticle(article);
            }
            else
            {
                ArticleBLL.UpdateArticle(article);
                alertMessage = Language.ReadLanguage("UpdateOK");
            }
            AdminBasePage.Alert(alertMessage, RequestHelper.RawUrl);
        }
    }
}
