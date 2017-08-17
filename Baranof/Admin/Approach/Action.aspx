<%@ Page Title="Approach" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Action.aspx.cs" Inherits="Admin.Approach.Action" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1><asp:Label ID="ActionName" runat="server"></asp:Label></h1>
    <div style="margin-bottom: 15px;">
        <asp:DetailsView ID="PageDetailsView" runat="server" Height="50px" Width="900px" AutoGenerateRows="False" DataSourceID="PageDataSource" DataKeyNames="ContentId,ParentPage,ContentName,ContentDetails,ContentOrder,Created,Modified,isDeleted" OnItemCommand="PageDetailsView_ItemCommand" OnItemUpdated="PageDetailsView_ItemUpdated">
            <Fields>
                <asp:BoundField DataField="ContentId" HeaderText="ContentId" SortExpression="ContentId" Visible="false" />
                <asp:BoundField DataField="ParentPage" HeaderText="ParentPage" SortExpression="ParentPage" Visible="false" />
                <asp:TemplateField HeaderText="Name" SortExpression="ContentName">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ContentName") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Content" SortExpression="ContentDetails">
                    <EditItemTemplate>
                        <CKEditor:CKEditorControl ID="TextBox2" runat="server" Text='<%# Bind("ContentDetails") %>'></CKEditor:CKEditorControl>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ContentOrder" HeaderText="ContentOrder" SortExpression="ContentOrder" Visible="False" />
                <asp:BoundField DataField="Created" HeaderText="Created" SortExpression="Created" Visible="false" />
                <asp:BoundField DataField="Modified" HeaderText="Modified" SortExpression="Modified" Visible="false" />
                <asp:CheckBoxField DataField="isDeleted" HeaderText="isDeleted" SortExpression="isDeleted" Visible="false" />
                <asp:TemplateField ShowHeader="False">
                    <EditItemTemplate>
                        <asp:LinkButton ID="submit" runat="server" CommandName="Update" Text="Update"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="cancel" runat="server" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                    </EditItemTemplate>
                </asp:TemplateField>
            </Fields>
        </asp:DetailsView>
        <asp:ObjectDataSource ID="PageDataSource" runat="server" DataObjectTypeName="DAL.Models.PageContent" SelectMethod="GetById" TypeName="BLL.ManagePageContent" UpdateMethod="UpdatePageContent">
            <SelectParameters>
                <asp:RouteParameter DefaultValue="0" Name="id" RouteKey="id" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>