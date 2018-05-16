<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="UserAdd.aspx.cs" Inherits="XueFu.Website.UserAdd" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <div class="panel-body">
        <form id="Form1" class="form-horizontal userinfo" action="" method="post" autocomplete="off">
        <%if(action == "Add") {%>
            <div class="form-group row" id="block-introducer">
                <label for="introducer" class="col-xs-3 control-label text-right">推荐人</label>
                <div class="col-xs-9">
                    <input type="text" class="form-control" id="introducer" name="introducer" placeholder="推荐人用户名">
                    <p id="error-introducer">&nbsp;</p>
                </div>
            </div>
            <div class="form-group" id="block-username">
                <label for="username" class="col-xs-3 control-label text-right">用户名</label>
                <div class="col-xs-9">
                    <input type="text" class="form-control" id="username" name="username" value="" placeholder="5-16位[字符、数字、_.@]">
                    <p id="error-username">&nbsp;</p>
                </div>
            </div>
            <div class="form-group" id="block-password">
                <label for="password" class="col-xs-3 control-label text-right">密码</label>
                <div class="col-xs-9">
                    <input type="password" class="form-control" id="password" name="password" placeholder="字母和数字的组合">
                    <p id="error-password">&nbsp;</p>
                </div>
            </div>
        <%} else {%>
            <div class="form-group" id="block-username">
                <label for="username" class="col-xs-3 control-label text-right">用户名</label>
                <div class="col-xs-9">
                    <input type="text" class="form-control" id="username" name="username" value="<%=user.Name %>" placeholder="5-16位[字符、数字、_.@]" disabled>
                    <p id="error-username">&nbsp;</p>
                </div>
            </div>
            <div class="form-group" id="block-realname">
                <label for="realname" class="col-xs-3 control-label text-right">姓名</label>
                <div class="col-xs-9">
                    <input type="text" class="form-control" id="realname" name="realname" value="<%=user.RealName %>" placeholder="真实姓名">
                    <p id="error-realname">&nbsp;</p>
                </div>
            </div>
            <div class="form-group" id="block-sex">
                <label for="sex" class="col-xs-3 control-label text-right">性别</label>
                <div class="col-xs-9">
                    <label class="checkbox-inline">
                        <input type="checkbox" name="sex" id="sex1" value="1" checked> 男
                    </label>
                    <label class="checkbox-inline">
                        <input type="checkbox" name="sex" id="sex2" value="2"> 女
                    </label>
                </div>
            </div>
            <div class="form-group" id="block-idcard">
                <label for="idcard" class="col-xs-3 control-label text-right">身份证</label>
                <div class="col-xs-9">
                    <input type="text" class="form-control" id="idcard" name="idcard" value="<%=user.IDCard %>" placeholder="身份证号码"<%if(!string.IsNullOrEmpty(user.IDCard)) {%> disabled<%} %>>
                    <p id="error-idcard">&nbsp;</p>
                </div>
            </div>
            <div class="form-group" id="block-address">
                <label for="address" class="col-xs-3 control-label text-right">地址</label>
                <div class="col-xs-9">
                    <input type="text" class="form-control" id="address" name="address" value="<%=user.Address %>" placeholder="身份证地址">
                    <p id="error-address">&nbsp;</p>
                </div>
            </div>
            <div class="form-group" id="block-wechat">
                <label for="wechat" class="col-xs-3 control-label text-right">微信号</label>
                <div class="col-xs-9">
                    <input type="text" class="form-control" id="wechat" name="wechat" value="<%=user.WeChat %>" placeholder="微信号">
                    <p id="error-wechat">&nbsp;</p>
                </div>
            </div>
        <%}%>
            <input type="hidden" name="Action" id="Action" value="<%=action %>">
            <input type="hidden" name="CanReport" id="CanReport" value="<%=canReport %>">
            <button id="userbutton" type="button" class="btn btn-danger btn-lg btn-block">添加</button>
        </form>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FootContent" runat="server">
    <script type="text/javascript" src="js/Common.js"></script>
</asp:Content>
