<%@ Page Title="List of Patients" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MedicalStaffPanelPage.aspx.cs" Inherits="GUI.Pages.MedicalStaffMemberPages.MedicalStaffPanelPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div style="margin-top:15px;">

        <asp:Button ID="BtnPatientList" runat="server" Text="Reception Page (List of patients)" OnClick="BtnPatientList_Click" />
        <br />
        <br />
        <asp:Button ID="BtnLogout" runat="server" Text="Logout" OnClick="BtnLogout_Click" />
        
        <asp:Button ID="BtnBackToMenu" runat="server" Enabled="False" OnClick="BtnBackToMenu_Click" Text="Back to administrator menu" Visible="False" />
        
    </div>

</asp:Content>         
