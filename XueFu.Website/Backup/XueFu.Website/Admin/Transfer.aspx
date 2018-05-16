<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage.Master" AutoEventWireup="true" CodeBehind="Transfer.aspx.cs" Inherits="XueFu.Website.Admin.Transfer" Title="无标题页" %>
<asp:Content ID="MasterContent" ContentPlaceHolderID="ContentPlaceHolder" runat="server"><div class="position"><img src="/Admin/images/PositionIcon.png"  alt=""/>转帐记录</div><ul class="search">    <li>        转帐类型：
        <asp:DropDownList ID="Type" runat="server">
            <asp:ListItem Selected="True" Value="0">转入和转出</asp:ListItem>
            <asp:ListItem Value="1">转入</asp:ListItem>
            <asp:ListItem Value="2">转出</asp:ListItem>
        </asp:DropDownList>		        用户名：        <XueFu:TextBox CssClass="input" ID="Name" runat="server"  Width="200px" />		<asp:Button CssClass="button" ID="SearchButton" Text=" 搜 索 " runat="server"  OnClick="SearchButton_Click" />   </li></ul><table class="listTable" cellpadding="0">    <tr class="listTableHead">	    <td style="width:5%">ID</td>	    <td style="width:20%;text-indent:8px;">转出用户名</td>	    <td style="width:20%">转入用户名</td>	    <td style="width:20%">转帐金额</td>       	    <td>日期</td>        </tr><asp:Repeater ID="RecordList" runat="server">	<ItemTemplate>	             <tr class="listTableMain" onmousemove="changeColor(this,'#FFFDD7')" onmouseout="changeColor(this,'#FFF')">			<td><%# Eval("ID") %></td>			<td><%# Eval("OutName")%></td>
            <td><%# Eval("InName")%></td>
            <td><%# Eval("Money")%></td>
            <td><%# Convert.ToDateTime(Eval("CreateDate")).ToString("d") %></td>	        		</tr>        </ItemTemplate></asp:Repeater></table><div class="listPage"><XueFu:CommonPager ID="MyPager" runat="server" /></div>
</asp:Content>
