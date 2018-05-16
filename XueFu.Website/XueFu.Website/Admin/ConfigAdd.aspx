<%@ Page Language="C#" MasterPageFile="MasterPage.Master" AutoEventWireup="true" CodeBehind="ConfigAdd.aspx.cs" Inherits="XueFu.Admin.ConfigAdd" %>
<asp:Content ID="MasterContent" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
<div class="position"><img src="/Admin/Images/PositionIcon.png"  alt=""/>基础配置</div>
<div  class="listBlock">
    <ul>
        <li class="listOn" id="TitleDefault" onclick="switchBlock('Default')">基本设置</li>
    </ul>	
</div>
<div class="line"></div>
<div class="add"  id="ContentDefault">
	<ul>
		<li class="left">总积分：</li>
		<li class="right"><XueFu:TextBox CssClass="input" Width="100px" ID="TotalScore" runat="server" CanBeNull="必填"  RequiredFieldType="数据校验"/></li>		   
	</ul>
	<ul>
		<li class="left">同一身份证最大数：</li>
		<li class="right"><XueFu:TextBox CssClass="input" Width="100px" ID="MaxUserNum" runat="server" CanBeNull="必填"  RequiredFieldType="数据校验"/></li>
		<li class="left">每个会员扣除积分：</li>
		<li class="right"><XueFu:TextBox CssClass="input" Width="100px" ID="PerUserScore" runat="server" CanBeNull="必填"  RequiredFieldType="数据校验"/></li>
	</ul>
	<ul>
		<li class="left">转帐基数：</li>
		<li class="right"><XueFu:TextBox CssClass="input" Width="100px" ID="TransferBase" runat="server" CanBeNull="必填"  RequiredFieldType="数据校验"/></li>
		<li class="left">转帐倍数：</li>
		<li class="right"><XueFu:TextBox CssClass="input" Width="100px" ID="TransferMultiple" runat="server" CanBeNull="必填"  RequiredFieldType="数据校验" /></li>
	</ul>
	<ul>
		<li class="left">推荐奖：</li>
		<li class="right"><XueFu:TextBox CssClass="input" Width="100px" ID="IntroduceMoney" runat="server" CanBeNull="必填" RequiredFieldType="数据校验" /></li>
		<li class="left">报单奖：</li>
		<li class="right"><XueFu:TextBox CssClass="input" Width="100px" ID="ReportMoney" runat="server" CanBeNull="必填" RequiredFieldType="数据校验" /></li>
	</ul>
	<ul>
	    <li class="left">分红上限：</li>
		<li class="right"><XueFu:TextBox CssClass="input" Width="100px" ID="MaxBonus" runat="server" CanBeNull="必填" RequiredFieldType="数据校验" /></li>
		<li class="left">团队奖比例：</li>
		<li class="right"><XueFu:TextBox CssClass="input" Width="100px" ID="TeamPercent" runat="server" CanBeNull="必填" RequiredFieldType="自定义验证表达式" ValidationExpression="^(([1-9]?\d{1})|([1-9]?\d{1}\.[0-9]{1,2}))$" />%</li>
	</ul>
</div>
<div class="action">
    <asp:Button CssClass="button" ID="SubmitButton" Text=" 确 定 " runat="server" OnClick="SubmitButton_Click" />
</div>
</asp:Content>
