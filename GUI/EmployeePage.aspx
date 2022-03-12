<%@ Page Title="Employee Panel" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EmployeePage.aspx.cs" Inherits="GUI.EmployeePage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>

        <h1>You are logged as Employee</h1>
        <br />
        <asp:Button ID="BtnUserList" runat="server" Text="View calendar" />
        <br />
        <br />
        <asp:Button ID="BtnLogout" runat="server" Text="Logout" OnClick="BtnLogout_Click" />

    </div>

</asp:Content>