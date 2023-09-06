<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Manager.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MyBank.Manager.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    

    <h1 class="text-center mt-5">Manager Login</h1>

    <div class="container">

        <div class="mb-3">
            <label for="email" class="form-label">Email address</label>
            <input type="email" class="form-control" id="email" runat="server">
        </div>

        <div class="mb-3">
            <label for="password" class="form-label">Password</label>
            <input type="password" class="form-control" id="password" runat="server">
        </div>
       
        <asp:Button ID="btn" runat="server" Text="Login" class="btn btn-primary" OnClick="btn_Click" />

    </div>

</asp:Content>
