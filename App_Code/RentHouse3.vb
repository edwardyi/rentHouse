Imports System.Data

Public Class RentHouse3
    '開始時間
    '私有屬性加上底線
    Private _sDate As String
    '結束時間
    Private _eDate As String
    '前三個月，每個月的費用
    Dim _threeMonthFee = 35000
    '免繳五分之三
    Dim _rate = 1 - 3 / 5
    '建構式必須要用Sub
    Public Sub New(ByVal sDate As String, ByVal eDate As String)
        _sDate = sDate
        _eDate = eDate
    End Sub
    '使用Property方法設定及存取屬性
    '必須要大寫開頭
    Public Property SDate() As String
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
    '開始時間
    'Dim startDate = "2014/2/9"
    '結束時間
    'Dim endDate = "2015/12/28"
    Public output As String = ""
    'Public full_test As String = ""
    '用來判斷是否滿月
    Private currentFlag As Integer = 0
    Private fullFlag As Integer = 0
    Public Sub New(ByVal sDate, ByVal eDate, ByVal threemonthFee, ByVal rate)
        sDate = sDate
        eDate = eDate
        threemonthFee = threemonthFee
        rate = rate
    End Sub
    Public Function createArr(ByVal sDate, ByVal eDate)
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
            'System.Diagnostics.Debug.WriteLine("createArr" & DateTime.DaysInMonth(currentYear, currentMonth))
        Next

        Return daysArray
    End Function
    '判斷開始租屋是否為滿月
    Public Function isfullStart(ByVal day, ByVal eday, ByVal daysInMonth, ByVal threeMonthFee, ByVal rate)
        '判斷開始到結束日期天數是否在一個月內
        'http://www.cnblogs.com/freshman0216/archive/2008/08/27/1276991.html
        ' /:普通除法
        ' \:整數除法
        Dim unit As Double = 0
        'Return DateTime.Compare(day, eday)
        'Return (day.Year & "|" & eday.Year)
        Dim span As TimeSpan = eday.Subtract(day)
        '同年同月
        'If (day.Year.Equals(eday.Year) And day.Month.Equals(eday.Month)) Then
        'System.Diagnostics.Debug.WriteLine("isFullStart")
        'System.Diagnostics.Debug.WriteLine(span.Days)
        'System.Diagnostics.Debug.WriteLine("<br>")
        'System.Diagnostics.Debug.WriteLine("daysInMonth=>" & daysInMonth)
        'System.Diagnostics.Debug.WriteLine(span.Days < daysInMonth)
        If span.Days < daysInMonth Then
            'unit = (span.Days + 1) / daysInMonth
            unit = span.Days + 1
            'System.Diagnostics.Debug.WriteLine("span" & span.Days)
            'System.Diagnostics.Debug.WriteLine("daysInMonth" & daysInMonth)
            unit = unit / daysInMonth
            'System.Diagnostics.Debug.WriteLine("unit" & unit)
            'unit = 10
            '滿月
            If (unit.Equals(1)) Then
                currentFlag = currentFlag + 1
                Return threeMonthFee
            Else
                Return threeMonthFee * unit

            End If
        Else
            'unit = (daysInMonth - day.Day + 1) / daysInMonth
            unit = daysInMonth - day.Day + 1
            unit = unit / daysInMonth
            currentFlag = currentFlag + 1
            If (unit.Equals(1)) Then

                Return threeMonthFee

            Else
                Return threeMonthFee * unit
            End If
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
                'System.Diagnostics.Debug.WriteLine("pushArr=>" & Item)
                dayCount = Item - sDate.Day + 1
                arr_month_fee(i) = isfullStart(sDate, eDate, Item, threeMonthFee, rate)
                'System.Diagnostics.Debug.WriteLine(Item)
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
    '顯示DataSet
    Public Function showRent(ByVal sDate, ByVal eDate, ByVal arr_month_fee, ByVal threeMonthFee, ByVal rate) As DataSet
        Dim connection = New Connection
        Dim ds As DataSet = Nothing
        '取得RentRecord資料
        Return ds
    End Function
    '加入RentRecord資料
    Public Function AddRent(ByVal workId As Integer, ByVal startDate As DateTime, ByVal endDate As DateTime, ByVal RentPerPrice As Integer)
        Dim connection = New Connection
        '檢查工號是否存在
        Dim queryResult As DataSet = connection.GetRecord(workId)

        If queryResult.Tables(0).Rows.Count.Equals(0) Then
            Return 1
        Else

            Dim queryRecord As DataSet = connection.GetRentRecord(workId)
            If queryRecord.Tables(0).Rows.Count.Equals(0) Then
                connection.AddRentRecord(workId, startDate, endDate, RentPerPrice)
                Return 0
            Else
                Return 2
            End If
        End If

    End Function
    '顯示明細gridview
    Public Function showDetail(ByVal workId, ByVal sDate, ByVal eDate, ByVal arr_month_fee, ByVal threeMonthFee, ByVal rate, ByVal dt)
        Dim rowList As New List(Of DataRow)

        Dim totalRent = 0
        Dim currentYear = sDate.Year
        Dim currentMonth = sDate.Month
        Dim j As Integer = 0
        'System.Diagnostics.Debug.WriteLine("中文1XD")
        'System.Diagnostics.Debug.WriteLine("This is real crazy")
        For Each Item As Integer In arr_month_fee
            Dim dr As DataRow = dt.NewRow()
            System.Diagnostics.Debug.WriteLine("當前月份?")
            System.Diagnostics.Debug.WriteLine(eDate.Month.Equals(currentMonth))
            'System.Diagnostics.Debug.WriteLine("J = 0 ?")
            'System.Diagnostics.Debug.WriteLine(j.Equals(0))
            'System.Diagnostics.Debug.WriteLine("ShowDetail=>" & Item)
            'System.Diagnostics.Debug.WriteLine("J=>" & j)
            'System.Diagnostics.Debug.WriteLine("currentYear=>" & currentYear)
            'System.Diagnostics.Debug.WriteLine("currentMonth=>" & currentMonth)
            'System.Diagnostics.Debug.WriteLine("daysInMonth Funk=>" & DateTime.DaysInMonth(currentYear, currentMonth))
            Dim outStr As String = ""
            If currentMonth > 12 Then
                currentMonth = 1
                currentYear = currentYear + 1
            End If
            'outStr = outStr & currentYear & "年" & currentMonth & "月"
            '當前月份天數
            Dim daysInmonth = DateTime.DaysInMonth(currentYear, currentMonth)
            Dim money As Integer = 0
            dr.Item("workId") = workId
            'System.Diagnostics.Debug.WriteLine("中文字喔XD")
            If j.Equals(0) Then
                dr.Item("s_date") = currentYear & "-" & currentMonth & "-" & sDate.Day
                'System.Diagnostics.Debug.WriteLine("比較月份")
                'System.Diagnostics.Debug.WriteLine(eDate.Month)
                'System.Diagnostics.Debug.WriteLine(currentMonth)
                'System.Diagnostics.Debug.WriteLine(eDate.Month.Equals(currentMonth))
                If eDate.Month.Equals(currentMonth) Then
                    dr.Item("e_date") = currentYear & "-" & currentMonth & "-" & eDate.Day
                Else
                    'Dim span As TimeSpan = sDate.Subtract(eDate)
                    'System.Diagnostics.Debug.WriteLine("比較月份")
                    'System.Diagnostics.Debug.WriteLine(span.Days < daysInmonth)

                    'System.Diagnostics.Debug.WriteLine("daysInmonth=>" & daysInmonth)
                    dr.Item("e_date") = currentYear & "-" & currentMonth & "-" & daysInmonth
                End If
                Dim span As TimeSpan = eDate.Subtract(sDate)
                '0511發現isfullStart帶錯值(不是代Item)
                money = isfullStart(sDate, eDate, daysInmonth, threeMonthFee, rate)
                dr.Item("money") = money
                dr.Item("average") = Convert.ToInt32(money / (daysInmonth - sDate.Day + 1))
                'dr.Item("liveDays") = 1
                System.Diagnostics.Debug.WriteLine("前daysInMonth=>" & daysInmonth)
                'IIf(span.Days < daysInmonth, daysInmonth = eDate.Day, "")
                System.Diagnostics.Debug.WriteLine(span.Days < daysInmonth)
                System.Diagnostics.Debug.WriteLine("後daysInMonth=>" & daysInmonth)
                'dr.Item("liveDays") = span.Days
                dr.Item("liveDays") = daysInmonth - sDate.Day + 1
            ElseIf j.Equals(arr_month_fee.Length - 1) Then
                dr.Item("s_date") = currentYear & "-" & currentMonth & "-" & 1
                money = isfullEnd(eDate.Day, Item, threeMonthFee, rate)
                dr.Item("money") = money
                dr.Item("e_date") = currentYear & "-" & currentMonth & "-" & eDate.Day
                dr.Item("average") = Convert.ToInt32(money / eDate.Day)
                dr.Item("liveDays") = eDate.Day
            Else
                dr.Item("s_date") = currentYear & "-" & currentMonth & "-" & 1
                dr.Item("e_date") = currentYear & "-" & currentMonth & "-" & daysInmonth
                money = isfullother(Item, threeMonthFee, rate)
                dr.Item("money") = money
                dr.Item("average") = Convert.ToInt32(money / daysInmonth)
                dr.Item("liveDays") = daysInmonth
            End If

            'dr.Item("money") = Item

            output = output & "<br/>"
            currentMonth = currentMonth + 1
            totalRent = totalRent + Item
            j = j + 1
            rowList.Add(dr)
        Next
        Return rowList
    End Function
    Public Function showResult(ByVal sDate, ByVal eDate, ByVal arr_month_fee, ByVal threeMonthFee, ByVal rate)
        Dim totalRent = 0
        Dim currentYear = sDate.Year
        Dim currentMonth = sDate.Month
        Dim j As Integer = 0

        For Each Item As Integer In arr_month_fee
            Dim outStr As String = ""
            If currentMonth > 12 Then
                currentMonth = 1
                currentYear = currentYear + 1
            End If
            outStr = outStr & currentYear & "年" & currentMonth & "月"
            '當前月份天數
            Dim daysInmonth = DateTime.DaysInMonth(currentYear, currentMonth)

            If j.Equals(0) Then
                outStr = outStr & sDate.Day & "日"
                outStr = outStr & "/住屋天數:" & (daysInmonth - sDate.Day + 1) & "天"
                outStr = outStr & "/日租金:" & FormatCurrency(Item / (daysInmonth - sDate.Day + 1), 0).ToString().Replace("NT$", "")
            ElseIf j.Equals(arr_month_fee.Length - 1) Then
                outStr = outStr & eDate.Day & "日"
                outStr = outStr & "/住屋天數:" & eDate.Day & "天"
                outStr = outStr & "/日租金:" & FormatCurrency(Item / (eDate.Day), 0).ToString().Replace("NT$", "")
            Else
                outStr = outStr & 1 & "日"
                outStr = outStr & "/住屋天數:" & daysInmonth & "天"
                outStr = outStr & "/日租金:" & FormatCurrency(Item / daysInmonth, 0).ToString().Replace("NT$", "")


            End If
            output = output & outStr & "  =>" & FormatCurrency(Item, 0).ToString().Replace("NT$", "")
            output = output & "<br/>"
            currentMonth = currentMonth + 1
            totalRent = totalRent + Item
            j = j + 1
        Next
        Return totalRent
    End Function

End Class
