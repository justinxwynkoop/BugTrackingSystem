<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tester.aspx.cs" Inherits="MidtermWebApplication.Tester" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblNewBug" runat="server" Text="Report A New Bug"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblBugSubject" runat="server" Text="Subject : "></asp:Label>
            <asp:TextBox ID="tbxBugSubject" runat="server" Width="134px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblBugPriorityLevel" runat="server" Text="Priority Level: "></asp:Label>
            <asp:DropDownList ID="ddlBugPriority" runat="server">
                <asp:ListItem>Low</asp:ListItem>
                <asp:ListItem>Medium</asp:ListItem>
                <asp:ListItem>High</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblBugDiscription" runat="server" Text="Bug Discription: "></asp:Label>
            <br />
            <asp:TextBox ID="tbxBugDiscription" runat="server" Height="227px" Width="587px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnSubmitBug" runat="server" Text="Submit Bug" OnClick="btnSubmitBug_Click" />
        </div>
    </form>
</body>
</html>
