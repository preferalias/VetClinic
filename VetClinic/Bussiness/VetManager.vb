Imports System.Data.SqlClient

Public Class VetManager

    Private DefaultConnString As String = System.Configuration.ConfigurationManager.ConnectionStrings("vet_dbConnectionString").ConnectionString

    Public Function NewDataContext() As VetDataContextDataContext
        Return New VetDataContextDataContext(DefaultConnString)
    End Function

#Region "Generic Method"
    Public Function findNextID(ByVal ids As List(Of Integer)) As Integer
        If ids.Count > 0 Then
            Return ids.Max + 1
        Else
            Return 1
        End If
    End Function

    Public Function findNextOPDnum() As Integer
        Dim opdNum As Integer
        Using ctx = NewDataContext()
            Dim second = ((Now.Year + 543) Mod 100) * 10000
            Dim forth As List(Of Integer) = (From r In ctx.OPDs Select r.opd_num).ToList
            If forth.Count > 0 Then
                Dim f = (forth.Max Mod 10000) + 1
                opdNum = second + f
            Else
                opdNum = second + 1
            End If
        End Using
        Return opdNum
    End Function
#End Region

#Region "OPD"
    Public Function GetOPD() As List(Of OPD)
        Dim opds As New List(Of OPD)
        Using ctx = NewDataContext()
            opds = (From r In ctx.OPDs Order By r.id Descending).ToList
        End Using
        Return opds
    End Function

    Public Function GetOPDbyID(ByVal id As Integer) As OPD
        Dim opds As OPD
        Using ctx = NewDataContext()
            opds = (From r In ctx.OPDs Where r.id = id).SingleOrDefault
        End Using
        Return opds
    End Function

    Public Function GetOPD(ByVal opdNum As Integer, ByVal petName As String, ByVal type As String, ByVal holderName As String) As IEnumerable
        Dim opds As New List(Of OPD)
        Using ctx = NewDataContext()
            opds = (From r In ctx.OPDs Where (r.opd_num = opdNum OrElse opdNum = 0) AndAlso (r.pet_name.Contains(petName) OrElse String.IsNullOrEmpty(petName)) _
                                           AndAlso (r.pet_type.Contains(type) OrElse String.IsNullOrEmpty(type)) _
                                           AndAlso (r.holder_name.Contains(holderName) OrElse String.IsNullOrEmpty(holderName)) Order By r.id Descending).ToList
        End Using
        Return opds
    End Function

    Public Function AddOPD(ByVal opd As OPD, ByVal detail As OPD_Detail) As Integer
        Using ctx = NewDataContext()
            If ctx.Connection.State <> ConnectionState.Open Then ctx.Connection.Open()
            Dim tx = ctx.Connection.BeginTransaction
            ctx.Transaction = tx
            Try
                Dim ids As List(Of Integer) = (From r In ctx.OPDs Select r.id).ToList
                With opd
                    .id = findNextID(ids)
                    .opd_num = findNextOPDnum()
                End With
                ctx.OPDs.InsertOnSubmit(opd)
                ctx.SubmitChanges()
                detail.detail_id = findNextID((From r In ctx.OPD_Details Select r.detail_id).ToList)
                detail.opd_id = opd.id
                ctx.OPD_Details.InsertOnSubmit(detail)
                ctx.SubmitChanges()
                tx.Commit()
                Return opd.id
            Catch ex As Exception
                Throw New Exception
                tx.Rollback()
            End Try
        End Using
    End Function

    Public Sub updateOPD(ByVal newOPD As OPD)
        Using ctx = NewDataContext()
            Dim origOPD As OPD = (From r In ctx.OPDs Where r.id = newOPD.id).Single
            With origOPD
                .opd_num = newOPD.opd_num
                .pet_age = newOPD.pet_age
                .pet_age_month = newOPD.pet_age_month
                .pet_breed = newOPD.pet_breed
                .pet_name = newOPD.pet_name
                .pet_sex = newOPD.pet_sex
                .pet_type = newOPD.pet_type
                .holder_name = newOPD.holder_name
                .address = newOPD.address
                .contact = newOPD.contact
            End With
            ctx.SubmitChanges()
        End Using
    End Sub

    Public Function ImportOPDfile(ByVal fileStream As IO.Stream) As String
        Dim errMsg As String = String.Empty
        Dim p As New OfficeOpenXml.ExcelPackage
        p.Load(fileStream)
        Dim sheet = p.Workbook.Worksheets.First
        Dim row = 2
        Using ctx = NewDataContext()
            If ctx.Connection.State <> ConnectionState.Open Then ctx.Connection.Open()
            Dim tx = ctx.Connection.BeginTransaction
            ctx.Transaction = tx
            While True
                Dim newOpd As New OPD
                Dim hasData As Boolean = False
                For col = 1 To 12
                    If sheet.Cells(row, col).Value IsNot Nothing Then
                        hasData = True
                        Exit For
                    End If
                Next
                If hasData Then
                    Try
                        With sheet
                            newOpd.opd_num = .Cells(row, 1).Value
                            newOpd.pet_name = .Cells(row, 2).Value
                            newOpd.pet_type = .Cells(row, 3).Value
                            newOpd.pet_sex = .Cells(row, 4).Value
                            newOpd.pet_breed = .Cells(row, 5).Value
                            newOpd.pet_age = If(.Cells(row, 7).Value Is Nothing, 0, CInt(Math.Floor(.Cells(row, 7).Value) \ 1))
                            newOpd.pet_age_month = If(.Cells(row, 7).Value Is Nothing, 0, CInt((Math.Floor(.Cells(row, 7).Value) Mod 1) * 100))
                            newOpd.holder_name = .Cells(row, 8).Value & " " & .Cells(row, 9).Value
                            newOpd.contact = If(.Cells(row, 10).Value Is Nothing, String.Empty, .Cells(row, 10).Value.ToString.Replace("-", Nothing))
                            newOpd.address = .Cells(row, 11).Value & " " & .Cells(row, 12).Value
                        End With
                        Try
                            newOpd.id = findNextID((From r In ctx.OPDs Select r.id).ToList)
                            ctx.OPDs.InsertOnSubmit(newOpd)
                            ctx.SubmitChanges()
                        Catch ex As Exception
                            errMsg &= "Sql Added error."
                            Throw New Exception
                        End Try
                    Catch ex As Exception
                        errMsg &= "Error at row " & row
                        tx.Rollback()
                        Return errMsg
                    End Try
                Else
                    errMsg &= "Import sucess: " & row & " were added."
                    Exit While
                End If
                row += 1
            End While
            tx.Commit()
        End Using
        Return errMsg
    End Function

