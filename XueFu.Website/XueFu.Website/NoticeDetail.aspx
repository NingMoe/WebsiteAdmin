<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="NoticeDetail.aspx.cs" Inherits="XueFu.Website.NoticeDetail" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
<div class="container-fluid">
<h3 class="text-center"><%=article.Title %></h3>
<div><%=article.Summary%></div>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootContent" runat="server">
</asp:Content>
