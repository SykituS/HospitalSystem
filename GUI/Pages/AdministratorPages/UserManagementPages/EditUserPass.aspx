<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditUserPass.aspx.cs" Inherits="GUI.Pages.AdministratorPages.UserManagementPages.EditUserPass"MasterPageFile="~/Site.Master"
Title="Edit User Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="user-add-page-div">
        <h3 >Password change</h3>
        <div>
            <asp:Label ID="Label1" runat="server" Text="New Password"></asp:Label><br>
            <asp:TextBox ID="Tbnewpass" runat="server" Width="119px" TextMode="Password"></asp:TextBox>
        </div>
        <br><asp:Label ID="Label2" runat="server" Text="Confirm Password"></asp:Label><br>
        <asp:TextBox ID="Tbconpass" runat="server" Height="22px" TextMode="Password"></asp:TextBox>
        <p>
            <asp:Button ID="BtnSave"  CssClass="btn-usr-mngmt-pg" runat="server" Text="Save" OnClick="Button1_Click" Height="30px" Width="200px" />
            <asp:Button ID="BtnCancel" CssClass="btn-usr-mngmt-pg" runat="server" Text="Cancel" OnClick="Button2_Click" EnableTheming="True" />
            <p>
            <asp:Label ID="LabelCriteria" runat="server"></asp:Label>
        </p>

        </div>

</asp:Content>