'自定義方法
Namespace CustomMethod
    Partial Public Class RentHouse
        Public output As String = ""
        Public full_test As String = ""
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
                currentFlag = 1
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
                    'arr_month_fee(i) = threeMonthFee
                    'If i Mod 4 <> 3 Or i < 3 Then
                    'arr_month_fee(i) = threeMonthFee * (eDate.Day / 30)
                    'Else
                    ' arr_month_fee(i) = threeMonthFee * (eDate.Day / 30) * rate
                    'End If
                    arr_month_fee(i) = isfullEnd(eDate.Day, Item, threeMonthFee, rate)

                    '其他月份
                Else
                    dayCount = dayCount + Item
                    arr_month_fee(i) = isfullother(Item, threeMonthFee, rate)
                    'If i Mod 4 <> 3 Or i < 3 Then
                    'arr_month_fee(i) = threeMonthFee
                    'Else
                    'arr_month_fee(i) = threeMonthFee * rate
                    'End If


                End If
                '遞增
                i = i + 1
            Next
            Return arr_month_fee
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
                    'outStr = outStr & j & "number"
                    outStr = outStr & sDate.Day & "日"
                    outStr = outStr & "/住屋天數:" & (daysInmonth - sDate.Day + 1) & "天"
                    outStr = outStr & "/日租金:" & FormatCurrency(threeMonthFee / (daysInmonth - sDate.Day + 1), 0).ToString().Replace("NT$", "")
                ElseIf j.Equals(arr_month_fee.Length - 1) Then
                    'outStr = outStr & j & "number"
                    outStr = outStr & eDate.Day & "日"
                    outStr = outStr & "/住屋天數:" & eDate.Day & "天"
                    outStr = outStr & "/日租金:" & FormatCurrency(threeMonthFee * rate / (eDate.Day), 0).ToString().Replace("NT$", "")
                Else
                    'outStr = outStr & j & "number"
                    outStr = outStr & 1 & "日"
                    outStr = outStr & "/住屋天數:" & daysInmonth & "天"

                    If j Mod 4 <> 3 Or j < 3 Then
                        outStr = outStr & "/日租金:" & FormatCurrency(threeMonthFee / (daysInmonth), 0).ToString().Replace("NT$", "")
                    Else
                        outStr = outStr & "/日租金:" & FormatCurrency(threeMonthFee * rate / (daysInmonth), 0).ToString().Replace("NT$", "")
                    End If


                End If
                output = output & outStr & "  =>" & FormatCurrency(Item, 0).ToString().Replace("NT$", "")
                output = output & "<br/>"
                currentMonth = currentMonth + 1
                totalRent = totalRent + Item
                j = j + 1
            Next
            Return totalRent
        End Function
        Public Property Ouput() As String
            Get
                Return output
            End Get
            Set(ByVal value As String)
                output = value
            End Set
        End Property

    End Class
End Namespace
