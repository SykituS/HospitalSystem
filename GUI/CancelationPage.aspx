<%@ Page Title="Confirm cancelation" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CancelationPage.aspx.cs" Inherits="GUI.CancelationPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>

        <asp:Label ID="LabelWarning" runat="server" Text="Do you want to confirm logout?"></asp:Label>
        <br />
        <asp:Button ID="BtnOk" runat="server" Text="Ok" OnClick="BtnOk_Click" />
        <asp:Button ID="BtnCancel" runat="server" Text="Cancel" OnClick="BtnCancel_Click" />

    </div>

</asp:Content>