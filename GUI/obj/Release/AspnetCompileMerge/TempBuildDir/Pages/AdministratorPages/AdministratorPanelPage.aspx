<%@ Page Title="MedicalClinic-Administrator Panel" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AdministratorPanelPage.aspx.cs" Inherits="GUI.AdministratorPanelPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div id="Admin-panel-page-div">
        <h3>Main Panel</h3>
        <asp:Button ID="BtnSettings" CssClass="admin-panel-btn" runat="server" Text="Settings" OnClick="BtnSettings_Click" />
        <br />
        <br />
        <asp:Button ID="BtnUserManegement"  CssClass="admin-panel-btn" runat="server" Text="User Management" OnClick="BtnUserManagement_Click" />
        <br />
        <br />
        <asp:Button ID="BtnEmpManage"  CssClass="admin-panel-btn" runat="server" OnClick="BtnEmpManage_Click" Text="Employees Management" />
        <br />
        <br />
        <asp:Button ID="BtnSpecializationManagement"  CssClass="admin-panel-btn" runat="server" OnClick="BtnSpecializationManagement_Click" Text="Specialization Management" />
        <br />
        <br />
        <asp:Button ID="BtnOfficesManage"  CssClass="admin-panel-btn" runat="server" OnClick="BtnOfficesManage_Click" Text="Offices" />
        <br />
        <br />
        <asp:Button ID="BtnCalendarPage"  CssClass="admin-panel-btn" runat="server" OnClick="BtnCalendarPage_Click" Text="Calendar" />
        <br />
        <br />
        <asp:Button ID="BtnLogout"  CssClass="admin-panel-btn" runat="server" Text="Logout" OnClick="BtnLogout_Click" />

        <asp:Button ID="BtnBackToMenu"  CssClass="admin-panel-btn" runat="server" Enabled="False" OnClick="BtnBackToMenu_Click" Text="Back to administrator menu" Visible="False" />

    </div>

</asp:Content>