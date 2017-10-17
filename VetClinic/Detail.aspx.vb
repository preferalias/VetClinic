Imports DevExpress.Web
Imports DevExpress.Web.Data

Public Class Detail
    Inherits System.Web.UI.Page

    Public Property vetMgr As New VetManager

    Public ReadOnly Property SelectedID As Integer
        Get
            Return CInt(hdn_id.Text)
        End Get
    End Property


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request("id") = 0 OrElse Request("id") Is Nothing OrElse
            String.IsNullOrEmpty(Request("id")) Then
            Response.Redirect("~/")
        End If
        If Not IsPostBack Then
            hdn_id.Text = Request("id")
            UpdateLabelGeneral()
        End If
    End Sub

    Public Sub UpdateLabelGeneral()
        Dim opd As OPD = vetMgr.GetOPDbyID(SelectedID)
        With opd
            opd_num.Value = opd.opd_num
            petName.Value = opd.pet_name
            pet_Type.Value = opd.pet_type
            sex.Value = opd.pet_sex
            age.Value = opd.pet_age
            breed.Value = opd.pet_breed
            holder_name.Value = opd.holder_name
            address.Value = opd.address
            contact.Value = opd.contact
            month.Value = opd.pet_age_month
            'weight.Value = opd.pet_weight
        End With
    End Sub

    Private Sub ods_detail_Selecting(sender As Object, e As ObjectDataSourceSelectingEventArgs) Handles ods_detail.Selecting
        e.InputParameters("opdID") = SelectedID
    End Sub

    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        UpdateLabelGeneral()
    End Sub

    Private Sub gv_OPD_RowUpdating(sender As Object, e As ASPxDataUpdatingEventArgs) Handles gv_OPD.RowUpdating
        Dim Detail As New OPD_Detail
        With Detail
            .detail_id = CInt(e.Keys("detail_id"))
            .opd_details = e.NewValues("opd_details")
            .opd_date = e.NewValues("opd_date")
            .opd_lab = e.NewValues("opd_lab")
            .opd_fee = e.NewValues("opd_fee")
            .opd_fee2 = e.NewValues("opd_fee2")
            .opd_amount = e.NewValues("opd_amount")
            .opd_type = e.NewValues("opd_type")
            .opd_bw = e.NewValues("opd_bw")
        End With
        vetMgr.UpdateDetail(Detail)
        e.Cancel = True
        gv_OPD.CancelEdit()
        gv_OPD.DataBind()
    End Sub

    Private Sub gv_OPD_RowDeleting(sender As Object, e As ASPxDataDeletingEventArgs) Handles gv_OPD.RowDeleting
        vetMgr.DeleteDetail(CInt(e.Keys("detail_id")))
        e.Cancel = True
        gv_OPD.CancelEdit()
        gv_OPD.DataBind()
    End Sub

    'Private Sub gv_OPD_RowInserting(sender As Object, e As ASPxDataInsertingEventArgs) Handles gv_OPD.RowInserting
    '    Dim detail As New OPD_Detail
    '    With detail
    '        .opd_details = e.NewValues("opd_details")
    '        .opd_date = e.NewValues("opd_date")
    '        .opd_lab = e.NewValues("opd_lab")
    '        .opd_fee = e.NewValues("opd_fee")
    '        .opd_amount = e.NewValues("opd_amount")
    '        .opd_type = e.NewValues("opd_type")
    '    End With
    '    vetMgr.InsertDetail(detail, SelectedID)
    '    gv_OPD.DataBind()
    'End Sub

    Private Sub gv_OPD_CellEditorInitialize(sender As Object, e As ASPxGridViewEditorEventArgs) Handles gv_OPD.CellEditorInitialize
        If (e.Column.FieldName = "opd_type") Then
            Dim cbb_type As DevExpress.Web.Bootstrap.BootstrapComboBox = CType(e.Editor, DevExpress.Web.Bootstrap.BootstrapComboBox)
            If cbb_type IsNot Nothing Then
                cbb_type.Items.Add(OPDTypeEnum.Diagnosis, OPDTypeEnum.Diagnosis)
                cbb_type.Items.Add(OPDTypeEnum.Appointment, OPDTypeEnum.Appointment)
            End If
        End If
        If (e.Column.FieldName = "opd_num") Then
            e.Editor.Visible = True
            e.Editor.Attributes.Add("readonly", "readonly")
        End If
        If e.Column.FieldName = "opd_bw" Then
            e.Editor.Attributes.Add("onkeypress", "return isNumberKeyDecimal(event)")
        End If
        If e.Column.FieldName = "opd_amount" Then
            e.Editor.Attributes.Add("onkeypress", "return isNumberKey(event)")
        End If
    End Sub

    Private Sub btn_update_Click(sender As Object, e As EventArgs) Handles btn_update.Click
        Dim newOPD As New OPD
        Dim errMsg As String = "Error List"
        Try
            If String.IsNullOrWhiteSpace(petName.Value) Then
                errMsg &= "\nPet name cannot be null"
                Throw New Exception
            End If
            With newOPD
                .opd_num = opd_num.Value
                .id = SelectedID
                .pet_name = petName.Value
                .pet_type = pet_Type.Value
                .pet_sex = sex.Value
                .pet_age = If(String.IsNullOrWhiteSpace(age.Value), Nothing, age.Value)
                .pet_age_month = If(String.IsNullOrWhiteSpace(month.Value), Nothing, month.Value)
                .pet_breed = breed.Value
                .holder_name = holder_name.Value
                .address = address.Value
                .contact = contact.Value
                '.pet_weight = weight.Value
            End With
            vetMgr.updateOPD(newOPD)
            ClientScript.RegisterClientScriptBlock(Page.GetType, "Saved", "<script type=""text/javascript"">alert('Success')</script>")
            UpdateLabelGeneral()
        Catch ex As Exception
            ClientScript.RegisterClientScriptBlock(Page.GetType, "Invalid Data", "<script type=""text/javascript"">alert('" & errMsg & "')</script>")
        End Try
    End Sub

End Class