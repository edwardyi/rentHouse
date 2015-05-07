<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="WebApplication3._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <!-- 一個頁面只能有一個form表單 -->
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lbl_WorkId" runat="server" Text="工號"></asp:Label>
        <asp:TextBox ID="workId" runat="server"></asp:TextBox>
        <!--如果輸入空白字元則會發生錯誤 -->
        <asp:RequiredFieldValidator ID="workIdCheckEmpty" runat="server" 
            ControlToValidate="workId" ErrorMessage="工號不能為空" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="workIdCheck" runat="server" ControlToValidate="workId" 
            ErrorMessage="工號需要為數字" Type="Integer" MinimumValue="0" MaximumValue="80000000" 
            Display="Dynamic"></asp:RangeValidator>
        
        <br />
        
        <asp:Label ID="lbl_start" runat="server" Text="開始租屋"></asp:Label>
        <asp:TextBox ID="startDate" runat="server"  ></asp:TextBox><br />
        <asp:Label ID="lbl_end" runat="server" Text="結束租屋"></asp:Label>
        <asp:TextBox ID="endDate" runat="server" ></asp:TextBox><br />
        <asp:Button ID="newRenter" runat="server" Text="新增" /> 
        <asp:Button ID="btn_Submit" runat="server" Text="計算" Visible="False" />
        
        
        <div id="showTable">
            <!--
            <asp:Label ID="showResult" runat="server" Text=""></asp:Label>
            使用databind的方式來呈現
            -->
             <%# output %>
            <asp:Label ID="lb1_total" runat="server" Text="總金額" Visible="False"></asp:Label>
            <asp:Label ID="total" runat="server" Text=""></asp:Label>
           
        </div>
        <asp:Label ID="result" runat="server" Text=""></asp:Label>
    </div>
    <div>
     
     <asp:Button ID="showAllUsers" runat="server" Text="顯示租屋狀況" />
     <asp:HyperLink ID="Show_Link" runat="server" NavigateUrl="AddRenter.aspx">新增使用者</asp:HyperLink>
     <!--設定取消自動生成欄位的屬性 -->
    <asp:GridView ID="showUsersGrid" AutoGenerateColumns="false"
        runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" >
        <Columns>
          <asp:TemplateField>
            <ItemTemplate>
                <span class="plus">+</span>
                <asp:Panel ID="showDetailGrid" runat="server" Style="display: none">
                    <asp:GridView ID="detailGrid" AutoGenerateColumns="false" runat="server">
                        <Columns>                      
                            <asp:BoundField ItemStyle-Width="150px" DataField="s_date" HeaderText="開始月份" dataformatstring="{0:yyyy/MM/dd}" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="e_date" HeaderText="結束月份" dataformatstring="{0:yyyy/MM/dd}" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="money" HeaderText="當月租金" dataformatstring="{0:N0}"  />
                            <asp:BoundField ItemStyle-Width="150px" DataField="average" HeaderText="當月平均" dataformatstring="{0:N0}"/>
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
           <asp:BoundField ItemStyle-Width="150px" DataField="StartDate" HeaderText="開始日期" dataformatstring="{0:yyyy/MM/dd}"/>
           <asp:BoundField ItemStyle-Width="150px" DataField="EndDate" HeaderText="結束日期" dataformatstring="{0:yyyy/MM/dd}" />
           <asp:BoundField ItemStyle-Width="150px" DataField="RentPerPrice" HeaderText="總租金" dataformatstring="{0:N0}" />
        </Columns>    
            
        <RowStyle BackColor="#EFF3FB" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <!--
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
        <HeaderTemplate>
            <asp:Table ID="Table1" runat="server">
                <asp:TableRow>
                    <asp:TableCell>所有使用者</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </HeaderTemplate>
        <ItemTemplate>
            <asp:Table ID="Table2" runat="server">
            <asp:TableRow>
                <asp:TableCell>編號</asp:TableCell>
                <asp:TableCell>工號</asp:TableCell>
                <asp:TableCell>姓名</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><%# Container.DataItem("ID") %></asp:TableCell>
                <asp:TableCell><%# Container.DataItem("WorkId") %></asp:TableCell>
                <asp:TableCell><%# Container.DataItem("Name") %></asp:TableCell>
            </asp:TableRow>
            </asp:Table>
        </ItemTemplate>
        </asp:Repeater>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:RentHouseConnectionString1 %>" 
            SelectCommand="SELECT * FROM [Renter]"></asp:SqlDataSource>
        -->
        
            
    </div>
    </form>
    
    
   
    
    
     <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        $("[class*=plus]").live("click", function() {
        //before
            $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>");
            $(this).html("-");
            $(this).attr("class", "minus");
        });
        $("[class*=minus]").live("click", function() {
            $(this).attr("class", "plus");
            $(this).html("+");
        //prev
            $(this).closest("tr").next().remove();
        });
    </script>
</body>
</html>
