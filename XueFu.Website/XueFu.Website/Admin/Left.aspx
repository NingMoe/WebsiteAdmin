<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Left.aspx.cs" Inherits="XueFu.Admin.Left" %>
<%@ Import Namespace="XueFu.BLL" %>
<%@ Import Namespace="XueFu.Model" %>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<title>左侧菜单</title>
<link href="Style/style.css" type="text/css" rel="stylesheet" media="all" />
</head>
<body>
<div id="middleLeft">
    <div id="menu">
        <div class="menuBody" id="MenuBody">
        <%int i=1; foreach (XueFu.Model.MenuInfo menu in menuList){ %>
            <div onclick="show('Default<%=i%>')" id="Default<%=i%>Div"><img src="images/icon/<%=menu.MenuImage %>-icon.gif" alt="" /><%=menu.MenuName %></div>
            <ul id="Default<%=i%>Menu" <%if(i>1){ %> style="display:none" <%} %>>
                <%int j = 1; foreach (MenuInfo tempMenu in MenuBLL.ReadMenuChildList(menu.ID)){ %>
                <li id="Default<%=i%>Menu-<%=j %>" onclick="shwoSmall('Default<%=i%>Menu-<%=j %>')"><img src="images/icon/<%=tempMenu.MenuImage %>-icon.gif" alt="" /><a href="javascript:goUrl('<%=tempMenu.URL %>')"><%=tempMenu.MenuName%></a></li>
                <%j += 1;} %>
                <%if (i < menuList.Count){ %><li class="foot"></li><%} %>
            </ul>     
            <%i+=1;} %>
        </div>
	</div>
</div>
<script language="javascript" type="text/javascript" src="js/Common.js"></script>
<script language="javascript" type="text/javascript" src="js/Left.js"></script>
</body>
</html>
