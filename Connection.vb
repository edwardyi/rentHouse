Imports System.Data
Imports System.Data.SqlClient

'多補上下方兩個imports
Imports System
Imports System.Web.Configuration
Public Class Connection
    'connectionString私有
    Private connectionString As String

    Dim con As New SqlConnection
    Dim cmd As New SqlCommand


    Public Sub New()
        connectionString = WebConfigurationManager.ConnectionStrings("RentHouseConnectionString1").ConnectionString
    End Sub
    '查詢開始
    Public Function GetRecord(Optional ByVal workId As Integer = 0)
        Dim query As String = "select * from Renter"
        If workId <> 0 Then
            query = query & " where WorkId  = @workId "
        End If
        Dim cmd = New SqlCommand(query)
        cmd.Parameters.AddWithValue("@workId", workId)
        Return FillDataSet(cmd, "Renter")
    End Function
    '查詢workId是否存在
    Public Function GetRentRecord(Optional ByVal workId As Integer = 0)
        Dim query As String = "select * from RentRecord"
        If workId <> 0 Then
            query = query & " where WorkID = @workId "
        End If
        Dim cmd = New SqlCommand(query)
        cmd.Parameters.AddWithValue("@workId", workId)
        Return FillDataSet(cmd, "RentRecord")
    End Function
    '公用方法，處理陣列後回傳dataset的物件
    Public Function FillDataSet(ByVal cmd As SqlCommand, ByVal tableName As String) As DataSet
        Dim con As New SqlConnection(connectionString)
        cmd.Connection = con
        Dim adapter As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        Try
            con.Open()
            adapter.Fill(ds, tableName)
        Catch ex As Exception
            con.Close()
        End Try
        Return ds
    End Function
    '查詢結束
    '新增開始
    'Sub為不需要回傳值的方法
    Public Sub AddRecord(ByVal workId As Integer, ByVal name As String)
        Dim con As New SqlConnection(connectionString)
        '建立查詢
        Dim insertSql As String = "INSERT INTO Renter (WorkId, Name) VALUES(@workId,@name)"
        Dim cmd As New SqlCommand(insertSql, con)
        'AddWithValue可以避免sql injection
        cmd.Parameters.AddWithValue("@workId", workId)
        cmd.Parameters.AddWithValue("@name", name)
        Try
            con.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            con.Close()
        End Try
    End Sub
    Public Sub AddRentRecord(ByVal workId As Integer, ByVal startDate As DateTime, ByVal endDate As DateTime, ByVal RentPerPrice As Integer)
        Dim con As New SqlConnection(connectionString)
        Dim insertSql As String = "INSERT INTO RentRecord(WorkID,StartDate,EndDate,RentPerPrice) VALUES(@workId,@startDate,@endDate,@RentPerPrice)"
        Dim cmd As New SqlCommand(insertSql, con)
        cmd.Parameters.AddWithValue("@workId", workId)
        cmd.Parameters.AddWithValue("@startDate", startDate)
        cmd.Parameters.AddWithValue("@endDate", endDate)
        cmd.Parameters.AddWithValue("@RentPerPrice", RentPerPrice)
        Try
            con.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            con.Close()
        End Try
    End Sub
    Public Function AddRecord2(ByVal table)
        'Try
        Dim connetionString As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\RentHouse.mdf;Integrated Security=True;User Instance=True"
        con.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\RentHouse.mdf;Integrated Security=True;User Instance=True"
        'con.Open()
        'cmd.Connection = con

        Try
            con = New SqlConnection(connetionString)
            Dim Sqlstr As String = "INSERT INTO " & table.ToString & "(WorkId, Name) VALUES(180003, " & "小郭" & ")"

            cmd.CommandText = Sqlstr
            'cmd = New SqlCommand(Sqlstr, con)
            'cmd.ExecuteNonQuery()
            'Sqlstr = "SELECT * FROM " & table
            'cmd.ExecuteReader()

            Return ("連線成功!")
            'MsgBox("Connection Open ! ", MsgBoxStyle.MsgBoxHelp, "ERROR")

            con.Close()
        Catch ex As Exception
            Return ex.Message
            'Return (ex.Message & "<br/>" & "INSERT INTO " & table & "(WorkId, Name) VALUES(180003, '小郭')")
            'MsgBox("Connection Open ! ", MsgBoxStyle.MsgBoxHelp, "Error")
        End Try
        ' Dim dsInternal As New DataSet()
        ' Add some actual information into the table.
        'Dim rowNew As DataRow = dsInternal.Tables(table.ToString).NewRow()
        'rowNew("WorkId") = "18001"
        'rowNew("Name") = "Uganda"
        'dsInternal.Tables(table).Rows.Add(rowNew)


        'cmd.CommandText = "INSERT INTO " & table & "([field1], [field2]) VALUES([Value1], [Value2])"
        ' cmd.ExecuteNonQuery()

        'Catch ex As Exception
        '   Return ("加入資料發生錯誤" & ex.Message)
        'Finally
        '   con.Close()
        'End Try
    End Function
End Class
