<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserDetailsPage.aspx.cs" Inherits="GUI.Pages.AdministratorPages.UserManagementPages.UserDetailsPage" 
MasterPageFile="~/Site.Master"
Title="MedicalClinic-User Details"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="user-add-page-div">
        <asp:GridView CssClass="tb-user-detail" ID="GridViewUsers" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Name &amp; Surname" />
                <asp:BoundField DataField="US_login" HeaderText="Login" />
                <asp:BoundField DataField="St_Status_Name" HeaderText="Status" />
                <asp:BoundField DataField="Po_Name" HeaderText="Position" />
            </Columns>
        </asp:GridView>
        <div>
        </div>
        <asp:Button CssClass="btn-logout-page" ID="Btneddit" runat="server" OnClick="Btneddit_Click" Text="Edit" />
        <asp:Button CssClass="btn-logout-page" ID="Btncancel" runat="server" OnClick="Btncancel_Click" Text="Cancel" />
</div>

</asp:Content>
