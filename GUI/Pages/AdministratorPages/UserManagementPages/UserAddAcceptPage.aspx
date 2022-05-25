<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserAddAcceptPage.aspx.cs" Inherits="GUI.Pages.AdministratorPages.UserManagementPages.UserAddAcceptPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Do you want to add new user?"></asp:Label>
        </div>
        <p>
            <asp:Button ID="BtnAccept" runat="server" OnClick="BtnAccept_Click" Text="Accept" />
            <asp:Button ID="BtnCancel" runat="server" Text="Cancel" OnClick="BtnCancel_Click" />
        </p>
    </form>
</body>
</html>
