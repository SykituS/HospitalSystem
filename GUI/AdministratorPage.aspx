<%@ Page Title="Administrator Panel" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AdministratorPage.aspx.cs" Inherits="GUI.AdministratorPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <h1>You are logged as Administrator</h1>
        <br />
        <asp:Button ID="BtnUserList" runat="server" Text="User List" OnClick="BtnUserList_Click" />
        <br />
        <br />
        <asp:Button ID="BtnEmpManage" runat="server" OnClick="BtnEmpManage_Click" Text="Employees Management" />
        <br />
        <br />
        <asp:Button ID="BtnLogout" runat="server" Text="Logout" OnClick="BtnLogout_Click" />

    </div>

</asp:Content>