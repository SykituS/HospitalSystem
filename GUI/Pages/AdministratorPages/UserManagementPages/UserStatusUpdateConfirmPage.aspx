<%@ Page Title="Confirm" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="UserStatusUpdateConfirmPage.aspx.cs" Inherits="GUI.Pages.AdministratorPages.UserManagementPages.UserStatusUpdateConfirmPage" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-top:15px">

        <asp:Label ID="Label1" runat="server" Text="Confirm"></asp:Label>
        <br />
        <asp:Button ID="BtnAccept" runat="server" Text="Accept" OnClick="BtnAccept_Click" />
        <asp:Button ID="BtnCancel" runat="server" Text="Cancel" OnClick="BtnCancel_Click" />

    </div>
</asp:Content>