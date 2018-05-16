<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Transfer.aspx.cs" Inherits="XueFu.Website.Transfer" Title="无标题页" %>
<%@ Import Namespace="XueFu.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
<div class="panel-body">
<form id="transferform" class="form-horizontal changepassword" action="" method="post" autocomplete="off">
    <div class="form-group row" id="block-username">
      <label for="username" class="col-xs-4 control-label text-right">转入帐号</label>
      <div class="col-xs-8">
        <input type="text" class="form-control" id="username" name="username" value="" placeholder="输入的帐号名称">
        <p id="error-username">&nbsp;</p>
      </div>
    </div>
    <div class="form-group" id="block-money">
      <label for="money" class="col-xs-4 control-label text-right">转入积分</label>
      <div class="col-xs-8">
        <input type="text" class="form-control" id="money" name="money" placeholder="要转帐的积分">
        <p id="error-money">&nbsp;</p>
      </div>
    </div>
    <input type="hidden" name="Action" id="Action" value="1">
    <input type="hidden" name="MyselfName" id="MyselfName" value="<%=Cookies.User.GetUserName(true) %>">
    <button id="transferbutton" type="button" class="btn btn-danger btn-lg btn-block">转帐</button>
</form>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootContent" runat="server">
    <script type="text/javascript" src="js/Common.js"></script>
</asp:Content>
