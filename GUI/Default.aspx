﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GUI._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">

        Login<asp:TextBox ID="TBLogin" runat="server"></asp:TextBox>
        <br />
        Password<asp:TextBox ID="TBPassword" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="BtnLogin" runat="server" OnClick="BtnLogin_Click" Text="Login" />

    </div>

</asp:Content>
