Imports System.Data.SqlClient
Imports System.IO

Public Class ErrorLogger
    Private ReadOnly _connectionString As String
    Private ReadOnly _logFilePath As String = "C:\Logs\error_log.txt"

    Public Sub New(connectionString As String)
        _connectionString = connectionString
    End Sub

    ' Método principal para registrar errores
    Public Sub LogError(ex As Exception, Optional query As String = "")
        EnsureErrorLogTableExists()

        Dim fullMessage As String = $"Message: {ex.Message}" & Environment.NewLine &
                                    $"StackTrace: {ex.StackTrace}" & Environment.NewLine &
                                    $"InnerException: {If(ex.InnerException IsNot Nothing, ex.InnerException.Message, "N/A")}" & Environment.NewLine &
                                    $"Query: {query}"

        Dim severity As Integer = 16
        Dim state As Integer = 1
        Dim procedureName As String = If(ex.TargetSite IsNot Nothing, ex.TargetSite.Name, DBNull.Value.ToString())
        Dim lineNumber As Integer = 0

        If ex.StackTrace IsNot Nothing AndAlso ex.StackTrace.Contains(":line ") Then
            Integer.TryParse(ex.StackTrace.Split(New String() {":line "}, StringSplitOptions.None).Last().Split(" "c)(0), lineNumber)
        End If

        Dim logQuery As String = "
            INSERT INTO ErrorLog (ErrorMessage, ErrorSeverity, ErrorState, ErrorProcedure, ErrorLine, ErrorDateTime) 
            VALUES (@ErrorMessage, @ErrorSeverity, @ErrorState, @ErrorProcedure, @ErrorLine, GETDATE())"

        Try
            Using conn As New SqlConnection(_connectionString)
                Using cmd As New SqlCommand(logQuery, conn)
                    cmd.Parameters.AddWithValue("@ErrorMessage", fullMessage) ' ADO.NET ya escapa los caracteres, no necesitas Replace("'", "''")
                    cmd.Parameters.AddWithValue("@ErrorSeverity", severity)
                    cmd.Parameters.AddWithValue("@ErrorState", state)
                    cmd.Parameters.AddWithValue("@ErrorProcedure", procedureName)
                    cmd.Parameters.AddWithValue("@ErrorLine", lineNumber)

                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch logEx As Exception
            ' Fallback: guardar en archivo si falla el log a la base de datos
            LogErrorToFile(fullMessage & Environment.NewLine & "Log DB Error: " & logEx.Message)
        End Try
    End Sub

    Private Sub EnsureErrorLogTableExists()
        Dim query As String = "
            IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ErrorLog')
            BEGIN
                CREATE TABLE ErrorLog (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    ErrorMessage NVARCHAR(MAX), -- Cambiado a MAX por si el log es muy largo
                    ErrorSeverity INT,
                    ErrorState INT,
                    ErrorProcedure NVARCHAR(200),
                    ErrorLine INT,
                    ErrorDateTime DATETIME DEFAULT GETDATE()
                )
            END"

        Try
            Using conn As New SqlConnection(_connectionString)
                Using cmd As New SqlCommand(query, conn)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            LogErrorToFile("No se pudo asegurar la existencia de la tabla ErrorLog: " & ex.Message)
        End Try
    End Sub

    Private Sub LogErrorToFile(message As String)
        Try
            ' Asegurar que el directorio exista
            Dim dir As String = Path.GetDirectoryName(_logFilePath)
            If Not Directory.Exists(dir) Then
                Directory.CreateDirectory(dir)
            End If

            File.AppendAllText(_logFilePath, $"{DateTime.Now}: {message}{Environment.NewLine}{New String("-"c, 50)}{Environment.NewLine}")
        Catch ex As Exception
            ' Si también falla el archivo, no hay mucho más que hacer sin lanzar una excepción que rompa la app
        End Try
    End Sub
End Class
