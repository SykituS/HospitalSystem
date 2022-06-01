<%@ Page Title="Main Panel" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministratorMainPanel.aspx.cs" Inherits="GUI.Pages.AdministratorMainPanel" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style="margin-top:15px">

        
        <asp:Label ID="Label1" runat="server" Text="Main panel for head administrator"></asp:Label>
        <br />
        <br />
        <asp:Button ID="BtnAdministrator" runat="server" Text="Administrator panel" OnClick="BtnAdministrator_Click" />
        <br /><br />
        <asp:Button ID="BtnDoctors" runat="server" Text="Doctor panel" OnClick="BtnDoctors_Click" />
        <br /><br />
        <asp:Button ID="BtnMedicalStaffMember" runat="server" Text="Medical staff member panel" OnClick="BtnMedicalStaffMember_Click" />
        <br /><br />
        <asp:Button ID="BtnLogOut" runat="server" Text="Log out" OnClick="BtnLogOut_Click" />

        
    </div>
</asp:Content>
