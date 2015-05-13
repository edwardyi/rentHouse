
Partial Class Controls_gvRentForm2
    Inherits System.Web.UI.UserControl


    'http://stackoverflow.com/questions/752935/set-datasource-on-controls-within-asp-net-usercontrol
    Public Property getGvDataSource()
        Get
            Return showUsersGrid.DataSource
        End Get
        Set(ByVal value)
            showUsersGrid.DataSource = value
            showUsersGrid.DataBind()
        End Set
    End Property


    '0513寫一個Property讓aspx可以取得gridview
    'Public ReadOnly Property getGridView()
    '    Get
    '        Return showUsersGrid
    '    End Get
    'End Property

    'gridview事件
    'Protected Sub showUsersGrid_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles showUsersGrid.SelectedIndexChanged

    'End Sub
End Class
