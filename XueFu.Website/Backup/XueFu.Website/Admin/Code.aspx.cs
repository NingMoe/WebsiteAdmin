using System;
using System.Web;
using XueFu.EntLib;
using XueFu.Common;

namespace XueFu.Admin
{
    public partial class Code : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckCode.CodeDot = Config.ReadConfigInfo().CodeDot;
            CheckCode.CodeLength = Config.ReadConfigInfo().CodeLength;
            CheckCode.CodeType = (CodeType)Config.ReadConfigInfo().CodeType;
            CheckCode.Key = Config.ReadConfigInfo().SecureKey;
            CheckCode m = new CheckCode();
            m.ProcessRequest(HttpContext.Current);
            this.mm.Text = CheckCode.Key;
        }
    }
}
