<%@ Page Title="MedicalClinic-Main Panel" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministratorMainPanel.aspx.cs" Inherits="GUI.Pages.AdministratorMainPanel" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="Head-admin-panel-page-div">

        
        <asp:Label ID="Label1" runat="server" Text="Main panel for head administrator"></asp:Label>
        <br />
        <br />
        <asp:Button ID="BtnAdministrator" CssClass="admin-panel-btn"  runat="server" Text="Administrator panel" OnClick="BtnAdministrator_Click" />
        <br /><br />
        <asp:Button ID="BtnDoctors" CssClass="admin-panel-btn" runat="server" Text="Doctor panel" OnClick="BtnDoctors_Click" />
        <br /><br />
        <asp:Button ID="BtnMedicalStaffMember" CssClass="admin-panel-btn" runat="server" Text="Medical staff member panel" OnClick="BtnMedicalStaffMember_Click" />
        <br /><br />
        <asp:Button ID="BtnLogOut" CssClass="admin-panel-btn" runat="server" Text="Log out" OnClick="BtnLogOut_Click" />

        
    </div>
</asp:Content>
