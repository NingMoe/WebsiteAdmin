<%@ Page Language="C#" MasterPageFile="MasterPage.Master" AutoEventWireup="true" CodeBehind="ConfigAdd.aspx.cs" Inherits="XueFu.Admin.ConfigAdd" %>
<asp:Content ID="MasterContent" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
<div class="position"><img src="/Admin/Images/PositionIcon.png"  alt=""/>��������</div>
<div  class="listBlock">
    <ul>
        <li class="listOn" id="TitleDefault" onclick="switchBlock('Default')">��������</li>
    </ul>	
</div>
<div class="line"></div>
<div class="add"  id="ContentDefault">
	<ul>
		<li class="left">�ܻ��֣�</li>
		<li class="right"><XueFu:TextBox CssClass="input" Width="100px" ID="TotalScore" runat="server" CanBeNull="����"  RequiredFieldType="����У��"/></li>		   
	</ul>
	<ul>
		<li class="left">ͬһ���֤�������</li>
		<li class="right"><XueFu:TextBox CssClass="input" Width="100px" ID="MaxUserNum" runat="server" CanBeNull="����"  RequiredFieldType="����У��"/></li>
		<li class="left">ÿ����Ա�۳����֣�</li>
		<li class="right"><XueFu:TextBox CssClass="input" Width="100px" ID="PerUserScore" runat="server" CanBeNull="����"  RequiredFieldType="����У��"/></li>
	</ul>
	<ul>
		<li class="left">ת�ʻ�����</li>
		<li class="right"><XueFu:TextBox CssClass="input" Width="100px" ID="TransferBase" runat="server" CanBeNull="����"  RequiredFieldType="����У��"/></li>
		<li class="left">ת�ʱ�����</li>
		<li class="right"><XueFu:TextBox CssClass="input" Width="100px" ID="TransferMultiple" runat="server" CanBeNull="����"  RequiredFieldType="����У��" /></li>
	</ul>
	<ul>
		<li class="left">�Ƽ�����</li>
		<li class="right"><XueFu:TextBox CssClass="input" Width="100px" ID="IntroduceMoney" runat="server" CanBeNull="����" RequiredFieldType="����У��" /></li>
		<li class="left">��������</li>
		<li class="right"><XueFu:TextBox CssClass="input" Width="100px" ID="ReportMoney" runat="server" CanBeNull="����" RequiredFieldType="����У��" /></li>
	</ul>
	<ul>
	    <li class="left">�ֺ����ޣ�</li>
		<li class="right"><XueFu:TextBox CssClass="input" Width="100px" ID="MaxBonus" runat="server" CanBeNull="����" RequiredFieldType="����У��" /></li>
		<li class="left">�Ŷӽ�������</li>
		<li class="right"><XueFu:TextBox CssClass="input" Width="100px" ID="TeamPercent" runat="server" CanBeNull="����" RequiredFieldType="�Զ�����֤���ʽ" ValidationExpression="^(([1-9]?\d{1})|([1-9]?\d{1}\.[0-9]{1,2}))$" />%</li>
	</ul>
</div>
<div class="action">
    <asp:Button CssClass="button" ID="SubmitButton" Text=" ȷ �� " runat="server" OnClick="SubmitButton_Click" />
</div>
</asp:Content>
