<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditUserStatus.aspx.cs" Inherits="GUI.Pages.AdministratorPages.UserManagementPages.EditUserStatus"MasterPageFile="~/Site.Master"
Title="MedicalClinic-Edit User Status" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"> 
    <div class="user-add-page-div">
        <div>
            <asp:Label ID="Label1" runat="server" Text=" "></asp:Label>
            <br>
            <asp:Button ID="BtnAccept" CssClass="btn-usr-mngmt-pg" runat="server" OnClick="BtnAccept_Click" Text="Accept" />
            <asp:Button ID="BtnCancel" CssClass="btn-usr-mngmt-pg" runat="server" OnClick="BtnCancel_Click" Text="Cancel" />
        </div>
   <div style="margin-top:15px;">
</div>
</div>
</asp:Content>
