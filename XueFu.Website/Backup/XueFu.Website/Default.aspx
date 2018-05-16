<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="XueFu.Website.Default" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
<div class="container-fluid">
	<div class="row">
		<div class="col-xs-5 moneyblock">
		    总积分 <h3><asp:Literal ID="TotalMoney" runat="server"></asp:Literal></h3>
		</div>
		<div class="col-xs-5"></div>
	</div>
	<div class="row">
		<div class="col-xs-5 moneyblock">
		    分红奖 <h2><asp:Literal ID="BonusMoney" runat="server"></asp:Literal></h2>
		</div>
		<div class="col-xs-5 moneyblock">
		    推荐奖 <h2><asp:Literal ID="IntroduceMoney" runat="server"></asp:Literal></h2>
		</div>
	</div>
	<div class="row">
		<div class="col-xs-5 moneyblock">
		    团队奖 <h2><asp:Literal ID="TeamMoney" runat="server">0</asp:Literal></h2>
		</div>
		<div class="col-xs-5 moneyblock">
		    报单奖 <h2><asp:Literal ID="ReportMoney" runat="server"></asp:Literal></h2>
        </div>
	</div>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootContent" runat="server">
</asp:Content>
