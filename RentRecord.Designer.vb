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

<Assembly: Global.System.Data.Objects.DataClasses.EdmSchemaAttribute("25eacd5b-32ee-484f-8dd1-97f3962de6ee")> 

'原始檔案名稱:
'產生日期: 2015/4/30 上午 09:48:59
'''<summary>
'''結構描述中沒有 RentHouseEntities 的註解。
'''</summary>
Partial Public Class RentHouseEntities
    Inherits Global.System.Data.Objects.ObjectContext
    '''<summary>
    '''使用應用程式組態檔 'RentHouseEntities' 區段中找到的連接字串初始化新的 RentHouseEntities 物件。
    '''</summary>
    Public Sub New()
        MyBase.New("name=RentHouseEntities", "RentHouseEntities")
        Me.OnContextCreated
    End Sub
    '''<summary>
    '''初始化新的 RentHouseEntities 物件。
    '''</summary>
    Public Sub New(ByVal connectionString As String)
        MyBase.New(connectionString, "RentHouseEntities")
        Me.OnContextCreated
    End Sub
    '''<summary>
    '''初始化新的 RentHouseEntities 物件。
    '''</summary>
    Public Sub New(ByVal connection As Global.System.Data.EntityClient.EntityConnection)
        MyBase.New(connection, "RentHouseEntities")
        Me.OnContextCreated
    End Sub
    Partial Private Sub OnContextCreated()
        End Sub
    '''<summary>
    '''結構描述中沒有 RentRecord 的註解。
    '''</summary>
    Public ReadOnly Property RentRecord() As Global.System.Data.Objects.ObjectQuery(Of RentRecord)
        Get
            If (Me._RentRecord Is Nothing) Then
                Me._RentRecord = MyBase.CreateQuery(Of RentRecord)("[RentRecord]")
            End If
            Return Me._RentRecord
        End Get
    End Property
    Private _RentRecord As Global.System.Data.Objects.ObjectQuery(Of RentRecord)
    '''<summary>
    '''結構描述中沒有 RentRecord 的註解。
    '''</summary>
    Public Sub AddToRentRecord(ByVal rentRecord As RentRecord)
        MyBase.AddObject("RentRecord", rentRecord)
    End Sub
End Class
'''<summary>
'''結構描述中沒有 RentHouseModel.RentRecord 的註解。
'''</summary>
'''<KeyProperties>
'''ID
'''</KeyProperties>
<Global.System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName:="RentHouseModel", Name:="RentRecord"),  _
 Global.System.Runtime.Serialization.DataContractAttribute(IsReference:=true),  _
 Global.System.Serializable()>  _
Partial Public Class RentRecord
    Inherits Global.System.Data.Objects.DataClasses.EntityObject
    '''<summary>
    '''建立新的 RentRecord 物件。
    '''</summary>
    '''<param name="id">ID 的初始值。</param>
    '''<param name="workID">WorkID 的初始值。</param>
    '''<param name="startDate">StartDate 的初始值。</param>
    '''<param name="endDate">EndDate 的初始值。</param>
    '''<param name="rentPerPrice">RentPerPrice 的初始值。</param>
    Public Shared Function CreateRentRecord(ByVal id As Integer, ByVal workID As Integer, ByVal startDate As Date, ByVal endDate As Date, ByVal rentPerPrice As Integer) As RentRecord
        Dim rentRecord As RentRecord = New RentRecord
        rentRecord.ID = id
        rentRecord.WorkID = workID
        rentRecord.StartDate = startDate
        rentRecord.EndDate = endDate
        rentRecord.RentPerPrice = rentPerPrice
        Return rentRecord
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
    '''結構描述中沒有屬性 WorkID 的註解。
    '''</summary>
    <Global.System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable:=false),  _
     Global.System.Runtime.Serialization.DataMemberAttribute()>  _
    Public Property WorkID() As Integer
        Get
            Return Me._WorkID
        End Get
        Set
            Me.OnWorkIDChanging(value)
            Me.ReportPropertyChanging("WorkID")
            Me._WorkID = Global.System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            Me.ReportPropertyChanged("WorkID")
            Me.OnWorkIDChanged
        End Set
    End Property
    Private _WorkID As Integer
    Partial Private Sub OnWorkIDChanging(ByVal value As Integer)
        End Sub
    Partial Private Sub OnWorkIDChanged()
        End Sub
    '''<summary>
    '''結構描述中沒有屬性 StartDate 的註解。
    '''</summary>
    <Global.System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable:=false),  _
     Global.System.Runtime.Serialization.DataMemberAttribute()>  _
    Public Property StartDate() As Date
        Get
            Return Me._StartDate
        End Get
        Set
            Me.OnStartDateChanging(value)
            Me.ReportPropertyChanging("StartDate")
            Me._StartDate = Global.System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            Me.ReportPropertyChanged("StartDate")
            Me.OnStartDateChanged
        End Set
    End Property
    Private _StartDate As Date
    Partial Private Sub OnStartDateChanging(ByVal value As Date)
        End Sub
    Partial Private Sub OnStartDateChanged()
        End Sub
    '''<summary>
    '''結構描述中沒有屬性 EndDate 的註解。
    '''</summary>
    <Global.System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable:=false),  _
     Global.System.Runtime.Serialization.DataMemberAttribute()>  _
    Public Property EndDate() As Date
        Get
            Return Me._EndDate
        End Get
        Set
            Me.OnEndDateChanging(value)
            Me.ReportPropertyChanging("EndDate")
            Me._EndDate = Global.System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            Me.ReportPropertyChanged("EndDate")
            Me.OnEndDateChanged
        End Set
    End Property
    Private _EndDate As Date
    Partial Private Sub OnEndDateChanging(ByVal value As Date)
        End Sub
    Partial Private Sub OnEndDateChanged()
        End Sub
    '''<summary>
    '''結構描述中沒有屬性 RentPerPrice 的註解。
    '''</summary>
    <Global.System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable:=false),  _
     Global.System.Runtime.Serialization.DataMemberAttribute()>  _
    Public Property RentPerPrice() As Integer
        Get
            Return Me._RentPerPrice
        End Get
        Set
            Me.OnRentPerPriceChanging(value)
            Me.ReportPropertyChanging("RentPerPrice")
            Me._RentPerPrice = Global.System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            Me.ReportPropertyChanged("RentPerPrice")
            Me.OnRentPerPriceChanged
        End Set
    End Property
    Private _RentPerPrice As Integer
    Partial Private Sub OnRentPerPriceChanging(ByVal value As Integer)
        End Sub
    Partial Private Sub OnRentPerPriceChanged()
        End Sub
End Class
