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
End Class
