<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="NewRenter.aspx.vb" Inherits="WebApplication3.NewRenter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <style type="text/css">
    p.updateProcess {
      background-color: Black;
      color: white;
      font-weight: bold;
      padding: 5px;
      text-transform: uppercase;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
     使用者列表&nbsp;
     <!--Ajax -->
     <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
    <p>頁面更新時間<%=DateTime.Now.ToLongTimeString() %></p>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="true">
                <ProgressTemplate>
                   <p class="updateProcess">處理中，請稍候...</p>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <p>GridView更新時間<%=DateTime.Now.ToLongTimeString() %></p>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                DataSourceID="SqlDataSource2" EmptyDataText="沒有資料錄可顯示。" AllowPaging="True" 
                AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="ChangeColor" PageSize="2">
                <RowStyle BackColor="#EFF3FB" />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                    <asp:BoundField DataField="WorkId" HeaderText="工號" 
                        SortExpression="WorkId" />
                    <asp:BoundField DataField="Name" HeaderText="姓名" SortExpression="Name" />
                    <asp:CommandField HeaderText="編輯" ShowEditButton="True" />
                </Columns>
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    
    <div>
       
    </div>

    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
         ConnectionString="<%$ ConnectionStrings:RentHouseConnectionString1 %>" 
         DeleteCommand="DELETE FROM [Renter] WHERE [ID] = @ID" 
         InsertCommand="INSERT INTO [Renter] ([WorkId], [Name]) VALUES (@WorkId, @Name)" 
         SelectCommand="SELECT * FROM [Renter]" 
         UpdateCommand="UPDATE [Renter] SET [WorkId] = @WorkId, [Name] = @Name WHERE [ID] = @ID">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="WorkId" Type="Int32" />
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="ID" Type="Int32" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="WorkId" Type="Int32" />
            <asp:Parameter Name="Name" Type="String" />
        </InsertParameters>
     </asp:SqlDataSource>
    </form>
    
</body>
</html>
