Imports DevExpress.Web

Public Class Admit
    Inherits System.Web.UI.Page
    Public Property vetMgr As New VetManager

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

    Private Sub ods_opd_ObjectCreating(sender As Object, e As ObjectDataSourceEventArgs) Handles ods_opd.ObjectCreating
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
        Dim btn_detail As Bootstrap.BootstrapButton = CType(gv_admit.FindRowCellTemplateControl(e.VisibleIndex, gv_admit.Columns(6), "btn_view"), Bootstrap.BootstrapButton)
        If btn_detail IsNot Nothing Then
            btn_detail.ClientSideEvents.Click = "function(s,e){window.location = 'AppointDetail.aspx?id=" & e.KeyValue & "&back=Admit.aspx';}"
        End If
    End Sub

    Private Sub ods_admit_Selecting(sender As Object, e As ObjectDataSourceSelectingEventArgs) Handles ods_admit.Selecting
        e.InputParameters("stats") = 2
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
            gv_admit.DataBind()
        End If
    End Sub
End Class