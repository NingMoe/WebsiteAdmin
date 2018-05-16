<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MyTeam.aspx.cs" Inherits="XueFu.Website.MyTeam" Title="无标题页" %>
<%@ MasterType  VirtualPath="~/Master.Master" %>
<%@ Import Namespace="XueFu.Model" %>
<%@ Import Namespace="XueFu.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
<div class="strt-wrap" id="strtWrap">
    <div class="strt-part">
        <span class="strt-name current"><%=myself.RealName%></span>
        <%=createLevevHtml(myself.ID, Config.ReadConfigInfo().LevelNum)%>
    </div>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootContent" runat="server">
</asp:Content>
