
<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="MyBank.Dashboard" %>
<%@ Import Namespace="MyBank" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h1>Welcome <b><% Response.Write(UserLogic.getCutsomer(Session["UserId"].ToString()).Rows[0]["name"].ToString()); %></b> to Dashboard....!</h1>


</asp:Content>
