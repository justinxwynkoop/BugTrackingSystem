<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manager.aspx.cs" Inherits="MidtermWebApplication.Manager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblListofBugs" runat="server" Text="List of Bugs"></asp:Label>
            <br />
            <br />
            <asp:DropDownList ID="ddlListofBugs" runat="server" OnSelectedIndexChanged="ddlListofBugs_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblAssignBug" runat="server" Text="Assign Bug to Developer"></asp:Label>
            <br />
            <asp:DropDownList ID="ddlListofDevelopers" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="btnSubmitAssignment" runat="server" Text="Submit Assignment" OnClick="btnSubmitAssignment_Click" />
        </div>
    </form>
</body>
</html>
