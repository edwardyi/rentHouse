Imports System.Data
Partial Class showTempDataTable
    Inherits System.Web.UI.Page
    '全域變數
    Dim tempDataSet As New DataSet()

    Protected Sub btn_Show_DataTable_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Show_DataTable.Click

        Dim workId = Request("workId")
        Dim startDate = Request("startDate")
        Dim endDate = Request("endDate")
        '計算每個月的狀況

        Dim list As New List(Of String)
        list.add(workId)
        list.add(startDate)
        list.add(endDate)
        Dim tempDataTable As DataTable = GetDetailData(list)
        'Dim rent4 As New RentHouse4(startDate, endDate)
        'Dim tempDataTable As DataTable = rent4.getTempDataTable(workId, startDate, endDate)
        '設定表頭(跨欄)
        'Dim header_row As New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
        'Dim header As New TableHeaderCell()
        '設值
        'header.Text = "工號:" & workId
        'header.ColumnSpan = 5
        '加入欄位
        'header_row.Controls.Add(header)
        '表首
        'show_temp_gridview.HeaderRow.Parent.Controls.Add(header_row)
        Response.Write(35000 / 31)
        show_temp_gridview.DataSource = tempDataTable
        show_temp_gridview.DataBind()
        '設定表單尾巴(跨欄)
        Dim row As New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
        Dim cell As New TableHeaderCell()

        Dim sum_money As Integer
        For Each temp_row As DataRow In tempDataTable.Rows
            Dim money As Integer = temp_row("money")
            sum_money = sum_money + money
        Next
        '設值
        '千分位
        'http://blog.xuite.net/isonic/MS/18550524-VB.Net%E6%A0%BC%E5%BC%8F%E5%8C%96%E5%AD%97%E4%B8%B2%E6%96%B9%E6%B3%95
        cell.Text = "工號:" & workId & " 加總:" & Format(sum_money, "###,###")
        cell.ColumnSpan = 5
        '加入欄位
        row.Controls.Add(cell)
        '表尾
        show_temp_gridview.FooterRow.Parent.Controls.Add(row)

        btn_Confirm_DataTable.Visible = True
    End Sub

    
    '保存至暫存的DataTable
    Protected Sub btn_Confirm_DataTable_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Confirm_DataTable.Click
        Dim workId = Request("workId")
        Dim startDate = Request("startDate")
        Dim endDate = Request("endDate")
        Dim rent4 As New RentHouse4(startDate, endDate)
        Dim tempDataTable As DataTable = rent4.getTempDataTable(workId, startDate, endDate)
        '保存dataset到session
        tempDataSet.Tables.Add(tempDataTable)
        Session("dataset") = tempDataSet
        'rent4.SaveInTempDataTable(tempDataTable)
        'Dim saveDataTable As DataTable = tempDataTable
        'tempDataSet.Tables.Add(saveDataTable)
        'Dim tempDataTable As DataTable = rent4.getTempDataTable(tempDataSet, workId, startDate, endDate)
    End Sub

    Protected Sub btn_Get_Current_DataSet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Get_Current_DataSet.Click
        Dim tempDataSet As New DataSet
        '從session取得dataset
        tempDataSet = Session("dataset")
        'Response.Write(tempDataSet.Tables.Count)

        'tempDataSet = CType(Session("dataset"), DataSet)
        ' tempDataSet = DirectCast(Session("dataset"), DataSet)
        'Dim rent4 = New RentHouse4("2015/01/01", "2015/01/01")
        'tempDataSet = rent4.GetTempDataSet()
        'tempDataSet = 
        'If tempDataSet.Tables.Count.Equals(0) Then
        'Response.Write("請輸入資料!目前暫無資料!")
        'Else
        'show_temp_gridview.DataSource = tempDataSet
        'show_temp_gridview.DataBind()
        'End If

    End Sub
    '要改成System.Web.UI.WebControls.GridViewRowEventArgs，判斷式才不會出錯(沒有進來)
    Protected Sub show_temp_gridview_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles show_temp_gridview.SelectedIndexChanged
        'Response.Write("GG")
        If e.Row.RowType = DataControlRowType.DataRow Then
            Response.Write("RowDataBound")
            Dim show_temp_gridview As GridView = TryCast(e.Row.FindControl("show_temp_gridview"), GridView)

            show_temp_gridview.DataBind()
            '設定表單尾巴(跨欄)
            Dim row As New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
            Dim cell As New TableHeaderCell()
            cell.Text = "加總:" & e.Row.Cells(5).Text
            cell.ColumnSpan = 4

            row.Controls.Add(cell)
            show_temp_gridview.FooterRow.Parent.Controls.Add(row)
        End If
    End Sub
    '在這裡定義顯示明細(由程式計算而來)
    Private Shared Function GetDetailData(ByVal list) As DataTable
        Dim dt As DataTable = New DataTable
        dt.Columns.Add("workId", Type.GetType("System.Int32"))
        dt.Columns.Add("s_date", Type.GetType("System.DateTime"))
        dt.Columns.Add("e_date", Type.GetType("System.DateTime"))
        dt.Columns.Add("money", Type.GetType("System.Int32"))
        dt.Columns.Add("average", Type.GetType("System.Int32"))
        dt.Columns.Add("liveDays", Type.GetType("System.Int32"))

        Dim workId As String = list(0).ToString
        '字串轉成日期格式
        Dim s_date As DateTime = list(1).ToString
        Dim e_date As DateTime = list(2).ToString
       

        Dim Rent3 As New RentHouse3(s_date, e_date)

        'Dim dictionary = createRent(s_date, e_date)
        'Dim Rent3 = dictionary.Item("Rent")
        '前三個月，每個月的費用
        Dim threeMonthFee = Rent3.ThreeMonthFee
        '免繳五分之三
        Dim rate = Rent3.Rate
        '回傳天數陣列
        Dim arr_month_fee = Rent3.pushArr(s_date, e_date, threeMonthFee, rate)
        Dim rowList = Rent3.showDetail(workId, s_date, e_date, arr_month_fee, threeMonthFee, rate, dt)
        '加入每一列
        For Each row As DataRow In rowList
            dt.Rows.Add(row)
        Next

        'dt.Rows.Add(s_date, e_date, money, average)
        'Dim table As DataTable = getRecordRow(query, dt)
        'Dim row As DataRow = dt.NewRow()

        Return dt
    End Function

   
End Class
