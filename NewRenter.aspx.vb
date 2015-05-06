Public Partial Class NewRenter
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim connection = New Connection
        'Dim dictionary As New Dictionary(Of String, String)
        'dictionary.Add("WorkId", 180001)
        'dictionary.Add("Name", "小明")
        'Dim list As New List(Of String)(dictionary.Keys)
        Dim ds As DataSet = connection.GetRecord()
        'Response.Write(ds.GetXml())
        'connection.AddRecord(180004, "小李")
        'For Each ds As DataRow In ds.Tables("Renter").Rows(1).Item(1)

        'Next

        'connection.AddRecord("Renter")

    End Sub
    '小於六十分的變色
    Sub ChangeColor(ByVal obj As Object, ByVal args As GridViewRowEventArgs)
        If (args.Row.RowIndex >= 0) Then
            args.Row.Cells(0).Text = "<font color='blue' style='text-align:center;'>" & args.Row.Cells(0).Text & "</font>"
        End If
    End Sub
End Class