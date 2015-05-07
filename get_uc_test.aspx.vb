
Partial Class get_uc_test
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim uc_test = FindControl("uc_test")

        Response.Write("There you go~")
    End Sub
End Class
