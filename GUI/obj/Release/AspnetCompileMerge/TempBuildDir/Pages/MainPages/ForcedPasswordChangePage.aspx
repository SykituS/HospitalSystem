<%@ Page Title="MedicalClinic-Forced password change" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ForcedPasswordChangePage.aspx.cs" Inherits="GUI.Pages.MainPages.ForcedPasswordChangePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="user-add-page-div">
        <h3>Forced password change</h3>
        <asp:Label ID="Label1" runat="server" Text="It looks like your password has been changed by the system! For security reasons, we ask you to change your password again"></asp:Label>
        <br /><br />
        <asp:Label ID="Label2" runat="server" Text="New password"></asp:Label>
        <br />
        <asp:TextBox ID="TBNewPassword" runat="server" TextMode="Password"></asp:TextBox>
        <br /><br />
        <asp:Label ID="Label3" runat="server" Text="Confirmy password"></asp:Label>
        <br />
        <asp:TextBox ID="TBConfirmNewPassword" runat="server" TextMode="Password"></asp:TextBox>
        <br /><br />
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:Label ID="LabelWarning" runat="server" Text="Warning" Visible="False"></asp:Label>
                <br /><br />
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Button ID="BtnContiune" CssClass="btn-usr-mngmt-pg" runat="server" Text="Contiune" OnClick="BtnContiune_Click" />

    </div>

</asp:Content>