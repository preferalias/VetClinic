Imports DevExpress.Web

Public Class Contact
    Inherits Page
    Public Property vetMgr As New VetManager

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

    Private Sub ods_opd_ObjectCreating(sender As Object, e As ObjectDataSourceEventArgs) Handles ods_opd.ObjectCreating
        e.ObjectInstance = vetMgr
    End Sub

    Private Sub ods_opd_Selecting(sender As Object, e As ObjectDataSourceSelectingEventArgs) Handles ods_opd.Selecting
        e.InputParameters("petName") = petName.Value
        e.InputParameters("type") = petType.Value
        e.InputParameters("holderName") = holder_name.Value
    End Sub

    Private Sub gv_OPD_CustomCallback(sender As Object, e As ASPxGridViewCustomCallbackEventArgs) Handles gv_OPD.CustomCallback
        gv_OPD.DataBind()
    End Sub

    Private Sub gv_OPD_HtmlRowPrepared(sender As Object, e As ASPxGridViewTableRowEventArgs) Handles gv_OPD.HtmlRowPrepared
        Dim btn_detail As Bootstrap.BootstrapButton = CType(gv_OPD.FindRowCellTemplateControl(e.VisibleIndex, gv_OPD.Columns(9), "btn_detail"), Bootstrap.BootstrapButton)
        If btn_detail IsNot Nothing Then
            btn_detail.ClientSideEvents.Click = "function(s,e){window.location = 'AppointDetail.aspx?id=" & e.KeyValue & "';}"
        End If
    End Sub
End Class