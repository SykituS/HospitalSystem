<%@ Page Title="MedicalClinic-Settings Panel" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SettingPanelPage.aspx.cs" Inherits="GUI.Pages.AdministratorPages.SettingsPages.SettingPanelPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="settings-panel-page">
        <h5>
            <asp:Label ID="LabelWarning" runat="server" Text=""></asp:Label>

        </h5>
        <h5>Set the login form blocking time: <br /><br />
            <asp:TextBox ID="TBTimeToUnlock" runat="server" TextMode="Number" MaxLength="100"></asp:TextBox>
            &nbsp;(in minutes)<br /><br />
            <asp:Button ID="BtnBack" CssClass="btn-logout-page" runat="server" OnClick="BtnBack_Click" Text="Back to menu" />
            <br />
            <asp:Button ID="BtnConfirm" CssClass="btn-logout-page" runat="server" OnClick="BtnConfirm_Click" Text="Confirm " />

        </h5>  
    </div>

</asp:Content>
