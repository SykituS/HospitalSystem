<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserAddAcceptPage.aspx.cs" Inherits="GUI.Pages.AdministratorPages.UserManagementPages.UserAddAcceptPage" MasterPageFile="~/Site.Master"
Title="MedicalClinic-User Adding Acceptation"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class=" user-add-page-div">

        <div>
            <asp:Label ID="Label1" runat="server" Text=" "></asp:Label>
        </div>
        <p>
            <asp:Button ID="BtnAccept" CssClass="btn-logout-page" runat="server" OnClick="BtnAccept_Click" Text="Accept" />
            <asp:Button ID="BtnCancel" CssClass="btn-logout-page" runat="server" Text="Cancel" OnClick="BtnCancel_Click" />
        </p>
    </div>

</asp:Content>
