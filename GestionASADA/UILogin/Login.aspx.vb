Imports GestionASADA.Utils
Imports GestionASADA.Models


Public Class Login
    Inherits System.Web.UI.Page

    Private dbUsuario As New UsuariosDB()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs)
        Dim errorMessage As String

        Dim encryptor As New Simple3Des("frase$-secreta-123")
        Dim PasswordHash = encryptor.EncryptData(txtPass.Text)

        Dim result = dbUsuario.Login(txtUsername.Text, PasswordHash, errorMessage)

        If result.Rows.Count = 0 Then
            SwalUtils.ShowSwalError(Me, "Error de Login", errorMessage)
        Else

            Dim user = result.Rows(0)
            Session("User") = user("Username")
            Session("Rol") = user("Rol")

            If user("Rol") = "Administrador" Then
                Response.Redirect("/UI/Home.aspx", False)
            Else
                Response.Redirect("/UI/Usuario.aspx", False)
            End If
        End If

    End Sub
End Class