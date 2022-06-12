<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserEditPage.aspx.cs" Inherits="GUI.Pages.AdministratorPages.UserManagementPages.UserEditPage"MasterPageFile="~/Site.Master"
Title="MedicalClinic-User Edit" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"> 
    <div class="settings-panel-page">
        <div>
            <asp:Label ID="LbLogin" CssClass="edit-page-h" runat="server" Text="Login"></asp:Label><br />
            <asp:TextBox ID="TbLogin" CssClass="edit-page-btn" runat="server" Enabled="False"></asp:TextBox>
        </div>
        <asp:Label ID="LbPassword" CssClass="edit-page-h" runat="server" Text="Change Password:"></asp:Label><br />
        <asp:Button ID="Btnpass" CssClass="edit-page-btn" runat="server" OnClick="Btnpass_Click" Text="Password" />
        <br />        
        <div>
            <asp:Label ID="LbStatus" CssClass="edit-page-h" runat="server" Text="Status"></asp:Label><br>
            <asp:Button ID="Btnstatus" CssClass="edit-page-btn" runat="server" Text="Btn" OnClick="Btnstatus_Click" />
        </div>
        <div>
            <asp:Button ID="BtnAccept" CssClass="btn-usr-mngmt-pg" runat="server" OnClick="BtnAccept_Click" Text="Save" />
            <asp:Button ID="Btncancel" CssClass="btn-usr-mngmt-pg" runat="server" Text="Cancel" OnClick="Btncancel_Click" />
        </div>
        <div>
            <asp:Label ID="LabelCriteria" runat="server" ></asp:Label>
        </div>
           
</div>

</asp:Content>
 
