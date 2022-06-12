<%@ Page Title="MedicalClinic-User Management" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="UserManagementPage.aspx.cs" Inherits="GUI.Pages.AdministratorPages.UserManagementPages.UserManagementPage" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="usr-mng-pg-div">

        <asp:Button ID="BtnBack" CssClass="btn-usr-mngmt-pg" runat="server" Text="Back to menu" OnClick="BtnBack_Click" />
        <br />
        <asp:Button ID="BtnAddNewUser" CssClass="btn-usr-mngmt-pg" runat="server" Text="Add new user" OnClick="BtnAddNewUser_Click" />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Filter by:"></asp:Label>
        <br /><br />
        <asp:Label ID="Label2" runat="server" Text="First name:   "></asp:Label>
        <asp:TextBox ID="TBNameFirst" runat="server" OnTextChanged="FilterGridView" AutoPostBack="true" MaxLength="100"></asp:TextBox>
        <br /><br />
        <asp:Label ID="Label3" runat="server" Text="Second name:   "></asp:Label>
        <asp:TextBox ID="TBNameSecond" runat="server" OnTextChanged="FilterGridView" AutoPostBack="true" MaxLength="100"></asp:TextBox>
        <br /><br />
        <asp:Label ID="Label4" runat="server" Text="Position:   "></asp:Label>
        <asp:DropDownList ID="DropDownListPosition" runat="server" OnSelectedIndexChanged="FilterGridView" AutoPostBack="true">
        </asp:DropDownList>
        <br />
        <br />
        <asp:GridView ID="GridViewUsers" runat="server" AllowSorting="True" OnSorting="GridViewUsers_Sorting" AutoGenerateColumns="False" OnRowCommand="GridViewUsers_RowCommand" OnSelectedIndexChanged="GridViewUsers_SelectedIndexChanged" Width="784px">
            <Columns>
                <asp:BoundField HeaderText="User name" DataField="US_Login" SortExpression="US_Login"/>
                <asp:BoundField HeaderText="First name" DataField="EM_Name" SortExpression="EM_Name" />
                <asp:BoundField HeaderText="Second Name" DataField="EM_Sec_Name" SortExpression="EM_Sec_Name" NullDisplayText=" " />
                <asp:BoundField HeaderText="Position" DataField="PO_Name" SortExpression="PO_Name" />
                <asp:TemplateField HeaderText="Change status" SortExpression="St_Status_Name">
                    <ItemTemplate>
                        <asp:Button ID="BtnChangeStatus" runat="server" Text='<%# Eval("St_Status_Name") %>' CommandName="ChangeStatus" CommandArgument="<%# Container.DataItemIndex %>" />
                    </ItemTemplate>
                </asp:TemplateField>

                
                <asp:ButtonField Text="Edit user" CommandName="EditUser" />
            </Columns>
        </asp:GridView>
        <br />
        <br />
        <br />

    </div>

</asp:Content>