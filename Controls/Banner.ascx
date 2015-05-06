<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Banner.ascx.vb" Inherits="WebApplication3.Banner" %>
<asp:Panel ID="VerticalPanel" runat="server">
    <a href="http://google.com.tw" target="_blank">
        <asp:Image ID="Image1" runat="server" 
            AlternateText="測試Banner" ImageUrl="~/Images/Banner120x240.gif" />
    </a>
</asp:Panel>
<asp:Panel ID="HorizontalPanel" runat="server" >
    <a href="http://google.com.tw" target="_blank">
        <asp:Image ID="Image2" runat="server" 
            AlternateText="測試Banner" ImageUrl="~/Images/Banner468x60.gif" />
    </a>
    
</asp:Panel>