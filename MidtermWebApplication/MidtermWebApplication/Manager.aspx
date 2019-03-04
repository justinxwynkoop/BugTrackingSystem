<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manager.aspx.cs" Inherits="MidtermWebApplication.Manager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblBugsToBeFixed" runat="server" Text="New Bugs To Be Fixed: "></asp:Label>

            &nbsp;&nbsp;&nbsp;
            
            <asp:DropDownList ID="ddlNewBugs" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlNewBugs_SelectedIndexChanged"></asp:DropDownList>
            
            <br />
            <br />
            
            <br />
            
            <asp:Label ID="lblListOfDevelopers" runat="server" Text="Assign To A Developer: "></asp:Label>
            
            &nbsp;&nbsp;&nbsp;
            
            <asp:DropDownList ID="ddlListOfDevelopers" runat="server"></asp:DropDownList>
            
            <br /><br />
            
            <asp:GridView ID="gvBugInfo" runat="server"></asp:GridView>
            
            <br />

            <asp:Button ID="btnAssign" runat="server" Text="Assign to Developer" OnClick="btnAssign_Click" />
            <br /><br />
            <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />
        </div>
    </form>
</body>
</html>