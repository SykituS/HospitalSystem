<%@ Page Title="List of Patients" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PatientList.aspx.cs" Inherits="Reception.PatientList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

 <p>
     <asp:Button ID="BtnBack" runat="server" OnClick="BtnBack_Click" Text="Back to panel" />
    </p>
    
        <p>
            Filter by name:

            <asp:TextBox ID="Tbx_name" runat="server"></asp:TextBox>

            <asp:Button ID="Btn_filter" runat="server" OnClick="Btn_filter_Click" Text="Filter" />

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

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
            Filter by date of the latest visit:</p>
       
        <asp:Calendar ID="Calendar1" runat="server" Height="16px" Width="213px"></asp:Calendar>
       
        <br />
    <br />
    <br />
       
        <asp:GridView ID="Gv_patients" runat="server" AllowSorting="True" AutoGenerateColumns="False" OnSorting="Gv_patients_Sorting">
            <Columns>
                <asp:BoundField DataField="Id_Patients" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="Id_Patients" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Surname" HeaderText="Surname" SortExpression="Surname" />
                <asp:BoundField DataField="Pesel" HeaderText="PESEL" SortExpression="Pesel" />
                <asp:BoundField DataField="Date_of_birth" HeaderText="Date of birth" SortExpression="Date_of_birth" DataFormatString ="{0:dd-MM-yyyy}" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="Phone_number" HeaderText="Phone number" SortExpression="Phone_number" />
                <asp:BoundField DataField="Correspondence_adress" HeaderText="Correspondence adress" SortExpression="Correspondence_adress" />
                <asp:BoundField DataField="Date_of_the_visit" HeaderText="Date of the visit" SortExpression="Date_of_the_visit" DataFormatString ="{0:dd-MM-yyyy}" />
            </Columns>
        </asp:GridView>
        <p>
            &nbsp;</p>
    <p>
            &nbsp;</p>
        
 </asp:Content>         
        