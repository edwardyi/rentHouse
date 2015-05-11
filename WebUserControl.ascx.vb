Imports System.Data
Imports Microsoft.VisualBasic

Partial Class WebUserControl
    Inherits System.Web.UI.UserControl
    Property test() As DropDownList
        Get
            Return test
        End Get
        Set(ByVal value)
            test = value
        End Set
    End Property

    Enum MyEnum
        view = "0"
        edit = "1"
        delete = "2"
    End Enum

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Response.Write(1)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ddl = FindControl("ddlAA")
        Response.Write(2)
        bt()

    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Response.Write(3)
    End Sub
End Class
