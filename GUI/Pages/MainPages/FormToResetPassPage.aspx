<%@ Page Title="Form" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"  CodeBehind="FormToResetPassPage.aspx.cs" Inherits="GUI.FormToResetPassPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style="margin: 15px;">
        
        <asp:Label ID="Label1" runat="server" Text="Login:"></asp:Label>
        <asp:TextBox ID="TBLogin" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Email:"></asp:Label>
        <asp:TextBox ID="TBEmail" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="LabelSendInfo" runat="server" Text="PlaceHolder" Visible="False"></asp:Label>
        <br />
        <br />

        <div>
         <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick" ></asp:Timer>
        
           <asp:UpdatePanel ID="update" runat="server" Mode="Conditional">
               <ContentTemplate>
                 <asp:Button ID="BtnOk" runat="server" OnClick="BtnOk_Click" Text="Ok" Enabled="False" />
                 <asp:Button ID="BtnCancel" runat="server" OnClick="BtnCancel_Click" Text="Cancel" />
               </ContentTemplate>
               <Triggers>
                   <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="tick" />
               </Triggers>
           </asp:UpdatePanel> 
        </div>
        <br />

    </div>

</asp:Content>

