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
            'Throw New Exception("ROL: " & user("Rol").ToString())
            Session("User") = user("Username")
            Session("Rol") = user("Rol")
            Session("Identificacion") = user("IDENTIFICACION")

            Dim rol As String = user("Rol").ToString().Trim().ToUpper()

            If rol = "ADMINISTRADOR" Then
                Response.Redirect("~/UI/Home.aspx")
            Else
                Response.Redirect("~/UI/Usuario.aspx")
            End If
        End If

    End Sub
End Class