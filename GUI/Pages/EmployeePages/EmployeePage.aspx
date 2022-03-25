<%@ Page Title="Employee Panel" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EmployeePage.aspx.cs" Inherits="GUI.EmployeePage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>

        <asp:Label ID="LabelPostion" runat="server" Text="<h1>PlaceHolder position</h1>"></asp:Label>
        <br />
        <asp:Button ID="BtnUserList" runat="server" Text="View calendar" />
        <br />
        <br />
        <asp:Button ID="BtnDoctorPage" runat="server" Text="Doctor Page (Appoiment View)" OnClick="BtnDoctorPage_Click" />
        <br />
        <br />
        <asp:Button ID="BtnLogout" runat="server" Text="Logout" OnClick="BtnLogout_Click" />

    </div>

</asp:Content>