<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="SpecializationConfirmPage.aspx.cs" Inherits="GUI.Pages.AdministratorPages.SpecializationManagementPages.SpecializationConfirmPage" Title="MedicalClinic-Confirm Specialization" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="spec-mng-pg-div">
        <h2>Confirm specialization</h2>
        <asp:Label ID="LabelText" runat="server" Text="Label"></asp:Label><br /><br/>
        <asp:Button ID="BtnConfirm" CssClass="btn-usr-mngmt-pg" runat="server" Text="Confirm" OnClick="BtnConfirm_Click" />
        <asp:Button ID="BtnCancel" CssClass="btn-usr-mngmt-pg" runat="server" Text="Cancel" OnClick="BtnCancel_Click" />

    </div>
</asp:Content>
