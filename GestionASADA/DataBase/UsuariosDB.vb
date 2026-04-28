Public Class UsuariosDB
    Private db As New DbHelper()

    Public Function CrearUsuario(ByVal pUsuario As Models.Usuarios, ByRef errorMessage As String) As Boolean
        ' Lógica para crear un nuevo usuario en la base de datos
        Using db.GetConnection()
            Dim query As String = "INSERT INTO Usuarios (IdPersona, Username, PasswordHash, Rol, Activo) 
                              VALUES (@IdPersona, @Username, @PasswordHash, @Rol, @Activo)"

            Dim parameters As New Dictionary(Of String, Object) From {
                {"@IdPersona", pUsuario.IdPersona},
                {"@Username", pUsuario.Username},
                {"@PasswordHash", pUsuario.PasswordHash},
                {"@Rol", pUsuario.Rol},
                {"@Activo", pUsuario.Activo}
            }

            Return db.ExecuteNonQuery(query, parameters, errorMessage)
        End Using

        Return False
    End Function

    Public Function CargarPersonas(ByRef errorMessage As String) As DataTable
        Dim query As String = "SELECT IdPersona, Username, PasswordHash, Rol, Activo FROM Usuarios"

        Return db.ExecuteQuery(query, Nothing, errorMessage)
    End Function

    Public Function Login(ByVal username As String, ByVal passwordHash As String, ByRef errorMessage As String) As DataTable
        'Dim query As String = "SELECT IdPersona, Username, Rol, Activo FROM Usuarios WHERE Username = 
        '@Username AND PasswordHash = @PasswordHash AND Activo = 1"
        Dim query As String = "
        SELECT U.IdPersona, U.Username, U.Rol, U.Activo, P.IDENTIFICACION
        FROM Usuarios U
        INNER JOIN Personas P ON U.IdPersona = P.IdPersona
        WHERE U.Username = @Username 
        AND U.PasswordHash = @PasswordHash 
        AND U.Activo = 1"

        Dim parameters As New Dictionary(Of String, Object) From {
            {"@Username", username},
            {"@PasswordHash", passwordHash}
        }

        Return db.ExecuteQuery(query, parameters, errorMessage)
    End Function
End Class
