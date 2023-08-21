<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyBank.Admin.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container">

        <h1 class="text-center">Welcome Admin ...!</h1>
        <div class="row">
            <div class="col-6"><a class="btn btn-outline-success">Add Branch</a></div>
            <div class="col-6"><a class="btn btn-outline-success">Add Manager</a></div>
            <div class="col-6"><a class="btn btn-outline-success">Show Customers</a></div>
            <div class="col-6"><asp:Button ID="logout" runat="server" Text="Logout" OnClick="logout_Click" CssClass="btn btn-outline-danger" /></div>
        </div>


    </div>


</asp:Content>
