<%@ Page Title="MedicalClinic-Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GUI._Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumptron">
    <asp:HiddenField runat="server" ID="_repostcheckcode" />
        <div class="top-side"><!-- <img src="../../img/img1.jpg" alt="picture" /> --></div>
        <div class="bot-side">
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

        <asp:Label ID="LabelWarnings" runat="server" ForeColor="Red" Text="Waringin placeholder" Visible="False"></asp:Label>
           <br />

        <asp:Label ID="LabelWarAct" runat="server" ForeColor="Red" Text="Waringin placeholder" Visible="False"></asp:Label><br />
        Login  <br />
        <asp:TextBox ID="TBLogin" CssClass="field" runat="server" MaxLength="100"></asp:TextBox>
        <br />
        Password  <br />
        <asp:TextBox ID="TBPassword" CssClass="field" runat="server" TextMode="Password" MaxLength="100"></asp:TextBox>
        <br />
          <br />
           <div id="Reset">
            <asp:Button ID="Button1" CssClass="psswrd" runat="server" Text="Forgot password" OnClick="BtnResetPassword_Click" UseSubmitBehavior="False" />
        </div>
        <asp:Button ID="BtnLogin" CssClass="btn" runat="server" OnClick="BtnLogin_Click" Text="Login" />
        
        <asp:Button ID="BtnCancel" CssClass="btn" runat="server" Text="Cancel" OnClick="BtnCancel_Click" />
       </div>

        </div>
    </div>

    </asp:Content>
