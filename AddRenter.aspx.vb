'DataSet
Imports System.Data

Partial Class AddRenter
    Inherits System.Web.UI.Page
    Protected Sub Add_Button_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Add_Button.Click
        Dim workId = Request("WorkId")
        Dim name = Request("Name")
        '將connection的類別放到App_Code的資料夾中
        Dim connection As New Connection()
        Dim dataset As DataSet = connection.GetRecord(workId)

        If dataset.Tables(0).Rows.Count = 0 Then
            connection.AddRecord(workId, name)
            Response.Write("新增" & name & "成功!")

        Else
            Response.Write("該使用者已存在，不需新增!")
        End If


    End Sub
End Class
