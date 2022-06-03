<%@ Page Title="Specialization" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="SpecializationManagementPage.aspx.cs" Inherits="GUI.Pages.AdministratorPages.SpecializationManagementPages.SpecializationManagementPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-top: 15px;">

        <asp:Button ID="BtnBackToMenu" runat="server" Text="Button" />
        <asp:Button ID="BtnAddNewSpecialization" runat="server" Text="Button" />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Name" HeaderText="Specialization name" />
                <asp:ButtonField HeaderText="Edit specialization" Text="Przycisk" />
                <asp:ButtonField HeaderText="Delete specialization" Text="Przycisk" />
            </Columns>
        </asp:GridView>

    </div>
</asp:Content>
