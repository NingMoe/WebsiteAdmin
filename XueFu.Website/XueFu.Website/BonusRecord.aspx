<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="BonusRecord.aspx.cs" Inherits="XueFu.Website.BonusRecord" Title="无标题页" %>
<%@ Register Assembly="XueFu.Common" Namespace="XueFu.Common" TagPrefix="XueFu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
<table class="table text-center" id="datalist" data-action="BonusRecord">
    <tr>
        <th class="text-center">序号</th>
        <th class="text-center">分红金额</th>
        <th class="text-center">日期</th>
    </tr>
    <%--<asp:Repeater ID="RecordList" runat="server">
    <ItemTemplate>
    <tr>
        <td><%# Container.ItemIndex + 1%></td>
        <td><%# Eval("Money") %></td>
        <td><%# Convert.ToDateTime(Eval("CreateDate")).ToString("d") %></td>
    </tr>
    </ItemTemplate>
    </asp:Repeater>
    <XueFu:CommonPager ID="MyPager" runat="server" />--%>
</table>
    <div id="loadMore" class="load_more" style="display: none;"></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootContent" runat="server">
    <script type="text/javascript" src="js/scrollloading.js"></script>
</asp:Content>
