<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GUI._Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumptron">
    <asp:HiddenField runat="server" ID="_repostcheckcode" />
        
      <h3>Sign in</h3> 
        <br />

       <div id="login">
        <div>
         <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick" ></asp:Timer>
        
           <asp:UpdatePanel ID="update" runat="server" Mode="Conditional">
               <ContentTemplate>
                 
                   <asp:Literal ID="litMsg" runat="server"></asp:Literal>
               </ContentTemplate>
               <Triggers>
                   <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="tick" />
               </Triggers>
           </asp:UpdatePanel> 
        </div>

        <asp:Label ID="LabelWarnings" runat="server" ForeColor="Red" Text="Waringin placeholder" Visible="False"></asp:Label><br />
        Login  <br />
        <asp:TextBox ID="TBLogin" runat="server"></asp:TextBox>
        <br />
        Password  <br />
        <asp:TextBox ID="TBPassword" runat="server" TextMode="Password"></asp:TextBox>
        <br />
          <br />

        <asp:Button ID="BtnLogin" runat="server" OnClick="BtnLogin_Click" Text="Login" />
        
        <asp:Button ID="BtnCancel" runat="server" Text="Cancel" OnClientClick="window.close(); return false" />
       </div>

        <div id="Reset">
            <asp:Button ID="BtnResetPassword" runat="server" Text="Forgot password" OnClick="BtnResetPassword_Click" />
        </div>
    </div>

    </asp:Content>
