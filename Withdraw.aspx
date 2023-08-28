<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Withdraw.aspx.cs" Inherits="MyBank.Withdraw" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   


    <div class="container">
        <div class="mb-3">
            <label for="amount" class="form-label">Amount : </label>
            <input type="number" class="form-control" id="amount" runat="server">
        </div>

        <asp:Button ID="btn" runat="server" Text="Withdraw" class="btn btn-primary" OnClick="btn_Click"/>
    </div>




</asp:Content>
