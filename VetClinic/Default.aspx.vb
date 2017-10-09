Imports System.Globalization
Imports DevExpress.Web

Public Class _Default
    Inherits Page

    Public Property vetMgr As New VetManager

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            calen_Note.SelectedDate = Date.Now
            lbl_date.InnerHtml = "Selected Date : " & Date.Now.ToString("dd/MM/yyyy", New CultureInfo("en-GB"))
            gv_detail.DataBind()
        End If
    End Sub

    Private Sub calen_Note_DayRender(sender As Object, e As WebControls.DayRenderEventArgs) Handles calen_Note.DayRender
        Dim dateList As New List(Of Date?)
        dateList = vetMgr.GetAppointDateList
        'dateList = esopMgr.GetUsedPaymentDate(If(cbb_ac.Text = "-Select all-", "", cbb_ac.Text))
        For Each d In dateList
            If e.Day.Date = If(d.HasValue, d.Value.Date, Nothing) Then
                e.Cell.BackColor = Drawing.Color.LightBlue
                If e.Day.IsSelected Then
                    e.Cell.BackColor = Drawing.ColorTranslator.FromHtml("#666666")
                End If
            End If
        Next
    End Sub

    Private Sub calen_Note_SelectionChanged(sender As Object, e As EventArgs) Handles calen_Note.SelectionChanged
        Dim txtDate As String = calen_Note.SelectedDate.ToString("dd/MM/yyyy", New CultureInfo("en-GB"))
        lbl_date.InnerHtml = "Selected Date : " & txtDate
        gv_detail.DataBind()
    End Sub

    Private Sub gv_detail_DataBinding(sender As Object, e As EventArgs) Handles gv_detail.DataBinding
        Dim sdate As Date
        sdate = calen_Note.SelectedDate
        gv_detail.DataSource = vetMgr.GetDetailAppointByDate(sdate)
    End Sub

    Private Sub gv_OPD_HtmlRowPrepared(sender As Object, e As ASPxGridViewTableRowEventArgs) Handles gv_OPD.HtmlRowPrepared
        Dim btn_detail As Bootstrap.BootstrapButton = CType(gv_OPD.FindRowCellTemplateControl(e.VisibleIndex, gv_OPD.Columns(8), "btn_detail"), Bootstrap.BootstrapButton)
        If btn_detail IsNot Nothing Then
            btn_detail.ClientSideEvents.Click = "function(s,e){window.location = 'AppointDetail.aspx?id=" & e.KeyValue & "';}"
        End If
    End Sub

    Private Sub gv_detail_HtmlRowPrepared(sender As Object, e As ASPxGridViewTableRowEventArgs) Handles gv_detail.HtmlRowPrepared
        Dim btn_detail As Bootstrap.BootstrapButton = CType(gv_detail.FindRowCellTemplateControl(e.VisibleIndex, gv_detail.Columns(3), "btn_detail"), Bootstrap.BootstrapButton)
        If btn_detail IsNot Nothing Then
            btn_detail.ClientSideEvents.Click = "function(s,e){window.location = 'AppointDetail.aspx?id=" & gv_detail.GetRowValues(e.VisibleIndex, "opd_id") & "';}"
        End If
    End Sub

End Class