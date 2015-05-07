<%@ Page Language="VB" AutoEventWireup="false" CodeFile="showTempDataTable.aspx.vb" Inherits="showTempDataTable" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <h1>顯示目前DataTable(代確認)未寫入資料庫</h1>
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
        <asp:Button ID="btn_Show_DataTable" runat="server" Text="顯示" />
        <asp:Button ID="btn_Confirm_DataTable" runat="server" Text="確認送出" Visible="false" />
        <asp:Button ID="btn_Get_Current_DataSet" runat="server" Text="取得所有資料" />
        <asp:GridView ID="show_temp_gridview" runat="server"  AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="工號" DataField="WorkId" />
                <asp:BoundField HeaderText="開始日期" DataField="s_current_date" DataFormatString="{0:yyyy/MM/dd}" />
                <asp:BoundField HeaderText="結束日期" DataField="e_current_date" DataFormatString="{0:yyyy/MM/dd}" />
                <asp:BoundField HeaderText="當月費用" DataField="current_money" DataFormatString="{0:N0}" />
                <asp:BoundField HeaderText="平均" DataField="current_average" DataFormatString="{0:N0}" />
                <asp:BoundField HeaderText="住屋天數" DataField="debug" />
            </Columns>
           
        </asp:GridView>
        
        <asp:GridView ID="gv_debug" runat="server">
        </asp:GridView>
    </div>
    </form>
</body>
</html>
