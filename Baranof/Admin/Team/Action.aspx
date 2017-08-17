<%@ Page Title="Team" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Action.aspx.cs" Inherits="Admin.Team.Action" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1><asp:Label runat="server" ID="ActionName"></asp:Label></h1>
    <div style="margin-top: 15px">
        <asp:DetailsView ID="TeamDetailsView" runat="server" Height="50px" Width="900px" AutoGenerateRows="False" DataSourceID="TeamDataSource" DataKeyNames="TeamMemberId,MemberType,Prefix,FirstName,MiddleName,LastName,Suffix,MemberTitle,MemberEmail,MemberPhone,MemberLinkedIn,MembervCard,MemberPicture,MemberBriefIntro,MemberBio,MemberOrder,Created,Modified,isDeleted" OnItemCommand="TeamDetailsView_ItemCommand" OnItemInserting="TeamDetailsView_ItemInserting" OnItemUpdating="TeamDetailsView_ItemUpdating" OnItemInserted="TeamDetailsView_ItemInserted" OnItemUpdated="TeamDetailsView_ItemUpdated">
            <Fields>
                <asp:BoundField DataField="TeamMemberId" HeaderText="TeamMemberId" SortExpression="TeamMemberId" Visible="false" />
                <asp:TemplateField HeaderText="Type" SortExpression="MemberType">
                    <EditItemTemplate>
                        <asp:DropDownList ID="TypeDDL" runat="server" ClientIDMode="Static"></asp:DropDownList>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:DropDownList ID="TypeDDL" runat="server" ClientIDMode="Static">
                            <asp:ListItem Value="Team">Team</asp:ListItem>
                            <asp:ListItem Value="Borad">Borad</asp:ListItem>
                        </asp:DropDownList>
                    </InsertItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Prefix" SortExpression="Prefix">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Prefix") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Prefix") %>'></asp:TextBox>
                    </InsertItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="First Name" SortExpression="FirstName">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("FirstName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("FirstName") %>'></asp:TextBox>
                    </InsertItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Middle Name" SortExpression="MiddleName">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("MiddleName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("MiddleName") %>'></asp:TextBox>
                    </InsertItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Last Name" SortExpression="LastName">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("LastName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("LastName") %>'></asp:TextBox>
                    </InsertItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Suffix" SortExpression="Suffix">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Suffix") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Suffix") %>'></asp:TextBox>
                    </InsertItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Title" SortExpression="MemberTitle">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("MemberTitle") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("MemberTitle") %>'></asp:TextBox>
                    </InsertItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email" SortExpression="MemberEmail">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("MemberEmail") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("MemberEmail") %>'></asp:TextBox>
                    </InsertItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Phone" SortExpression="MemberPhone">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("MemberPhone") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("MemberPhone") %>'></asp:TextBox>
                    </InsertItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="LinkedIn" SortExpression="MemberLinkedIn">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("MemberLinkedIn") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("MemberLinkedIn") %>'></asp:TextBox>
                    </InsertItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="vCard" SortExpression="MembervCard">
                    <EditItemTemplate>
                        <asp:Label ID="LabelvCard1" runat="server" Text='<%# Bind("MemberVCard") %>' Visible='<%# !HasFile(Eval("MemberVCard")) %>'></asp:Label>
                        <asp:Label ID="LabelvCard2" runat="server" Text="No vCard" Visible='<%# HasFile(Eval("MemberVCard")) %>'></asp:Label>
                        <br />
                        <asp:Label ID="vCardInfo" runat="server" Text="Click below to upload a new vCard:"></asp:Label>
                        <br />
                        <asp:FileUpload ID="vCardUpload" runat="server" />
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:FileUpload ID="vCardUpload" runat="server" />
                    </InsertItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Picture" SortExpression="MemberPicture">
                    <EditItemTemplate>
                        <asp:Label ID="LabeImage" runat="server" Text="no image" Visible='<%# HasImage(Eval("MemberPicture")) %>'></asp:Label>
                        <asp:Image ID="Image" runat="server" Visible='<%# !HasImage(Eval("MemberPicture")) %>' ImageUrl='<%# GetImageUrl(Eval("MemberPicture")) %>' />
                        <asp:HiddenField ID="HiddenPicField" runat="server" Value='<%# Eval("MemberPicture") %>' />
                        <br />
                        <asp:FileUpload ID="ImageUpload" runat="server" />
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:FileUpload ID="ImageUpload" runat="server" />
                    </InsertItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Brief Intro" SortExpression="MemberBriefIntro">
                    <EditItemTemplate>
                        <CKEditor:CKEditorControl ID="TextBox15" runat="server" Text='<%# Bind("MemberBriefIntro") %>'></CKEditor:CKEditorControl>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <CKEditor:CKEditorControl ID="TextBox15" runat="server" Text='<%# Bind("MemberBriefIntro") %>'></CKEditor:CKEditorControl>
                    </InsertItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Bio" SortExpression="MemberBio">
                    <EditItemTemplate>
                        <CKEditor:CKEditorControl ID="TextBox14" runat="server" Text='<%# Bind("MemberBio") %>'></CKEditor:CKEditorControl>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <CKEditor:CKEditorControl ID="TextBox14" runat="server" Text='<%# Bind("MemberBio") %>'></CKEditor:CKEditorControl>
                    </InsertItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="MemberOrder" HeaderText="MemberOrder" SortExpression="MemberOrder" Visible="False" />
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
        <asp:ObjectDataSource ID="TeamDataSource" runat="server" DataObjectTypeName="DAL.Models.TeamMember" InsertMethod="AddTeamMember" SelectMethod="GetById" TypeName="BLL.ManageTeamMember" UpdateMethod="UpdateTeamMember">
            <SelectParameters>
                <asp:RouteParameter DefaultValue="0" Name="id" RouteKey="id" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>