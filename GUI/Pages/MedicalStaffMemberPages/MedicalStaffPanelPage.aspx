<%@ Page Title="List of Patients" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MedicalStaffPanelPage.aspx.cs" Inherits="GUI.Pages.MedicalStaffMemberPages.MedicalStaffPanelPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div style="margin-top:15px;">

        <asp:Button ID="BtnPatientList" runat="server" Text="List of patients" OnClick="BtnPatientList_Click" />
        <br />
        <br />
        <asp:Button ID="Btn_visits" runat="server" Text="Display appointments" OnClick="Btn_visits_Click" />
        <br />
        <br />
        <asp:Calendar ID="Cal_appointments" runat="server" OnSelectionChanged="Cal_appointments_SelectionChanged"></asp:Calendar>
        <br />
        <asp:GridView ID="Gv_appointments" runat="server">

        </asp:GridView>
        <br />
        <br />
        <asp:Button ID="BtnLogout" runat="server" Text="Logout" OnClick="BtnLogout_Click" style="left: 773px; top: -322px" /><br />
        <asp:Button ID="BtnBackToMenu" runat="server" Enabled="False" OnClick="BtnBackToMenu_Click" Text="Back to administrator menu" Visible="False" style="left: 773px; top: -322px"/>
        
    </div>

</asp:Content>         
