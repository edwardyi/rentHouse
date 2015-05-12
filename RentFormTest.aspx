<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RentFormTest.aspx.vb" Inherits="RentFormTest" %>

<%@ Register Src="Controls/RentForm2.ascx" TagName="RentForm2" TagPrefix="uc1" %>
<%@ Register Src="Controls/gvRentForm2.ascx" TagName="gvRentForm2" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:RentForm2 ID="RentForm21" runat="server" />
    </div>
    <uc2:gvRentForm2 ID="gvRentForm21" runat="server" />
    </form>
</body>
</html>