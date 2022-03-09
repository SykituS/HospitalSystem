<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="GUI.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>You are logged</h2>
    <p>
        <asp:Button ID="BtnLogOut" runat="server" OnClick="BtnLogOut_Click" Text="Log out" />
    </p>
    </asp:Content>
