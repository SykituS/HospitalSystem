<%@ Page Title="User add" Language="C#" AutoEventWireup="true" CodeBehind="UserAddPage.aspx.cs" MasterPageFile="~/Site.Master" Inherits="GUI.Pages.AdministratorPages.UserManagementPages.UserAddPage" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style="margin-top:15px">

            <asp:Label ID="Label1" runat="server" Text="Select employee"></asp:Label>
            <asp:DropDownList ID="DropDownList" runat="server" AutoPostBack="true" >
            </asp:DropDownList>
        </div>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="BtnAddNewUser" runat="server" Text="Add new user" OnClick="BtnAddNewUser_Click" />
            <asp:Button ID="Button2" runat="server" Text="Cancel" OnClick="Button2_Click" />
        </p>
    
    </div>

</asp:Content>