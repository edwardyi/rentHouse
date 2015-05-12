
Partial Class Controls_WebUserControlTest
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '下拉式選單
        ddl.clear()
        ddl.Item.Add(New ListItem("Title", "Value"))
    End Sub
End Class
