﻿<%@ Page Language="C#" MasterPageFile="MasterPage.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="XueFu.Admin.User"%>
<%@ Register Assembly="XueFu.Common" Namespace="XueFu.Common" TagPrefix="XueFu" %>
<%@ Import Namespace="XueFu.EntLib" %>
<%@ Import Namespace="XueFu.BLL" %>
<asp:Content ID="MasterContent" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
<script type="text/javascript" src="http://cdn.bootcss.com/jquery/1.12.1/jquery.min.js"></script>
function deleteUser(userID){