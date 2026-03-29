Imports GestionASADA.Models
Imports GestionASADA.Utils
Imports System.Data.SqlClient


'DBHelper Se utiliza para manejar la conexión a la base de datos y ejecutar consultas SQL. 
'La clase MedidorDB contiene métodos para interactuar con la tabla de medidores en la base de datos, como crear un nuevo medidor.


Public Class MedidorDB
    Private db As New DbHelper()
    'crear medidor

    Public Function CrearMedidor(medidor As Models.Medidor, ByRef errorMessage As String) As Boolean

        Dim query As String = "INSERT INTO MEDIDOR (SUSCRIPTORID, UBICACION, ESTADO) 
                              VALUES (@SUSCRIPTORID, @UBICACION, @ESTADO)"

        Dim parameters As New Dictionary(Of String, Object) From {
            {"@SUSCRIPTORID", medidor.SuscriptorId},
            {"@UBICACION", medidor.Ubicacion},
            {"@ESTADO", medidor.Estado}
        }

        Return db.ExecuteNonQuery(query, parameters, errorMessage)

    End Function


    Public Function EliminarMedidor(id As Integer, ByRef errorMessage As String) As Boolean

        Dim query As String = "DELETE FROM MEDIDOR WHERE MEDIDORID = @ID"

        Dim parameters As New Dictionary(Of String, Object) From {
            {"@ID", id}
        }

        Return db.ExecuteNonQuery(query, parameters, errorMessage)

    End Function

    Public Function ActualizarMedidor(medidor As Models.Medidor, ByRef errorMessage As String) As Boolean

        Dim query As String = "UPDATE MEDIDOR SET 
                              SUSCRIPTORID=@SUSCRIPTORID,
                              UBICACION=@UBICACION,
                              ESTADO=@ESTADO
                              WHERE MEDIDORID=@MEDIDORID"

        Dim parameters As New Dictionary(Of String, Object) From {
            {"@SUSCRIPTORID", medidor.SuscriptorId},
            {"@UBICACION", medidor.Ubicacion},
            {"@ESTADO", medidor.Estado},
            {"@MEDIDORID", medidor.IdMedidor}
        }

        Return db.ExecuteNonQuery(query, parameters, errorMessage)

    End Function

End Class