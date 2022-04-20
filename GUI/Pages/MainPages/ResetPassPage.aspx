<%@ Page Title="Form" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResetPassPage.aspx.cs" Inherits="GUI.ResetPassPage" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style="margin:25px; padding:10px;">
        <h3>Change password!</h3><br />
        <asp:Label ID="LabelInfo" runat="server" Text="labelLoginInfo"></asp:Label>
        <br /><br />
        <div>New password: </div><asp:TextBox ID="TBNewPass" runat="server" TextMode="Password"></asp:TextBox> 
        <br />
        <div>Confirm password: </div><asp:TextBox ID="TBConfirmNewPass" runat="server" TextMode="Password"></asp:TextBox>
        <br />

        <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick" ></asp:Timer>
    
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" Mode="Conditional">
            <ContentTemplate>
                <br />
                <asp:Label ID="LabelCriteria" runat="server" Text=""></asp:Label>
                <br /> <br />
                <asp:Button ID="BtnOk" runat="server" Text="OK" OnClick="BtnOk_Click" Enabled="False" />
                <asp:Button ID="BtnCancel" runat="server" Text="Cancel" OnClick="BtnCancel_Click" />
                <br />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="tick" />
            </Triggers>
        </asp:UpdatePanel> 
    </div>

</asp:Content>

