<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="XueFu.Website.ChangePassword" Title="无标题页" %>
<%@ Import Namespace="XueFu.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
<div class="panel-body">
<form id="Form1" class="form-horizontal changepassword" action="" method="post" autocomplete="off">
    <div class="form-group row" id="block-username">
      <label for="username" class="col-xs-4 control-label text-right">用户名</label>
      <div class="col-xs-8">
        <input type="text" class="form-control" id="username" name="username" value="<%=Cookies.User.GetUserName(false) %>" disabled>
        <p id="error-username">&nbsp;</p>
      </div>
    </div>
    <div class="form-group" id="block-oldpassword">
      <label for="oldpassword" class="col-xs-4 control-label text-right">旧密码</label>
      <div class="col-xs-8">
        <input type="password" class="form-control" id="oldpassword" name="oldpassword" placeholder="正在使用的密码">
        <p id="error-oldpassword">&nbsp;</p>
      </div>
    </div>
    <div class="form-group" id="block-password1">
      <label for="password1" class="col-xs-4 control-label text-right">新密码</label>
      <div class="col-xs-8">
        <input type="password" class="form-control" id="password1" name="password1" placeholder="6-16位字母和数字的组合">
        <p id="error-password1">&nbsp;</p>
      </div>
    </div>
    <div class="form-group" id="block-password2">
      <label for="password2" class="col-xs-4 control-label text-right">确认密码</label>
      <div class="col-xs-8">
        <input type="password" class="form-control" id="password2" name="password2" placeholder="再次输入新密码">
        <p id="error-password2">&nbsp;</p>
      </div>
    </div>
    <input type="hidden" name="Action" id="Action" value="1">
    <button id="changepasswordbutton" type="button" class="btn btn-danger btn-lg btn-block">确定</button>
</form>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootContent" runat="server">
    <script type="text/javascript" src="js/Common.js"></script>
</asp:Content>
