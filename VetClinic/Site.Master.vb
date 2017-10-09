Public Class SiteMaster
    Inherits MasterPage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

    Private Sub signOut_ServerClick(sender As Object, e As EventArgs) Handles signOut.ServerClick
        FormsAuthentication.SignOut()
        Response.Redirect("~/Login?ReturnUrl=%2fDefault.aspx")
    End Sub
End Class