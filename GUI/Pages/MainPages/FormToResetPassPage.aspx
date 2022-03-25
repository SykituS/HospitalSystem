<%@ Page Title="Form" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"  CodeBehind="FormToResetPassPage.aspx.cs" Inherits="GUI.FormToResetPassPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>

        <asp:Label ID="Label1" runat="server" Text="Login:"></asp:Label>
        <asp:TextBox ID="TBLogin" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Email:"></asp:Label>
        <asp:TextBox ID="TBEmail" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="BtnOk" runat="server" OnClick="BtnOk_Click" Text="Ok" />
        <asp:Button ID="BtnCancel" runat="server" OnClick="BtnCancel_Click" Text="Cancel" />

    </div>

</asp:Content>

