<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Branch.aspx.cs" Inherits="MyBank.Admin.Branch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="text-center">All Branches</h1>

    <asp:GridView ID="branches" runat="server" AutoGenerateColumns="false" DataKeyNames="id" CssClass="table">

        <Columns>
            <asp:TemplateField HeaderText="Branch Name">
                <ItemTemplate>
                    <asp:Label ID="lblname" runat="server" Text='<%# Bind("name") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Branch Code">
                <ItemTemplate>
                    <asp:Label ID="lblcode" runat="server" Text='<%# Bind("code") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Branch Location">
                <ItemTemplate>
                    <asp:Label ID="lbllocation" runat="server" Text='<%# Bind("address") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:CommandField ShowEditButton="true"  HeaderText="Edit"/>
            <asp:CommandField ShowDeleteButton="true"  HeaderText="Delete"/>

        </Columns>

    </asp:GridView>


</asp:Content>
