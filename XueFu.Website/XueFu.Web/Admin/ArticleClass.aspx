﻿<%@ Page Language="C#" MasterPageFile="MasterPage.Master" AutoEventWireup="true" CodeBehind="ArticleClass.aspx.cs" Inherits="XueFu.Web.Admin.ArticleClass" %>
<%@ Import Namespace="XueFu.EntLib.MethodExtend" %>
<asp:Content ID="MasterContent" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
<div class="position"><img src="Style/Images/PositionIcon.png"  alt=""/>文章分类列表</div>	
<table class="listTable" cellpadding="0">
    <tr class="listTableHead">
	<td style="width:5%">ID</td>
	<td style="width:55%; text-align:left;text-indent:8px;">分类名称</td>
	<td style="width:10%">是否系统</td>   
	<td style="width:10%">排序</td>   
	<td style="width:20%">管理</td>   
</tr>
<asp:Repeater ID="RecordList" runat="server">
	<ItemTemplate>	     
        	<tr class="listTableMain" onmousemove="changeColor(this,'#FFFDD7')" onmouseout="changeColor(this,'#FFF')">
			    <td style="width:5%"><%# Eval("ID") %></td>
			    <td style="width:55%; text-align:left;text-indent:8px;"><%# Eval("ClassName") %></td>
			    <td style="width:10%"><%# Convert.ToBoolean(Eval("IsSystem")).Display(2)%></td>
			    <td style="width:10%"><%# Eval("OrderID") %></td>
			    <td style="width:20%;">
			        <a href="?Action=Up&ID=<%# Eval("ID") %>"><img src="Style/Images/moveUp.gif" alt="上移" title="上移" /></a> 
			        <a href="?Action=Down&ID=<%# Eval("ID") %>"><img src="Style/Images/moveDown.gif" alt="下移" title="下移" /></a> 
			        <a href="javascript:pop('ArticleClassAdd.aspx?ID=<%# Eval("ID") %>',600,400,'文章分类修改','ArticleClassAdd<%# Eval("ID") %>')"><img src="Style/Images/edit.gif" alt="修改" title="修改" /></a> 
			        <a href='ArticleClass.aspx?Action=Delete&ID=<%# Eval("ID") %>' onclick="return check()"><img src="Style/Images/delete.gif" alt="删除" title="删除" /></a>
			    </td>	        
		    </tr>
        </ItemTemplate>
</asp:Repeater>	
</table>
<div class="action"></div>
        <input type="button"  value=" 添 加 " class="button" onclick="pop('ArticleClassAdd.aspx',600,400,'文章分类添加','ArticleClassAdd')" id="Button1"/>
</asp:Content>
