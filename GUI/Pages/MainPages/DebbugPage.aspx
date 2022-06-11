<%@ Page Title="MedicalClinic-Confirm cancelation" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DebbugPage.aspx.cs" Inherits="GUI.Pages.MainPages.DebbugPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:HiddenField runat="server" ID="_repostcheckcode" />
    <div style ="margin:15px;">

        <asp:GridView ID="GVUsers" runat="server" Width="200px" AutoGenerateColumns="False" OnSelectedIndexChanged="GVUsers_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="Login" DataField="us_login"/>
                <asp:BoundField HeaderText="Email" DataField="EM_Email"/>
                <asp:BoundField HeaderText="isDuringReset" DataField="US_isDuringReset"/>
                <asp:BoundField HeaderText="US_PassResetActiveTime" DataField="US_PassResetActiveTime"/>
                <asp:ButtonField CommandName="Select" HeaderText="GetDefaultData" ShowHeader="True" Text="Przycisk" />
            </Columns>
        </asp:GridView>

        <br />
        <asp:Label ID="LabelSelectTimeToUnlock" runat="server" Text="Label"></asp:Label>
        <br />
        <br />

        <asp:Label ID="Label1" runat="server" Text="Login:" style="margin: 15px;"></asp:Label>
        <asp:TextBox ID="TBlogin" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Email:" style="margin: 15px;"></asp:Label>
        <asp:TextBox ID="TBEmail" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:CheckBox ID="CheckBoxIsDuringReset" runat="server" style="margin: 15px;"/>
        <br />
        <br />
        <asp:TextBox ID="TBDate" runat="server" TextMode="DateTime" Width="207px" style="margin: 15px;"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="BtnSendUpdate" runat="server" OnClick="BtnSendUpdate_Click" Text="Update" style="margin: 15px;"/>
        <br />
        <br />
        <asp:Label ID="LabelInfo" runat="server" Text="Label"></asp:Label>

    </div>

</asp:Content>
