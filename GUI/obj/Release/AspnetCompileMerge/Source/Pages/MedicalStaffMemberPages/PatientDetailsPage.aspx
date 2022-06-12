<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PatientDetailsPage.aspx.cs" Inherits="GUI.Pages.MedicalStaffMemberPages.PatientDetailsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <br />
    <div class="user-add-page-div">

    <asp:DetailsView ID="Gv_PatientDetails" runat="server" Height="50px" Width="125px" AutoGenerateRows="False">
        <Fields>
                <asp:BoundField DataField="Name" HeaderText="Name"/>
                <asp:BoundField DataField="Surname" HeaderText="Surname"/>
                <asp:BoundField DataField="Pesel" HeaderText="PESEL" />
                <asp:BoundField DataField="Date_of_birth" HeaderText="Date of birth" DataFormatString ="{0:dd-MM-yyyy}" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="Phone_number" HeaderText="Phone number" />
                <asp:BoundField DataField="Correspondence_adress" HeaderText="Correspondence adress" />
                <asp:BoundField DataField="St_Status_Name" HeaderText="Status" />

               
        </Fields>
    </asp:DetailsView>

    <p>

    <br />
        </p>

   <p>
    <asp:Button ID="Btn_cancel_edit" cssClass="btn-usr-mngmt-pg" runat="server" Text="Cancel" OnClick="Btn_cancel_edit_Click" />
    </p>
</div>
</asp:Content> 