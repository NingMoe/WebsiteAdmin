<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Record.aspx.cs" Inherits="XueFu.Website.Record" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
<%if (action == "Bonus")
  {%>
<table class="table text-center" id="datalist" data-action="BonusRecord">
    <tr>
        <th class="text-center">序号</th>
        <th class="text-center">分红金额</th>
        <th class="text-center">日期</th>
    </tr>
</table>
<%} %>
<%if (action == "AddUser")
  {%>
<table class="table text-center" id="datalist" data-action="AddUserRecord">
    <tr>
        <th class="text-center">序号</th>
        <th class="text-center">推荐人</th>
        <th class="text-center">用户名</th>
        <th class="text-center">日期</th>
    </tr>
</table>
<%} %>
<%if (action == "Introduce")
  {%>
<table class="table text-center" id="datalist" data-action="IntroduceRecord">
    <tr>
        <th class="text-center">序号</th>
        <th class="text-center">用户名</th>
        <th class="text-center">姓名</th>
        <th class="text-center">日期</th>
    </tr>
</table>
<%} %>
<%if (action == "Transfer")
  {%>
<table class="table text-center" id="datalist" data-action="TransferRecord">
    <tr>
        <th class="text-center">转出</th>
        <th class="text-center">转入</th>
        <th class="text-center">金额</th>
        <th class="text-center">日期</th>
    </tr>
</table>
<%} %>
<%if (action == "Notice")
  {%>
<table class="table text-center" id="datalist" data-action="Notice">
    <tr>
        <th class="text-center">标题</th>
        <th class="text-center">日期</th>
    </tr>
</table>
<%} %>
    <div id="loadMore" class="load_more" style="display: none;"></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootContent" runat="server">
    <script type="text/javascript" src="js/scrollloading.js"></script>
</asp:Content>
