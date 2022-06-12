<%@ Page Title="manager Panel" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ManagerPanelPage.aspx.cs" Inherits="GUI.ManagerPanelPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style ="margin-top:15px; ">

        <asp:Button ID="BtnLogout" runat="server" Text="Logout" OnClick="BtnLogout_Click" />

    </div>

</asp:Content>