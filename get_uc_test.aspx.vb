
Partial Class get_uc_test
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '參考網站
        'http://blog.miniasp.com/post/2007/11/04/ASPNET-FindControl-Tips-and-Hacks.aspx
        Dim uc_test = FindControl("uc_test$ctl00$uc_label")
        Response.Write(uc_test.Text)

        Response.Write("There you go~")
    End Sub
End Class
