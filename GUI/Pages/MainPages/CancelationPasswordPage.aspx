<%@ Page Title="Confirm cancelation" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CancelationPasswordPage.aspx.cs" Inherits="GUI.Pages.MainPages.CancelationPasswordPage" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>

        <h3>Do you want to cancel password change ?</h3>
        <br />
        <asp:Button ID="BtnOk" runat="server" Text="Ok" OnClick="BtnOk_Click" style="margin: 5px"/>
        <asp:Button ID="BtnCancel" runat="server" Text="Cancel" OnClick="BtnCancel_Click" style="margin: 5px"/>

    </div>

</asp:Content>