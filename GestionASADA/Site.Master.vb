Public Class SiteMaster
    Inherits MasterPage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        Dim rol As String = ""
        If Session("Rol") IsNot Nothing Then
            rol = Session("Rol").ToString().Trim().ToUpper()
        End If

        If rol = "ADMINISTRADOR" Then
            pnlAdminMenu.Visible = True
        Else
            pnlAdminMenu.Visible = False
        End If

        If Session("User") IsNot Nothing Then
            lblUser.Text = "👤 " & Session("User").ToString()
            btnLogout.Visible = True
        Else
            lblUser.Text = ""
            btnLogout.Visible = False
        End If

        Dim currentUrl As String = Request.Url.AbsolutePath.ToLower()


        If Not currentUrl.Contains("/uilogin/") Then

            If Session("User") Is Nothing Then
                Response.Redirect("~/UILogin/Login.aspx")
            End If


            If rol <> "ADMINISTRADOR" Then

                If currentUrl.Contains("/ui/suscriptor") OrElse
                   currentUrl.Contains("/ui/medidor") OrElse
                   currentUrl.Contains("/ui/consumo") OrElse
                   currentUrl.Contains("/ui/factura") Then

                    Response.Redirect("~/UI/Usuario.aspx")

                End If

            End If

        End If


    End Sub

    Protected Sub btnLogout_Click(sender As Object, e As EventArgs)
        Session.Clear()
        Session.Abandon()

        Response.Redirect("~/UILogin/Login.aspx")
    End Sub
End Class