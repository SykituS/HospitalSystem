<%@ Page Title="MedicalClinic-Information" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InfoPage.aspx.cs" Inherits="GUI.Pages.MainPages.InfoPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="user-add-page-div">

       <h3><asp:Label ID="Label1" runat="server" Text="Information about program: "></asp:Label><br /><br /></h3>
        
        Version control system: Azure DevOps <br />
        Technology on which the application was created: asp.net c# <br />
        .Net FrameWork version: 4.7.2 <br />
        IDE: Visual Studio

        <br />
        <br />

        <asp:Label ID="Label2" runat="server" Text="Links to Azure DevOps: "></asp:Label><br />

        <a href="https://dev.azure.com/UL0253554/Testowanie Oprogramowania">System Administrator Module</a><br />
        <a href="https://dev.azure.com/UL0253543/TO2022_Projekt_2">Business Administrator Module</a><br />
        <a href="https://dev.azure.com/ModulLekarza/Moduł Lekarza">Doctor Module</a><br />
        <a href="https://dev.azure.com/UL0253594/testowanie">Reception Module</a>
        <br />
        <br />
        <br /><br />
        <asp:Button ID="BtnBack" CssClass="btn-logout-page" runat="server" Text="Back To Menu" OnClick="BtnBack_Click" />


    </div>

</asp:Content>

