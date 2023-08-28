<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="MyBank.Dashboard" %>

<%@ Import Namespace="MyBank" %>
<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <% 
        DataRow data = UserLogic.getCutsomer(Session["UserId"].ToString()).Rows[0];
    %>


    <div class="container">

        <div class="table-responsive border">
            <table class="table table-primary table-striped table-hover " style="margin: 0;">
                <tbody>

                    <tr>
                        <th>Name : </th>
                        <td><% Response.Write(data["name"]); %></td>
                    </tr>

                    <tr>
                        <th>Email : </th>
                        <td><% Response.Write(data["email"]); %></td>
                    </tr>

                    <tr>
                        <th>Address : </th>
                        <td><% Response.Write(data["address"]); %></td>
                    </tr>

                    <tr>
                        <th>Gender : </th>
                        <td><% Response.Write(data["gender"]); %></td>
                    </tr>

                    <tr>
                        <th>Opened On : </th>
                        <td><% Response.Write(data["openOn"]); %></td>
                    </tr>

                    <tr>
                        <th>Available Balance : </th>
                        <td>₹<% Response.Write(data["balance"]); %></td>
                    </tr>

                    <tr>
                        <th>Minimum Required Balance : </th>
                        <td>₹<% Response.Write(data["minAmount"]); %></td>
                    </tr>

                    <tr>
                        <th>Maximum Transfer Amount : </th>
                        <td>₹<% Response.Write(data["maxAmount"]); %></td>
                    </tr>
                </tbody>

            </table>
        </div>

    </div>
</asp:Content>
