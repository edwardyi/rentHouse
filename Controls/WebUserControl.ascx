<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControl.ascx.vb"
    Inherits="WebUserControl" %>
<style type="text/css">
    .nowrap td
    {
        white-space: nowrap;
    }
</style>
<asp:DropDownList ID="ddlAA" runat="server">
</asp:DropDownList>
<asp:DropDownList ID="ddltest" runat="server">
    <asp:ListItem>選項1</asp:ListItem>
    <asp:ListItem>選項2</asp:ListItem>
    <asp:ListItem>選項3</asp:ListItem>
    <asp:ListItem>選項4</asp:ListItem>
    <asp:ListItem>選項5</asp:ListItem>
</asp:DropDownList>
<asp:Button ID="btn" runat="server" Text="Button" /><br />
<asp:CheckBox ID="checkAll" Text="全選" runat="server" AutoPostBack="true" />
<asp:CheckBoxList ID="cbltest" runat="server">
</asp:CheckBoxList>
<asp:ListBox ID="lstb" runat="server" CssClass="nowrap"></asp:ListBox>