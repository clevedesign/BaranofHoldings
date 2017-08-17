<%@ Page Title="Team" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Admin.Team.Default" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%= Title %></h1>
    <div style="margin-bottom: 15px">
        <p>
            <asp:Button ID="AddMember" runat="server" Text="Add New Member" OnClick="AddMember_Click" />
        </p>

        <ul class="tabs" data-persist="true">
            <li><a href="#team">Team</a></li>
            <li><a href="#borad">Advisors</a></li>
        </ul>

        <div class="tabcontents">
            <div id="team">
                <asp:GridView ID="TeamGridView" runat="server" AutoGenerateColumns="False" DataSourceID="TeamDataSource" DataKeyNames="TeamMemberId,MemberType,Prefix,FirstName,MiddleName,LastName,Suffix,MemberTitle,MemberEmail,MemberPhone,MemberLinkedIn,MembervCard,MemberPicture,MemberBriefIntro,MemberBio,MemberOrder,Created,Modified,isDeleted" OnSelectedIndexChanged="TeamGridView_SelectedIndexChanged" OnRowDeleted="GridView_RowDeleted">
                    <Columns>
                        <asp:TemplateField ShowHeader="False" HeaderStyle-Width="150px">
                            <ItemTemplate>
                                <asp:LinkButton ID="EditBtn" runat="server" CausesValidation="False" CommandName="Select" Text="Edit"></asp:LinkButton>
                                <asp:LinkButton ID="DelBtn" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" OnClientClick="return confirm(&quot;Are you sure you want to delete?&quot;)"></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle Width="150px"></HeaderStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TeamMemberId" SortExpression="TeamMemberId" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="HiddenTeamMemberId" runat="server" Text='<%# Bind("TeamMemberId") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="MemberType" HeaderText="MemberType" SortExpression="MemberType" Visible="false" />
                        <asp:BoundField DataField="Prefix" HeaderText="Prefix" SortExpression="Prefix" Visible="false" />
                        <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" HeaderStyle-Width="150px" />
                        <asp:BoundField DataField="MiddleName" HeaderText="MiddleName" SortExpression="MiddleName" Visible="false" />
                        <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" HeaderStyle-Width="150px" />
                        <asp:BoundField DataField="Suffix" HeaderText="Suffix" SortExpression="Suffix" Visible="false" />
                        <asp:BoundField DataField="MemberTitle" HeaderText="Title" SortExpression="MemberTitle" />
                        <asp:BoundField DataField="MemberEmail" HeaderText="MemberEmail" SortExpression="MemberEmail" Visible="false" />
                        <asp:BoundField DataField="MemberPhone" HeaderText="MemberPhone" SortExpression="MemberPhone" Visible="false" />
                        <asp:BoundField DataField="MemberLinkedIn" HeaderText="MemberLinkedIn" SortExpression="MemberLinkedIn" Visible="false" />
                        <asp:BoundField DataField="MembervCard" HeaderText="MembervCard" SortExpression="MembervCard" Visible="false" />
                        <asp:BoundField DataField="MemberPicture" HeaderText="MemberPicture" SortExpression="MemberPicture" Visible="false" />
                        <asp:BoundField DataField="MemberBriefIntro" HeaderText="MemberBriefIntro" SortExpression="MemberBriefIntro" Visible="false" />
                        <asp:BoundField DataField="MemberBio" HeaderText="MemberBio" SortExpression="MemberBio" Visible="false" />
                        <asp:TemplateField HeaderText="Order" SortExpression="TeamMemberId" HeaderStyle-Width="200px">
                            <ItemTemplate>
                                <asp:LinkButton ID="MoveUp" runat="server" OnClick="MoveUp_Click" Visible='<%# !isFirst(Eval("TeamMemberId")) %>'>Move Up</asp:LinkButton>
                                <asp:LinkButton ID="MoveDown" runat="server" OnClick="MoveDown_Click" Visible='<%# !isLast(Eval("TeamMemberId")) %>'>Move Down</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
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
                <asp:ObjectDataSource ID="TeamDataSource" runat="server" DataObjectTypeName="DAL.Models.TeamMember" DeleteMethod="DeleteTeamMember" SelectMethod="GetAllTeamMembersOf" TypeName="BLL.ManageTeamMember">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="Team" Name="type" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
            <div id="borad">
                <asp:GridView ID="BoradGridView" runat="server" AutoGenerateColumns="False" DataSourceID="BoradDataSource" DataKeyNames="TeamMemberId,MemberType,Prefix,FirstName,MiddleName,LastName,Suffix,MemberTitle,MemberEmail,MemberPhone,MemberLinkedIn,MembervCard,MemberPicture,MemberBriefIntro,MemberBio,MemberOrder,Created,Modified,isDeleted" OnSelectedIndexChanged="BoradGridView_SelectedIndexChanged" OnRowDeleted="GridView_RowDeleted">
                    <Columns>
                        <asp:TemplateField ShowHeader="False" HeaderStyle-Width="150px">
                            <ItemTemplate>
                                <asp:LinkButton ID="EditBtn" runat="server" CausesValidation="False" CommandName="Select" Text="Edit"></asp:LinkButton>
                                <asp:LinkButton ID="DelBtn" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" OnClientClick="return confirm(&quot;Are you sure you want to delete?&quot;)"></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle Width="150px"></HeaderStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TeamMemberId" SortExpression="TeamMemberId" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="HiddenTeamMemberId" runat="server" Text='<%# Bind("TeamMemberId") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="MemberType" HeaderText="MemberType" SortExpression="MemberType" Visible="false" />
                        <asp:BoundField DataField="Prefix" HeaderText="Prefix" SortExpression="Prefix" Visible="false" />
                        <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" HeaderStyle-Width="150px" />
                        <asp:BoundField DataField="MiddleName" HeaderText="MiddleName" SortExpression="MiddleName" Visible="false" />
                        <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" HeaderStyle-Width="150px" />
                        <asp:BoundField DataField="Suffix" HeaderText="Suffix" SortExpression="Suffix" Visible="false" />
                        <asp:BoundField DataField="MemberTitle" HeaderText="Title" SortExpression="MemberTitle" />
                        <asp:BoundField DataField="MemberEmail" HeaderText="MemberEmail" SortExpression="MemberEmail" Visible="false" />
                        <asp:BoundField DataField="MemberPhone" HeaderText="MemberPhone" SortExpression="MemberPhone" Visible="false" />
                        <asp:BoundField DataField="MemberLinkedIn" HeaderText="MemberLinkedIn" SortExpression="MemberLinkedIn" Visible="false" />
                        <asp:BoundField DataField="MembervCard" HeaderText="MembervCard" SortExpression="MembervCard" Visible="false" />
                        <asp:BoundField DataField="MemberPicture" HeaderText="MemberPicture" SortExpression="MemberPicture" Visible="false" />
                        <asp:BoundField DataField="MemberBriefIntro" HeaderText="MemberBriefIntro" SortExpression="MemberBriefIntro" Visible="false" />
                        <asp:BoundField DataField="MemberBio" HeaderText="MemberBio" SortExpression="MemberBio" Visible="false" />
                        <asp:TemplateField HeaderText="Order" SortExpression="TeamMemberId" HeaderStyle-Width="200px">
                            <ItemTemplate>
                                <asp:LinkButton ID="MoveUp" runat="server" OnClick="MoveUp_Click" Visible='<%# !isFirst(Eval("TeamMemberId")) %>'>Move Up</asp:LinkButton>
                                <asp:LinkButton ID="MoveDown" runat="server" OnClick="MoveDown_Click" Visible='<%# !isLast(Eval("TeamMemberId")) %>'>Move Down</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
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
                <asp:ObjectDataSource ID="BoradDataSource" runat="server" DataObjectTypeName="DAL.Models.TeamMember" DeleteMethod="DeleteTeamMember" SelectMethod="GetAllTeamMembersOf" TypeName="BLL.ManageTeamMember">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="Advisor" Name="type" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </div>
    </div>
</asp:Content>