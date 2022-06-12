<%@ Page Title="MedicalClinic-Invalid Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InvalidPage.aspx.cs" Inherits="GUI.Pages.MainPages.InvalidPage" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-to-reset-password">

        <h3 id="form-pass-page-header">Something went wrong :( <br />Back to Home Page</h3>
        
        <p>
            <asp:Button ID="BtnBack" CssClass="btn" runat="server" OnClick="BtnBack_Click" Text="Back to main page" />
        </p>
        <br />
    </div>

</asp:Content>

