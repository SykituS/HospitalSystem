<%@ Page Title="MedicalClinic-Reset Password" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"  CodeBehind="FormToResetPassPage.aspx.cs" Inherits="GUI.FormToResetPassPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-to-reset-password">
        <h3 id="form-pass-page-header">Password change</h3>
        
        <asp:Label ID="Label1" runat="server" Text="Login:"></asp:Label>
        <asp:TextBox ID="TBLogin" runat="server" MaxLength="100"></asp:TextBox>
        <br /><br />
        <asp:Label ID="Label2" runat="server" Text="Email:"></asp:Label>
        <asp:TextBox ID="TBEmail" runat="server" OnTextChanged="TBEmail_TextChanged" AutoPostBack="true" MaxLength="100"></asp:TextBox>
        <br />
        <br />

        <div>
        <asp:Label ID="LabelSendInfo" runat="server" Text="The e-mail has been sent. Please check your mailbox." Visible="False"></asp:Label>
        <br />
        <br />
        <asp:Button ID="BtnOk" CssClass="btn" runat="server" OnClick="BtnOk_Click" Text="Ok" Enabled="False" />
        <asp:Button ID="BtnCancel" CssClass="btn" runat="server" OnClick="BtnCancel_Click" Text="Cancel" />
        </div>
        <br />

    </div>

</asp:Content>

