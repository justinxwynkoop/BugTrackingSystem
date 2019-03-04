<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tester.aspx.cs" Inherits="MidtermWebApplication.Tester" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblSubjectOfBug" runat="server" Text="Subject: "></asp:Label>
                
        &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbxSubjectOfBug" runat="server"></asp:TextBox>
                <br /><br />
            <asp:Label ID="lblPriorityOfBug" runat="server" Text="Priority Of Bug: "></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlPriorityOfBug" runat="server"></asp:DropDownList>
            <br /><br />
            <asp:Label ID="lblDescriptionOfBug" runat="server" Text="Description Of Bug: "></asp:Label>

        &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbxDescriptionOfBug" runat="server" TextMode="MultiLine" Height="100px" Width="250px"></asp:TextBox>
        &nbsp;&nbsp;<br />
            <br />
            &nbsp;
            <asp:Button ID="btnSubmitBug" runat="server" Text="Submit Bug" OnClick="btnSubmitBug_Click" />
            <br /><br />
            &nbsp;
            <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />
        </div>
    </form>
</body>
</html>
