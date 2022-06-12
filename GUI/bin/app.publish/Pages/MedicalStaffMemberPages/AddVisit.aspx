<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddVisit.aspx.cs" Inherits="GUI.Pages.MedicalStaffMemberPages.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server"> 

    <div class="user-add-page-div">

    <p>
        <asp:Label ID="Lbl_added" runat="server" ForeColor="Lime"></asp:Label>
        <br />
        Patient:<asp:DropDownList ID="Ddl_patient" runat="server">
        </asp:DropDownList>
    </p>
    <p>
        Date of the visit:<asp:TextBox ID="Tbx_date" runat="server" TextMode="Date"></asp:TextBox>
    </p>
    <p>
        Time of the visit:<asp:TextBox ID="Tbx_time" runat="server" TextMode="Time"></asp:TextBox>
    </p>
    <p>
        Specialization:<asp:DropDownList ID="Ddl_specialization" runat="server">
        </asp:DropDownList>
    </p>
    <p>
        Doctor:<asp:DropDownList ID="Ddl_doctor" runat="server">
        </asp:DropDownList>
    </p>
    <p>
        Office:<asp:DropDownList ID="Ddl_office" runat="server">
        </asp:DropDownList>
    </p>
    <p>
        <asp:Button ID="Btn_addappointment" CssClass="btn-usr-mngmt-pg" runat="server" OnClick="Btn_addappointment_Click" Text="Add " />
    </p>
    <p>
        <asp:Button ID="Btn_cancel" CssClass="btn-usr-mngmt-pg" runat="server" Text="Cancel" OnClick="Btn_cancel_Click" />
    </p>
    <p>
        <asp:Label ID="Lbl_errorwarning" runat="server" ForeColor="Red"></asp:Label>
    </p>
    <p>
    </p>


</div>
</asp:Content>