﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.Linq
Imports System.Data.Linq.Mapping
Imports System.Linq
Imports System.Linq.Expressions
Imports System.Reflection


<Global.System.Data.Linq.Mapping.DatabaseAttribute(Name:="vet-db")>  _
Partial Public Class VetDataContextDataContext
	Inherits System.Data.Linq.DataContext
	
	Private Shared mappingSource As System.Data.Linq.Mapping.MappingSource = New AttributeMappingSource()
	
  #Region "Extensibility Method Definitions"
  Partial Private Sub OnCreated()
  End Sub
  Partial Private Sub InsertOPD(instance As OPD)
    End Sub
  Partial Private Sub UpdateOPD(instance As OPD)
    End Sub
  Partial Private Sub DeleteOPD(instance As OPD)
    End Sub
  Partial Private Sub InsertOPD_Detail(instance As OPD_Detail)
    End Sub
  Partial Private Sub UpdateOPD_Detail(instance As OPD_Detail)
    End Sub
  Partial Private Sub DeleteOPD_Detail(instance As OPD_Detail)
    End Sub
  #End Region
	
	Public Sub New()
		MyBase.New(Global.System.Configuration.ConfigurationManager.ConnectionStrings("vet_dbConnectionString").ConnectionString, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As String)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As System.Data.IDbConnection)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As String, ByVal mappingSource As System.Data.Linq.Mapping.MappingSource)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As System.Data.IDbConnection, ByVal mappingSource As System.Data.Linq.Mapping.MappingSource)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public ReadOnly Property OPDs() As System.Data.Linq.Table(Of OPD)
		Get
			Return Me.GetTable(Of OPD)
		End Get
	End Property
	
	Public ReadOnly Property OPD_Details() As System.Data.Linq.Table(Of OPD_Detail)
		Get
			Return Me.GetTable(Of OPD_Detail)
		End Get
	End Property
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.OPD")>  _
Partial Public Class OPD
	Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	
	Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
	
	Private _id As Integer
	
	Private _opd_num As Integer
	
	Private _pet_name As String
	
	Private _pet_age As System.Nullable(Of Integer)
	
	Private _pet_age_month As System.Nullable(Of Integer)
	
	Private _pet_sex As String
	
	Private _pet_breed As String
	
	Private _pet_type As String
	
	Private _holder_name As String
	
	Private _contact As String
	
	Private _address As String
	
	Private _OPD_Details As EntitySet(Of OPD_Detail)
	
    #Region "Extensibility Method Definitions"
    Partial Private Sub OnLoaded()
    End Sub
    Partial Private Sub OnValidate(action As System.Data.Linq.ChangeAction)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnidChanging(value As Integer)
    End Sub
    Partial Private Sub OnidChanged()
    End Sub
    Partial Private Sub Onopd_numChanging(value As Integer)
    End Sub
    Partial Private Sub Onopd_numChanged()
    End Sub
    Partial Private Sub Onpet_nameChanging(value As String)
    End Sub
    Partial Private Sub Onpet_nameChanged()
    End Sub
    Partial Private Sub Onpet_ageChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub Onpet_ageChanged()
    End Sub
    Partial Private Sub Onpet_age_monthChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub Onpet_age_monthChanged()
    End Sub
    Partial Private Sub Onpet_sexChanging(value As String)
    End Sub
    Partial Private Sub Onpet_sexChanged()
    End Sub
    Partial Private Sub Onpet_breedChanging(value As String)
    End Sub
    Partial Private Sub Onpet_breedChanged()
    End Sub
    Partial Private Sub Onpet_typeChanging(value As String)
    End Sub
    Partial Private Sub Onpet_typeChanged()
    End Sub
    Partial Private Sub Onholder_nameChanging(value As String)
    End Sub
    Partial Private Sub Onholder_nameChanged()
    End Sub
    Partial Private Sub OncontactChanging(value As String)
    End Sub
    Partial Private Sub OncontactChanged()
    End Sub
    Partial Private Sub OnaddressChanging(value As String)
    End Sub
    Partial Private Sub OnaddressChanged()
    End Sub
    #End Region
	
	Public Sub New()
		MyBase.New
		Me._OPD_Details = New EntitySet(Of OPD_Detail)(AddressOf Me.attach_OPD_Details, AddressOf Me.detach_OPD_Details)
		OnCreated
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_id", DbType:="Int NOT NULL", IsPrimaryKey:=true)>  _
	Public Property id() As Integer
		Get
			Return Me._id
		End Get
		Set
			If ((Me._id = value)  _
						= false) Then
				Me.OnidChanging(value)
				Me.SendPropertyChanging
				Me._id = value
				Me.SendPropertyChanged("id")
				Me.OnidChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_opd_num", DbType:="Int NOT NULL")>  _
	Public Property opd_num() As Integer
		Get
			Return Me._opd_num
		End Get
		Set
			If ((Me._opd_num = value)  _
						= false) Then
				Me.Onopd_numChanging(value)
				Me.SendPropertyChanging
				Me._opd_num = value
				Me.SendPropertyChanged("opd_num")
				Me.Onopd_numChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_pet_name", DbType:="VarChar(50)")>  _
	Public Property pet_name() As String
		Get
			Return Me._pet_name
		End Get
		Set
			If (String.Equals(Me._pet_name, value) = false) Then
				Me.Onpet_nameChanging(value)
				Me.SendPropertyChanging
				Me._pet_name = value
				Me.SendPropertyChanged("pet_name")
				Me.Onpet_nameChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_pet_age", DbType:="Int")>  _
	Public Property pet_age() As System.Nullable(Of Integer)
		Get
			Return Me._pet_age
		End Get
		Set
			If (Me._pet_age.Equals(value) = false) Then
				Me.Onpet_ageChanging(value)
				Me.SendPropertyChanging
				Me._pet_age = value
				Me.SendPropertyChanged("pet_age")
				Me.Onpet_ageChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_pet_age_month", DbType:="Int")>  _
	Public Property pet_age_month() As System.Nullable(Of Integer)
		Get
			Return Me._pet_age_month
		End Get
		Set
			If (Me._pet_age_month.Equals(value) = false) Then
				Me.Onpet_age_monthChanging(value)
				Me.SendPropertyChanging
				Me._pet_age_month = value
				Me.SendPropertyChanged("pet_age_month")
				Me.Onpet_age_monthChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_pet_sex", DbType:="VarChar(50)")>  _
	Public Property pet_sex() As String
		Get
			Return Me._pet_sex
		End Get
		Set
			If (String.Equals(Me._pet_sex, value) = false) Then
				Me.Onpet_sexChanging(value)
				Me.SendPropertyChanging
				Me._pet_sex = value
				Me.SendPropertyChanged("pet_sex")
				Me.Onpet_sexChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_pet_breed", DbType:="VarChar(50)")>  _
	Public Property pet_breed() As String
		Get
			Return Me._pet_breed
		End Get
		Set
			If (String.Equals(Me._pet_breed, value) = false) Then
				Me.Onpet_breedChanging(value)
				Me.SendPropertyChanging
				Me._pet_breed = value
				Me.SendPropertyChanged("pet_breed")
				Me.Onpet_breedChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_pet_type", DbType:="VarChar(50)")>  _
	Public Property pet_type() As String
		Get
			Return Me._pet_type
		End Get
		Set
			If (String.Equals(Me._pet_type, value) = false) Then
				Me.Onpet_typeChanging(value)
				Me.SendPropertyChanging
				Me._pet_type = value
				Me.SendPropertyChanged("pet_type")
				Me.Onpet_typeChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_holder_name", DbType:="VarChar(50)")>  _
	Public Property holder_name() As String
		Get
			Return Me._holder_name
		End Get
		Set
			If (String.Equals(Me._holder_name, value) = false) Then
				Me.Onholder_nameChanging(value)
				Me.SendPropertyChanging
				Me._holder_name = value
				Me.SendPropertyChanged("holder_name")
				Me.Onholder_nameChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_contact", DbType:="VarChar(50)")>  _
	Public Property contact() As String
		Get
			Return Me._contact
		End Get
		Set
			If (String.Equals(Me._contact, value) = false) Then
				Me.OncontactChanging(value)
				Me.SendPropertyChanging
				Me._contact = value
				Me.SendPropertyChanged("contact")
				Me.OncontactChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_address", DbType:="VarChar(100)")>  _
	Public Property address() As String
		Get
			Return Me._address
		End Get
		Set
			If (String.Equals(Me._address, value) = false) Then
				Me.OnaddressChanging(value)
				Me.SendPropertyChanging
				Me._address = value
				Me.SendPropertyChanged("address")
				Me.OnaddressChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.AssociationAttribute(Name:="OPD_OPD_Detail", Storage:="_OPD_Details", ThisKey:="id", OtherKey:="opd_id")>  _
	Public Property OPD_Details() As EntitySet(Of OPD_Detail)
		Get
			Return Me._OPD_Details
		End Get
		Set
			Me._OPD_Details.Assign(value)
		End Set
	End Property
	
	Public Event PropertyChanging As PropertyChangingEventHandler Implements System.ComponentModel.INotifyPropertyChanging.PropertyChanging
	
	Public Event PropertyChanged As PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
	
	Protected Overridable Sub SendPropertyChanging()
		If ((Me.PropertyChangingEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanging(Me, emptyChangingEventArgs)
		End If
	End Sub
	
	Protected Overridable Sub SendPropertyChanged(ByVal propertyName As [String])
		If ((Me.PropertyChangedEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End If
	End Sub
	
	Private Sub attach_OPD_Details(ByVal entity As OPD_Detail)
		Me.SendPropertyChanging
		entity.OPD = Me
	End Sub
	
	Private Sub detach_OPD_Details(ByVal entity As OPD_Detail)
		Me.SendPropertyChanging
		entity.OPD = Nothing
	End Sub
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.OPD_Detail")>  _
Partial Public Class OPD_Detail
	Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	
	Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
	
	Private _opd_id As Integer
	
	Private _opd_date As System.Nullable(Of Date)
	
	Private _opd_details As String
	
	Private _opd_bw As System.Nullable(Of Double)
	
	Private _opd_lab As String
	
	Private _opd_fee2 As String
	
	Private _opd_type As String
	
	Private _opd_fee As String
	
	Private _opd_amount As System.Nullable(Of Double)
	
	Private _detail_id As Integer
	
	Private _OPD As EntityRef(Of OPD)
	
    #Region "Extensibility Method Definitions"
    Partial Private Sub OnLoaded()
    End Sub
    Partial Private Sub OnValidate(action As System.Data.Linq.ChangeAction)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub Onopd_idChanging(value As Integer)
    End Sub
    Partial Private Sub Onopd_idChanged()
    End Sub
    Partial Private Sub Onopd_dateChanging(value As System.Nullable(Of Date))
    End Sub
    Partial Private Sub Onopd_dateChanged()
    End Sub
    Partial Private Sub Onopd_detailsChanging(value As String)
    End Sub
    Partial Private Sub Onopd_detailsChanged()
    End Sub
    Partial Private Sub Onopd_bwChanging(value As System.Nullable(Of Double))
    End Sub
    Partial Private Sub Onopd_bwChanged()
    End Sub
    Partial Private Sub Onopd_labChanging(value As String)
    End Sub
    Partial Private Sub Onopd_labChanged()
    End Sub
    Partial Private Sub Onopd_fee2Changing(value As String)
    End Sub
    Partial Private Sub Onopd_fee2Changed()
    End Sub
    Partial Private Sub Onopd_typeChanging(value As String)
    End Sub
    Partial Private Sub Onopd_typeChanged()
    End Sub
    Partial Private Sub Onopd_feeChanging(value As String)
    End Sub
    Partial Private Sub Onopd_feeChanged()
    End Sub
    Partial Private Sub Onopd_amountChanging(value As System.Nullable(Of Double))
    End Sub
    Partial Private Sub Onopd_amountChanged()
    End Sub
    Partial Private Sub Ondetail_idChanging(value As Integer)
    End Sub
    Partial Private Sub Ondetail_idChanged()
    End Sub
    #End Region
	
	Public Sub New()
		MyBase.New
		Me._OPD = CType(Nothing, EntityRef(Of OPD))
		OnCreated
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_opd_id", DbType:="Int NOT NULL")>  _
	Public Property opd_id() As Integer
		Get
			Return Me._opd_id
		End Get
		Set
			If ((Me._opd_id = value)  _
						= false) Then
				If Me._OPD.HasLoadedOrAssignedValue Then
					Throw New System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException()
				End If
				Me.Onopd_idChanging(value)
				Me.SendPropertyChanging
				Me._opd_id = value
				Me.SendPropertyChanged("opd_id")
				Me.Onopd_idChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_opd_date", DbType:="Date")>  _
	Public Property opd_date() As System.Nullable(Of Date)
		Get
			Return Me._opd_date
		End Get
		Set
			If (Me._opd_date.Equals(value) = false) Then
				Me.Onopd_dateChanging(value)
				Me.SendPropertyChanging
				Me._opd_date = value
				Me.SendPropertyChanged("opd_date")
				Me.Onopd_dateChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_opd_details", DbType:="VarChar(200)")>  _
	Public Property opd_details() As String
		Get
			Return Me._opd_details
		End Get
		Set
			If (String.Equals(Me._opd_details, value) = false) Then
				Me.Onopd_detailsChanging(value)
				Me.SendPropertyChanging
				Me._opd_details = value
				Me.SendPropertyChanged("opd_details")
				Me.Onopd_detailsChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_opd_bw", DbType:="Float")>  _
	Public Property opd_bw() As System.Nullable(Of Double)
		Get
			Return Me._opd_bw
		End Get
		Set
			If (Me._opd_bw.Equals(value) = false) Then
				Me.Onopd_bwChanging(value)
				Me.SendPropertyChanging
				Me._opd_bw = value
				Me.SendPropertyChanged("opd_bw")
				Me.Onopd_bwChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_opd_lab", DbType:="VarChar(200)")>  _
	Public Property opd_lab() As String
		Get
			Return Me._opd_lab
		End Get
		Set
			If (String.Equals(Me._opd_lab, value) = false) Then
				Me.Onopd_labChanging(value)
				Me.SendPropertyChanging
				Me._opd_lab = value
				Me.SendPropertyChanged("opd_lab")
				Me.Onopd_labChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_opd_fee2", DbType:="VarChar(200)")>  _
	Public Property opd_fee2() As String
		Get
			Return Me._opd_fee2
		End Get
		Set
			If (String.Equals(Me._opd_fee2, value) = false) Then
				Me.Onopd_fee2Changing(value)
				Me.SendPropertyChanging
				Me._opd_fee2 = value
				Me.SendPropertyChanged("opd_fee2")
				Me.Onopd_fee2Changed
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_opd_type", DbType:="VarChar(50) NOT NULL", CanBeNull:=false)>  _
	Public Property opd_type() As String
		Get
			Return Me._opd_type
		End Get
		Set
			If (String.Equals(Me._opd_type, value) = false) Then
				Me.Onopd_typeChanging(value)
				Me.SendPropertyChanging
				Me._opd_type = value
				Me.SendPropertyChanged("opd_type")
				Me.Onopd_typeChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_opd_fee", DbType:="VarChar(200)")>  _
	Public Property opd_fee() As String
		Get
			Return Me._opd_fee
		End Get
		Set
			If (String.Equals(Me._opd_fee, value) = false) Then
				Me.Onopd_feeChanging(value)
				Me.SendPropertyChanging
				Me._opd_fee = value
				Me.SendPropertyChanged("opd_fee")
				Me.Onopd_feeChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_opd_amount", DbType:="Float")>  _
	Public Property opd_amount() As System.Nullable(Of Double)
		Get
			Return Me._opd_amount
		End Get
		Set
			If (Me._opd_amount.Equals(value) = false) Then
				Me.Onopd_amountChanging(value)
				Me.SendPropertyChanging
				Me._opd_amount = value
				Me.SendPropertyChanged("opd_amount")
				Me.Onopd_amountChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_detail_id", DbType:="Int NOT NULL", IsPrimaryKey:=true)>  _
	Public Property detail_id() As Integer
		Get
			Return Me._detail_id
		End Get
		Set
			If ((Me._detail_id = value)  _
						= false) Then
				Me.Ondetail_idChanging(value)
				Me.SendPropertyChanging
				Me._detail_id = value
				Me.SendPropertyChanged("detail_id")
				Me.Ondetail_idChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.AssociationAttribute(Name:="OPD_OPD_Detail", Storage:="_OPD", ThisKey:="opd_id", OtherKey:="id", IsForeignKey:=true)>  _
	Public Property OPD() As OPD
		Get
			Return Me._OPD.Entity
		End Get
		Set
			Dim previousValue As OPD = Me._OPD.Entity
			If ((Object.Equals(previousValue, value) = false)  _
						OrElse (Me._OPD.HasLoadedOrAssignedValue = false)) Then
				Me.SendPropertyChanging
				If ((previousValue Is Nothing)  _
							= false) Then
					Me._OPD.Entity = Nothing
					previousValue.OPD_Details.Remove(Me)
				End If
				Me._OPD.Entity = value
				If ((value Is Nothing)  _
							= false) Then
					value.OPD_Details.Add(Me)
					Me._opd_id = value.id
				Else
					Me._opd_id = CType(Nothing, Integer)
				End If
				Me.SendPropertyChanged("OPD")
			End If
		End Set
	End Property
	
	Public Event PropertyChanging As PropertyChangingEventHandler Implements System.ComponentModel.INotifyPropertyChanging.PropertyChanging
	
	Public Event PropertyChanged As PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
	
	Protected Overridable Sub SendPropertyChanging()
		If ((Me.PropertyChangingEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanging(Me, emptyChangingEventArgs)
		End If
	End Sub
	
	Protected Overridable Sub SendPropertyChanged(ByVal propertyName As [String])
		If ((Me.PropertyChangedEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End If
	End Sub
End Class
