<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserEditPage.aspx.cs" Inherits="GUI.Pages.AdministratorPages.UserManagementPages.UserEditPage"MasterPageFile="~/Site.Master"
Title="UserEditPage" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"> 
    <div style="margin-top:15px;">
        <div>
            <asp:Label ID="LbLogin" runat="server" Text="Login"></asp:Label>
            <asp:TextBox ID="TbLogin" runat="server" Enabled="False"></asp:TextBox>
        </div>
        <asp:Label ID="LbPassword" runat="server" Text="New Password"></asp:Label>
        <asp:TextBox ID="TbNewPass" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="LbConfirmPass" runat="server" Text="Confirm Password"></asp:Label>
            <asp:TextBox ID="TbConfirmPass" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="LbStatus" runat="server" Text="Status"></asp:Label>
            <asp:Button ID="Btnstatus" runat="server" Text="Btn" Width="169px" OnClick="Btnstatus_Click" />
        </p>
        <p>
            <asp:Button ID="BtnAccept" runat="server" OnClick="BtnAccept_Click" Text="Accept" />
            <asp:Button ID="Btncancel" runat="server" Text="Cancel" OnClick="Btncancel_Click" />
        </p>
        <p>
            <asp:Label ID="LabelCriteria" runat="server" ></asp:Label>
        </p>
           
</div>

</asp:Content>
 
