Imports System.Data.SqlClient



Public Class SuscriptorDB

    Private db As New DbHelper()
    Public Function CrearSuscriptor(ByVal sSuscriptor As Models.Suscriptor, ByRef errorMessage As String) As Boolean
        'Lógica para crear una nueva persona en la base de datos
        Using db.GetConnection()
            Dim query As String = "INSERT INTO SUSCRIPTOR (TIPO_IDENTIFICACION, IDENTIFICACION, NOMBRE, PRIMER_APELLIDO, SEGUNDO_APELLIDO,
 DIRECCION, FECHANAC, TELEFONO, CORREO, ESTADO) VALUES (@TIPO_IDENTIFICACION,@IDENTIFICACION,@NOMBRE,@PRIMER_APELLIDO,@SEGUNDO_APELLIDO,
@DIRECCION,@FECHANAC,@TELEFONO,@CORREO,@ESTADO)"

            Dim parameters As New Dictionary(Of String, Object) From {
            {"@TIPO_IDENTIFICACION", sSuscriptor.Tipodocumento},
            {"@IDENTIFICACION", sSuscriptor.NumeroDocumento},
            {"@NOMBRE", sSuscriptor.Nombre},
            {"@PRIMER_APELLIDO", sSuscriptor.Apellido1},
            {"@SEGUNDO_APELLIDO", sSuscriptor.Apellido2},
            {"@DIRECCION", sSuscriptor.Direccion},
            {"@FECHANAC", sSuscriptor.FechaNacimiento},
            {"@TELEFONO", sSuscriptor.Telefono},
            {"@CORREO", sSuscriptor.Correo},
            {"@ESTADO", sSuscriptor.Estado}
}
            Return db.ExecuteNonQuery(query, parameters, errorMessage)
        End Using
        Return True
    End Function

    Public Function EliminarSuscriptor(ByVal id As Integer, ByRef errorMessage As String) As Boolean

        Dim query As String = "DELETE FROM SUSCRIPTOR WHERE SUSCRIPTORID = @Id"
        Dim parameters As New Dictionary(Of String, Object) From {
                {"@Id", id}
            }
        Return db.ExecuteNonQuery(query, parameters, errorMessage)

    End Function
End Class
