<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PatientDeactivationPage.aspx.cs" Inherits="GUI.Pages.MedicalStaffMemberPages.PatientDeactivationPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="user-add-page-div">

    <p>
        <br />
        <asp:Label ID="Lbl_deactivate" runat="server" Text="Are you sure you want to deactivate this patient?"></asp:Label>
    </p>
    <p>
        <asp:Button ID="Btn_deactivate" CssClass="btn-usr-mngmt-pg" runat="server" Text="Confirm deactivation" OnClick="Btn_deactivate_Click" />
    </p>
    <p>
        
    <p>
        <asp:Button ID="Btn_cancel" CssClass="btn-usr-mngmt-pg" runat="server" OnClick="Btn_cancel_Click" Text="Cancel" />
    </p>
     </div>
    </asp:Content>