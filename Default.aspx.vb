Imports System.Data
Partial Public Class _Default
    Inherits System.Web.UI.Page
    Protected output As String
    'Repeater會用到(全域變數)
    'Protected show1 As Integer = 1
    'Protected show2 As Integer = 1
    'Protected show3 As String = "Test"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim uc As UserControl = FindControl("rent_uc")
        Dim workId As TextBox = FindControl("workId")
        Dim startDate As TextBox = FindControl("startDate")
        Dim endDate As TextBox = FindControl("endDate")
        workId.Text = "180001"
        startDate.Text = "2014/2/9"
        endDate.Text = "2015/12/28"
        'Response.Write(Rent3.full_test)

        'Repeater1.DataBind()
        'Me.DataBind()
    End Sub
    'Handles btn_Submit.Click
    Protected Sub btn_Submit_Click(ByVal sender As Object, ByVal e As EventArgs)

        '使用request取值
        Dim startDate = Request("startDate")
        Dim endDate = Request("endDate")

        Dim dictionary = createRent(startDate, endDate)
        Dim Rent3 = dictionary.Item("Rent")
        Dim totalRent = dictionary.Item("totalRent").ToString
        Dim lb1_total As Label = FindControl("lb1_total")
        Dim showResult As Label = FindControl("showResult")
        Dim total As Label = FindControl("total")
        lb1_total.Visible = True
        showResult.Text = Rent3.output
        total.Text = FormatCurrency(totalRent, 0)
        output = Rent3.output
        Me.DataBind()
        'Response.Write(Rent3.output)
        'Response.Write("總租金:" + FormatCurrency(totalRent, 0))
    End Sub

    '建立Rent物件，並回傳dictionary物件(共用方法:像static修飾子差不多)
    Public Shared Function createRent(ByVal startDate, ByVal endDate) As Dictionary(Of String, Object)
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
        'Dim output = Rent3.output()
        '房租加總
        Dim totalRent = Rent3.showResult(sDate, eDate, arr_month_fee, threeMonthFee, rate)
        Dim dictionary As New Dictionary(Of String, Object)
        dictionary.Add("Rent", Rent3)
        dictionary.Add("totalRent", totalRent)
        Return dictionary
    End Function
    'Handles showAllUsers.Click
    Protected Sub showAllUsers_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim connection = New Connection
        '呼叫完方法後就關閉連線(要用連線的話在開啟)
        Dim ds As DataSet = connection.GetRentRecord()
        Dim showUsersGrid As GridView = Page.FindControl("showUsersGrid")
        showUsersGrid.DataSource = ds
        showUsersGrid.DataBind()

    End Sub
    'Handles newRenter.Click
    Protected Sub newRenter_Click(ByVal sender As Object, ByVal e As EventArgs)

        Dim WorkID = Request("workId")
        Dim startDate = Request("startDate")
        Dim endDate = Request("endDate")

        Dim Rent3 As New RentHouse3(startDate, endDate)
        '字串轉成日期格式
        Dim sDate As DateTime = Rent3.SDate
        Dim eDate As DateTime = Rent3.EDate
        '前三個月，每個月的費用
        Dim threeMonthFee = Rent3.ThreeMonthFee
        '免繳五分之三
        Dim rate = Rent3.Rate
        Dim arr_month_fee = Rent3.pushArr(sDate, eDate, threeMonthFee, rate)

        Dim RentPerPrice = Rent3.showResult(sDate, eDate, arr_month_fee, threeMonthFee, rate)

        '檢查workId是否為空白
        'workIdCheck.Validate()
        'If WorkID.Length.Equals(0) Then
        'workIdCheck.Text = "工號不能為空"
        'Else
        Dim addResult As Integer = Rent3.AddRent(WorkID, startDate, endDate, RentPerPrice)
        Dim result As Label = FindControl("result")
        'Response.Write(addResult.ToString)
        If addResult.Equals(0) Then
            result.Text = "新增成功!"
        ElseIf addResult.Equals(1) Then
            result.Text = "新增失敗!" & WorkID.ToString() & "工號不存在!"
        ElseIf addResult.Equals(2) Then
            result.Text = "新增失敗!" & WorkID.ToString() & "資料已存在!"
        End If
    End Sub
    '這個方法看起來像沒有用
    Private Shared Function GetDetailData(ByVal list) As DataTable
        System.Diagnostics.Debug.WriteLine("shared function getDetailData")
        Dim dt As DataTable = New DataTable
        dt.Columns.Add("s_date", Type.GetType("System.DateTime"))
        dt.Columns.Add("e_date", Type.GetType("System.DateTime"))
        dt.Columns.Add("money", Type.GetType("System.Int32"))
        dt.Columns.Add("average", Type.GetType("System.Int32"))
        Dim userId As String = list(0).ToString
        Dim workId As String = list(1).ToString
        '字串轉成日期格式
        Dim s_date As DateTime = list(2).ToString
        Dim e_date As DateTime = list(3).ToString

        'Dim money As Integer = list(4).ToString
        'Dim average As Integer = 3


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
    Public Function getRecordRow(ByVal query As String, ByVal datatable As DataTable) As DataTable

        datatable.Rows.Add(1)
        datatable.Rows.Add(4)
        Return datatable
    End Function
    'RowDataBound事件(每一個列)
    'Handles showUsersGrid.RowDataBound
    Private Sub showUsersGrid_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            '取得UserId
            Dim UserId As String = e.Row.Cells(1).Text
            Dim detailGrid As GridView = TryCast(e.Row.FindControl("detailGrid"), GridView)
            'Response.Write("GG")
            'For Each row As Object In GetDetailData(UserId).Rows
            ' Response.Write(row(0))
            'Next
            System.Diagnostics.Debug.WriteLine("showUsersGrid_RowDataBound=>")
            Dim list As New List(Of String)
            'list.Add(e.Row.Cells(0).Text)
            list.Add(e.Row.Cells(1).Text)
            list.Add(e.Row.Cells(2).Text)
            list.Add(e.Row.Cells(3).Text)
            list.Add(e.Row.Cells(4).Text)
            list.Add(e.Row.Cells(5).Text)
            detailGrid.DataSource = GetDetailData(list)
            '設定表單尾巴(跨欄)
            Dim row As New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
            Dim cell As New TableHeaderCell()
            cell.Text = "加總:" & e.Row.Cells(5).Text
            cell.ColumnSpan = 4

            row.Controls.Add(cell)

            'detailGrid.FooterRow.Parent.Controls.Add(0, row)
            detailGrid.DataBind()
            detailGrid.FooterRow.Parent.Controls.Add(row)
        End If


    End Sub

End Class