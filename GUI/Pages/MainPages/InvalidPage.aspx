<%@ Page Title="Invalid Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InvalidPage.aspx.cs" Inherits="GUI.Pages.MainPages.InvalidPage" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style="margin-top: 25p; position:center;">

        <h1>Page not found!</h1>
        <p>
            <asp:Button ID="BtnBack" runat="server" OnClick="BtnBack_Click" Text="Back to main page" />
        </p>

    </div>

</asp:Content>

