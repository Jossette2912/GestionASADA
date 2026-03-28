Imports GestionASADA.Models
Imports GestionASADA.Utils
Imports System.Data.SqlClient


'DBHelper Se utiliza para manejar la conexión a la base de datos y ejecutar consultas SQL. 
'La clase MedidorDB contiene métodos para interactuar con la tabla de medidores en la base de datos, como crear un nuevo medidor.


Public Class MedidorDB
    Private db As New DbHelper()
    'crear medidor

    Public Function CrearMedidor(ByVal pMedidor As Models.Medidor, ByRef errorMessage As String) As Boolean
        'logica para crear un nuevo medidor en la base de datos

        Using db.GetConnection()
            Dim query As String = "
            INSERT INTO medidor (Suscriptor, Medidor, Ubicacion, Estado) 
            VALUES (@Suscriptor, @Medidor, @Ubicacion, @Estado)"

            Dim parameters As New Dictionary(Of String, Object) From {
             {"@Suscriptor", pMedidor.Suscriptor},
             {"@Medidor", pMedidor.Medidor},
            {"@Ubicacion", pMedidor.Ubicacion},
            {"@Estado", pMedidor.Estado}
            }

            Return db.ExecuteNonQuery(query, parameters, errorMessage)

        End Using
        Return True
    End Function

    Public Function eliminarMedidor(ByVal Medidor As Integer, ByRef errorMessage As String) As Boolean

        Dim query As String = "DELETE FROM medidor WHERE Medidor = @Medidor"
        Dim parameters As New Dictionary(Of String, Object) From {
                {"@Medidor", Medidor}
            }
        Return db.ExecuteNonQuery(query, parameters, errorMessage)
    End Function

End Class
