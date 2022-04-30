<%@ Page Title="User Management" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="UserManagementPage.aspx.cs" Inherits="GUI.Pages.AdministratorPages.UserManagement.UserManagementPage" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style="margin-top:15px">

        <asp:Button ID="BtnBack" runat="server" Text="Back to menu" />
        <br />
        <asp:Button ID="BtnAddNewUser" runat="server" Text="Add new user" />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Filter by:"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="First name:   "></asp:Label>
        <asp:TextBox ID="TBNameFirst" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Second name:   "></asp:Label>
        <asp:TextBox ID="TBNameSecond" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Position:   "></asp:Label>
        <asp:DropDownList ID="DropDownListPosition" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        <asp:GridView ID="GridViewUsers" runat="server" OnSelectedIndexChanged="GridViewUsers_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="User name" DataField="US_Login" />
                <asp:BoundField HeaderText="First name" DataField="EM_Name" />
                <asp:BoundField HeaderText="Second Name" DataField="EM_Second_Name" NullDisplayText=" " />
                <asp:BoundField HeaderText="Position" DataField="PO_Name" />
                <asp:ButtonField DataTextField="St_Status_Name" HeaderText="Active status" Text="Active" />
                <asp:ButtonField Text="Edit user" />
            </Columns>
        </asp:GridView>
        <br />
        <br />
        <br />

    </div>

</asp:Content>