<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddManager.aspx.cs" Inherits="MyBank.Admin.AddManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="text-center mt-5">Add Manager</h1>

    <div class="container">
        <div class="mb-3">
            <label for="name" class="form-label">Manager Name</label>
            <input type="text" class="form-control" id="name" runat="server">
        </div>

        <div class="mb-3">
            <label for="code" class="form-label">Branch Code</label>
            <asp:DropDownList ID="branches" runat="server" class="form-select"></asp:DropDownList>
        </div>
         
        <asp:Button ID="btn" runat="server" Text="Add Manager" class="btn btn-primary" OnClick="btn_Click"/>
    </div>



</asp:Content>
