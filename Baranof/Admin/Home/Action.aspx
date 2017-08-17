<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Action.aspx.cs" Inherits="Admin.Home.Action" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit Home Content</h1>
    <asp:HiddenField ID="hiddenInfo" Value="" runat="server" />
    <div style="padding-top:25px; text-align:left; vertical-align:top;">
        <table border="0">
            <tr>
                <td style="width: 150px;padding-top:20px;">
                    <asp:Label ID="Label1" runat="server" Text="Title"></asp:Label>
                </td>
                <td style="padding-top:20px;">
                    <CKEditor:CKEditorControl ID="TitleInput" runat="server"></CKEditor:CKEditorControl>
                </td>
            </tr>
            <tr>
                <td style="width: 150px;padding-top:20px;">
                    <asp:Label ID="Label2" runat="server" Text="Content"></asp:Label>
                </td>
                <td style="padding-top:20px;">
                    <CKEditor:CKEditorControl ID="ContentInput" runat="server"></CKEditor:CKEditorControl>
                </td>
            </tr>
        </table>

        <div style="text-align:center;">
            <asp:Button ID="Update" runat="server" Text="Update" OnClick="Update_Click" />
            <asp:Button ID="Cancel" runat="server" Text="Cancel" OnClick="Cancel_Click" />
        </div>
     </div>
</asp:Content>