<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Deposite.aspx.cs" Inherits="MyBank.Deposite" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%@ Import Namespace="MyBank" %>
<%@ Import Namespace="System.Data" %>
    <% 
        DataRow data = UserLogic.getCutsomer(Session["UserId"].ToString()).Rows[0];
    %>


    <div class="container">
        <div class="mb-3">
            <label for="amount" class="form-label">Amount : </label>
            <input type="number" class="form-control" id="amount" runat="server">
        </div>
         
        <asp:Button ID="btn" runat="server" Text="Deposite" class="btn btn-primary" OnClick="btn_Click" />
    </div>


</asp:Content>
