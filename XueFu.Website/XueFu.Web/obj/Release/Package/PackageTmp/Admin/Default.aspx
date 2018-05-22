<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="XueFu.Web.Admin.Default" %>
<%@ Import Namespace="XueFu.Common" %>
<%@ Import Namespace="XueFu.BLL" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title><%=Config.ReadConfigInfo().Title%>管理平台</title>
    <META http-equiv=Content-Type content="text/html; charset=utf-8">
    <script language="javascript" type="text/javascript" src="js/Common.js"></script>
    <script language="javascript" type="text/javascript" src="js/Admin.js"></script>
    <script language="javascript" type="text/javascript" src="js/ScrollText.js"></script>
    <script type="text/javascript" src="Pop/lhgcore.min.js"></script>
    <script type="text/javascript" src="Pop/lhgdialog.min.js?s=chrome"></script>	
    <link href="Style/style.css" type="text/css" rel="stylesheet" media="all" />
</head>
<body>
    <form id="form1" runat="server">
    <DIV class=head>
        <div class="top">
	        <div class="logo"></div>
            <div class="welcome">
                <%=Cookies.Admin.GetAdminName(false)%>：您好，
                <script language="javascript" type="text/javascript">
                var today=new Date();
                document.write("今天："+today.getFullYear()+ "年"+(today.getMonth()+1)+"月"+today.getDate()+"日");
                </script>
               <a href="javascript:goUrl('ChangePassword.aspx')" >修改密码</a>
               <a href="Logout.aspx" target="_top">安全退出</a>
           </div>                             
	    </div>
        <ul class="channel">
            <li class="on" id="aCommon"><a href="javascript:switchBlock('Common','Left.aspx?ID=1','Right.aspx')">基础设置</a></li>        
        </ul>
    <div class="menu">
	        <div class="text">公告：</div><script language="javascript" src="" type="text/javascript"></script>
	        <ul>   
	            <li><img src="images/menuPadding.gif"  alt=""/></li>
	            <li><a href="/" target="_blank" >网站主页</a></li>
	            <li><img src="images/menuPadding.gif"  alt=""/></li>
	            <li><a href="javascript:goUrl('Menu.aspx')" >菜单设置</a></li>
	            <li><img src="images/menuPadding.gif"  alt=""/></li>
	            <li><a href="javascript:popPageOnly('NoteBook.aspx',500,280,'记事本','NoteBook')"/>记事本</a></li>
	        </ul>
	    </div>
    </DIV>
    <ul class="body" id="Body">
	    <li class="leftFrame"><iframe src="Left.aspx" height="100%" frameborder="0" id="LeftFrame"></iframe></li>
	    <li class="rightFrame"><iframe src="SystemInfo.aspx" height="100%" width="100%" frameborder="0" id="RightFrame"></iframe></li>
	</ul>
	</form>
	<script language="javascript" type="text/javascript" src="Js/Default.js"></script>
</body>
</html>
