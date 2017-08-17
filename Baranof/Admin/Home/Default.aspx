<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Admin.Home.Default" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%= Title %></h1>
    <div style="margin-top: 15px;">
        <h3>
            <asp:Label ID="TitleContent" runat="server"></asp:Label>
        </h3>
        <asp:Label ID="Content" runat="server"></asp:Label><br />
        <br />
        <asp:Button ID="Edit_Content" Text="Edit" runat="server" OnClick="Edit_Content_Click" />
    </div>
</asp:Content>