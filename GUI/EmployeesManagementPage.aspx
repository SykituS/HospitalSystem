﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeesManagementPage.aspx.cs" Inherits="GUI.EmployeesManagementPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        &nbsp;</p>
    <p>
        Filter by role:
        <asp:DropDownList ID="DdlRoles" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlRoles_SelectedIndexChanged" AppendDataBoundItems="True">
            <asp:ListItem Text="All" Value="ALL"></asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        Filter by status:
        <asp:DropDownList ID="DdlStatus" runat="server" OnSelectedIndexChanged="DdlStatus_SelectedIndexChanged" AutoPostBack="True">
            <asp:ListItem Text="All" Value="ALL"></asp:ListItem>
            <asp:ListItem Text="Active" Value="1"></asp:ListItem>
            <asp:ListItem Text="Inactive" Value="2"></asp:ListItem>
        </asp:DropDownList>
    </p>
<div style="overflow-y: scroll; height: 200px; width: 600px;">
    <p>
        <asp:GridView ID="GvEmployees" runat="server" AllowSorting="True" OnSorting="GvEmployees_Sorting" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="EM_Id_Employee" SortExpression="EM_Id_Employee" />
                <asp:BoundField HeaderText="Name" DataField="EM_Name" SortExpression="EM_Name" />
                <asp:BoundField HeaderText="Surname" DataField="EM_Surname" SortExpression="EM_Surname" />
                <asp:BoundField HeaderText="PESEL" DataField="EM_Pesel" SortExpression="EM_Pesel" />
                <asp:BoundField HeaderText="Date of Birth" DataField="EM_Date_of_birth" SortExpression="EM_Date_of_birth" DataFormatString="{0:dd-MM-yyyy}" />
                <asp:BoundField HeaderText="Role" DataField="PO_Name" SortExpression="PO_Name" />
                <asp:BoundField HeaderText="Status" DataField="St_Status_Name" SortExpression="St_Status_Name" />
            </Columns>
        </asp:GridView>
    </p>
</div>
    <p>
        <br />
        <asp:Button ID="BtnAddEmployee" runat="server" Text="Add new employee" />

    </p>
    <p>
        &nbsp;</p>

</asp:Content>
