Imports System.Web.Configuration
Imports System.Data
Imports System.Data.SqlClient
'store Procedure
Imports System
Partial Public Class showRepeater
    Inherits System.Web.UI.Page

    '== 重點 =================================
    '== 必須設定為 public。否則就會視為 private而發生錯誤。
    Public myNO1, myNO2, myTotal As Integer
    Public recordID, WorkID, RentPerPrice As Integer
    Public startDate, endDate As DateTime
    Public outputTd As String
    '跑回圈使用
    Public i As Integer = 0
    '=======================================

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '0412 okay(先註解掉)
        StoreProcedureTest()
        createStoreProcedure()

    End Sub
    Private Sub createStoreProcedure()
        Dim Connection As SqlConnection = New SqlConnection(WebConfigurationManager.ConnectionStrings("RentHouseConnectionString1").ConnectionString)
        Dim command As SqlCommand = New SqlCommand("createRepeater", Connection)
        command.CommandType = CommandType.StoredProcedure
        Connection.Open()
        Dim myReader = command.ExecuteReader()
        Do While myReader.Read
            Response.Write(myReader.GetString(0))
        Loop
        Connection.Close()
        Me.DataBind()
    End Sub
    '0412 okay(在Page_Load方法中先註解掉)
    Private Sub StoreProcedureTest()
        Dim Connection As SqlConnection = New SqlConnection(WebConfigurationManager.ConnectionStrings("RentHouseConnectionString1").ConnectionString)
        Dim command As SqlCommand = New SqlCommand("showRepeater", Connection)
        command.CommandType = CommandType.StoredProcedure
        Connection.Open()
        Dim myReader = command.ExecuteReader()
        Do While myReader.Read
            '資料表欄位
            Dim recordId As Int32 = myReader.GetInt32(0)
            Dim workId As Int32 = myReader.GetInt32(1)
            Dim startDate As String = myReader.GetDateTime(2)
            Dim endDate As String = myReader.GetDateTime(3)
            Dim rentPerPrice As Int32 = myReader.GetInt32(4)
            'Rent3物件
            Dim Rent3 As New RentHouse3(startDate, endDate)
            '字串轉成日期格式
            Dim sDate As DateTime = Rent3.SDate
            Dim eDate As DateTime = Rent3.EDate
            '前三個月，每個月的費用
            Dim threeMonthFee = Rent3.ThreeMonthFee
            '免繳五分之三
            Dim rate = Rent3.Rate
            '回傳天數陣列

            Dim arr_month_fee = Rent3.pushArr(sDate, eDate, threeMonthFee, rate)
            outputTd = outputHtml(recordId, workId, sDate, eDate, arr_month_fee, threeMonthFee, rate)
            

        Loop
        Connection.Close()
        Me.DataBind()

        
    End Sub
    Public Function outputHtml(ByVal recordId, ByVal workId, ByVal sDate, ByVal eDate, ByVal arr_month_fee, ByVal threeMonthFee, ByVal rate)
        Dim totalRent = 0
        Dim currentYear = sDate.Year
        Dim currentMonth = sDate.Month
        Dim j As Integer = 0

        For Each Item As Integer In arr_month_fee
            Dim outStr As String = ""
            If currentMonth > 12 Then
                currentMonth = 1
                currentYear = currentYear + 1
            End If

            '當前月份天數
            Dim daysInmonth = DateTime.DaysInMonth(currentYear, currentMonth)

            If j.Equals(0) Then
                outStr = outStr & "<tr>"
                outStr = outStr & "<td>" & recordId & "</td>"
                outStr = outStr & "<td>" & workId & "</td>"
                outStr = outStr & "<td>" & sDate & "</td>"
                outStr = outStr & "<td>" & currentYear & "/" & currentMonth & "/" & daysInmonth & "</td>"
                outStr = outStr & "<td>" & FormatCurrency(Item, 0).ToString().Replace("NT$", "") & "</td>"
                outStr = outStr & "</tr>"
            ElseIf j.Equals(arr_month_fee.Length - 1) Then
                outStr = outStr & "<tr>"
                outStr = outStr & "<td>" & recordId & "</td>"
                outStr = outStr & "<td>" & workId & "</td>"
                outStr = outStr & "<td>" & currentYear & "/" & currentMonth & "/1</td>"
                outStr = outStr & "<td>" & currentYear & "/" & currentMonth & "/" & eDate.Day & "</td>"
                outStr = outStr & "<td>" & FormatCurrency(Item, 0).ToString().Replace("NT$", "") & "</td>"
                outStr = outStr & "</tr>"
               
            Else
                outStr = outStr & "<tr>"
                outStr = outStr & "<td>" & recordId & "</td>"
                outStr = outStr & "<td>" & workId & "</td>"
                outStr = outStr & "<td>" & currentYear & "/" & currentMonth & "/1</td>"
                outStr = outStr & "<td>" & currentYear & "/" & currentMonth & "/" & daysInmonth & "</td>"
                outStr = outStr & "<td>" & FormatCurrency(Item, 0).ToString().Replace("NT$", "") & "</td>"
                outStr = outStr & "</tr>"
            End If
            '輸出
            outputTd = outputTd & outStr
            '當月加一
            currentMonth = currentMonth + 1
            totalRent = totalRent + Item
            j = j + 1
        Next
        outputTd = outputTd & "<tr><td colspan='5' style='text-align:right'>" & FormatCurrency(totalRent, 0).ToString().Replace("NT$", "") & "</td></tr>"
        Return outputTd
    End Function
    Private Sub DataReaderTest()
        Dim Connection As SqlConnection = New SqlConnection(WebConfigurationManager.ConnectionStrings("RentHouseConnectionString1").ConnectionString)
        Dim command As SqlCommand = New SqlCommand("select * from RentRecord", Connection)
        Connection.Open()

        Dim reader As SqlDataReader = command.ExecuteReader()

        If reader.HasRows Then
            Do While reader.Read()
                'reader.GetInt32()
                Response.Write(reader.GetInt32(1))
                'Console.WriteLine(vbTab & reader.GetString(1))
            Loop
        Else
            Response.Write("NO")
            'Console.WriteLine("No rows found.")
        End If

        reader.Close()
    End Sub
    Private Sub DataSetTest()
        '----連結資料庫----
        Dim Conn As SqlConnection = New SqlConnection(WebConfigurationManager.ConnectionStrings("RentHouseConnectionString1").ConnectionString)
        Dim myAdapter As SqlDataAdapter = New SqlDataAdapter("select * from RentRecord", Conn)

        Dim ds As DataSet = New DataSet()

        'Conn.Open()   '---- 不用寫，DataAdapter會自動開啟
        'Response.Write("<hr />1. Fill()方法之前，資料庫連線 Conn.State ---- " & Conn.State.ToString() & "<hr />")
        myAdapter.Fill(ds, "s_test")   '---- 這時候執行SQL指令。取出資料，放進 DataSet。
        '註解：執行SQL指令之後，把資料庫撈出來的結果，交由畫面上 DataBinding Expression來呈現。
        '****************************************
        'DataSet是一種 "離線（Disconnect）"的資料存取，不需要長時間與資料來源保持連接的狀態。
        'Response.Write("<hr />1. Fill()方法之後，資料庫連線 Conn.State ---- " & Conn.State.ToString() & "<hr />")
        '-------------------------------------------------------------------(start)
        If ds.Tables("s_test").Rows.Count <= i Then
            '-- 倘若不加這段 if判別式就會出大錯！！
            Exit Sub  '
        Else
            '新增一列資料
            Dim row As DataRow
            row = ds.Tables("s_test").NewRow
            row("ID") = 123 + i
            row("WorkID") = 312
            row("startDate") = "2014-01-01"
            row("endDate") = "2014-01-01"
            row("RentPerPrice") = 343
            'ds.Tables("s_test").Rows.Add(row)
            i = i + 1

        End If
        'Response.Write("test")
        showRepeater1.DataSource = ds
        showRepeater1.DataBind()
        'outputTd = "<tr><td colspan='4'>test</td></tr>"
        Me.DataBind()
    End Sub
    
End Class