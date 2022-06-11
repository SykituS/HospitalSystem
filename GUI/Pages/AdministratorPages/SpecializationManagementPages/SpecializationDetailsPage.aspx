<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="SpecializationDetailsPage.aspx.cs" Inherits="GUI.Pages.AdministratorPages.SpecializationManagementPages.SpecializationDetailsPage"Title="MedicalClinic-Specialization Details" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="spec-mng-pg-div">
        <h2 style="margin-bottom: 40px">New specialization</h2>
        <asp:Label ID="Label1" runat="server" Text="Name of specialization"></asp:Label><br/>
        <asp:Label ID="LabelWaring" runat="server" Text="Warning" ForeColor="#990000" Visible="False"></asp:Label>
        <asp:TextBox ID="TBName" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="BtnSave" CssClass="btn-usr-mngmt-pg" runat="server" Text="Save" OnClick="BtnSave_Click" />
        <asp:Button ID="BtnCancel" CssClass="btn-usr-mngmt-pg" runat="server" Text="Cancel" OnClick="BtnCancel_Click" />
    </div>
</asp:Content>