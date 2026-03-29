Imports System.Data.SqlClient
Public Class FacturaDB
    Private db As New DbHelper()

    Public Function CrearFactura(factura As Models.Factura, ByRef errorMessage As String) As Boolean

        Dim query As String = "INSERT INTO FACTURA 
        (SUSCRIPTORID, FECHA, CONSUMO, TARIFA, TOTAL, ESTADO)
        VALUES (@SUSCRIPTORID, @FECHA, @CONSUMO, @TARIFA, @TOTAL, @ESTADO)"

        Dim parameters As New Dictionary(Of String, Object) From {
            {"@SUSCRIPTORID", factura.SuscriptorId},
            {"@FECHA", factura.Fecha},
            {"@CONSUMO", factura.Consumo},
            {"@TARIFA", factura.Tarifa},
            {"@TOTAL", factura.Total},
            {"@ESTADO", factura.Estado}
        }

        Return db.ExecuteNonQuery(query, parameters, errorMessage)

    End Function


    Public Function ActualizarFactura(factura As Models.Factura, ByRef errorMessage As String) As Boolean

        Dim query As String = "UPDATE FACTURA SET 
        SUSCRIPTORID=@SUSCRIPTORID,
        FECHA=@FECHA,
        CONSUMO=@CONSUMO,
        TARIFA=@TARIFA,
        TOTAL=@TOTAL,
        ESTADO=@ESTADO
        WHERE FACTURAID=@FACTURAID"

        Dim parameters As New Dictionary(Of String, Object) From {
            {"@SUSCRIPTORID", factura.SuscriptorId},
            {"@FECHA", factura.Fecha},
            {"@CONSUMO", factura.Consumo},
            {"@TARIFA", factura.Tarifa},
            {"@TOTAL", factura.Total},
            {"@ESTADO", factura.Estado},
            {"@FACTURAID", factura.IdFactura}
        }

        Return db.ExecuteNonQuery(query, parameters, errorMessage)

    End Function

    Public Function EliminarFactura(id As Integer, ByRef errorMessage As String) As Boolean

        Dim query As String = "DELETE FROM FACTURA WHERE FACTURAID = @ID"

        Dim parameters As New Dictionary(Of String, Object) From {
            {"@ID", id}
        }

        Return db.ExecuteNonQuery(query, parameters, errorMessage)

    End Function

    Public Function ConsultarFactura(id As Integer, ByRef errorMessage As String) As Models.Factura

        Dim query As String = "SELECT * FROM FACTURA WHERE FACTURAID = @ID"

        Dim parameters As New Dictionary(Of String, Object) From {
            {"@ID", id}
        }

        Dim dt As DataTable = db.ExecuteQuery(query, parameters, errorMessage)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Dim row As DataRow = dt.Rows(0)

            Dim f As New Models.Factura() With {
                .IdFactura = Convert.ToInt32(row("FACTURAID")),
                .SuscriptorId = Convert.ToInt32(row("SUSCRIPTORID")),
                .Fecha = Convert.ToDateTime(row("FECHA")),
                .Consumo = Convert.ToInt32(row("CONSUMO")),
                .Tarifa = Convert.ToDecimal(row("TARIFA")),
                .Estado = row("ESTADO").ToString()
            }

            ' recalcula total por consistencia
            Dim err As String = ""
            f.CalcularTotal(err)

            Return f
        End If

        Return Nothing
    End Function
End Class
