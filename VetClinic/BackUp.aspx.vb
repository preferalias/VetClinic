
Imports System.Data.SqlClient
Imports System.IO

Public Class BackUp
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub btnbt_bkup_Click(sender As Object, e As EventArgs) Handles btnbt_bkup.Click
        Dim d As String = Now.Date
        d = d.Replace("/", "-")
        Dim dbname As String = "[" & System.Configuration.ConfigurationManager.AppSettings("DBNameForBackup") & "]"
        Dim path As String = System.Configuration.ConfigurationManager.AppSettings("BackupPath")
        Dim filename As String = dbname & " Back Up " & d & ".bak"
        Dim filepath As String = path & filename
        Dim conStr As String = System.Configuration.ConfigurationManager.ConnectionStrings("vet_dbConnectionString").ConnectionString
        Dim conn As New SqlConnection(conStr)
        Dim cmd As New SqlCommand("backup database " & dbname & " to DISK = '" & filepath & "'", conn)

        If Not File.Exists(filepath) Then
            conn.Open()
            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                ClientScript.RegisterClientScriptBlock(Page.GetType, "Error", "<script type=""text/javascript"">alert('SQL Error')</script>")
            End Try
            conn.Close()
        End If

        Dim filedl = New FileInfo(filepath)
        If (filedl.Exists) Then
            Try
                With Response
                    .ClearContent()
                    .ClearHeaders()
                    .AddHeader("Content-Disposition", "attachment; filename=" & filedl.Name)
                    .AddHeader("Content-Length", filedl.Length.ToString())
                    .ContentType = "application/octet-stream"
                    .TransmitFile(filedl.FullName)
                    .Flush()
                End With
            Finally
                If File.Exists(filepath) Then File.Delete(filepath) 'ลบ file
            End Try
        End If
    End Sub
End Class