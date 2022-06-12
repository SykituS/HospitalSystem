<%@ Page Title="MedicalClinic -Adding User" Language="C#" AutoEventWireup="true" CodeBehind="UserAddPage.aspx.cs" MasterPageFile="~/Site.Master" Inherits="GUI.Pages.AdministratorPages.UserManagementPages.UserAddPage" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="user-add-page-div">

            <asp:Label ID="Label1" runat="server" Text="Select employee"></asp:Label>
            <asp:DropDownList ID="DropDownList" runat="server" AutoPostBack="true" >
            </asp:DropDownList>

        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="BtnAddNewUser" CssClass="btn" runat="server" Text="Add new user" OnClick="BtnAddNewUser_Click" />
            <asp:Button ID="Button2" CssClass="btn" runat="server" Text="Cancel" OnClick="Button2_Click" />
        </p>
    
    </div>

</asp:Content>