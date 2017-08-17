<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Action.aspx.cs" Inherits="Admin.Contact.Action" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit Contact</h1>
    <div style="margin-top: 15px">
        <asp:DetailsView ID="ContactDetailsView" runat="server" Height="50px" Width="900px" AutoGenerateRows="False" DataSourceID="ContactDataSource" DataKeyNames="ContactId,AddressLine1,AddressLine2,City,State,Zip,Phone,Email,Map,Created,Modified,isDeleted" OnItemCommand="ContactDetailsView_ItemCommand" OnItemUpdated="ContactDetailsView_ItemUpdated">
            <Fields>
                <asp:BoundField DataField="ContactId" HeaderText="ContactId" SortExpression="ContactId" Visible="false" />
                <asp:TemplateField HeaderText="Address Line1" SortExpression="AddressLine1">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("AddressLine1") %>' Width="500"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Address Line2" SortExpression="AddressLine2">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("AddressLine2") %>' Width="500"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="City" SortExpression="City">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("City") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="State" SortExpression="State">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("State") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Zip" SortExpression="Zip">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Zip") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Phone" SortExpression="Phone">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("Phone") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email" SortExpression="Email">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("Email") %>' Width="500"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Map" HeaderText="Map" SortExpression="Map" Visible="false" />
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
        <asp:ObjectDataSource ID="ContactDataSource" runat="server" DataObjectTypeName="DAL.Models.Contact" SelectMethod="GetById" TypeName="BLL.ManageContact" UpdateMethod="UpdateContact">
            <SelectParameters>
                <asp:RouteParameter DefaultValue="0" Name="id" RouteKey="id" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>