<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OfficesManagementPage.aspx.cs" Inherits="GUI.OfficesManagementPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:GridView ID="GvOffices" runat="server" AutoGenerateColumns="false" OnRowCommand="GvOffices_RowCommand" >
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="Of_id_office" Visible="false" />
            <asp:BoundField HeaderText="Room" DataField="Of_office_number" />
            <asp:BoundField HeaderText="Status" DataField="Of_status" />
            <asp:BoundField HeaderText="Plenary" DataField="Of_plenary" />
            <asp:BoundField HeaderText="Specialisation" DataField="Name" />
            <asp:ButtonField ButtonType="Button" HeaderText="Edit" Text="Edit" CommandName="Edit" />
            <asp:ButtonField ButtonType="Button" HeaderText="Delete" Text="Delete" CommandName="Delete" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Button ID="BtnAddNewOffice" runat="server" OnClick="BtnAddNewOffice_Click" Text="Add new office" />
    <br />
    <asp:Button ID="BtnBackToMain" runat="server" OnClick="BtnBackToMain_Click" Text="Back to main page" />
</asp:Content>
