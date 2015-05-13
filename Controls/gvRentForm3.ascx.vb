
Partial Class Controls_gvRentForm3
    Inherits System.Web.UI.UserControl
    '0513 設定 gridview資料來源
    Public Property getGvDataSource()
        '取值
        Get
            Return show_temp_gridview.DataSource
        End Get
        '設值用function
        Set(ByVal value)
            value = addNoRow(value)
            setGvData(value)
        End Set
    End Property

    Public Sub setGvData(ByVal value)
        show_temp_gridview.DataSource = value
        show_temp_gridview.DataBind()
    End Sub

    '增加一列NO
    Public Function addNoRow(ByVal value)
        value.Columns.Add("NO")
        Dim length = value.Rows.Count()
        Dim i = 1
        For Each row In value.Rows
            value.Rows(i - 1).Item("NO") = i.ToString("D" + i.ToString().Length.ToString())
            i = i + 1
        Next
        Return value
        'show_temp_gridview
    End Function

End Class
