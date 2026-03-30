Public Class PersonaDB
    Private db As New DbHelper()
    'Crear Persona
    Public Function CrearPersona(ByVal pPersona As Models.Persona, ByRef errorMessage As String) As Int32
        'Lógica para crear una nueva persona en la base de datos
        Using db.GetConnection()
            Dim query As String = "INSERT INTO Personas (Identificacion, NombreCompleto, Correo) 
            VALUES (@Identificacion, @NombreCompleto, @Correo); SELECT SCOPE_IDENTITY()"


            Dim parameters As New Dictionary(Of String, Object) From {
              {"@Identificacion", pPersona.Identificacion},
              {"@NombreCompleto", pPersona.NombreCompleto},
              {"@Correo", pPersona.Correo}
            }

            Return Convert.ToInt32(db.ExecuteScalar(query, parameters, errorMessage))
        End Using
        Return True
    End Function
End Class
