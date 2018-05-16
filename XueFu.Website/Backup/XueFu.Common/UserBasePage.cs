using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using XueFu.EntLib;
using System.Web.UI.WebControls;

namespace XueFu.Common
{
    public class UserBasePage : Page
    {
        protected int UserID = 0;
        protected int Count = 0;
        protected int PageSize = 20;
        private string description = string.Empty;
        private string keywords = string.Empty;
        private string title = string.Empty;

        protected void BindControl(CommonPager commonPager)
        {
            this.BindControl(null, null, commonPager);
        }

        protected void BindControl(object dataSource, Repeater repeater)
        {
            this.BindControl(dataSource, repeater, null);
        }

        protected void BindControl(object dataSource, Repeater repeater, CommonPager commonPager)
        {
            if (repeater != null)
            {
                repeater.DataSource = dataSource;
                repeater.DataBind();
            }
            if (commonPager != null)
            {
                commonPager.CurrentPage = this.CurrentPage;
                commonPager.PageSize = this.PageSize;
                commonPager.Count = this.Count;
            }
        }


        private void CheckLogin()
        {
            this.UserID = Cookies.User.GetUserID(true);
            if (this.UserID == 0)
            {
                ResponseHelper.Write("<script language='javascript'>window.parent.location.href='Login.aspx';</script>");
                ResponseHelper.End();
            }
        }

        protected void ClearCache()
        {
            base.Response.Cache.SetNoServerCaching();
            base.Response.Cache.SetNoStore();
            base.Response.Expires = 0;
        }

        protected static string GetAddUpdate()
        {
            string str = "Ìí¼Ó";
            if (RequestHelper.GetQueryString<int>("ID") > 0)
            {
                str = "ÐÞ¸Ä";
            }
            return str;
        }

        protected override void OnInit(EventArgs e)
        {
            this.CheckLogin();
            base.OnInit(e);
        }

        protected int CurrentPage
        {
            get
            {
                int queryString = RequestHelper.GetQueryString<int>("Page");
                if (queryString < 1)
                {
                    queryString = 1;
                }
                return queryString;
            }
        }

        public string Description
        {
            get
            {
                string description = this.description;
                if (description == string.Empty)
                {
                    description = Config.ReadConfigInfo().Description;
                }
                return description;
            }
            set
            {
                this.description = value;
            }
        }

        public string Keywords
        {
            get
            {
                string keywords = this.keywords;
                if (keywords == string.Empty)
                {
                    keywords = Config.ReadConfigInfo().Keywords;
                }
                return keywords;
            }
            set
            {
                this.keywords = value;
            }
        }

        public string Title
        {
            get
            {
                string title = Config.ReadConfigInfo().Title;
                if (this.title != string.Empty)
                {
                    title = this.title + " - " + Config.ReadConfigInfo().Title;
                }
                return title;
            }
            set
            {
                this.title = value;
            }
        }
    }
}
