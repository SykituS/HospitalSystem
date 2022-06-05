<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="SpecializationDetailsPage.aspx.cs" Inherits="GUI.Pages.AdministratorPages.SpecializationManagementPages.SpecializationDetailsPage" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-top: 15px;">
        <asp:Label ID="Label1" runat="server" Text="Name of specialization"></asp:Label>
        <asp:TextBox ID="TBName" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="BtnSave" runat="server" Text="Save" OnClick="BtnSave_Click" />
        <asp:Button ID="BtnCancel" runat="server" Text="Cancel" OnClick="BtnCancel_Click" />
    </div>
</asp:Content>