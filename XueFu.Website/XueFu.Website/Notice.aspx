<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Notice.aspx.cs" Inherits="XueFu.Website.Notice" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
<table class="table text-center" id="datalist" data-action="Notice">
    <tr>
        <th class="text-center">标题</th>
        <th class="text-center">日期</th>
    </tr>
    <%--<asp:Repeater ID="RecordList" runat="server">
    <ItemTemplate>
    <tr>
        <td class="text-left"><a href="NoticeDetail.aspx?ID=<%# Eval("ID") %>"><%# Eval("Title")%></a></td>
        <td><%# Convert.ToDateTime(Eval("Date")).ToString("d") %></td>
    </tr>
    </ItemTemplate>
    </asp:Repeater>--%>
</table>
    <div id="loadMore" class="load_more" style="display: none;"></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootContent" runat="server">
    <script type="text/javascript" src="js/scrollloading.js"></script>
</asp:Content>
