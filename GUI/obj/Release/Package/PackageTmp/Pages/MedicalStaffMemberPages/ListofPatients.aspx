<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListofPatients.aspx.cs" Inherits="Reception.PatientList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <div Class="spec-mng-pg-div"> 
 <p>
     <asp:Button ID="BtnBack" CssClass="btn-usr-mngmt-pg" runat="server" OnClick="BtnBack_Click" Text="Back to panel" />
    </p>
    <asp:Button ID="Button1" CssClass="btn-usr-mngmt-pg" runat="server" OnClick="Btn_filter_Click" Text="Filter" />

       
     <asp:Button ID="Button2" CssClass="btn-usr-mngmt-pg" runat="server" OnClick="Btn_addpat_Click" Text="Add a patient" />
       <br />
       <br />
        <p>
            Filter by name:

            <asp:TextBox ID="Tbx_name" runat="server"></asp:TextBox>


        </p>
    <p>
            Filter by surname:
            <asp:TextBox ID="Tbx_surname" runat="server"></asp:TextBox>

        </p>
        <p>
            Filter by PESEL:
            <asp:TextBox ID="Tbx_pesel" runat="server"></asp:TextBox>
        </p>
        <p>
            Filter by date of the latest visit:<asp:CheckBox ID="ChBx_visit" runat="server"  />
    </p>
        
    
        </div> 
    <br />
  <div style="overflow-y: scroll; height: 350px; width: 1000px;">
         <asp:GridView ID="Gv_patients" runat="server" AllowSorting="True" AutoGenerateColumns="False" OnSorting="Gv_patients_Sorting" OnRowCommand="Gv_patients_RowCommand" >
            <Columns>
                <asp:BoundField DataField="Id_Patients" HeaderText="ID" SortExpression="Id_Patients" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Surname" HeaderText="Surname" SortExpression="Surname" />
                <asp:BoundField DataField="Pesel" HeaderText="PESEL" SortExpression="Pesel" />
                <asp:BoundField DataField="Date_of_birth" HeaderText="Date of birth" SortExpression="Date_of_birth" DataFormatString ="{0:dd-MM-yyyy}" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="Phone_number" HeaderText="Phone number" SortExpression="Phone_number" />
                <asp:BoundField DataField="Correspondence_adress" HeaderText="Correspondence adress" SortExpression="Correspondence_adress" />
                <asp:BoundField DataField="Ap_appoitment_day" HeaderText="Date of visit" SortExpression="Ap_appoitment_day" DataFormatString ="{0:dd-MM-yyyy}"/>
                <asp:BoundField HeaderText="Status" DataField="St_Status_Name" SortExpression="St_Status_Name" />
                <asp:ButtonField HeaderText="Details" Text="Check details" CommandName="Details" ButtonType="Button" />
                <asp:ButtonField HeaderText="Edit" Text="Edit" ButtonType="Button" CommandName="Edit"/>
                <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="Delete" ShowHeader="True" Text="Delete" />
                <asp:ButtonField ButtonType="Button" CommandName="Status" HeaderText="Activate/Disactivate Patient" Text="Reactivate/Deactivate" />

            </Columns>
        </asp:GridView>
             
   </div>       

        <p>
            &nbsp;</p>
    <p>
            &nbsp;</p>
        
 </asp:Content>         
        