<%@ Page Title="Administrator Panel" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AdministratorPanelPage.aspx.cs" Inherits="GUI.AdministratorPanelPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style="margin-top:15px">
        <asp:Button ID="BtnSettings" runat="server" Text="Settings" OnClick="BtnSettings_Click" />
        <br />
        <br />
        <asp:Button ID="BtnUserManegment" runat="server" Text="User Management" OnClick="BtnUserManagement_Click" />
        <br />
        <br />
        <asp:Button ID="BtnEmpManage" runat="server" OnClick="BtnEmpManage_Click" Text="Employees Management" />
        <br />
        <br />
        <asp:Button ID="BtnOfficesManage" runat="server" OnClick="BtnOfficesManage_Click" Text="Offices" />
        <br />
        <br />
        <asp:Button ID="BtnLogout" runat="server" Text="Logout" OnClick="BtnLogout_Click" />

        <asp:Button ID="BtnBackToMenu" runat="server" Enabled="False" OnClick="BtnBackToMenu_Click" Text="Back to administrator menu" Visible="False" />

    </div>

</asp:Content>