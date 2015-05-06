<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MultiViewTest.aspx.vb" Inherits="WebApplication3.MultiViewTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <asp:Button ID="PreView" runat="server" Text="PreView" />
                <asp:Button ID="Button2" runat="server" Text="NextView" />
                <asp:Button ID="Button3" runat="server" Text="Button" />
                <asp:Button ID="Button4" runat="server" Text="Button" />
            </asp:View>
            <asp:View ID="View2" runat="server">
            </asp:View>
            <asp:View ID="View3" runat="server">
            </asp:View>
        </asp:MultiView>
    
    </div>
    </form>
</body>
</html>
