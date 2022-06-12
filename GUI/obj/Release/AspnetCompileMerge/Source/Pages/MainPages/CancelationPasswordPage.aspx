<%@ Page Title="MedicalClinic-Confirm cancelation" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CancelationPasswordPage.aspx.cs" Inherits="GUI.Pages.MainPages.CancelationPasswordPage" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-to-reset-password">

        <h3>Do you want to cancel password change ?</h3>
        <br />
        <asp:Button ID="BtnOk" CssClass="btn-logout-page" runat="server" Text="Ok" OnClick="BtnOk_Click" style="margin: 5px"/>
        <asp:Button ID="BtnCancel" CssClass="btn-logout-page" runat="server" Text="Cancel" OnClick="BtnCancel_Click" style="margin: 5px"/>
        <br /><br />
    </div>

</asp:Content>