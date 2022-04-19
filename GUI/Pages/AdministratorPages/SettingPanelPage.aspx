<%@ Page Title="Settings Panel" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SettingPanelPage.aspx.cs" Inherits="GUI.Pages.AdministratorPages.SettingsPages.SettingPanelPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style="margin-top: 15px;">
        <h5>
            <asp:Label ID="LabelWarning" runat="server" Text="InfoPlaceholder"></asp:Label>

        </h5>
        <h5>Set the login form blocking time: 
            <asp:TextBox ID="TBTimeToUnlock" runat="server" TextMode="Number"></asp:TextBox>
            &nbsp;(in minutes)<br /><br />
            <asp:Button ID="BtnBack" runat="server" OnClick="BtnBack_Click" Text="Back to menu" />
            <br />
            <asp:Button ID="BtnConfirm" runat="server" OnClick="BtnConfirm_Click" Text="Confirm " />

        </h5>  
    </div>

</asp:Content>
