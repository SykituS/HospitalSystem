<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GUI._Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumptron">
        
      <h3>Sign in</h3> 
        <asp:Label ID="LabelWarnings" runat="server" ForeColor="Red" Text="Sing in" Visible="False"></asp:Label>
        <br />
       <div id="login">
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
    </div>

    </asp:Content>
