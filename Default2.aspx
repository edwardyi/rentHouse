<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default2.aspx.vb" Inherits="Default2" %>

<%@ Register Src="Controls/WebUserControl.ascx" TagName="WebUserControl" TagPrefix="uc2" %>
<%@ Register Src="Controls/Greeter.ascx" TagName="Greeter" TagPrefix="uc1" %>
<%@ Register Src="Controls/RentForm2.ascx" TagName="RentForm2" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc3:RentForm2 ID="RentForm21" runat="server" />
    </div>
    <div>
        <asp:Panel ID="Panel1" runat="server">
            <uc2:WebUserControl ID="WebUserControl2" runat="server" />
            <asp:Button ID="btn1" runat="server" Text="Button" />
        </asp:Panel>
    </div>
    <asp:Panel ID="Panel2" runat="server">
        <uc1:Greeter ID="Greeter1" runat="server" />
    </asp:Panel>
    </form>
</body>
</html>