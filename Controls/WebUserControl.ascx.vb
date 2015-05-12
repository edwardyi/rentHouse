Imports System.Web.UI
Imports System.Data
Imports Microsoft.VisualBasic

Partial Class WebUserControl
    Inherits System.Web.UI.UserControl

    '設定listbox的值
    'Public Sub setListBox(ByVal text, ByVal body)
    '    Dim item = New ListViewItem()
    '    item.Text = text
    '    item.SubItems().Add(body)
    '    lstb.Items.Add(item)
    'End Sub


    '觸發事件，當點擊全選後，就取一次值，並設定checkboxlist
    Protected Sub checkAll_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles checkAll.CheckedChanged
        setCheckboxList(False)
    End Sub
    '沒寫下方的方法似乎也能夠運作
    Public Property setcbl() As Boolean
        Get
            Return checkAll.checked
        End Get
        Set(ByVal value As Boolean)
            checkAll.checked = value
            setCheckboxList(False)
        End Set
    End Property
    '使用公開屬性將DropDownList.SelectedValue指定給GetDL()變數
    Public ReadOnly Property getCheckAll() As Boolean
        Get
            Return checkAll.checked
        End Get
    End Property

    '設定多個核取方塊的值
    Public Sub setCheckboxList(ByVal isset As Boolean)
        For index As Integer = 1 To 10
            If isset Then
                cbltest.Items.Add(New ListItem("選項" & index, index))
            Else
                cbltest.Items(index - 1).Selected = getCheckAll()
            End If
        Next
    End Sub

    Public Property GetDL() As DropDownList
        Get
            Return ddltest
            'GetDL = ddltest.SelectedValue
            'GetDL = ddltest
        End Get
        Set(ByVal value As DropDownList)
            value.Items.Add(New ListItem("AA", 11))
        End Set
    End Property



    Public Enum DropState
        view
        edit
        remove
    End Enum

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        setCheckboxList(True)
    End Sub

    '  Public ReadOnly Property ShowState() As DropState

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Dim dataTable As New DataTable()
            'setListBox(New ListItem("T1", 1))
            'setListBox(New ListItem("T2", 2))
            'setListBox(New ListItem("T3", 3))
            'dataTable.Columns.Add("ID", System.Type.GetType("System.Int32"))
            'dataTable.Columns.Add("Name", System.Type.GetType("System.String"))
            'dataTable.Rows.Add(1, "GG")
            'dataTable.Rows.Add(2, "BB")
            'lstb.datasource = dataTable.Rows
            'lstb.databind()
            'Response.Write("Not Post Back")
            'setCheckboxList(False)
            'getCheckAll()
        End If
        Response.Write("Post Back")
        'setCheckboxList()
        'Select Case ShowState

        'End Select
    End Sub




End Class
