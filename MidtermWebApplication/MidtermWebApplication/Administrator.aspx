<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Administrator.aspx.cs" Inherits="MidtermWebApplication.Administrator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblCreateNewUser" runat="server" Text="Create a New User"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblFirstName" runat="server" Text="First Name :" Font-Bold="True"></asp:Label>
            <asp:TextBox ID="tbxFirstNameNewUser" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblLastName" runat="server" Text="Last Name: " Font-Bold="True"></asp:Label>
            <asp:TextBox ID="txtlastNameNewUser" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblJobTitle" runat="server" Text="Job Title: " Font-Bold="True"></asp:Label>
            <asp:DropDownList ID="ddlJobTitle" runat="server">
                <asp:ListItem>Tester</asp:ListItem>
                <asp:ListItem>Manager</asp:ListItem>
                <asp:ListItem>Developer</asp:ListItem>
                <asp:ListItem>Administrator</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblUniqePassword" runat="server" Text="Unique Password: " Font-Bold="True"></asp:Label>
            <asp:TextBox ID="tbxUniquePassword" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
&nbsp;(Can be changed at a later time by employee)<br />
            *Must be at least 8 characters long<br />
            *Must contain at least one letter<br />
            *Must contain at least one number<br />
            <br />
            <asp:Button ID="btnCreateUser" runat="server" Text="Create New User" OnClick="btnCreateUser_Click" />
        </div>
    </form>
</body>
</html>
