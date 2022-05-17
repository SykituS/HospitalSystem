<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserAddPage.aspx.cs" Inherits="GUI.Pages.AdministratorPages.UserManagementPages.UserAddPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        button,
select {
  text-transform: none;
            margin-left: 73px;
        }
* {
  -webkit-box-sizing: border-box;
  -moz-box-sizing: border-box;
  box-sizing: border-box;
}
  *,
  *:before,
  *:after {
    color: #000 !important;
    text-shadow: none !important;
    background: transparent !important;
    -webkit-box-shadow: none !important;
    box-shadow: none !important;
  }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Select employee"></asp:Label>
            <asp:DropDownList ID="DropDownList" runat="server" AutoPostBack="true" >
            </asp:DropDownList>
        </div>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="BtnAddNewUser" runat="server" Text="Add new user" OnClick="BtnAddNewUser_Click" />
            <asp:Button ID="Button2" runat="server" Text="Button" />
        </p>
    </form>
</body>
</html>
