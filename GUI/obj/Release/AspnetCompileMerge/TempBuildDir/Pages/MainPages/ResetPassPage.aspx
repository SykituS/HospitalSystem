<%@ Page Title="MedicalClinic - Reset Password" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResetPassPage.aspx.cs" Inherits="GUI.ResetPassPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-to-reset-password">
        
        <h3  id="form-pass-page-header">Change password!</h3>
         <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick" ></asp:Timer>
        
        <br />
        <asp:Label ID="LabelInfo" runat="server" Text="labelLoginInfo"></asp:Label>
        <br /><br />
        <div>New password: </div><asp:TextBox ID="TBNewPass" runat="server" TextMode="Password" ></asp:TextBox> 
        <br /><br />
        <div>Confirm password: </div><asp:TextBox ID="TBConfirmNewPass" runat="server" TextMode="Password" ></asp:TextBox>
        <br />
        <br />
        

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Label ID="LabelCriteria" runat="server" Text=""></asp:Label><br />
                <asp:Button ID="BtnOk" CssClass="btn" runat="server" Text="OK" OnClick="BtnOk_Click" Enabled="False"/>
                <asp:Button ID="BtnCancel" CssClass="btn" runat="server" Text="Cancel" OnClick="BtnCancel_Click" />
                <br /><br />
            </ContentTemplate>
            <Triggers>
                   <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="tick" />
            </Triggers>
        </asp:UpdatePanel>
    </div>

</asp:Content>
  
