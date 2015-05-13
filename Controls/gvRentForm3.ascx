<%@ Control Language="VB" AutoEventWireup="false" CodeFile="gvRentForm3.ascx.vb"
    Inherits="Controls_gvRentForm3" %>
<asp:GridView ID="show_temp_gridview" runat="server" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundField HeaderText="NO" DataField="NO" />
        <asp:BoundField HeaderText="開始日期" DataField="s_date" DataFormatString="{0:yyyy/MM/dd}" />
        <asp:BoundField HeaderText="結束日期" DataField="e_date" DataFormatString="{0:yyyy/MM/dd}" />
        <asp:BoundField HeaderText="當月費用" DataField="money" DataFormatString="{0:N0}" />
        <asp:BoundField HeaderText="平均" DataField="average" DataFormatString="{0:N0}" />
        <asp:BoundField HeaderText="住屋天數" DataField="liveDays" DataFormatString="{0:N0}" />
    </Columns>
</asp:GridView>