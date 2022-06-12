<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PatientEditPage.aspx.cs" Inherits="GUI.Pages.MedicalStaffMemberPages.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="user-add-page-div">
        <p>
            &nbsp;<asp:Label ID="Lbl_edited" runat="server" ForeColor="Lime"></asp:Label>
            <br />
            Name:
            <asp:TextBox ID="Tbx_nameedit" runat="server"></asp:TextBox>
        </p>
        <p>
            Surname:<asp:TextBox ID="Tbx_surnameedit" runat="server"></asp:TextBox>
        </p>
        <p>
            Pesel number:
            <asp:TextBox ID="Tbx_peseledit" runat="server"></asp:TextBox>
        </p>
        <p>
            Date of birth:
            <asp:TextBox ID="Tbx_birthedit" runat="server" TextMode="Date"></asp:TextBox>
        </p>
        <p>
            Adress: <asp:TextBox ID="Tbx_adressedit" runat="server"></asp:TextBox>
        </p>
        <p>
            Email:
            <asp:TextBox ID="Tbx_emailedit" runat="server"></asp:TextBox>
        </p>
        <p>
            Phone number:
            <asp:TextBox ID="Tbx_phoneedit" runat="server"></asp:TextBox>
            
        
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
        <p>
            <asp:Button ID="Btn_Save" CssClass="btn-usr-mngmt-pg" runat="server" Text="Save" OnClick="Btn_Save_Click" />
        </p>
        <p>
            <asp:Button ID="Btn_Cancel" CssClass="btn-usr-mngmt-pg" runat="server" OnClick="Btn_Cancel_Click" Text="Cancel" />
        </p>
    </div>
</asp:Content>

