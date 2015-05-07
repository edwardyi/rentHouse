<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AddRenter.aspx.vb" Inherits="AddRenter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lb_WorkId" runat="server" Text="工號"></asp:Label>
        <asp:TextBox ID="WorkId" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="WorkId" runat="server" ErrorMessage="必填欄位"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lb_Name" runat="server" Text="姓名"></asp:Label>
        <asp:TextBox ID="Name" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="Name" runat="server" ErrorMessage="必填欄位"></asp:RequiredFieldValidator>
        <br />
        <asp:Button ID="Add_Button" runat="server" Text="新增使用者" />
       
        <asp:HyperLink ID="Show_Link" runat="server" NavigateUrl="NewRenter.aspx">查看使用者</asp:HyperLink>
    </div>
    </form>
</body>
</html>
