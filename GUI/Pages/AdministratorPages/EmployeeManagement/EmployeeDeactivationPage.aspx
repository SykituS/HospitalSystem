<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeDeactivationPage.aspx.cs" Inherits="GUI.Pages.AdministratorPages.EmployeeManagement.EmployeeDeactivationPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:Label ID="LabDeactivation" runat="server" Text="Deactivation" Font-Size="Large"></asp:Label>
    <br />
    <br />
    <asp:Label ID="LabelDeactivation" runat="server" Text="Employee deactivation : "></asp:Label>
    <asp:Button ID="BtnDeactivation" runat="server" Text="Deactivation" OnClick="BtnDeactivation_Click" />
    <br />
    <br />
    <br />
    <asp:Button ID="BtnEditStatusEmp" runat="server" Text="Confirm" OnClick="BtnEditStatusEmp_Click" />
    <asp:Button ID="BtnCancel" runat="server" Text="Cancel" OnClick="BtnCancel_Click" />
    <br />

</asp:Content>
