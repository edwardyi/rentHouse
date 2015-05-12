
Partial Class Default2
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'WebUserControl2.GetDL()
        Response.Write(1)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'WebUserControl2.ddlAA.test()
        'WebUserControl2.test()
        Response.Write(2)
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Response.Write(3)
    End Sub

    Protected Sub btn1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn1.Click
        Dim test As DropDownList = WebUserControl2.GetDL()

        Response.Write(test.SelectedValue)
    End Sub
End Class
