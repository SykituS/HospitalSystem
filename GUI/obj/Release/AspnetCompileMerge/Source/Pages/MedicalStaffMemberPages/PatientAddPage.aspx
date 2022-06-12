<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PatientAddPage.aspx.cs" Inherits="GUI.Pages.MedicalStaffMemberPages.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="user-add-page-div">
        <p>
            &nbsp;<asp:Label ID="Lbl_added" runat="server" ForeColor="Lime"></asp:Label>
            <br />
            Name:
            <asp:TextBox ID="Tbx_nameadd" runat="server"></asp:TextBox>
        </p>
        <p>
            Surname:<asp:TextBox ID="Tbx_surnameadd" runat="server"></asp:TextBox>
        </p>
        <p>
            Pesel number:
            <asp:TextBox ID="Tbx_peseladd" runat="server"></asp:TextBox>
        </p>
        <p>
            Date of birth:
            <asp:TextBox ID="Tbx_birthadd" runat="server" TextMode="Date"></asp:TextBox>
        </p>
        <p>
            Adress: <asp:TextBox ID="Tbx_adressadd" runat="server"></asp:TextBox>
        </p>
        <p>
            Email:
            <asp:TextBox ID="Tbx_emailadd" runat="server"></asp:TextBox>
        </p>
        <p>
            Phone number:
            <asp:TextBox ID="Tbx_phoneadd" runat="server"></asp:TextBox>
            

        </p>
        <p>
            Sex:
            <asp:DropDownList ID="Ddl_sex" runat="server">
                <asp:ListItem Text="" Value=""></asp:ListItem>
                <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                <asp:ListItem Text="Female" Value="2"></asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>
            <asp:Label ID="Lbl_errorwarning" runat="server" ForeColor="Red"></asp:Label>
        </p>
        <asp:Button ID="Btn_addpatient" CssClass="btn-usr-mngmt-pg" runat="server" Text="Add" OnClick="Btn_addpatient_Click" />
        <br />
        <br />
        <p>
            <asp:Button ID="Btn_cancel" CssClass="btn-usr-mngmt-pg" runat="server" Text="Cancel" OnClick="Btn_cancel_Click" />
        </p>
        </div>
</asp:Content>
