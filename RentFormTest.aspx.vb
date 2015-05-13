Imports System.Data
Partial Class RentFormTest
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      
    End Sub
    Protected Sub newRenter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RentForm21.newRenterClickA
        '不能直接讀取user control中的屬性，要透過自定義的方法來取值
        Dim workId = RentForm21.getWorkId()
        Dim startDate = RentForm21.getStartDate()
        Dim endDate = RentForm21.getEndDate()
        '另一個user control
        'Dim showUsersGrid = gvRentForm21.getGvDataSource()
        Dim list As New List(Of String)
        list.add(workId.Text)
        list.add(startDate.Text)
        list.add(endDate.Text)
        Dim tempDataTable As DataTable = GetDetailData(list)
        gvRentForm31.getGvDataSource() = tempDataTable
        

    End Sub
    Protected Sub btn_Submit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RentForm21.customBtnClick
        Response.Write("calculating....")
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
        Return dt
    End Function
End Class
