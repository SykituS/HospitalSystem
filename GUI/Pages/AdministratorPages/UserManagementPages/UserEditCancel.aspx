﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserEditCancel.aspx.cs" Inherits="GUI.Pages.AdministratorPages.UserManagementPages.UserEditSave" MasterPageFile="~/Site.Master"
Title="User Edit Cancel"%>
  

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">  <div style="margin-top:15px;">
        <div>
            <asp:Label ID="Lbquestion" runat="server" Text="Label"></asp:Label><br></br>
            <asp:Button ID="Btnaccept" runat="server" OnClick="Btnaccept_Click" Text="Accept" />
            <asp:Button ID="Btncancel" runat="server" OnClick="Btncancel_Click" Text="Cancel" />
        </div>
</div>

</asp:Content>