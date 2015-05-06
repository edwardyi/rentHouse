<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="showRepeater.aspx.vb" Inherits="WebApplication3.showRepeater" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <style type="text/css">
        #showTable
        {
            border:1px solid black;
        }
       
        #showTable td
        {
              border:1px solid black;
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <!-- 'StoreProcedureTest()  -->
      <table id="showTable" cellpadding="5" cellspacing="0">
            <tr>
                <td>編號</td>
                <td>工號</td>
                <td>月(S)</td>
                <td>月(E)</td>
                <td>每月租金</td>
            </tr>
            <%= outputTd %>
        </table>

        <asp:Repeater ID="showRepeater1" runat="server"  >
        <HeaderTemplate>
            <table id="showTable" cellpadding="5" cellspacing="0">
            <tr>
                <td>編號</td>
                <td>工號</td>
                <td>月(S)</td>
                <td>月(E)</td>
                <td>每月租金</td>
            </tr>
        </HeaderTemplate>
        <ItemTemplate>
               
            <%
                'Dim startDate = Container.DataItem("StartDate")
                'Dim endDate = Container.DataItem("EndDate")
                
                For i = 0 To 5
            %>
            
            <tr>
                
                <td><%# Container.DataItem("ID") %></td>
                <td><%# Eval("WorkID") %></td>
                <td><%# DataBinder.Eval(Container.DataItem,"StartDate") %></td>
                <td><%# Eval("EndDate") %></td>
                <td><%# Eval("RentPerPrice") %></td>
                
            </tr>
            
             <%
                Next
            %>
        </table>
        </ItemTemplate>
        </asp:Repeater>
       
        
        
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:RentHouseConnectionString1 %>" 
            SelectCommand="SELECT * FROM [RentRecord]"></asp:SqlDataSource>
       
        
        
     </div>
    </form>
</body>
</html>
