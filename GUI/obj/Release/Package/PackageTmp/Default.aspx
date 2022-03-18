<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GUI._Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumptron">
    <asp:HiddenField runat="server" ID="_repostcheckcode" />
        
      <h3>Sign in</h3> 
        <br />
       <div id="login">
        <asp:Label ID="LabelWarnings" runat="server" ForeColor="Red" Text="Waringin placeholder" Visible="False"></asp:Label><br />
        Login  <br />
        <asp:TextBox ID="TBLogin" runat="server"></asp:TextBox>
        <br />
        Password  <br />
        <asp:TextBox ID="TBPassword" runat="server" TextMode="Password"></asp:TextBox>
        <br />
          <br />

        <asp:Button ID="BtnLogin" runat="server" OnClick="BtnLogin_Click" Text="Login" />
        
        <asp:Button ID="BtnCancel" runat="server" OnClick="BtnCancel_Click" Text="Cancel" />
       </div>

        <div id="Reset">
            <asp:Button ID="BtnResetPassword" runat="server" Text="Forgot password" OnClick="BtnResetPassword_Click" />
        </div>
    </div>

    </asp:Content>
