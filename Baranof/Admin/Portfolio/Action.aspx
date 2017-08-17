<%@ Page Title="Portfolio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Action.aspx.cs" Inherits="Admin.Portfolio.Action" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1><asp:Label runat="server" ID="ActionName"></asp:Label></h1>
    <asp:DetailsView ID="PortDetailsView" runat="server" Height="50px" Width="900px" AutoGenerateRows="False" DataSourceID="PortDataSource" DataKeyNames="PortfolioId,PortfolioType,PortfolioName,PortfolioLogo,PortfolioLocation,PortfolioServices,PortfolioDate,PortfolioSite,PortfolioDetails,Created,Modified,isDeleted" OnItemCommand="PortDetailsView_ItemCommand" OnItemInserting="PortDetailsView_ItemInserting" OnItemUpdating="PortDetailsView_ItemUpdating" OnItemInserted="PortDetailsView_ItemInserted" OnItemUpdated="PortDetailsView_ItemUpdated">
        <Fields>
            <asp:BoundField DataField="PortfolioId" HeaderText="PortfolioId" SortExpression="PortfolioId" Visible="false" />
            <asp:TemplateField HeaderText="Type" SortExpression="PortfolioType">
                    <EditItemTemplate>
                        <asp:DropDownList ID="TypeDDL" runat="server" ClientIDMode="Static"></asp:DropDownList>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:DropDownList ID="TypeDDL" runat="server" ClientIDMode="Static">
                            <asp:ListItem Value="Current">Current</asp:ListItem>
                            <asp:ListItem Value="Exited">Exited</asp:ListItem>
                        </asp:DropDownList>
                    </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name" SortExpression="PortfolioName">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("PortfolioName") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("PortfolioName") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Date" SortExpression="PortfolioDate">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("PortfolioDate", "{0:MMMM yyyy}") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("PortfolioDate") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Location" SortExpression="PortfolioLocation">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("PortfolioLocation") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("PortfolioLocation") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Services" SortExpression="PortfolioServices">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("PortfolioServices") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("PortfolioServices") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Site" SortExpression="PortfolioSite">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("PortfolioSite") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("PortfolioSite") %>'></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Logo" SortExpression="PortfolioLogo">
                    <EditItemTemplate>
                        <asp:Label ID="LabeImage" runat="server" Text="no image" Visible='<%# HasImage(Eval("PortfolioLogo")) %>'></asp:Label>
                        <asp:Image ID="Image" runat="server" Visible='<%# !HasImage(Eval("PortfolioLogo")) %>' ImageUrl='<%# GetImageUrl(Eval("PortfolioLogo")) %>' />
                        <asp:HiddenField ID="HiddenPicField" runat="server" Value='<%# Eval("PortfolioLogo") %>' />
                        <br />
                        <asp:FileUpload ID="ImageUpload" runat="server" />
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:FileUpload ID="ImageUpload" runat="server" />
                    </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Details" SortExpression="PortfolioDetails">
                <EditItemTemplate>
                    <CKEditor:CKEditorControl ID="TextBox8" runat="server" Text='<%# Bind("PortfolioDetails") %>'></CKEditor:CKEditorControl>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <CKEditor:CKEditorControl ID="TextBox8" runat="server" Text='<%# Bind("PortfolioDetails") %>'></CKEditor:CKEditorControl>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="PortfolioOrder" HeaderText="PortfolioOrder" SortExpression="PortfolioOrder" Visible="False" />
            <asp:BoundField DataField="Created" HeaderText="Created" SortExpression="Created" Visible="false" />
            <asp:BoundField DataField="Modified" HeaderText="Modified" SortExpression="Modified" Visible="false" />
            <asp:CheckBoxField DataField="isDeleted" HeaderText="isDeleted" SortExpression="isDeleted" Visible="false" />
                <asp:TemplateField ShowHeader="False">
                    <EditItemTemplate>
                        <asp:LinkButton ID="submit" runat="server" CommandName="Update" Text="Update"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="cancel" runat="server" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:LinkButton ID="submit" runat="server" CommandName="Insert" Text="Add"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="cancel" runat="server" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                    </InsertItemTemplate>
                </asp:TemplateField>
        </Fields>
    </asp:DetailsView>
    <asp:ObjectDataSource ID="PortDataSource" runat="server" DataObjectTypeName="DAL.Models.PortfolioContent" InsertMethod="AddPortfolio" SelectMethod="GetById" TypeName="BLL.ManagePortfolioContent" UpdateMethod="UpdatePortfolio">
        <SelectParameters>
            <asp:RouteParameter DefaultValue="0" Name="id" RouteKey="id" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>