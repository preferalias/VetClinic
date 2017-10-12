Imports DevExpress.Web
Imports DevExpress.Web.Data

Public Class AppointDetail
    Inherits System.Web.UI.Page

    Public Property vetMgr As New VetManager

    Public ReadOnly Property SelectedID As Integer
        Get
            Return CInt(hdn_id.Text)
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Request("id") = 0 Then
            Response.Redirect("~/")
        End If
        If Not IsPostBack Then
            hdn_id.Text = Request("id")
        End If
        Dim opd As OPD = vetMgr.GetOPDbyID(SelectedID)
        If opd IsNot Nothing Then
            Dim space As String = "&nbsp; &nbsp; &nbsp;"
            Dim petName As String = opd.pet_name
            Dim age As String = If(opd.pet_age.HasValue, opd.pet_age, "N/A")
            Dim month As String = If(opd.pet_age_month.HasValue, opd.pet_age_month, "N/A")
            Dim sex As String = opd.pet_sex
            'Dim weight As String = If(opd.pet_weight.HasValue, opd.pet_weight, "N/A")
            Dim breed As String = opd.pet_breed
            Dim type As String = opd.pet_type
            Dim holderName As String = opd.holder_name
            Dim contact = opd.contact
            Dim opdNum = opd.opd_num
            header_h4.InnerHtml = "OPD Number : " & opdNum
            para1.InnerHtml = "<b>ชื่อสัตว์เลี้ยง: </b>" & petName & space & "<b>ชนิด: </b>" &
                type & space & "<b>อายุ: </b>" & age & " ปี" & space & month & " เดือน" & space &
                "<b>เพศ: </b>" & sex & space & "<b>พันธุ์: </b>" & breed
            para2.InnerHtml = "<b>ชื่อเจ้าของ: </b>" & holderName & space & "<b>เบอร์ติดต่อ: </b>" & contact
        End If
    End Sub

    Private Sub ods_detail_Selecting(sender As Object, e As ObjectDataSourceSelectingEventArgs) Handles ods_detail.Selecting
        e.InputParameters("opdID") = SelectedID
        e.InputParameters("type") = "วันนัด"
    End Sub

    Private Sub ods_detail_ObjectCreating(sender As Object, e As ObjectDataSourceEventArgs) Handles ods_detail.ObjectCreating,
            ods_detail2.ObjectCreating
        e.ObjectInstance = vetMgr
    End Sub

    Private Sub gv_detail2_RowInserting(sender As Object, e As ASPxDataInsertingEventArgs) Handles gv_detail2.RowInserting
        Dim detail As New OPD_Detail
        With detail
            .opd_details = e.NewValues("opd_details")
            .opd_date = e.NewValues("opd_date")
            .opd_lab = e.NewValues("opd_lab")
            .opd_fee = e.NewValues("opd_fee")
            .opd_fee2 = e.NewValues("opd_fee2")
            .opd_amount = e.NewValues("opd_amount")
            .opd_type = "วันตรวจ"
            .opd_bw = e.NewValues("opd_bw")
        End With
        vetMgr.InsertDetail(detail, SelectedID)
        e.Cancel = True
        gv_detail2.CancelEdit()
        gv_detail2.DataBind()
    End Sub

    Private Sub gv_detail2_RowUpdating(sender As Object, e As ASPxDataUpdatingEventArgs) Handles gv_detail2.RowUpdating
        Dim Detail As New OPD_Detail
        With Detail
            .detail_id = CInt(e.Keys("detail_id"))
            .opd_details = e.NewValues("opd_details")
            .opd_date = e.NewValues("opd_date")
            .opd_lab = e.NewValues("opd_lab")
            .opd_fee = e.NewValues("opd_fee")
            .opd_fee2 = e.NewValues("opd_fee2")
            .opd_amount = e.NewValues("opd_amount")
            .opd_type = "วันตรวจ"
            .opd_bw = e.NewValues("opd_bw")
        End With
        vetMgr.UpdateDetail(Detail)
        e.Cancel = True
        gv_detail2.CancelEdit()
        gv_detail2.DataBind()
    End Sub

    Private Sub ods_detail2_Selecting(sender As Object, e As ObjectDataSourceSelectingEventArgs) Handles ods_detail2.Selecting
        e.InputParameters("opdID") = SelectedID
        e.InputParameters("type") = "วันตรวจ"
    End Sub

    Private Sub gv_detail_RowInserting(sender As Object, e As ASPxDataInsertingEventArgs) Handles gv_detail.RowInserting
        Dim detail As New OPD_Detail
        With detail
            .opd_details = e.NewValues("opd_details")
            .opd_date = e.NewValues("opd_date")
            .opd_type = "วันนัด"
        End With
        vetMgr.InsertDetail(detail, SelectedID)
        e.Cancel = True
        gv_detail.CancelEdit()
        gv_detail.DataBind()
    End Sub

    Private Sub gv_detail2_CellEditorInitialize(sender As Object, e As ASPxGridViewEditorEventArgs) Handles gv_detail2.CellEditorInitialize
        If e.Column.FieldName = "opd_bw" Then
            e.Editor.Attributes.Add("onkeypress", "return isNumberKeyDecimal(event)")
        End If
        If e.Column.FieldName = "opd_amount" Then
            e.Editor.Attributes.Add("onkeypress", "return isNumberKey(event)")
        End If
    End Sub
End Class