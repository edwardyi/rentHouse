Imports Microsoft.VisualBasic
Imports System.Data
Public Class RentHouse4
    '開始時間
    '私有屬性加上底線
    Private _sDate As String
    '結束時間
    Private _eDate As String
    '前三個月，每個月的費用
    Dim _threeMonthFee = 35000
    '免繳五分之三
    Dim _rate = 1 - 3 / 5

    Public output As String = ""
    'Public full_test As String = ""
    '用來判斷是否滿月
    Private currentFlag As Integer = 0
    Private fullFlag As Integer = 0
    '計算每月狀況
    Dim tempDataTable As New DataTable
    Dim tempDataSet As New DataSet

    Public Sub New(ByVal sDate As String, ByVal eDate As String)
        _sDate = sDate
        _eDate = eDate
    End Sub
    '使用Property方法設定及存取屬性
    '必須要大寫開頭
    Public Property sDate() As String
        Get
            Return _sDate
        End Get
        Set(ByVal value As String)
            _sDate = value
        End Set
    End Property
    Public Property EDate() As String
        Get
            Return _eDate
        End Get
        Set(ByVal value As String)
            _eDate = value
        End Set
    End Property
    Public ReadOnly Property ThreeMonthFee() As String
        Get
            Return _threeMonthFee
        End Get
    End Property
    Public ReadOnly Property Rate() As String
        Get
            Return _rate
        End Get
    End Property

    Public Sub New(ByVal sDate, ByVal eDate, ByVal threemonthFee, ByVal rate)

        sDate = sDate
        eDate = eDate
        threemonthFee = threemonthFee
        rate = rate
    End Sub
    Public Function createArr(ByVal sDate, ByVal eDate)
        'Return eDate
        sDate = Convert.ToDateTime(sDate)
        eDate = Convert.ToDateTime(eDate)
        '月份間距(當作鎮列的長度)
        Dim monthInterval = DateDiff(DateInterval.Month, sDate, eDate)

        '回傳daysArray陣列
        Dim daysArray As Array = New Integer(monthInterval) {}
        Dim currentYear As Integer = sDate.Year
        Dim currentMonth As Integer = sDate.Month
        For i As Integer = 0 To monthInterval
            '如果當前年分大於結束年分或當前月份大於12
            If currentYear > eDate.Year Or currentMonth > 12 Then
                currentYear = currentYear + 1
                currentMonth = 1
            End If
            '取得當前年分有幾天
            daysArray(i) = DateTime.DaysInMonth(currentYear, currentMonth)
            currentMonth = currentMonth + 1

        Next

        Return daysArray
    End Function
    '判斷開始租屋是否為滿月
    Public Function isfullStart(ByVal day, ByVal daysInMonth, ByVal threeMonthFee, ByVal rate)
        '滿月
        If (day.Equals(1)) Then
            currentFlag = currentFlag + 1
            Return threeMonthFee
        Else
            Dim interval = daysInMonth - day + 1
            '非滿月
            Return threeMonthFee * (interval / 30)
        End If

    End Function
    '判斷結束租屋是否滿月
    Public Function isfullEnd(ByVal day, ByVal daysInMonth, ByVal threeMonthFee, ByVal rate)
        '滿月如果又為九十天後一個月
        If (day.Equals(daysInMonth)) Then
            '先加上1後再取餘數
            currentFlag = currentFlag + 1
            If (currentFlag Mod 4 = 0) Then
                Return threeMonthFee * rate
            Else
                Return threeMonthFee
            End If
        Else
            currentFlag = currentFlag + 1
            If (currentFlag Mod 4 = 0) Then
                Return threeMonthFee * rate * (day / 30)
            Else
                Return threeMonthFee * (day / 30)
            End If
        End If
    End Function
    '判斷其他月份
    Public Function isfullother(ByVal daysInMonth, ByVal threeMonthFee, ByVal rate)
        '先加上1後再取餘數
        currentFlag = currentFlag + 1
        If (currentFlag Mod 4 = 0) Then
            currentFlag = 0
            Return threeMonthFee * rate
        Else
            Return threeMonthFee
        End If

        '判斷是否滿三個月

    End Function
    Public Function pushArr(ByVal sDate, ByVal eDate, ByVal threeMonthFee, ByVal rate)
        '回傳天數陣列
        Dim arr = createArr(sDate, eDate)
        '日期加總
        Dim dayCount = 0

        'flag用來判斷天數是否大於九十天
        Dim flag As Integer = 0
        Dim tempDays As Integer = 0
        'i用來判斷目前foreach執行位置(當作key使用)
        Dim i As Integer = 0

        Dim arr_month_fee As Array = New Integer(arr.length - 1) {}
        '日期計算
        For Each Item As Integer In arr

            '判斷是否為開始時間
            If i.Equals(0) Then

                dayCount = Item - sDate.Day + 1
                arr_month_fee(i) = isfullStart(sDate.Day, Item, threeMonthFee, rate)
                'arr_month_fee(i) = threeMonthFee * (dayCount / 30)
                '判斷是否為結束時間
            ElseIf i.Equals(CInt(arr.length) - 1) Then
                dayCount = dayCount + eDate.Day
                arr_month_fee(i) = isfullEnd(eDate.Day, Item, threeMonthFee, rate)

                '其他月份
            Else
                dayCount = dayCount + Item
                arr_month_fee(i) = isfullother(Item, threeMonthFee, rate)


            End If
            '遞增
            i = i + 1
        Next
        Return arr_month_fee
    End Function
    '點擊顯示後佔存於datatable中
    Public Sub SaveInTempDataTable(ByVal dataTable As DataTable)
        tempDataSet.Tables.Add(dataTable)
    End Sub
    Public Function GetTempDataSet() As DataSet
        Return tempDataSet
    End Function

    '點擊修改佔存datatable
    Public Sub UpdateTempDataTable(ByVal dataset, ByVal workId, ByVal startDate, ByVal endDate)

    End Sub

    '計算每一列資料
    Public Function getTempDataTable(ByVal workId, ByVal sDate, ByVal eDate) As DataTable
        sDate = Convert.ToDateTime(sDate)
        eDate = Convert.ToDateTime(eDate)
        Dim tempDataTable As DataTable = New DataTable()
        tempDataTable.Columns.Add("WorkId", Type.GetType("System.Int32"))
        tempDataTable.Columns.Add("s_current_date", Type.GetType("System.DateTime"))
        tempDataTable.Columns.Add("e_current_date", Type.GetType("System.DateTime"))
        tempDataTable.Columns.Add("current_money", Type.GetType("System.Int32"))
        tempDataTable.Columns.Add("current_average", Type.GetType("System.Int32"))
        tempDataTable.Columns.Add("debug", Type.GetType("System.String"))
        '回傳天數陣列
        Dim arr = createArr(sDate, eDate)
        '日期加總
        Dim dayCount = 0

        'flag用來判斷天數是否大於九十天
        Dim flag As Integer = 0
        Dim tempDays As Integer = 0
        'i用來判斷目前foreach執行位置(當作key使用)
        Dim i As Integer = 0

        'Dim arr_month_fee As Array = New Integer(arr.length - 1) {}
        '日期計算
        For Each Item As Integer In arr
            '定義欄位
            Dim row As DataRow = tempDataTable.NewRow()

            '判斷是否為開始時間
            If i.Equals(0) Then

                dayCount = Item - sDate.Day + 1
                tempDataTable.Rows.Add(workId, _
                                      sDate, _
                                      eDate, _
                                      isfullStart(sDate.Day, Item, ThreeMonthFee, Rate), _
                                      isfullStart(sDate.Day, Item, ThreeMonthFee, Rate) / Item, _
                                     dayCount)
                'arr_month_fee(i) = isfullStart(sDate.Day, Item, ThreeMonthFee, Rate)
                'arr_month_fee(i) = threeMonthFee * (dayCount / 30)
                '判斷是否為結束時間
            ElseIf i.Equals(CInt(arr.length) - 1) Then
                dayCount = dayCount + eDate.Day
                tempDataTable.Rows.Add(workId, _
                                      sDate, _
                                      eDate, _
                                      isfullEnd(eDate.Day, Item, ThreeMonthFee, Rate), _
                                      isfullEnd(eDate.Day, Item, ThreeMonthFee, Rate) / Item, _
                                      Item)
                'arr_month_fee(i) = isfullEnd(eDate.Day, Item, ThreeMonthFee, Rate)

                '其他月份
            Else
                dayCount = dayCount + Item
                tempDataTable.Rows.Add(workId, _
                                       sDate, _
                                       eDate, _
                                       isfullother(Item, ThreeMonthFee, Rate), _
                                       isfullother(Item, ThreeMonthFee, Rate) / Item, _
                                       eDate.Day)
                'arr_month_fee(i) = isfullother(Item, ThreeMonthFee, Rate)


            End If
            '遞增
            i = i + 1
        Next
        tempDataTable.AcceptChanges()
        Return tempDataTable
        'Return arr_month_fee
    End Function

End Class
