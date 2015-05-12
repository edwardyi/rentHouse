
Partial Class RentFormTest
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      
    End Sub
    Protected Sub newRenter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RentForm21.newRenterClickA
        '不能直接讀取user control中的屬性，要透過自定義的方法來取值
        Dim workId = RentForm21.getWorkId()
        Dim startDate = RentForm21.getStartDate()
        Dim endDate = RentForm21.getEndDate()
        Dim rent3 = New RentHouse3(startDate.Text, endDate.Text)

    End Sub
    Protected Sub btn_Submit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RentForm21.customBtnClick
        Response.Write("calculating....")
        
    End Sub

End Class
