Imports System.Data.SqlClient

Public Class SuscriptorDB

    Private db As New DbHelper()
    Public Function CrearSuscriptor(ByVal sSuscriptor As Models.Suscriptor, ByRef errorMessage As String) As Boolean
        'Lógica para crear una nueva persona en la base de datos
        Using db.GetConnection()
            Dim query As String = "INSERT INTO SUSCRIPTOR (TIPO_IDENTIFICACION, IDENTIFICACION, NOMBRE, PRIMER_APELLIDO, SEGUNDO_APELLIDO, DIRECCION, FECHANAC, TELEFONO, CORREO, ESTADO) VALUES (@TIPO_IDENTIFICACION,@IDENTIFICACION,@NOMBRE,@PRIMER_APELLIDO,@SEGUNDO_APELLIDO, @DIRECCION,@FECHANAC,@TELEFONO,@CORREO,@ESTADO)"
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

    'lógica para actualizar un suscriptor existente en la base de datos
    Public Function ConsultarSuscriptor(id As String, ByRef errorMessage As String) As Models.Suscriptor
        Dim query As String = "SELECT * FROM Suscriptor WHERE SUSCRIPTORID = @Id"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@Id", id}
        }
        Dim dt As DataTable = db.ExecuteQuery(query, parameters, errorMessage)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Dim row As DataRow = dt.Rows(0)
            Dim suscriptor As New Models.Suscriptor() With {
                .Nombre = row("NOMBRE").ToString(),
                .Apellido1 = row("PRIMER_APELLIDO").ToString(),
                .Apellido2 = row("SEGUNDO_APELLIDO").ToString(),
                .Direccion = row("DIRECCION").ToString(),
                .FechaNacimiento = Convert.ToDateTime(row("FECHANAC")),
                .Telefono = row("TELEFONO").ToString(),
                .Correo = row("CORREO").ToString(),
                .Estado = row("ESTADO").ToString(),
                .NumeroDocumento = row("IDENTIFICACION").ToString(),
                .Tipodocumento = row("TIPO_IDENTIFICACION").ToString()
            }
            Return suscriptor
        End If
        Return Nothing
    End Function

    Public Function ActualizarSuscriptor(suscriptor As Models.Suscriptor, ByRef errorMessage As String) As Boolean
        Dim query As String = "UPDATE SUSCRIPTOR SET TIPO_IDENTIFICACION=@TIPO_IDENTIFICACION, IDENTIFICACION=@IDENTIFICACION, NOMBRE=@NOMBRE, PRIMER_APELLIDO=@PRIMER_APELLIDO, SEGUNDO_APELLIDO=@SEGUNDO_APELLIDO, DIRECCION=@DIRECCION, FECHANAC=@FECHANAC, TELEFONO=@TELEFONO, CORREO=@CORREO, ESTADO=@ESTADO WHERE SUSCRIPTORID=@SUSCRIPTORID"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@TIPO_IDENTIFICACION", suscriptor.Tipodocumento},
            {"@IDENTIFICACION", suscriptor.NumeroDocumento},
            {"@NOMBRE", suscriptor.Nombre},
            {"@PRIMER_APELLIDO", suscriptor.Apellido1},
            {"@SEGUNDO_APELLIDO", suscriptor.Apellido2},
            {"@DIRECCION", suscriptor.Direccion},
            {"@FECHANAC", suscriptor.FechaNacimiento},
            {"@TELEFONO", suscriptor.Telefono},
            {"@CORREO", suscriptor.Correo},
            {"@ESTADO", suscriptor.Estado},
            {"@SUSCRIPTORID", suscriptor.IdSuscriptor}
        }
        Return db.ExecuteNonQuery(query, parameters, errorMessage)

    End Function
End Class
