<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PatientDeletePage.aspx.cs" Inherits="GUI.Pages.MedicalStaffMemberPages.PatientDeletePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div Class="user-add-page-div">
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="Tbx_Delete_Text" runat="server" Font-Size="Large" Text="Are you sure you want to remove this patient?"></asp:Label>
    </p>
    <p>
        <br />
        <asp:Button ID="Btn_Delete" CssClass="btn-usr-mngmt-pg" runat="server" Text="Remove" OnClick="BtnDelete_Click" />
    </p>
    <p>
        <asp:Button ID="Btn_Cancel" CssClass="btn-usr-mngmt-pg" runat="server" OnClick="BtnCancel_Click" Text="Cancel" />
    </p
     </div>
</asp:Content>
