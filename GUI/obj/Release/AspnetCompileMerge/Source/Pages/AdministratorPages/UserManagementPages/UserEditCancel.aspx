<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserEditCancel.aspx.cs" Inherits="GUI.Pages.AdministratorPages.UserManagementPages.UserEditSave" MasterPageFile="~/Site.Master"
Title="MedicalClinic-User Edit Cancelation"%>
  

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server"> 
    <div class="user-add-page-div">
        <div>
            <asp:Label ID="Lbquestion" runat="server" Text="Label"></asp:Label><br></br>
            <asp:Button ID="Btnaccept" CssClass="btn-usr-mngmt-pg" runat="server" OnClick="Btnaccept_Click" Text="Accept" />
            <asp:Button ID="Btncancel" CssClass="btn-usr-mngmt-pg" runat="server" OnClick="Btncancel_Click" Text="Cancel" />
        </div>
</div>

</asp:Content>