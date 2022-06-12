<%@ Page Title="List of Patients" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MedicalStaffPanelPage.aspx.cs" Inherits="GUI.Pages.MedicalStaffMemberPages.MedicalStaffPanelPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="usr-mng-pg-div">
        <asp:Button ID="Button1" CssClass="btn-usr-mngmt-pg" runat="server" Text="Logout" OnClick="BtnLogout_Click"/>

        <asp:Button ID="BtnPatientList" CssClass="btn-usr-mngmt-pg" runat="server" Text="List of patients" OnClick="BtnPatientList_Click" />
        <br />
        <br />
        <asp:Button ID="Btn_visits" CssClass="btn-usr-mngmt-pg" runat="server" Text="Display appointments" OnClick="Btn_visits_Click" />
        <br />
        <br />
        <asp:Calendar ID="Cal_appointments" CssClass="tb-user-detail" runat="server" OnSelectionChanged="Cal_appointments_SelectionChanged"></asp:Calendar>
        <br />
        <asp:GridView ID="Gv_appointments" CssClass="tb-user-detail" runat="server">

        </asp:GridView>
        <br />
        <br />
        <br />
        <asp:Button ID="BtnBackToMenu" runat="server" Enabled="False" OnClick="BtnBackToMenu_Click" Text="Back to administrator menu" Visible="False"/>
        
    </div>

</asp:Content>         
