<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserEditPage.aspx.cs" Inherits="GUI.Pages.AdministratorPages.UserManagementPages.UserEditPage"MasterPageFile="~/Site.Master"
Title="UserEditPage" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"> 
    <div style="margin-top:15px;">
        <div>
            <asp:Label ID="LbLogin" runat="server" Text="Login"></asp:Label><br>
            <asp:TextBox ID="TbLogin" runat="server" Enabled="False"></asp:TextBox>
        </div>
        <asp:Label ID="LbPassword" runat="server" Text="Change Password:"></asp:Label><br>
        <asp:Button ID="Btnpass" runat="server" OnClick="Btnpass_Click" Text="Password" />
        <p>
            &nbsp;</p>
        <p>
            <asp:Label ID="LbStatus" runat="server" Text="StatusL"></asp:Label><br>
            <asp:Button ID="Btnstatus" runat="server" Text="Btn" OnClick="Btnstatus_Click" />
        </p>
        <p>
            <asp:Button ID="BtnAccept" runat="server" OnClick="BtnAccept_Click" Text="Save" />
            <asp:Button ID="Btncancel" runat="server" Text="Cancel" OnClick="Btncancel_Click" />
        </p>
        <p>
            <asp:Label ID="LabelCriteria" runat="server" ></asp:Label>
        </p>
           
</div>

</asp:Content>
 
