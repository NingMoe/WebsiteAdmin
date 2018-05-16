<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="TransferRecord.aspx.cs" Inherits="XueFu.Website.TransferRecord" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
<table class="table text-center" id="datalist" data-action="TransferRecord">
    <tr>
        <th class="text-center">转出</th>
        <th class="text-center">转入</th>
        <th class="text-center">金额</th>
        <th class="text-center">日期</th>
    </tr>
    <%--<asp:Repeater ID="RecordList" runat="server">
    <ItemTemplate>
    <tr>
        <td><%# Eval("OutName")%></td>
        <td><%# Eval("InName")%></td>
        <td><%# Eval("Money")%></td>
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
