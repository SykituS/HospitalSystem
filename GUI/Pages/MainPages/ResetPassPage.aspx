<%@ Page Title="Form" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResetPassPage.aspx.cs" Inherits="GUI.ResetPassPage" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style="margin:25px; padding:10px;">
        <h3>Change password!</h3><br />
        <asp:Label ID="LabelInfo" runat="server" Text="labelLoginInfo"></asp:Label>
        <br /><br />
        <div>New password: </div><asp:TextBox ID="TBNewPass" runat="server"></asp:TextBox> 
        <br />
        <div>Confirm password: </div><asp:TextBox ID="TBConfirmNewPass" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="BtnOk" runat="server" Text="OK" OnClick="BtnOk_Click" />
        <asp:Button ID="BtnCancel" runat="server" Text="Cancel" />
        <br />
    </div>

</asp:Content>

