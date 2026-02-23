Imports System.Data.SqlClient
Public Class DbHelper
    'El nombre de la conexión se obtiene del archivo Web.config, específicamente de la sección <connectionStrings>. 
    '    Asegúrate de que el nombre "ASADAConnectionString" coincida con el nombre definido en tu archivo Web.config.
    Private connectionString As String = ConfigurationManager.ConnectionStrings("ASADAConnectionString").ConnectionString

    Public Function GetConnection() As SqlConnection
        Dim conn As New SqlConnection(connectionString)
        Try
            conn.Open()
        Catch ex As Exception
            conn.Dispose() 'limpia la conexion
            Throw New Exception("Error al abrir la conexión: " & ex.Message)
        End Try
        Return conn
    End Function

    Public Function ExecuteNonQuery(query As String, parameters As Dictionary(Of String, Object), ByRef errorMessage As String) As Boolean

        If String.IsNullOrWhiteSpace(query) Then
            Throw New ArgumentException("La consulta no puede estar vacía")
        End If
        Using conn As SqlConnection = GetConnection()
            Using cmd As New SqlCommand(query, conn)
                If parameters IsNot Nothing Then
                    For Each p In parameters
                        cmd.Parameters.AddWithValue(p.Key, p.Value)
                    Next
                End If

                Try
                    cmd.ExecuteNonQuery()

                    Return True
                Catch ex As Exception
                    errorMessage = "Error al ejecutar la consulta: " & ex.Message
                    Return False
                End Try
            End Using
        End Using
    End Function
End Class
