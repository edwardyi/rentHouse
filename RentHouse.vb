'用來設定屬性
Namespace RentProperty
    Partial Public Class RentHouse
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



    End Class
End Namespace
