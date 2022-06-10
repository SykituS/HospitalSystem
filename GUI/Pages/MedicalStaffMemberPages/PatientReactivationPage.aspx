<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PatientReactivationPage.aspx.cs" Inherits="GUI.Pages.MedicalStaffMemberPages.PatientReactivationPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="user-add-page-div">
    <p>
        <br />
        Are you sure you want to reactivate the patient?</p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="Btn_reactivate" CssClass="btn-usr-mngmt-pg" runat="server" OnClick="Btn_reactivate_Click" Text="Confirm reactivation" />
    </p>
    <p>
        
    <p>
        <asp:Button ID="Btn_cancel" CssClass="btn-usr-mngmt-pg" runat="server" OnClick="Btn_cancel_Click" Text="Cancel" />
    </p>
    </div>
    </asp:Content>
