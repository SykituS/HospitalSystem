<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GUI._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">

        <asp:Label ID="LabelWarnings" runat="server" ForeColor="Red" Text="LabelWarnings" Visible="False"></asp:Label>
        <br />

        Login<asp:TextBox ID="TBLogin" runat="server"></asp:TextBox>
        <br />
        Password<asp:TextBox ID="TBPassword" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Button ID="BtnLogin" runat="server" OnClick="BtnLogin_Click" Text="Login" />

        <asp:Button ID="BtnCancel" runat="server" OnClick="BtnCancel_Click" Text="Cancel" />

    </div>

</asp:Content>
