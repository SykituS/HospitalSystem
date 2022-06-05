<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="SpecializationConfirmPage.aspx.cs" Inherits="GUI.Pages.AdministratorPages.SpecializationManagementPages.SpecializationConfirmPage" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-top: 15px;">

        <asp:Label ID="LabelText" runat="server" Text="Label"></asp:Label><br /><br/>
        <asp:Button ID="BtnConfirm" runat="server" Text="Confirm" OnClick="BtnConfirm_Click" />
        <asp:Button ID="BtnCancel" runat="server" Text="Cancel" OnClick="BtnCancel_Click" />

    </div>
</asp:Content>
