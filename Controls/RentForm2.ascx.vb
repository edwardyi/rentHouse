
Partial Class Controls_RentForm2
    Inherits System.Web.UI.UserControl
    '屬性取值
    Public ReadOnly Property getWorkId()
        Get
            Return workId
        End Get
    End Property
    Public ReadOnly Property getStartDate()
        Get
            Return startDate
        End Get
    End Property
    Public ReadOnly Property getEndDate()
        Get
            Return endDate
        End Get
    End Property
    ' 宣告事件
    ' 宣告事件型態
    Public Delegate Sub newRenterClick(ByVal sender As Object, ByVal e As System.EventArgs)
    ' 定義事件為此型態
    Public Event newRenterClickA As newRenterClick
    ' 點擊事件
    Protected Sub newRenter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles newRenter.Click
        RaiseEvent newRenterClickA(sender, e)
    End Sub

    '宣告事件
    Public Delegate Sub btnSubmitClick(ByVal sender As Object, ByVal e As System.EventArgs)
    '定義事件
    Public Event customBtnClick As btnSubmitClick
    '點擊事件
    Protected Sub btn_Submit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Submit.Click
        RaiseEvent customBtnClick(sender, e)
    End Sub
End Class
