Imports System.Data
Partial Public Class PureArray
    Inherits System.Web.UI.Page
    Dim recordTable As DataTable = New DataTable("record")
    Dim renterTable As DataTable = New DataTable("renter")
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dsNew As DataSet = New DataSet
        Dim dtNew As DataTable = dsNew.Tables.Add(0)
        '呼叫方法建立datatable資料
        renterTable = BuildRenter()
        recordTable = BuildRecord()
        '結果
        Dim dsMerge As DataSet = New DataSet
        '加入資料表
        dsMerge.Tables.Add(renterTable)
        dsMerge.Tables.Add(recordTable)
        '加入關聯
        dsMerge.Relations.Add("Rid", renterTable.Columns("ID"), recordTable.Columns("ID"), True)
        '加總
        'Dim subTotal As DataColumn("subTotal",GetType(Decimal),"Sum(Child.RentPerPrice)")
        For Each row As DataRow In dsMerge.Tables(0).Rows
            Response.Write(row(4).ToString)
            Response.Write("<br/>")
        Next

        'ID是主鍵
        Dim rid1 = renterTable.AsEnumerable().Select(Function(r) r.Field(Of Int32)("ID"))
        Dim rid2 = recordTable.AsEnumerable().Select(Function(r) r.Field(Of Int32)("ID"))
        Dim uniqueRid = rid1.Except(rid2).ToList()
        Dim tblResult = (From row In renterTable.AsEnumerable() Join Rid In uniqueRid On row.Field(Of Int32)("ID") Equals Rid Select row).CopyToDataTable()
        Response.Write(tblResult)


        '不能以變數來存，要加左右括號
        Dim select_result() As DataRow = renterTable.Select("WorkId = 2 ")
        For Each row As DataRow In select_result
            'Response.Write(row.Field(Of String)(2))
        Next

        renterTable.Merge(recordTable)

        'PrintValues(renterTable, "Merge")
        'PrintValues(renterTable, "test")

        'For Each row As DataRow In BuildRecord.Rows
        'Response.Write(row(2).ToString)

        'Next

    End Sub
    Public Function BuildRenter()
        Dim RId As DataColumn = renterTable.Columns.Add("ID", Type.GetType("System.Int32"))
        'RId.AllowDBNull = False
        'RId.AutoIncrement = True
        'RId.Unique = True
        'RId.AutoIncrementSeed = 200
        'RId.AutoIncrementStep = 2
        renterTable.Columns.Add("WorkId", Type.GetType("System.Int32"))
        renterTable.Columns.Add("Name", Type.GetType("System.String"))
        '兩種方式都能夠建立欄位
        renterTable.Columns.Add(New DataColumn("Test", Type.GetType("System.String")))
        '針對資料表設定主鍵
        renterTable.PrimaryKey = New DataColumn() {RId}

        renterTable.Rows.Add(1, 1, "GG")
        renterTable.Rows.Add(2, 2, "HH")
        renterTable.Rows.Add(3, 3, "JJ")
        Return renterTable
    End Function
    Public Function BuildRecord()

        Dim RId As DataColumn = recordTable.Columns.Add("ID", Type.GetType("System.Int32"))
        'RId.AllowDBNull = False
        'RId.AutoIncrement = True
        'RId.Unique = True
        'RId.AutoIncrementSeed = 200
        'RId.AutoIncrementStep = 2

        recordTable.Columns.Add("WorkID", Type.GetType("System.Int32"))
        recordTable.Columns.Add("StartDate", Type.GetType("System.DateTime"))
        recordTable.Columns.Add("EndDate", Type.GetType("System.DateTime"))
        recordTable.Columns.Add("RentPerPrice", Type.GetType("System.Int32"))

        Dim i As Integer = 0
        Do
            Dim row As DataRow = recordTable.NewRow
            row("ID") = 1
            row("WorkID") = 1
            row("StartDate") = "2015/5/5"
            row("EndDate") = "2015/5/5"
            row("RentPerPrice") = 123
            recordTable.Rows.Add(row)
            Dim row1 As DataRow = recordTable.NewRow
            row1("ID") = 2
            row1("WorkID") = 2
            row1("StartDate") = "2015/5/5"
            row1("EndDate") = "2015/5/5"
            row1("RentPerPrice") = 123
            recordTable.Rows.Add(row1)
        Loop Until i = 0

        ' Accept changes.
        recordTable.AcceptChanges()
        Return recordTable
    End Function

    Private Sub PrintValues(ByVal table As DataTable, ByVal label As String)
        Response.Write(label)
        Response.Write("<br/>")
        For Each row As DataRow In table.Rows
            For Each column As DataColumn In table.Columns
                Response.Write(ControlChars.Tab & "+" & row(column).ToString)
            Next
            Response.Write("<br/>")
        Next
    End Sub

End Class