<%@ Page Title="Forced password change" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ForcedPasswordChangePage.aspx.cs" Inherits="GUI.Pages.MainPages.ForcedPasswordChangePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div style="margin-top:15px;">

        <asp:Label ID="Label1" runat="server" Text="It looks like your password has been changed by the system! For security reasons, we ask you to change your password again"></asp:Label>
        <br /><br />
        <asp:Label ID="Label2" runat="server" Text="New password"></asp:Label>
        <br />
        <asp:TextBox ID="TBNewPassword" runat="server"></asp:TextBox>
        <br /><br />
        <asp:Label ID="Label3" runat="server" Text="Confirmy password"></asp:Label>
        <br />
        <asp:TextBox ID="TBConfirmNewPassword" runat="server"></asp:TextBox>
        <br /><br />
        <asp:Label ID="Label4" runat="server" Text="Warning" Visible="False"></asp:Label>
        <br /><br />
        <asp:Button ID="BtnContiune" runat="server" Text="Contiune" />

    </div>

</asp:Content>