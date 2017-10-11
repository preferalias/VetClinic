Public Class Exel_Upload
    Inherits System.Web.UI.Page

    Public Property vetMgr As New VetManager
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub btn_upload_Click(sender As Object, e As EventArgs) Handles btn_upload.Click
        If upload_opd.HasFile Then
            If upload_opd.PostedFile.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" Then
                lbl_upload_status.Text = vetMgr.ImportOPDfile(upload_opd.FileContent)
            Else
                lbl_upload_status.Text = "Only accept file content .xlsx"
            End If
        Else
            lbl_upload_status.Text = "Choose you file."
        End If
    End Sub
End Class