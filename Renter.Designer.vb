﻿'------------------------------------------------------------------------------
' <auto-generated>
'     這段程式碼是由工具產生的。
'     執行階段版本:2.0.50727.5485
'
'     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
'     變更將會遺失。
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

<Assembly: Global.System.Data.Objects.DataClasses.EdmSchemaAttribute("fc6deac4-b3b1-45cd-94c1-3783fea0e84a")> 

'原始檔案名稱:
'產生日期: 2015/4/30 上午 10:20:05
'''<summary>
'''結構描述中沒有 RentHouseEntities1 的註解。
'''</summary>
Partial Public Class RentHouseEntities1
    Inherits Global.System.Data.Objects.ObjectContext
    '''<summary>
    '''使用應用程式組態檔 'RentHouseEntities1' 區段中找到的連接字串初始化新的 RentHouseEntities1 物件。
    '''</summary>
    Public Sub New()
        MyBase.New("name=RentHouseEntities1", "RentHouseEntities1")
        Me.OnContextCreated
    End Sub
    '''<summary>
    '''初始化新的 RentHouseEntities1 物件。
    '''</summary>
    Public Sub New(ByVal connectionString As String)
        MyBase.New(connectionString, "RentHouseEntities1")
        Me.OnContextCreated
    End Sub
    '''<summary>
    '''初始化新的 RentHouseEntities1 物件。
    '''</summary>
    Public Sub New(ByVal connection As Global.System.Data.EntityClient.EntityConnection)
        MyBase.New(connection, "RentHouseEntities1")
        Me.OnContextCreated
    End Sub
    Partial Private Sub OnContextCreated()
        End Sub
    '''<summary>
    '''結構描述中沒有 Renter 的註解。
    '''</summary>
    Public ReadOnly Property Renter() As Global.System.Data.Objects.ObjectQuery(Of Renter)
        Get
            If (Me._Renter Is Nothing) Then
                Me._Renter = MyBase.CreateQuery(Of Renter)("[Renter]")
            End If
            Return Me._Renter
        End Get
    End Property
    Private _Renter As Global.System.Data.Objects.ObjectQuery(Of Renter)
    '''<summary>
    '''結構描述中沒有 Renter 的註解。
    '''</summary>
    Public Sub AddToRenter(ByVal renter As Renter)
        MyBase.AddObject("Renter", renter)
    End Sub
End Class
'''<summary>
'''結構描述中沒有 RentHouseModel1.Renter 的註解。
'''</summary>
'''<KeyProperties>
'''ID
'''</KeyProperties>
<Global.System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName:="RentHouseModel1", Name:="Renter"),  _
 Global.System.Runtime.Serialization.DataContractAttribute(IsReference:=true),  _
 Global.System.Serializable()>  _
Partial Public Class Renter
    Inherits Global.System.Data.Objects.DataClasses.EntityObject
    '''<summary>
    '''建立新的 Renter 物件。
    '''</summary>
    '''<param name="id">ID 的初始值。</param>
    '''<param name="workId">WorkId 的初始值。</param>
    Public Shared Function CreateRenter(ByVal id As Integer, ByVal workId As Integer) As Renter
        Dim renter As Renter = New Renter
        renter.ID = id
        renter.WorkId = workId
        Return renter
    End Function
    '''<summary>
    '''結構描述中沒有屬性 ID 的註解。
    '''</summary>
    <Global.System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=true, IsNullable:=false),  _
     Global.System.Runtime.Serialization.DataMemberAttribute()>  _
    Public Property ID() As Integer
        Get
            Return Me._ID
        End Get
        Set
            Me.OnIDChanging(value)
            Me.ReportPropertyChanging("ID")
            Me._ID = Global.System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            Me.ReportPropertyChanged("ID")
            Me.OnIDChanged
        End Set
    End Property
    Private _ID As Integer
    Partial Private Sub OnIDChanging(ByVal value As Integer)
        End Sub
    Partial Private Sub OnIDChanged()
        End Sub
    '''<summary>
    '''結構描述中沒有屬性 WorkId 的註解。
    '''</summary>
    <Global.System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable:=false),  _
     Global.System.Runtime.Serialization.DataMemberAttribute()>  _
    Public Property WorkId() As Integer
        Get
            Return Me._WorkId
        End Get
        Set
            Me.OnWorkIdChanging(value)
            Me.ReportPropertyChanging("WorkId")
            Me._WorkId = Global.System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            Me.ReportPropertyChanged("WorkId")
            Me.OnWorkIdChanged
        End Set
    End Property
    Private _WorkId As Integer
    Partial Private Sub OnWorkIdChanging(ByVal value As Integer)
        End Sub
    Partial Private Sub OnWorkIdChanged()
        End Sub
    '''<summary>
    '''結構描述中沒有屬性 Name 的註解。
    '''</summary>
    <Global.System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(),  _
     Global.System.Runtime.Serialization.DataMemberAttribute()>  _
    Public Property Name() As String
        Get
            Return Me._Name
        End Get
        Set
            Me.OnNameChanging(value)
            Me.ReportPropertyChanging("Name")
            Me._Name = Global.System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true)
            Me.ReportPropertyChanged("Name")
            Me.OnNameChanged
        End Set
    End Property
    Private _Name As String
    Partial Private Sub OnNameChanging(ByVal value As String)
        End Sub
    Partial Private Sub OnNameChanged()
        End Sub
End Class
