<%@ Page Title="Welcome" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Admin._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>!</h1>
                <h2>You can edit your site content here.</h2>
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>We suggest the following:</h3>
    <ol class="round">
        <li class="one">
            <h5>Home</h5>
            In here, you can edit the contents in Home page.
            Just click the link and click <i><b style="color:red;">"Edit"</b></i> to <b style="color:red;">update</b>.
        </li>
        <li class="two">
            <h5>Approach</h5>
            In here, you can edit the contents in Approach page.
            Just click the link and click <i><b style="color:red;">"Edit"</b></i> to <b style="color:red;">update</b>.
        </li>
        <li class="three">
            <h5>Criteria</h5>
            In here, you can edit the contents in Criteria page.
            Just click the link and click <i><b style="color:red;">"Edit"</b></i> to <b style="color:red;">update</b>.
        </li>
        <li class="four">
            <h5>Team</h5>
            In here, you can edit the contents in Team page.
            Just click the link and click <i><b style="color:red;">"Edit"</b></i> to <b style="color:red;">update</b>.
            <br />            
            Also, you can click <i><b>"Add New Member"</b></i> to <b>add a new team member</b>.
        </li>
        <li class="five">
            <h5>Portfolio</h5>
            In here, you can edit the contents in Portfolio page.
            Just click the link and click <i><b style="color:red;">"Edit"</b></i> to <b style="color:red;">update</b>.
            <br />            
            Also, you can click <i><b>"Add New Investmet"</b></i> to <b>add a new Portfolio</b>.
        </li>
        <li class="seven">
            <h5>Contact</h5>
            In here, you can edit the contents in Contact page.
            Just click the link and click <i><b style="color:red;">"Edit"</b></i> to <b style="color:red;">update</b>.
            <%--<br />
            Also, you can update the Firm Overview PDF by uploading a new PDF.--%>
        </li>
        <%--<li class="eight">
            <h5>Log</h5>
            In here, you can check the changing log.
            Just click the link and click <i><b style="color:red;">"View"</b></i> to <b style="color:red;">read the details of the change</b>.
            <br />            
            Also, you can click <i><b style="color:red;">"Restore"</b></i> to <b style="color:red;">restore the original content before it was changed</b>.
        </li>--%>
    </ol>
</asp:Content>