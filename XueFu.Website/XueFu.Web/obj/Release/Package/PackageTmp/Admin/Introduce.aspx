﻿<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage.Master" AutoEventWireup="true" CodeBehind="Introduce.aspx.cs" Inherits="XueFu.Web.Admin.Introduce" Title="无标题页" %><%@ Import Namespace="XueFu.BLL" %><asp:Content ID="MasterContent" ContentPlaceHolderID="ContentPlaceHolder" runat="server"><div class="position"><img src="/Admin/images/PositionIcon.png"  alt=""/>推荐/报单记录</div><ul class="search">    <li>        报单人：        <XueFu:TextBox CssClass="input" ID="Operator" runat="server"  Width="200px" />        推荐人：        <XueFu:TextBox CssClass="input" ID="Introducer" runat="server"  Width="200px" />        用户名：        <XueFu:TextBox CssClass="input" ID="Name" runat="server"  Width="200px" />		<asp:Button CssClass="button" ID="SearchButton" Text=" 搜 索 " runat="server"  OnClick="SearchButton_Click" />   </li></ul><table class="listTable" cellpadding="0">    <tr class="listTableHead">	    <td style="width:5%">ID</td>	    <td style="width:20%;text-indent:8px;">推荐人</td>	    <td style="width:20%">推荐的用户名</td>	    <td style="width:20%">报单人</td>	    <td>日期</td>        </tr><asp:Repeater ID="RecordList" runat="server">	<ItemTemplate>	             <tr class="listTableMain" onmousemove="changeColor(this,'#FFFDD7')" onmouseout="changeColor(this,'#FFF')">			<td><%# Eval("ID") %></td>			<td><%# UserBLL.ReadUser(int.Parse(Eval("IntroducerID").ToString())).Name%></td>            <td><%# Eval("Name")%></td>            <td><%# UserBLL.ReadUser(int.Parse(Eval("OperatorID").ToString())).Name%></td>            <td><%# Convert.ToDateTime(Eval("CreateDate")).ToString("d") %></td>	        		</tr>        </ItemTemplate></asp:Repeater></table><div class="listPage"><XueFu:CommonPager ID="MyPager" runat="server" /></div></asp:Content>