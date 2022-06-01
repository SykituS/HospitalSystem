<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditUserPass.aspx.cs" Inherits="GUI.Pages.AdministratorPages.UserManagementPages.EditUserPass"MasterPageFile="~/Site.Master"
Title="Edit User Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div style="margin-top:15px;">
        <div>
            <asp:Label ID="Label1" runat="server" Text="New Password"></asp:Label><br>
            <asp:TextBox ID="Tbnewpass" runat="server" Width="119px" TextMode="Password"></asp:TextBox>
        </div>
        <br><asp:Label ID="Label2" runat="server" Text="Confirm Password"></asp:Label><br>
        <asp:TextBox ID="Tbconpass" runat="server" Height="22px" TextMode="Password"></asp:TextBox>
        <p>
            <asp:Button ID="BtnSave" runat="server" Text="Save" OnClick="Button1_Click" />
            <asp:Button ID="BtnCancel" runat="server" Text="Cancel" OnClick="Button2_Click" />
            <p>
            <asp:Label ID="LabelCriteria" runat="server"></asp:Label>
        </p>

        </div>

</asp:Content>