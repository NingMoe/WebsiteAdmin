using System;
using XueFu.EntLib;
using XueFu.Common;
using XueFu.Model;

namespace XueFu.Web.Admin
{
    public partial class ConfigAdd : AdminBasePage
    {
        public ConfigAdd()
        {
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.PerUserScore.Text = Config.ReadConfigInfo().PerUserScore.ToString();
                this.MaxUserNum.Text = Config.ReadConfigInfo().MaxUserNum.ToString();
                this.TotalScore.Text = Config.ReadConfigInfo().TotalScore.ToString();
                this.TransferBase.Text = Config.ReadConfigInfo().TransferBase.ToString();
                this.TransferMultiple.Text = Config.ReadConfigInfo().TransferMultiple.ToString();
                this.IntroduceMoney.Text = Config.ReadConfigInfo().IntroduceMoney.ToString();
                this.ReportMoney.Text = Config.ReadConfigInfo().ReportMoney.ToString();
                this.TeamPercent.Text = Config.ReadConfigInfo().TeamPercent.ToString();
                this.MaxBonus.Text = Config.ReadConfigInfo().MaxBonus.ToString();
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            ConfigInfo config = Config.ReadConfigInfo();
            config.PerUserScore = Convert.ToInt32(this.PerUserScore.Text);
            config.MaxUserNum = Convert.ToInt32(this.MaxUserNum.Text);
            config.TotalScore = Convert.ToInt32(this.TotalScore.Text);
            config.TransferBase = Convert.ToInt32(this.TransferBase.Text);
            config.TransferMultiple = Convert.ToInt32(this.TransferMultiple.Text);
            config.IntroduceMoney = Convert.ToInt32(this.IntroduceMoney.Text);
            config.ReportMoney = Convert.ToInt32(this.ReportMoney.Text);
            config.TeamPercent = Convert.ToDecimal(this.TeamPercent.Text);
            config.MaxBonus = Convert.ToInt32(this.MaxBonus.Text);
            
            Config.UpdateConfigInfo(config);
            ScriptHelper.Alert(Language.ReadLanguage("UpdateOK"), RequestHelper.RawUrl);
        }
    }
}
