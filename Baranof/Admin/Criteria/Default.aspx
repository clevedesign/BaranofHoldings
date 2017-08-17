<%@ Page Title="Criteria" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Admin.Criteria.Default" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%= Title %></h1>
    <div style="margin-bottom: 15px;">
        <asp:GridView ID="CriteriaGridView" runat="server" AutoGenerateColumns="False" DataSourceID="CriteriaDataSource" DataKeyNames="ContentId,ParentPage,ContentName,ContentDetails,ContentOrder,Created,Modified,isDeleted" OnSelectedIndexChanged="CriteriaGridView_SelectedIndexChanged">
            <Columns>
                <asp:TemplateField ShowHeader="False" HeaderStyle-Width="100px">
                    <ItemTemplate>
                        <asp:LinkButton ID="EditBtn" runat="server" CausesValidation="False" CommandName="Select" Text="Edit"></asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle Width="100px"></HeaderStyle>
                </asp:TemplateField>
                <asp:BoundField DataField="ContentId" HeaderText="ContentId" SortExpression="ContentId" Visible="false" />
                <asp:BoundField DataField="ParentPage" HeaderText="ParentPage" SortExpression="ParentPage" Visible="false" />
                <asp:TemplateField HeaderText="Title" SortExpression="ContentName">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("ContentName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Amount" SortExpression="ContentDetails">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("ContentDetails") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ContentOrder" HeaderText="ContentOrder" SortExpression="ContentOrder" Visible="false" />
                <asp:BoundField DataField="Created" HeaderText="Created" SortExpression="Created" Visible="false" />
                <asp:BoundField DataField="Modified" HeaderText="Modified" SortExpression="Modified" Visible="false" />
                <asp:CheckBoxField DataField="isDeleted" HeaderText="isDeleted" SortExpression="isDeleted" Visible="false" />
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" Height="40px" />
            <AlternatingRowStyle CssClass="alter-row-style" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
        <asp:ObjectDataSource ID="CriteriaDataSource" runat="server" SelectMethod="GetAllPageContentOf" TypeName="BLL.ManagePageContent">
            <SelectParameters>
                <asp:Parameter DefaultValue="Criteria" Name="parent" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>