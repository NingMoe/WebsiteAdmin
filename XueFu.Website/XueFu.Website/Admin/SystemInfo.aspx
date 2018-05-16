<%@ Page Language="C#" MasterPageFile="MasterPage.Master" AutoEventWireup="true" CodeBehind="SystemInfo.aspx.cs" Inherits="XueFu.Admin.SystemInfo" %>
<%@ Import Namespace="XueFu.Common" %>
<asp:Content ID="MasterContent" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
<style type="text/css">
.add ul .right{
	
}
.add ul .right span{
	margin-left:22px;
	line-height:22px;
}
</style>		
<div class="position"><img src="images/PositionIcon.png"  alt=""/>产品说明</div>
<div class="add">
	<ul>
	    <li class="left">系统名称：</li>
	    <li class="right"><%=Global.ProductName%></li>
	</ul>
	<ul>
	    <li class="left">系统版本：</li>
	    <li class="right"><%=Global.Version%></li>
	</ul>
	<ul>
	    <li class="left">产品介绍：</li>
	    <li class="right" style="width:600px;"><%=Global.Description%></li>
	</ul>
	<ul>
	    <li class="left">产品版权：</li>
	    <li class="right"><%=Global.CopyRight%></li>
	</ul>	
	<ul>
	    <li class="left">第三方组件：</li>
	    <li class="right">lhgcore 框架组件</li>
	</ul>
</div>
</asp:Content>
