Imports System.Data
Partial Class showTempDataTable
    Inherits System.Web.UI.Page
    '全域變數
    Dim tempDataSet As New DataSet("RentTemp")

    Protected Sub btn_Show_DataTable_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Show_DataTable.Click

        Dim workId = Request("workId")
        Dim startDate = Request("startDate")
        Dim endDate = Request("endDate")
        '計算每個月的狀況

     

        Dim rent4 As New RentHouse4(startDate, endDate)
        Dim tempDataTable As DataTable = rent4.getTempDataTable(workId, startDate, endDate)

        show_temp_gridview.DataSource = tempDataTable
        show_temp_gridview.DataBind()
        btn_Confirm_DataTable.Visible = True
    End Sub

    
    '保存至暫存的DataTable
    Protected Sub btn_Confirm_DataTable_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Confirm_DataTable.Click
        Dim workId = Request("workId")
        Dim startDate = Request("startDate")
        Dim endDate = Request("endDate")
        Dim rent4 As New RentHouse4(startDate, endDate)
        Dim tempDataTable As DataTable = rent4.getTempDataTable(workId, startDate, endDate)

        rent4.SaveInTempDataTable(tempDataTable)
        'Dim saveDataTable As DataTable = tempDataTable
        'tempDataSet.Tables.Add(saveDataTable)
        'Dim tempDataTable As DataTable = rent4.getTempDataTable(tempDataSet, workId, startDate, endDate)
    End Sub

    Protected Sub btn_Get_Current_DataSet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Get_Current_DataSet.Click
        Dim rent4 = New RentHouse4("2015/01/01", "2015/01/01")
        tempDataSet = rent4.GetTempDataSet()
        'tempDataSet = 
        If tempDataSet.Tables.Count.Equals(0) Then
            Response.Write("請輸入資料!目前暫無資料!")
        Else
            show_temp_gridview.DataSource = tempDataSet
            show_temp_gridview.DataBind()
        End If

    End Sub
    '要改成System.Web.UI.WebControls.GridViewRowEventArgs，判斷式才不會出錯
    Protected Sub show_temp_gridview_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles show_temp_gridview.SelectedIndexChanged
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim detailGrid As GridView = TryCast(e.Row.FindControl("detailGrid"), GridView)
            detailGrid.DataBind()
            '設定表單尾巴(跨欄)
            Dim row As New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
            Dim cell As New TableHeaderCell()
            cell.Text = "加總:" & e.Row.Cells(5).Text
            cell.ColumnSpan = 4

            row.Controls.Add(cell)
            detailGrid.FooterRow.Parent.Controls.Add(row)
        End If
    End Sub
End Class
