<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MidtermWebApplication.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Style.css">
</head>
<body>
        <form class="box" action="index.aspx" method="post" runat="server">
        <h1>Login</h1>
        <asp:TextBox type="text" ID="tbxUserName" placeholder="Username" runat="server"></asp:TextBox>
        <asp:TextBox type="password" ID="tbxPassword" placeholder="Password" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Login" OnClick="btnLogin_Click" />
        </form>
        
</body>
</html>
