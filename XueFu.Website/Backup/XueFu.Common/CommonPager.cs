using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;
using System.Text;
using XueFu.EntLib;

namespace XueFu.Common
{
    [DefaultProperty(""), ToolboxData("<{0}:CommonPager runat=server></{0}:CommonPager>")]
    public class CommonPager : BasePager
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            CommonPagerClass class2 = new CommonPagerClass();
            base.BasePagerClass = class2;
        }

        protected override void Render(HtmlTextWriter output)
        {
            output.Write(base.BasePagerClass.ShowPage());
        }
    }
}
