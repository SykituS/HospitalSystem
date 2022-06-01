<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeAddPage.aspx.cs" Inherits="GUI.EmployeeAddPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        &nbsp;<asp:Label ID="LblAdded" runat="server" ForeColor="Lime"></asp:Label>
        <br />
        Name:
        <asp:TextBox ID="TxbName" runat="server"></asp:TextBox>
        *<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name cannot be blank" ControlToValidate="TxbName" ForeColor="Red" ValidationGroup="valGroup1">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Enter correct name" ForeColor="Red" ControlToValidate="TxbName" ValidationExpression="^[\w'\-,.][^0-9_!¡?÷?¿/\\+=@#$%ˆ&*(){}|~<>;:[\]]{2,}$" ValidationGroup="valGroup1">*</asp:RegularExpressionValidator>
    </p>
    <p>
        Second name:
        <asp:TextBox ID="TxbSecName" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="Enter correct second name" ForeColor="Red" ControlToValidate="TxbSecName" ValidationExpression="^[\w'\-,.][^0-9_!¡?÷?¿/\\+=@#$%ˆ&*(){}|~<>;:[\]]{2,}$" ValidationGroup="valGroup1">*</asp:RegularExpressionValidator>
    </p>
    <p>
        Surname:
        <asp:TextBox ID="TxbSurname" runat="server"></asp:TextBox>
        *<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Surname cannot be blank" ControlToValidate="TxbSurname" ForeColor="Red" ValidationGroup="valGroup1">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Enter correct surname" ForeColor="Red" ControlToValidate="TxbSurname" ValidationExpression="^[\w'\-,.][^0-9_!¡?÷?¿/\\+=@#$%ˆ&*(){}|~<>;:[\]]{2,}$" ValidationGroup="valGroup1">*</asp:RegularExpressionValidator>
    </p>
    <p>
        PESEL:
        <asp:TextBox ID="TxbPesel" runat="server"></asp:TextBox>
        *<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="PESEL cannot be blank" ControlToValidate="TxbPesel" ForeColor="Red" ValidationGroup="valGroup1">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="PESEL must be 11 digit" ForeColor="Red" ControlToValidate="TxbPesel" ValidationExpression="^\d{11}$" ValidationGroup="valGroup1" >*</asp:RegularExpressionValidator>
        <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="PESEL must match your date of birth and selected sex" OnServerValidate="PeselValidate" ControlToValidate="TxbPesel" ForeColor="Red" ValidationGroup="valGroup1">*</asp:CustomValidator>
    </p>
    <p>
        Date of birth:
        <asp:TextBox ID="TxbDob" runat="server" TextMode="Date"></asp:TextBox>
        *<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please select your date of birth" ControlToValidate="TxbDob" ForeColor="Red" ValidationGroup="valGroup1">*</asp:RequiredFieldValidator>

        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Select correct date of birth" ForeColor="Red" ControlToValidate="TxbDob" Type="Date" MinimumValue="01-01-1900" MaximumValue="31-12-2010" ValidationGroup="valGroup1" >*</asp:RangeValidator>

    </p>
    <p>
        Role:
        <asp:DropDownList ID="DdlRoles" runat="server" AppendDataBoundItems="True">
            <asp:ListItem Text="" Value=""></asp:ListItem>
        </asp:DropDownList>
        *<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please select role" ControlToValidate="DdlRoles" ForeColor="Red" ValidationGroup="valGroup1">*</asp:RequiredFieldValidator>
    </p>
    <p>
        Address:
        <asp:TextBox ID="TxbAddress" runat="server"></asp:TextBox>
    </p>
    <p>
        E-mail:
        <asp:TextBox ID="TxbEmail" runat="server"></asp:TextBox>
        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Email must contain employee name and eksocmed.com domain" OnServerValidate="EmailValidate" ControlToValidate="TxbEmail" ForeColor="Red" ValidationGroup="valGroup1">*</asp:CustomValidator>
    </p>
    <p>
        Phone number:
        <asp:TextBox ID="TxbPhoneNumber" runat="server"></asp:TextBox>
        <asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="Phone number must be 9 digit" OnServerValidate="PhoneNumberValidate" ControlToValidate="TxbPhoneNumber" ForeColor="Red" ValidationGroup="valGroup1">*</asp:CustomValidator>
    </p>
    <p>
        Sex:
        <asp:DropDownList ID="DdlSex" runat="server">
            <asp:ListItem Text="" Value="3"></asp:ListItem>
            <asp:ListItem Text="Male" Value="1"></asp:ListItem>
            <asp:ListItem Text="Female" Value="2"></asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        * Those fields are required</p>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="valGroup1"/>
    <p>
        <asp:Button ID="BtnNext" runat="server" Text="Next" ValidationGroup="valGroup1" OnClick="BtnNext_Click"/>
    </p>
    <p>
        <asp:Button ID="BtnCancel" runat="server" Text="Cancel" OnClick="BtnCancel_Click" />
    </p>
</asp:Content>
