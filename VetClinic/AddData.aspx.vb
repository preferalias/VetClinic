Public Class About
    Inherits Page

    Public Property vetMgr As New VetManager

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

    Private Sub btn_Submit_Click(sender As Object, e As EventArgs) Handles btn_Submit.Click
        Dim newOPD As New OPD
        Dim newDetail As New OPD_Detail
        Dim errMsg As String = "Error List"
        Dim opd_id As Integer
        Try
            If String.IsNullOrEmpty(petName.Value) Then
                errMsg &= "\n-Fill the petname"
                Throw New Exception
            End If
            If [date].Value Is Nothing Then
                errMsg &= "\n-Detail date cannot be null."
                Throw New Exception
            End If
            With newOPD
                .pet_name = petName.Value
                .pet_breed = breed.Value
                Try
                    .pet_age = If(String.IsNullOrEmpty(age.Value), Nothing, CInt(age.Value))
                Catch ex As Exception
                    errMsg &= "\n-Pet Age is not in the correct form."
                    Throw New Exception
                End Try
                Try
                    .pet_age_month = If(String.IsNullOrEmpty(month.Value), Nothing, CInt(month.Value))
                Catch ex As Exception
                    errMsg &= "\n-Pet Month is not in the correct form."
                    Throw New Exception
                End Try

                .pet_sex = sex.Value
                .pet_type = pet_Type.Value
                .holder_name = holder_name.Value
                .address = address.Value
                .contact = contact.Value
            End With
            With newDetail
                .opd_date = [date].Value
                .opd_details = details.Value
                .opd_fee = fee.Value
                .opd_lab = lab.Value
                Try
                    .opd_amount = If(String.IsNullOrEmpty(amount.Value), Nothing, CDbl(amount.Value))
                Catch ex As Exception
                    errMsg &= "\n-Amount must be numeric."
                    Throw New Exception
                End Try
                '.opd_lab2 =
                .opd_fee2 = rx.Value
                .opd_type = OPDTypeEnum.Diagnosis
                Try
                    .opd_bw = If(String.IsNullOrEmpty(bw.Value), Nothing, CDbl(bw.Value))
                Catch ex As Exception
                    errMsg &= "\n-Body Weight is not in the correct form"
                    Throw New Exception
                End Try
            End With

            Try
                opd_id = vetMgr.AddOPD(newOPD, newDetail)
            Catch ex As Exception
                errMsg &= "\n-Invalid Data"
                Throw New Exception
            End Try
            ClientScript.RegisterClientScriptBlock(Page.GetType, "Invalid Data", "<script type=""text/javascript"">alert('Success')</script>")
            Response.Redirect("~/AppointDetail.aspx?id=" & opd_id, False)
        Catch ex As Exception
            ClientScript.RegisterClientScriptBlock(Page.GetType, "Invalid Data", "<script type=""text/javascript"">alert('" & errMsg & "')</script>")
            'MsgBox(errMsg)
        End Try
    End Sub
End Class