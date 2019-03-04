<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Developer.aspx.cs" Inherits="MidtermWebApplication.Developer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblNewBugs" runat="server" Text="List of bugs to be fixed: "></asp:Label>
        
            &nbsp;&nbsp;&nbsp;
            
            <asp:DropDownList ID="ddlNewBugs" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlNewBugs_SelectedIndexChanged"></asp:DropDownList>
            
            <br /><br />

            <asp:GridView ID="gvBugInfo" runat="server"></asp:GridView>
            
            <br /><br />
            <asp:Label ID="lblBugChanges" runat="server" Text="Changes made to fix bug: "></asp:Label>

            &nbsp;&nbsp;&nbsp;

            <asp:TextBox ID="tbxBugChanges" runat="server" TextMode="MultiLine" Height="100px" Width="250px"></asp:TextBox>
            
            &nbsp;&nbsp;<br />
            <br />
            <br />
            &nbsp;

            <asp:Button ID="btnSubmitChanges" runat="server" Text="Submit Changes To Bugs" OnClick="btnSubmitChanges_Click" />
            
            <br /><br />
            <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />
        </div>
        
    </form>
</body>
</html>