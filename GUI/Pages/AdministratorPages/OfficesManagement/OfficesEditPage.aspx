<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OfficesEditPage.aspx.cs" Inherits="GUI.Pages.AdministratorPages.OfficesManagement.OfficesEditPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:Label ID="LblEdit" runat="server" Font-Size="Large" Text="Editing office"></asp:Label>
        <br />
    </p>

    <p>
        &nbsp;<asp:Label ID="LblEdited" runat="server" ForeColor="Lime"></asp:Label>
    </p>

    <p>
        Specialization:
        <asp:DropDownList ID="DdlSpecialization" runat="server" AppendDataBoundItems="True">
        <asp:ListItem Text="" Value=""></asp:ListItem>
        </asp:DropDownList>
        *<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please select specialization" ControlToValidate="DdlSpecialization" ForeColor="Red" ValidationGroup="valGroup1">*</asp:RequiredFieldValidator>
    </p>

    <p>
        Status:
        <asp:DropDownList ID="DdlStatus" runat="server">
            <asp:ListItem Text="" Value=""></asp:ListItem>
            <asp:ListItem Text="Activated" Value="Activated"></asp:ListItem>
            <asp:ListItem Text="Deactivated" Value="Deactivated"></asp:ListItem>
        </asp:DropDownList>
        *<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please select status" ControlToValidate="DdlStatus" ForeColor="Red" ValidationGroup="valGroup1">*</asp:RequiredFieldValidator>
    </p>

    <p>
        Dedicated for general meetings:
        <asp:DropDownList ID="DdlPlenary" runat="server">
            <asp:ListItem Text="" Value=""></asp:ListItem>
            <asp:ListItem Text="Yes" Value="Checked"></asp:ListItem>
            <asp:ListItem Text="No" Value="unchecked"></asp:ListItem>
        </asp:DropDownList>
        *<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please select whether it can be dedicated to a general meetings" ControlToValidate="DdlPlenary" ForeColor="Red" ValidationGroup="valGroup1">*</asp:RequiredFieldValidator>
    </p>

    <p>
        Renumerated:
        <asp:DropDownList ID="DdlRenumerated" runat="server">
            <asp:ListItem Text="" Value=""></asp:ListItem>
            <asp:ListItem Text="Yes" Value="renumerated"></asp:ListItem>
            <asp:ListItem Text="No" Value="Default"></asp:ListItem>
        </asp:DropDownList>
        *<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please select renumerated" ControlToValidate="DdlRenumerated" ForeColor="Red" ValidationGroup="valGroup1">*</asp:RequiredFieldValidator>
    </p>

    <p>
        * Those fields are required</p>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="valGroup1"/>
    <p>

    <p>
        <asp:Button ID="BtnEdit" runat="server" Text="Edit" OnClick="BtnEdit_Click" ValidationGroup="valGroup1"/>
    </p>

    <p>
        <asp:Button ID="BtnCancel" runat="server" Text="Cancel" OnClick="BtnCancel_Click" />
    </p>
</asp:Content>
