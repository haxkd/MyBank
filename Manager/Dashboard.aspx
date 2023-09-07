<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/Manager.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="MyBank.Manager.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <h1>-: All customers :-</h1>


   


    <asp:GridView ID="customers" runat="server" 
        AutoGenerateColumns="false" DataKeyNames="id" CssClass="table" 
        OnRowEditing="customers_RowEditing" OnRowUpdating="customers_RowUpdating" OnRowCancelingEdit="customers_RowCancelingEdit">

        <Columns>
            <asp:TemplateField HeaderText="Sr No.">
                <ItemTemplate>
                    <asp:Label ID="srno" runat="server" Text='<%# Bind("SrNo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Customer Name">
                <ItemTemplate>
                    <asp:Label ID="lblname" runat="server" Text='<%# Bind("name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <asp:Label ID="lblstatus" runat="server" Text='<%# Bind("status") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="statuses" runat="server"></asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="true"  HeaderText="Edit" ControlStyle-CssClass="btn btn-success"/>
        </Columns>

    </asp:GridView>
</asp:Content>
