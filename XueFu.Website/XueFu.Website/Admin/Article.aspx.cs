using System;
using XueFu.EntLib;
using XueFu.Common;
using XueFu.BLL;
using XueFu.Model;
using System.Web.UI.WebControls;

namespace XueFu.Admin
{
    public partial class Article : AdminBasePage
    {
        protected string classID = string.Empty;

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            string intsForm = RequestHelper.GetIntsForm("SelectID");
            if (intsForm != string.Empty)
            {
                ArticleBLL.DeleteArticle(intsForm);
                ScriptHelper.Alert(Language.ReadLanguage("DeleteOK"), RequestHelper.RawUrl);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                foreach (ArticleClassInfo info in ArticleClassBLL.ReadArticleClassNamedList())
                {
                    this.ArticleClassID.Items.Add(new ListItem(info.ClassName, "|" + info.ID + "|"));
                }
                this.ArticleClassID.Items.Insert(0, new ListItem("所有分类", string.Empty));
                this.Title.Text = RequestHelper.GetQueryString<string>("Title");
                this.ArticleClassID.Text = RequestHelper.GetQueryString<string>("ClassID");
                this.classID = RequestHelper.GetQueryString<string>("ClassID");
                if (this.classID != string.Empty)
                {
                    this.classID = ArticleClassBLL.ReadArticleClassFullFatherID(Convert.ToInt32(this.classID.Replace("|", string.Empty)));
                    this.classID = this.classID.Substring(1, this.classID.Length - 2);
                    if (this.classID.IndexOf('|') > -1)
                    {
                        this.classID = this.classID.Substring(0, this.classID.IndexOf('|'));
                    }
                }
                ArticleSearchInfo article = new ArticleSearchInfo();
                article.Title = RequestHelper.GetQueryString<string>("Title");
                article.ClassID = RequestHelper.GetQueryString<string>("ClassID");
                article.IsTop = RequestHelper.GetQueryString<int>("IsTop");
                base.BindControl(ArticleBLL.SearchArticleList(base.CurrentPage, base.PageSize, article, ref this.Count), this.RecordList, this.MyPager);
            }
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            ResponseHelper.Redirect(("Article.aspx?Action=search&" + "Title=" + this.Title.Text + "&") + "ClassID=" + this.ArticleClassID.Text + "&");
        }
    }
}
