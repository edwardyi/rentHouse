<%@ Control Language="VB" AutoEventWireup="false" CodeFile="gvRentForm2.ascx.vb"
    Inherits="Controls_gvRentForm2" %>
<asp:GridView ID="showUsersGrid" AutoGenerateColumns="false" runat="server" CellPadding="4"
    ForeColor="#333333" GridLines="None">
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <span class="plus">+</span>
                <asp:Panel ID="showDetailGrid" runat="server" Style="display: none">
                    <asp:GridView ID="detailGrid" AutoGenerateColumns="false" runat="server">
                        <Columns>
                            <asp:BoundField ItemStyle-Width="150px" DataField="s_date" HeaderText="開始月份" DataFormatString="{0:yyyy/MM/dd}" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="e_date" HeaderText="結束月份" DataFormatString="{0:yyyy/MM/dd}" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="money" HeaderText="當月租金" DataFormatString="{0:N0}" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="average" HeaderText="當月平均" DataFormatString="{0:N0}" />
                        </Columns>
                        <RowStyle BackColor="#EFF3FB" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                </asp:Panel>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField ItemStyle-Width="150px" DataField="ID" HeaderText="編號" />
        <asp:BoundField ItemStyle-Width="150px" DataField="WorkID" HeaderText="工號" />
        <asp:BoundField ItemStyle-Width="150px" DataField="StartDate" HeaderText="開始日期" DataFormatString="{0:yyyy/MM/dd}" />
        <asp:BoundField ItemStyle-Width="150px" DataField="EndDate" HeaderText="結束日期" DataFormatString="{0:yyyy/MM/dd}" />
        <asp:BoundField ItemStyle-Width="150px" DataField="RentPerPrice" HeaderText="總租金"
            DataFormatString="{0:N0}" />
    </Columns>
    <RowStyle BackColor="#EFF3FB" />
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#2461BF" />
    <AlternatingRowStyle BackColor="White" />
</asp:GridView>