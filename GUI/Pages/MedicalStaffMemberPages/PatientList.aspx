<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PatientList.aspx.cs" Inherits="Reception.PatientList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

 <p>
     <asp:Button ID="BtnBack" runat="server" OnClick="BtnBack_Click" Text="Back to panel" style="left: -4px; top: 8px" />
    </p>
    
        <p>
            Filter by name:

            <asp:TextBox ID="Tbx_name" runat="server"></asp:TextBox>

            <asp:Button ID="Btn_filter" runat="server" OnClick="Btn_filter_Click" Text="Filter" style="left: 30px; top: 9px" />

       

            <asp:Button ID="Btn_addpat" runat="server" OnClick="Btn_addpat_Click" Text="Add a patient" style="left: 53px; top: 9px" />

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
    <br />
    <br />
  
         <asp:GridView ID="Gv_patients" runat="server" AllowSorting="True" AutoGenerateColumns="False" OnSorting="Gv_patients_Sorting" OnRowCommand="Gv_patients_RowCommand" >
            <Columns>
                <asp:BoundField DataField="Id_Patients" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="Id_Patients" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Surname" HeaderText="Surname" SortExpression="Surname" />
                <asp:BoundField DataField="Pesel" HeaderText="PESEL" SortExpression="Pesel" />
                <asp:BoundField DataField="Date_of_birth" HeaderText="Date of birth" SortExpression="Date_of_birth" DataFormatString ="{0:dd-MM-yyyy}" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="Phone_number" HeaderText="Phone number" SortExpression="Phone_number" />
                <asp:BoundField DataField="Correspondence_adress" HeaderText="Correspondence adress" SortExpression="Correspondence_adress" />
                <asp:BoundField DataField="Ap_appoitment_day" HeaderText="Date of visit" SortExpression="Ap_appoitment_day" DataFormatString ="{0:dd-MM-yyyy}"/>
                <asp:ButtonField HeaderText="Details" Text="Check details" CommandName="Details" ButtonType="Button" />
                <asp:ButtonField HeaderText="Edit" Text="Edit" ButtonType="Button" CommandName="Edit"/>
                <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="Delete" ShowHeader="True" Text="Delete" />
            </Columns>
        </asp:GridView>
             
         

        <p>
            &nbsp;</p>
    <p>
            &nbsp;</p>
        
 </asp:Content>         
        