<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OfficesConfirmDelete.aspx.cs" Inherits="GUI.Pages.AdministratorPages.OfficesManagement.OfficesConfirmDelete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="LblConfirmText" runat="server" Font-Size="Large" Text="Are you sure you want delete that office?"></asp:Label>
    </p>
    <p>
        <br />
        <asp:Button ID="BtnDelete" runat="server" OnClick="BtnDelete_Click" Text="Delete" />
    </p>
    <p>
        <asp:Button ID="BtnCancel" runat="server" OnClick="BtnCancel_Click" Text="Cancel" />
    </p>
</asp:Content>
