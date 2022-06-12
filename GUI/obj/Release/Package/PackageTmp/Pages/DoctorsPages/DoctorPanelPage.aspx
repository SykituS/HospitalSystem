<%@ Page Title="Doctor Panel" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DoctorPanelPage.aspx.cs" Inherits="GUI.Pages.DoctorsPages.DoctorPanelPage" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div style="margin:15px;"></div>
    <div>

        <asp:Button ID="BtnViewAppointment" runat="server" OnClick="BtnEmpManage_Click" Text="View Appointment" />
        <br />
        <br />
        <asp:Button ID="BtnLogout" runat="server" Text="Logout" OnClick="BtnLogout_Click" />
        
        <asp:Button ID="BtnBackToMenu" runat="server" Enabled="False" OnClick="BtnBackToMenu_Click" Text="Back to administrator menu" Visible="False" />
    </div>
</asp:Content>