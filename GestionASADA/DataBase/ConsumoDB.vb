Imports System.Data.SqlClient
Public Class ConsumoDB
    Private db As New DbHelper()
    Public Function CrearConsumo(consumo As Models.Consumo, ByRef errorMessage As String) As Boolean
        Using db.GetConnection()

            Dim query As String = "INSERT INTO CONSUMO (MEDIDORID, FECHALECTURA, LECTURAANTERIOR, LECTURAACTUAL, CONSUMO) " &
                                  "VALUES (@MEDIDORID, @FECHALECTURA, @LECTURAANTERIOR, @LECTURAACTUAL, @CONSUMO)"

            Dim parameters As New Dictionary(Of String, Object) From {
                {"@MEDIDORID", consumo.MedidorId},
                {"@FECHALECTURA", consumo.FechaLectura},
                {"@LECTURAANTERIOR", consumo.LecturaAnterior},
                {"@LECTURAACTUAL", consumo.LecturaActual},
                {"@CONSUMO", consumo.Consumo}
            }

            Return db.ExecuteNonQuery(query, parameters, errorMessage)

        End Using
    End Function


    Public Function ConsultarConsumo(id As Integer, ByRef errorMessage As String) As Models.Consumo

        Dim query As String = "SELECT * FROM CONSUMO WHERE CONSUMOID = @ID"

        Dim parameters As New Dictionary(Of String, Object) From {
            {"@ID", id}
        }

        Dim dt As DataTable = db.ExecuteQuery(query, parameters, errorMessage)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then

            Dim row As DataRow = dt.Rows(0)

            Dim consumo As New Models.Consumo()

            consumo.IdConsumo = row("CONSUMOID")
            consumo.MedidorId = row("MEDIDORID")
            consumo.FechaLectura = Convert.ToDateTime(row("FECHALECTURA"))
            consumo.LecturaAnterior = row("LECTURAANTERIOR")
            consumo.LecturaActual = row("LECTURAACTUAL")
            consumo.Consumo = row("CONSUMO")

            Return consumo
        End If

        Return Nothing
    End Function

    Public Function ActualizarConsumo(consumo As Models.Consumo, ByRef errorMessage As String) As Boolean

        Dim query As String = "UPDATE CONSUMO SET " &
                              "MEDIDORID=@MEDIDORID, " &
                              "FECHALECTURA=@FECHALECTURA, " &
                              "LECTURAANTERIOR=@LECTURAANTERIOR, " &
                              "LECTURAACTUAL=@LECTURAACTUAL, " &
                              "CONSUMO=@CONSUMO " &
                              "WHERE CONSUMOID=@CONSUMOID"

        Dim parameters As New Dictionary(Of String, Object) From {
            {"@MEDIDORID", consumo.MedidorId},
            {"@FECHALECTURA", consumo.FechaLectura},
            {"@LECTURAANTERIOR", consumo.LecturaAnterior},
            {"@LECTURAACTUAL", consumo.LecturaActual},
            {"@CONSUMO", consumo.Consumo},
            {"@CONSUMOID", consumo.IdConsumo}
        }

        Return db.ExecuteNonQuery(query, parameters, errorMessage)
    End Function

    Public Function EliminarConsumo(id As Integer, ByRef errorMessage As String) As Boolean

        Dim query As String = "DELETE FROM CONSUMO WHERE CONSUMOID = @ID"

        Dim parameters As New Dictionary(Of String, Object) From {
            {"@ID", id}
        }

        Return db.ExecuteNonQuery(query, parameters, errorMessage)
    End Function




End Class
