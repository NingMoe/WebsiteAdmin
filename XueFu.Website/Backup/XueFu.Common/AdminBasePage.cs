using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using XueFu.EntLib;

namespace XueFu.Common
{
    public class AdminBasePage : Page
    {
        protected int AdminID = 0;
        protected int Count = 0;
        protected string IDPrefix = Config.ReadConfigInfo().IDPrefix;
        protected string NamePrefix = Config.ReadConfigInfo().NamePrefix;
        protected int PageSize = 20;

        protected static void Alert(string alertMessage, string url)
        {
            if (Config.ReadConfigInfo().SaveAutoClosePop == 1)
            {
                string str = ("<script language='javascript'>window.alert('" + alertMessage + "');") + "try{ var DG = frameElement.lhgDG;DG.cancel();";
                if (Config.ReadConfigInfo().PopCloseRefresh == 1)
                {
                    str = str + "DG.curWin.location.reload();";
                }
                ResponseHelper.Write(str + "}catch (e) { }</script>");
                ResponseHelper.End();
            }
            else
            {
                ScriptHelper.Alert(alertMessage, url);
            }
        }

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
                commonPager.ListType = false;
            }
        }

        private void CheckAdminLogin()
        {
            if (Cookies.Admin.GetAdminID(true) == 0)
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
            this.CheckAdminLogin();
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
    }
}
