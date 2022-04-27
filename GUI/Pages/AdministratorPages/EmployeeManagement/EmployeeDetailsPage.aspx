<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeDetailsPage.aspx.cs" Inherits="GUI.EmployeeDetailsPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:DetailsView ID="DetailsViewEmployee" runat="server" Height="50px" Width="125px" AutoGenerateRows="False">
        <Fields>
            <asp:BoundField HeaderText="Name" DataField="EM_Name" />
            <asp:BoundField HeaderText="Surname" DataField="EM_Surname" />
            <asp:BoundField HeaderText="E-mail" DataField="EM_Email" />
            <asp:BoundField HeaderText="PESEL" DataField="EM_Pesel" />
            <asp:BoundField HeaderText="Date of Birth" DataField="EM_Date_of_birth" DataFormatString="{0:dd-MM-yyyy}" />
            <asp:BoundField HeaderText="Correspondence address" DataField="EM_Correspondence_address" />
            <asp:BoundField HeaderText="Phone number" DataField="EM_Phone_number" />
            <asp:BoundField HeaderText="Sex" DataField="Sx_Sex" />
        </Fields>
    </asp:DetailsView>
    <br />
    <asp:Button ID="BtnEditEmp" runat="server" Text="Edit employee" OnClick="BtnEditEmp_Click" />
    <br />
    <br />
    <asp:Button ID="BtnCancel" runat="server" OnClick="BtnCancel_Click" Text="Cancel" />
</asp:Content>
