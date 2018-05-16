<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AddUserRecord.aspx.cs" Inherits="XueFu.Website.AddUserRecord" Title="无标题页" %>
<%@ Import Namespace="XueFu.BLL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
<table class="table text-center" id="datalist" data-action="AddUserRecord">
    <tr>
        <th class="text-center">序号</th>
        <th class="text-center">推荐人</th>
        <th class="text-center">用户名</th>
        <th class="text-center">日期</th>
    </tr>
    <%--<asp:Repeater ID="RecordList" runat="server">
    <ItemTemplate>
    <tr>
        <td><%# Container.ItemIndex + 1%></td>
        <td><%# UserBLL.ReadUser(int.Parse(Eval("OperatorID").ToString())).Name%></td>
        <td><%# Eval("Name")%></td>
        <td><%# Convert.ToDateTime(Eval("CreateDate")).ToString("d") %></td>
    </tr>
    </ItemTemplate>
    </asp:Repeater>--%>
</table>
    <div id="loadMore" class="load_more" style="display: none;"></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootContent" runat="server">
    <script type="text/javascript" src="js/scrollloading.js"></script>
</asp:Content>
