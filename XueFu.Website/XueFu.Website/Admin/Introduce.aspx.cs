using System;
using XueFu.Common;
using XueFu.Model;
using XueFu.EntLib;
using XueFu.BLL;

namespace XueFu.Website.Admin
{
    public partial class Introduce : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string operatorName = StringHelper.SearchSafe(RequestHelper.GetQueryString<string>("Operator"));
                string introducer = StringHelper.SearchSafe(RequestHelper.GetQueryString<string>("Introducer"));
                string name = StringHelper.SearchSafe(RequestHelper.GetQueryString<string>("Name"));
                this.Operator.Text = operatorName;
                this.Introducer.Text = introducer;
                this.Name.Text = name;
                UserSearchInfo userSearch = new UserSearchInfo();
                if (!string.IsNullOrEmpty(operatorName))
                    userSearch.OperatorID = UserBLL.ReadUser(operatorName).ID;
                if (!string.IsNullOrEmpty(introducer))
                    userSearch.IntroducerID = UserBLL.ReadUser(introducer).ID;
                userSearch.Name = name;
                userSearch.Condition = "([IntroducerID] > 0 And [OperatorID] > 0)";
                base.BindControl(UserBLL.ReadUserList(userSearch, base.CurrentPage, base.PageSize, ref base.Count), RecordList);
            }
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            ResponseHelper.Redirect("Introduce.aspx?Action=search&" + "Operator=" + this.Operator.Text + "&Introducer=" + this.Introducer.Text+ "&Name=" + this.Name.Text);
        }
    }
}
