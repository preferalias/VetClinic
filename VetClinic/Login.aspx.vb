Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub btn_login_Click(sender As Object, e As EventArgs) Handles btn_login.Click
        If Not String.IsNullOrWhiteSpace(txt_user.Text) AndAlso Not String.IsNullOrWhiteSpace(txt_pass.Text) Then
            If txt_user.Text = "admin" AndAlso txt_pass.Text = "admin" Then
                '(bt_txt_Username.Text, bt_txt_Password.Text) Then
                FormsAuthentication.RedirectFromLoginPage(txt_user.Text, False)

                'With CType(Membership.Provider, GenericMembershipProvider).SecMgr
                '    Dim empData = .GetEmployeeData(bt_txt_Username.Text)
                '    .Employee_Name = empData.emp_name
                '    .Emp_id = empData.emp_id
                'End With
                Response.Redirect("~/Default.aspx")
            Else
                MsgBox("Invalid Login name or Password", MsgBoxStyle.Information, "Error")
                'WebUtils.ShowMessageBox(Me, "Invalid Login name or Password")
            End If
        Else
            MsgBox("Invalid Login name or Password", MsgBoxStyle.Information, "Error")
            'WebUtils.ShowMessageBox(Me, "Invalid Login name or Password")
        End If
    End Sub
End Class