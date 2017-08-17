<%@ Page Title="Contact Us" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Admin.Contact.Default" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%= Title %></h1>
    <div style="margin-bottom: 15px;">
        <asp:GridView ID="ContactGridView" runat="server" AutoGenerateColumns="False" DataSourceID="ContactDataSource" DataKeyNames="ContactId,AddressLine1,AddressLine2,City,State,Zip,Phone,Email,Map,Created,Modified,isDeleted" OnSelectedIndexChanged="ContactGridView_SelectedIndexChanged">
            <Columns>
                <asp:TemplateField ShowHeader="False" HeaderStyle-Width="150px">
                    <ItemTemplate>
                        <asp:LinkButton ID="EditBtn" runat="server" CausesValidation="False" CommandName="Select" Text="Edit"></asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle Width="100px"></HeaderStyle>
                </asp:TemplateField>
                <asp:BoundField DataField="ContactId" HeaderText="ContactId" SortExpression="ContactId" Visible="false" />
                <asp:BoundField DataField="AddressLine1" HeaderText="Address Line1" SortExpression="AddressLine1" HeaderStyle-Width="200px" />
                <asp:BoundField DataField="AddressLine2" HeaderText="Address Line2" SortExpression="AddressLine2" HeaderStyle-Width="200px" />
                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                <asp:BoundField DataField="State" HeaderText="State" SortExpression="State" />
                <asp:BoundField DataField="Zip" HeaderText="Zip" SortExpression="Zip" />
                <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" Visible="false" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" Visible="false" />
                <asp:BoundField DataField="Map" HeaderText="Map" SortExpression="Map" Visible="false" />
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
        <asp:ObjectDataSource ID="ContactDataSource" runat="server" SelectMethod="GetAllContact" TypeName="BLL.ManageContact"></asp:ObjectDataSource>
    </div>

    <%--<div style="margin-bottom: 15px;">
        <h1>Firm Overview PDF</h1>
        <asp:FileUpload runat="server" ID="SummaryUpload" />
        <br /><span style="color: red;">Please rename the pdf to "<b>PeriscopeEquityProfile.pdf</b>" before upload it!</span>
        <p>
            <asp:Button ID="UploadSummary" runat="server" Text="Upload" OnClick="UploadSummary_Click" />
        </p>
        <asp:Label ID="UploadResult" runat="server"></asp:Label>
    </div>--%>
</asp:Content>