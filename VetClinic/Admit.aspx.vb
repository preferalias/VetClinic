Imports DevExpress.Web
Imports DevExpress.Web.Data

Public Class Admit
    Inherits System.Web.UI.Page
    Public Property vetMgr As New VetManager

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

    Private Sub ods_opd_ObjectCreating(sender As Object, e As ObjectDataSourceEventArgs) Handles ods_opd.ObjectCreating, ods_dis.ObjectCreating
        e.ObjectInstance = vetMgr
    End Sub

    Private Sub ods_opd_Selecting(sender As Object, e As ObjectDataSourceSelectingEventArgs) Handles ods_opd.Selecting
        e.InputParameters("opdNum") = If(String.IsNullOrWhiteSpace(opd_num.Value), "", opd_num.Value.ToString)
        e.InputParameters("petName") = petName.Value
        e.InputParameters("type") = String.Empty
        e.InputParameters("contact") = contact.Value
        e.InputParameters("holderName") = holder_name.Value
    End Sub

    Private Sub gv_OPD_CustomCallback(sender As Object, e As ASPxGridViewCustomCallbackEventArgs) Handles gv_OPD.CustomCallback
        gv_OPD.DataBind()
    End Sub

    Private Sub gv_OPD_HtmlRowPrepared1(sender As Object, e As ASPxGridViewTableRowEventArgs) Handles gv_OPD.HtmlRowPrepared
        Dim btn_detail As Bootstrap.BootstrapButton = CType(gv_OPD.FindRowCellTemplateControl(e.VisibleIndex, gv_OPD.Columns(9), "btn_admit"), Bootstrap.BootstrapButton)
        If btn_detail IsNot Nothing Then
            btn_detail.ClientSideEvents.Click = "function(s,e){hdn_addID.SetText('" & e.KeyValue & "');" &
            "popup_add.SetHeaderText('" & "OPD : " & vetMgr.GetOPDNumByID(CInt(e.KeyValue)) & "');popup_add.Show();}"
        End If
    End Sub

    Private Sub gv_admit_HtmlRowPrepared(sender As Object, e As ASPxGridViewTableRowEventArgs) Handles gv_admit.HtmlRowPrepared
        If Not String.IsNullOrEmpty(e.KeyValue) Then
            Dim key As String() = e.KeyValue.ToString.Split("|")
            Dim opdID As Integer = key(0)
            Dim adID As Integer = key(1)
            Dim btn_detail As Bootstrap.BootstrapButton = CType(gv_admit.FindRowCellTemplateControl(e.VisibleIndex, gv_admit.Columns(6), "btn_view"), Bootstrap.BootstrapButton)
            Dim btn_del As Bootstrap.BootstrapButton = CType(gv_admit.FindRowCellTemplateControl(e.VisibleIndex, gv_admit.Columns(6), "btn_del"), Bootstrap.BootstrapButton)
            If btn_detail IsNot Nothing Then
                btn_detail.ClientSideEvents.Click = "function(s,e){window.location = 'AppointDetail.aspx?id=" & opdID & "&back=Admit.aspx';}"
            End If
            If btn_del IsNot Nothing Then
                btn_del.ClientSideEvents.Click = "function(s,e){hdn_addID.SetText('" & adID & "');" &
                "popup_discharged.SetHeaderText('" & "OPD : " & vetMgr.GetOPDNumByID(CInt(opdID)) & "');popup_discharged.Show();}"
            End If
        End If
    End Sub

    Private Sub ods_admit_Selecting(sender As Object, e As ObjectDataSourceSelectingEventArgs) Handles ods_admit.Selecting
        e.InputParameters("stats") = AdmitStatusEnum.Admitted
    End Sub

    Private Sub gv_admit_CustomCallback(sender As Object, e As ASPxGridViewCustomCallbackEventArgs) Handles gv_admit.CustomCallback
        If e.Parameters = "New" Then
            Dim newAdmit As New Admit
            With newAdmit
                .opd_id = CInt(hdn_addID.Text)
                .admit_date = dedit_addday.Value
                .admit_stats = AdmitStatusEnum.Admitted
            End With
            vetMgr.AddAdmit(newAdmit)
        End If
        If e.Parameters = "Del" Then
            vetMgr.DischargedAdmit(CInt(hdn_addID.Text), dedit_pup_delete.Value)
        End If
        gv_admit.DataBind()
    End Sub

    Private Sub ods_dis_Selecting(sender As Object, e As ObjectDataSourceSelectingEventArgs) Handles ods_dis.Selecting
        e.InputParameters("stats") = AdmitStatusEnum.Discharged
    End Sub

    Private Sub gv_admit_CellEditorInitialize(sender As Object, e As ASPxGridViewEditorEventArgs) Handles gv_admit.CellEditorInitialize
        If e.Column.FieldName = "pet_name" OrElse e.Column.FieldName = "opd_num" Or
            e.Column.FieldName = "pet_type" Or e.Column.FieldName = "contact" Or
            e.Column.FieldName = "holder_name" Or e.Column.Caption = "Details" Then
            e.Editor.Enabled = False
        End If
    End Sub

    Private Sub gv_admit_RowUpdating(sender As Object, e As ASPxDataUpdatingEventArgs) Handles gv_admit.RowUpdating
        vetMgr.UpdateDateAdmit(CInt(e.Keys("admit_id")), e.NewValues("admit_date"))
        e.Cancel = True
        gv_admit.CancelEdit()
        gv_admit.DataBind()
    End Sub

    Private Sub gv_admit_RowDeleting(sender As Object, e As ASPxDataDeletingEventArgs) Handles gv_admit.RowDeleting
        vetMgr.DeleteAdmit(CInt(e.Keys("admit_id")))
        e.Cancel = True
        gv_admit.CancelEdit()
        gv_admit.DataBind()
    End Sub
End Class