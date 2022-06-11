<%@ Page Title="MedicalClinic-Specialization Management" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="SpecializationManagementPage.aspx.cs" Inherits="GUI.Pages.AdministratorPages.SpecializationManagementPages.SpecializationManagementPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="spec-mng-pg-div">
        <h2>Specialization Management</h2>
        
        <br />
        <br />
        <asp:GridView ID="GridViewSpecialization" CssClass="tb-user-detail" runat="server" AutoGenerateColumns="False" OnRowCommand="GridViewSpecialization_RowCommand">
            <Columns>
                <asp:BoundField DataField="ID_Specialisation" HeaderText="ID" />
                <asp:BoundField DataField="Name" HeaderText="Specialization name" />
                <asp:ButtonField HeaderText="Edit specialization" Text="Edit" CommandName="Edit"/>
                <asp:ButtonField HeaderText="Delete specialization" Text="Delete" CommandName="Delete"/>
            </Columns>
        </asp:GridView>
        <asp:Button ID="Button1" CssClass="btn-usr-mngmt-pg" runat="server" Text="Back to menu" OnClick="BtnBackToMenu_Click" />
        <asp:Button ID="Button2" CssClass="btn-usr-mngmt-pg" runat="server" Text="Add new specialization" OnClick="BtnAddNewSpecialization_Click" />
    </div>
</asp:Content>
