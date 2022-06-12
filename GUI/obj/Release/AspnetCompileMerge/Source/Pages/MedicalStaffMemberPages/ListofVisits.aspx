<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListofVisits.aspx.cs" Inherits="GUI.Pages.MedicalStaffMemberPages.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div Class="spec-mng-pg-div">
    <asp:Button ID="Btn_back" CssClass="btn-usr-mngmt-pg" runat="server" style="left: 0px; top: 2px" Text="Back to panel" OnClick="Btn_back_Click" />
    <br />
    <asp:Button ID="Btn_addvisit" CssClass="btn-usr-mngmt-pg" runat="server" OnClick="Btn_addvisit_Click" Text="Add an appointment" />
    <asp:Button ID="Btn_filter" CssClass="btn-usr-mngmt-pg" runat="server" OnClick="Btn_filter_Click" Text="Filter" />
    <br />
    
    <br />
    Filter by patient:<asp:TextBox ID="Tbx_patient" runat="server"></asp:TextBox>
    <br />
    <br />
    Filter by PESEL:<asp:TextBox ID="Tbx_pesel" runat="server"></asp:TextBox>
    <br />
    <br />
    Filter by date of visit:<asp:TextBox ID="Tbx_date" runat="server" TextMode="Date"></asp:TextBox>
    <br />
    <br />
    Filter by doctor specialization:<asp:TextBox ID="Tbx_specialization" runat="server"></asp:TextBox>
    <br />
    <br />
    Filter by doctor:<asp:TextBox ID="Tbx_doctor" runat="server"></asp:TextBox>
    <br />
    
</div>
    <div style="overflow-y: scroll; height: 250px; width: 1000px;">
        <br />
        <br />

    <asp:GridView ID="Gv_visits" runat="server" AllowSorting="true" AutoGenerateColumns="false" OnSorting="Gv_visits_Sorting">
        <Columns>
                <asp:BoundField DataField="Ap_id_appoitment" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="Ap_id_appoitment" />
                <asp:BoundField DataField="Ap_appoitment_day" HeaderText="Date of visit" SortExpression="Ap_appoitment_day" DataFormatString="{0:dd-MM-yyyy}" />
                <asp:BoundField DataField="Ap_appoitment_time" HeaderText="Time of visit" SortExpression="Ap_appoitment_time" />
                <asp:BoundField DataField="Patient" HeaderText="Patient" SortExpression="Patient" />
                <asp:BoundField DataField="Pesel" HeaderText="PESEL" SortExpression="Pesel" />
                <asp:BoundField DataField="Of_office_number" HeaderText="Office" SortExpression="Of_office_number" />
                <asp:BoundField DataField="Doctor" HeaderText="Doctor" SortExpression="Doctor" />
                <asp:BoundField DataField="Name" HeaderText="Specialization" SortExpression="Name" />
                <asp:ButtonField HeaderText="Details" Text="Show details" CommandName="Details" ButtonType="Button" />



                    
        </Columns>

    </asp:GridView>
        </div>
   
   

</asp:Content>