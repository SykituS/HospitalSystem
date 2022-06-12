<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeReactivationPage.aspx.cs" Inherits="GUI.Pages.AdministratorPages.EmployeeManagement.EmployeeReactivationPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:Label ID="LabReactivation" runat="server" Text="Reactivation" Font-Size="Large"></asp:Label>
    <br />
    <br />
    <asp:Label ID="LabelReactivation" runat="server" Text="Employee reactivation : "></asp:Label>
    <asp:Button ID="BtnReactivation" runat="server" Text="Reactivation" OnClick="BtnReactivation_Click" />
    <br />
    <br />
    <br />
    <asp:Button ID="BtnEditStatusEmp" runat="server" Text="Confirm" OnClick="BtnEditStatusEmp_Click" />
    <asp:Button ID="BtnCancel" runat="server" Text="Cancel" OnClick="BtnCancel_Click" />

</asp:Content>
