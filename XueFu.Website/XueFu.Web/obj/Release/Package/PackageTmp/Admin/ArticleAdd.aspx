<%@ Page Language="C#" MasterPageFile="MasterPage.Master" AutoEventWireup="true" CodeBehind="ArticleAdd.aspx.cs" Inherits="XueFu.Web.Admin.ArticleAdd" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Import Namespace="XueFu.BLL" %>
<asp:Content ID="MasterContent" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
<script type="text/javascript" src="http://cdn.bootcss.com/jquery/1.12.1/jquery.min.js"></script>
<div class="position"><img src="/Admin/images/PositionIcon.png"  alt=""/>文章<%=GetAddUpdate()%></div>
<div class="add" >	
	<ul>
		<li class="left">分类：</li>
		<li class="right"><asp:DropDownList class="classdropdown" ID="ClassID"  runat="server"  /></li>
	</ul>	
	<ul>
		<li class="left">标题：</li>
		<li class="right"><XueFu:TextBox ID="Title" CssClass="input" runat="server" Width="400px"  CanBeNull="必填"/></li>
	</ul>
	<ul>
		<li class="left">链接地址：</li>
		<li class="right"><XueFu:TextBox ID="Url" CssClass="input" runat="server" Width="400px" HintInfo="填写该项就表示文章详细页直接链接到该地址，如果是外部地址，请在地址前带上Http://"/></li>
	</ul>   
	<ul>
		<li class="left">内容：</li>
		<li class="right"><FCKeditorV2:FCKeditor ToolbarSet="Basic" id="Content" runat="server" Width="600px" Height="260px"/></li>
	</ul>
	<ul><asp:HiddenField ID="Hint" runat="server" /></ul>
</div>
<div class="action">
    <asp:Button CssClass="button" ID="SubmitButton" Text=" 确 定 " runat="server"  OnClick="SubmitButton_Click" />
</div>
<script language="javascript">
$(function(){
    $(".classdropdown").change(function(){
        if($(this).val()=="1"){
            $(".topitem").show();
        }
        else{
            $(".topitem").hide();
        }
    })
    $(".classdropdown").change();
})
</script>
</asp:Content>
