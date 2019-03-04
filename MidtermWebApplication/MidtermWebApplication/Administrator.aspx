<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Administrator.aspx.cs" Inherits="MidtermWebApplication.Administrator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblNewUsername" runat="server" Text="Name: "></asp:Label>
        &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbxNewUsername" runat="server"></asp:TextBox>

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:Label ID="lblEmployeeType" runat="server" Text="User Type: "></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlEmployeeType" runat="server"></asp:DropDownList>
            <br /><br />
            <asp:Label ID="lblNewUserLogin" runat="server" Text="Login: "></asp:Label>
        &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbxNewUserLogin" runat="server"></asp:TextBox>
            <br /><br />
            <asp:Label ID="lblNewUserPassword" runat="server" Text="Password: "></asp:Label>
        &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbxNewUserPassword" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnCreateUser" runat="server" Text="Create User" OnClick="btnCreateUser_Click" />
            <br /><br />
            <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />
        </div>
    </form>
</body>
</html>