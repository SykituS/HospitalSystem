<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CalendarPage.aspx.cs" Inherits="GUI.CalendarPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        Filter by day: 
    <asp:DropDownList ID="DdlFilterDays" runat="server" OnSelectedIndexChanged="DdlFilterDays_SelectedIndexChanged" AutoPostBack="True">
        <asp:ListItem Value="0">All</asp:ListItem>
    </asp:DropDownList>

    <br />

    <div style="overflow-y: scroll; height: 300px; width: 250px;">
        <asp:GridView ID="GvCalendar" runat="server">
        </asp:GridView>
    </div>

    <br />

    Month: <asp:DropDownList ID="DdlMonths" runat="server">
        <asp:ListItem Value="1">January</asp:ListItem>
        <asp:ListItem Value="2">February</asp:ListItem>
        <asp:ListItem Value="3">March</asp:ListItem>
        <asp:ListItem Value="4">April</asp:ListItem>
        <asp:ListItem Value="5">May</asp:ListItem>
        <asp:ListItem Value="6">June</asp:ListItem>
        <asp:ListItem Value="7">July</asp:ListItem>
        <asp:ListItem Value="8">August</asp:ListItem>
        <asp:ListItem Value="9">September</asp:ListItem>
        <asp:ListItem Value="10">October</asp:ListItem>
        <asp:ListItem Value="11">November</asp:ListItem>
        <asp:ListItem Value="12">December</asp:ListItem>

    </asp:DropDownList>
    <br />
    <br />
    Year: <asp:DropDownList ID="DdlYears" runat="server"></asp:DropDownList>
    <br />
    <br />
    <asp:Button ID="BtnGenerate" runat="server" Text="Generate" OnClick="BtnGenerate_Click" />
        <br />
        <br />
        <asp:Button ID="BtnBackToMain" runat="server" OnClick="BtnBackToMain_Click" Text="Back to main page" />
</asp:Content>