#End Region

#Region "OPD Detail"
    Public Function GetDetail(ByVal opdID As Integer) As DataTable
        Dim a As New DataTable
        Using ctx = NewDataContext()
            ctx.Connection.Open()
            Dim q As String = "select d.detail_id, o.opd_num, d.opd_bw, d.opd_date, d.opd_details, " &
                "d.opd_lab, d.opd_type, d.opd_fee,d.opd_fee2, d.opd_amount from opd_detail d " &
                "inner join OPD o on d.opd_id = o.id " &
                "where d.opd_id = @ID"
            Dim cmd As New SqlCommand(q, ctx.Connection)
            With cmd
                .Parameters.AddWithValue("@ID", opdID)
            End With
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(a)
        End Using
        Return a
    End Function


    Public Function GetDetailByType(ByVal opdID As Integer, ByVal type As String) As List(Of OPD_Detail)
        Using ctx = NewDataContext()
            Return (From r In ctx.OPD_Details Where r.opd_id = opdID AndAlso r.opd_type = type).ToList
        End Using
    End Function

    Public Function GetDetailAppointByDate(ByVal data_date As Date) As DataTable
        'Using ctx = NewDataContext()
        '    Return (From r In ctx.OPD_Details Where r.opd_date = data_date).ToList
        'End Using
        Dim a As New DataTable
        Using ctx = NewDataContext()
            ctx.Connection.Open()
            Dim q As String = "select d.detail_id, d.opd_id, o.opd_num, d.opd_date, d.opd_details, " &
                "d.opd_lab, d.opd_type, d.opd_fee, d.opd_amount from opd_detail d " &
                "inner join OPD o on d.opd_id = o.id " &
                "where d.opd_date = @ID and d.opd_type = @TYPE"
            Dim cmd As New SqlCommand(q, ctx.Connection)
            With cmd
                .Parameters.AddWithValue("@ID", data_date.Date)
                .Parameters.AddWithValue("@TYPE", "วันนัด")
            End With
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(a)
        End Using
        Return a
    End Function

    Public Function GetAppointDateList() As List(Of Date?)
        Dim list As New List(Of Date?)
        Using ctx = NewDataContext()
            list = (From r In ctx.OPD_Details Where r.opd_type = "วันนัด" Select r.opd_date Distinct).ToList
        End Using
        Return list
    End Function

    Public Sub UpdateDetail(ByVal detail As OPD_Detail)
        Using ctx = NewDataContext()
            Dim origDetail As OPD_Detail = (From r In ctx.OPD_Details Where r.detail_id = detail.detail_id).Single
            With origDetail
                .opd_date = detail.opd_date
                .opd_details = detail.opd_details
                .opd_lab = detail.opd_lab
                .opd_type = detail.opd_type
                .opd_fee = detail.opd_fee
                .opd_amount = detail.opd_amount
                .opd_fee2 = detail.opd_fee2
                .opd_bw = detail.opd_bw
            End With
            ctx.SubmitChanges()
        End Using
    End Sub

    Public Sub InsertDetail(ByVal detail As OPD_Detail, ByVal opdID As Integer)
        Using ctx = NewDataContext()
            detail.detail_id = findNextID((From r In ctx.OPD_Details Select r.detail_id).ToList)
            detail.opd_id = opdID
            ctx.OPD_Details.InsertOnSubmit(detail)
            ctx.SubmitChanges()
        End Using
    End Sub

    Public Sub DeleteDetail(ByVal detailID As Integer)
        Using ctx = NewDataContext()
            Dim origDetail As OPD_Detail = (From r In ctx.OPD_Details Where r.detail_id = detailID).Single
            ctx.OPD_Details.DeleteOnSubmit(origDetail)
            ctx.SubmitChanges()
        End Using
    End Sub

    Public Sub AddOpdDetail(ByVal detail As OPD_Detail)
        Using ctx = NewDataContext()
            detail.detail_id = findNextID((From r In ctx.OPD_Details Select r.detail_id).ToList)
            ctx.OPD_Details.InsertOnSubmit(detail)
            ctx.SubmitChanges()
        End Using
    End Sub
#End Region

End Class
