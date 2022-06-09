<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PatientDeactivationPage.aspx.cs" Inherits="GUI.Pages.MedicalStaffMemberPages.PatientDeactivationPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <p>
        <br />
        <asp:Label ID="Lbl_deactivate" runat="server" Text="Are you sure you want to deactivate this patient?"></asp:Label>
    </p>
    <p>
        <asp:Button ID="Btn_deactivate" runat="server" Text="Confirm deactivation" OnClick="Btn_deactivate_Click" />
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="Btn_cancel" runat="server" OnClick="Btn_cancel_Click" Text="Cancel" />
    </p>

    </asp:Content>