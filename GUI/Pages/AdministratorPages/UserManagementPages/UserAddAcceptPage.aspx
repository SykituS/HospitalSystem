<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserAddAcceptPage.aspx.cs" Inherits="GUI.Pages.AdministratorPages.UserManagementPages.UserAddAcceptPage" MasterPageFile="~/Site.Master"
Title="User Add Accept"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div style="margin-top:15px;">

        <div>
            <asp:Label ID="Label1" runat="server" Text=" "></asp:Label>
        </div>
        <p>
            <asp:Button ID="BtnAccept" runat="server" OnClick="BtnAccept_Click" Text="Accept" />
            <asp:Button ID="BtnCancel" runat="server" Text="Cancel" OnClick="BtnCancel_Click" />
        </p>
    </div>

</asp:Content>
