Public Partial Class DataTableTest
    Inherits System.Web.UI.Page
    Private i As Integer = 1
    Private dt As DataTable = New DataTable
    Private dt2 As DataTable = New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dt.Columns.Add("ID")
        dt.Columns.Add("來源")
        dt2 = GetNormalDataTable()
        dt = GetDataTable(6, i)
        gv1.DataSource = dt
        gv1.DataBind()
        For Each row As DataRow In dt.Rows
            'Response.Write("TTTT")
            'Response.Write(row("ID").ToString())
            'Response.Write(row.Field(Of Integer)("ID"))
            'Response.Write("ttt")
        Next
        'Response.Write(factorial(5))

    End Sub
    '遞回寫法
    Private Function GetDataTable(ByVal length, ByRef i) As DataTable
        If i <= length Then
            Dim dr As DataRow = dt.NewRow
            'Response.Write(i)
            dr("ID") = i
            dr("來源") = "SQL"
            dt.Rows.Add(dr)
            GetDataTable(length, i + 1)
            Return dt
        End If
    End Function
    '遞回
    Function factorial(ByVal n As Integer) As Integer
        Return If(n <= 1, 1, factorial(n - 1) * n)
        'If n <= 1 Then
        ' Return 1
        'Else
        'Return factorial(n - 1) * n
        'End If
    End Function
    '迴圈設值
    Function GetNormalDataTable()
        dt2.Columns.Add("ID")
        dt2.Columns.Add("Name")
        For i As Integer = 1 To 10
            Dim row As DataRow = dt2.NewRow

            row("ID") = i
            row("Name") = "Test"
            dt2.Rows.Add(row)
        Next
        Return dt2
    End Function
    Function GetTable() As DataTable
        ' Create new DataTable instance.
        Dim table As New DataTable

        ' Create four typed columns in the DataTable.
        table.Columns.Add("Dosage", GetType(Integer))
        table.Columns.Add("Drug", GetType(String))
        table.Columns.Add("Patient", GetType(String))
        table.Columns.Add("Date", GetType(DateTime))

        ' Add five rows with those columns filled in the DataTable.
        table.Rows.Add(25, "Indocin", "David", DateTime.Now)
        table.Rows.Add(50, "Enebrel", "Sam", DateTime.Now)
        table.Rows.Add(10, "Hydralazine", "Christoff", DateTime.Now)
        table.Rows.Add(21, "Combivent", "Janet", DateTime.Now)
        table.Rows.Add(100, "Dilantin", "Melanie", DateTime.Now)

        Return table
    End Function
End Class