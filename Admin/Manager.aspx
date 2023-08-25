<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Manager.aspx.cs" Inherits="MyBank.Admin.Manager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="text-center">All Managers</h1>
    <asp:GridView ID="managers" runat="server" 
        AutoGenerateColumns="false" DataKeyNames="id" CssClass="table" 
        OnRowEditing="managers_RowEditing" OnRowUpdating="managers_RowUpdating" OnRowCancelingEdit="managers_RowCancelingEdit">

        <Columns>
            <asp:TemplateField HeaderText="Manager Name">
                <ItemTemplate>
                    <asp:Label ID="lblname" runat="server" Text='<%# Bind("name") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>  
                    <asp:TextBox ID="txtname" runat="server" Text='<%# Bind("name") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Branch Id">
                <ItemTemplate>
                    <asp:Label ID="lblbranchid" runat="server" Text='<%# Bind("branchid") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="branches" runat="server"></asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="true"  HeaderText="Edit" ControlStyle-CssClass="btn btn-success"/>
            <asp:CommandField ShowDeleteButton="true"  HeaderText="Delete" ControlStyle-CssClass="btn btn-danger"/>

        </Columns>

    </asp:GridView>


</asp:Content>
