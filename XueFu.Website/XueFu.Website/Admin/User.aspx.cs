using System;
using XueFu.EntLib;
using XueFu.Common;
using XueFu.BLL;
using XueFu.Model;
using System.Web.UI.WebControls;

namespace XueFu.Admin
{
    public partial class User : AdminBasePage
    {
        protected int status = 0;
        protected int companyID = RequestHelper.GetQueryString<int>("CompanyID");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.Sex.DataSource = EnumHelper.ReadEnumList<SexType>();
                this.Sex.DataValueField = "Value";
                this.Sex.DataTextField = "ChineseName";
                this.Sex.DataBind();
                this.Sex.Items.Insert(0, new ListItem("Ыљга", string.Empty));
                this.status = RequestHelper.GetQueryString<int>("Status");
                UserSearchInfo userSearch = new UserSearchInfo();
                userSearch.RealNameLike = RequestHelper.GetQueryString<string>("RealName");
                userSearch.Name = RequestHelper.GetQueryString<string>("UserName");
                userSearch.State = RequestHelper.GetQueryString<int>("Status");
                userSearch.Sex = RequestHelper.GetQueryString<int>("Sex");
                string startRegisterDate = RequestHelper.GetQueryString<string>("StartRegisterDate");
                string endRegisterDate = RequestHelper.GetQueryString<string>("EndRegisterDate");
                if (!string.IsNullOrEmpty(startRegisterDate))
                    userSearch.StartRegisterDate = RequestHelper.GetQueryString<DateTime>("StartRegisterDate");
                if (!string.IsNullOrEmpty(endRegisterDate))
                    userSearch.EndRegisterDate = RequestHelper.GetQueryString<DateTime>("EndRegisterDate").AddDays(1);
                this.UserName.Text = userSearch.Name;
                this.RealName.Text = userSearch.RealNameEqual;
                this.Sex.SelectedValue = userSearch.Sex.ToString();
                this.StartRegisterDate.Text = RequestHelper.GetQueryString<string>("StartRegisterDate");
                this.EndRegisterDate.Text = RequestHelper.GetQueryString<string>("EndRegisterDate");
                base.BindControl(UserBLL.ReadUserList(userSearch, base.CurrentPage, base.PageSize, ref this.Count), this.RecordList, this.MyPager);
            }
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            ResponseHelper.Redirect("User.aspx?Action=search&UserName=" + this.UserName.Text + "&RealName=" + this.RealName.Text + "&Sex=" + this.Sex.Text + "&StartRegisterDate=" + this.StartRegisterDate.Text + "&EndRegisterDate=" + this.EndRegisterDate.Text + "&Status=" + RequestHelper.GetQueryString<string>("Status")); //
        }
    }
}
