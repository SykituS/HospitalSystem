<%@ Page Title="Form" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResetPassPage.aspx.cs" Inherits="GUI.ResetPassPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <h3>Change password!</h3><br />
        <asp:Label ID="LabelInfo" runat="server" Text="labelLoginInfo"></asp:Label>
        <br />
        <asp:TextBox ID="TBNewPass" runat="server"></asp:TextBox> 
        <br />
        <asp:TextBox ID="TBConfirmNewPass" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="BtnOk" runat="server" Text="OK" OnClick="BtnOk_Click" />
        <asp:Button ID="BtnCancel" runat="server" Text="Cancel" />

    </div>

</asp:Content>

