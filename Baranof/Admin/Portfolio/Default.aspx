<%@ Page Title="Portfolio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Admin.Portfolio.Default" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%= Title %></h1>
    <div style="margin-bottom: 15px;">
        <p>
            <asp:Button ID="AddPort" runat="server" Text="Add New Portfolio" OnClick="AddPort_Click" />
        </p>
        <asp:GridView ID="PortGridView" runat="server" AutoGenerateColumns="False" DataSourceID="PortDataSource" DataKeyNames="PortfolioId,PortfolioType,PortfolioName,PortfolioLogo,PortfolioLocation,PortfolioServices,PortfolioDate,PortfolioSite,PortfolioDetails,Created,Modified,isDeleted" OnSelectedIndexChanged="PortGridView_SelectedIndexChanged" OnRowDeleted="PortGridView_RowDeleted">
            <Columns>
                <asp:TemplateField ShowHeader="False" HeaderStyle-Width="150px">
                    <ItemTemplate>
                        <asp:LinkButton ID="EditBtn" runat="server" CausesValidation="False" CommandName="Select" Text="Edit"></asp:LinkButton>
                        <asp:LinkButton ID="DelBtn" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" OnClientClick="return confirm(&quot;Are you sure you want to delete?&quot;)"></asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle Width="150px"></HeaderStyle>
                </asp:TemplateField>
                <asp:BoundField DataField="PortfolioId" HeaderText="PortfolioId" SortExpression="PortfolioId" Visible="false" />
                <asp:BoundField DataField="PortfolioType" HeaderText="Type" SortExpression="PortfolioType" />
                <asp:TemplateField HeaderText="Date" SortExpression="PortfolioDate">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("PortfolioDate", "{0:MMMM yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="PortfolioName" HeaderText="Name" SortExpression="PortfolioName" />
                <asp:BoundField DataField="PortfolioLogo" HeaderText="PortfolioLogo" SortExpression="PortfolioLogo" Visible="false" />
                <asp:BoundField DataField="PortfolioLocation" HeaderText="PortfolioLocation" SortExpression="PortfolioLocation" Visible="false" />
                <asp:BoundField DataField="PortfolioServices" HeaderText="PortfolioServices" SortExpression="PortfolioServices" Visible="false" />
                <asp:BoundField DataField="PortfolioSite" HeaderText="PortfolioSite" SortExpression="PortfolioSite" Visible="false" />
                <asp:BoundField DataField="PortfolioDetails" HeaderText="PortfolioDetails" SortExpression="PortfolioDetails" Visible="false" />
                <asp:BoundField DataField="PortfolioOrder" HeaderText="PortfolioOrder" SortExpression="PortfolioOrder" Visible="false" />
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
        <asp:ObjectDataSource ID="PortDataSource" runat="server" DataObjectTypeName="DAL.Models.PortfolioContent" DeleteMethod="DeletePortfolio" SelectMethod="GetAllPortfolios" TypeName="BLL.ManagePortfolioContent"></asp:ObjectDataSource>
    </div>
</asp:Content>
