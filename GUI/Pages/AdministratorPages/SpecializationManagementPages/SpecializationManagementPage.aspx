<%@ Page Title="Specialization" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="SpecializationManagementPage.aspx.cs" Inherits="GUI.Pages.AdministratorPages.SpecializationManagementPages.SpecializationManagementPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-top: 15px;">

        <asp:Button ID="BtnBackToMenu" runat="server" Text="Back to menu" OnClick="BtnBackToMenu_Click" />
        <asp:Button ID="BtnAddNewSpecialization" runat="server" Text="Add new specialization" OnClick="BtnAddNewSpecialization_Click" />
        <br />
        <br />
        <asp:GridView ID="GridViewSpecialization" runat="server" AutoGenerateColumns="False" OnRowCommand="GridViewSpecialization_RowCommand">
            <Columns>
                <asp:BoundField DataField="ID_Specialisation" HeaderText="ID" />
                <asp:BoundField DataField="Name" HeaderText="Specialization name" />
                <asp:ButtonField HeaderText="Edit specialization" Text="Edit" CommandName="Edit"/>
                <asp:ButtonField HeaderText="Delete specialization" Text="Delete" CommandName="Delete"/>
            </Columns>
        </asp:GridView>

    </div>
</asp:Content>
