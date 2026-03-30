Imports GestionASADA.Utils

Public Class Factura
    Inherits System.Web.UI.Page

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        Dim factura As New Models.Factura()
        Dim errorMessage As String = ""

        factura.SuscriptorId = Convert.ToInt32(ddlSuscriptor.SelectedValue)
        factura.Fecha = Convert.ToDateTime(txtFecha.Text)
        factura.Consumo = Convert.ToInt32(txtConsumo.Text)
        factura.Tarifa = Convert.ToDecimal(txtTarifa.Text)
        factura.Estado = ddlEstado.SelectedValue

        If Not factura.CalcularTotal(errorMessage) Then
            SwalUtils.ShowSwalError(Me, errorMessage)
            Return
        End If

        txtTotal.Text = factura.Total.ToString()

        Dim db As New FacturaDB()
        Dim resultado = db.CrearFactura(factura, errorMessage)

        If resultado Then
            SwalUtils.ShowSwal(Me, "Factura generada")
            gvFactura.DataBind()
            LimpiarCampos()
        Else
            SwalUtils.ShowSwalError(Me, errorMessage)
        End If
    End Sub

    Protected Sub ddlSuscriptor_SelectedIndexChanged(sender As Object, e As EventArgs)
        If ddlSuscriptor.SelectedValue = "" Then
            txtConsumo.Text = ""
            Return
        End If

        Dim suscriptorId As Integer = Convert.ToInt32(ddlSuscriptor.SelectedValue)
        Dim errorMessage As String = ""

        Dim query As String = "
        SELECT TOP 1 C.CONSUMO
        FROM CONSUMO C
        INNER JOIN MEDIDOR M ON C.MEDIDORID = M.MEDIDORID
        WHERE M.SUSCRIPTORID = @SUSCRIPTORID
        ORDER BY C.FECHALECTURA DESC"

        Dim parameters As New Dictionary(Of String, Object) From {
            {"@SUSCRIPTORID", suscriptorId}
        }

        Dim dt As DataTable = (New DbHelper()).ExecuteQuery(query, parameters, errorMessage)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            txtConsumo.Text = dt.Rows(0)("CONSUMO").ToString()
        Else
            txtConsumo.Text = "0"
        End If
    End Sub

    Protected Sub gvFactura_SelectedIndexChanged(sender As Object, e As EventArgs)
        hfIdFactura.Value = gvFactura.DataKeys(gvFactura.SelectedIndex).Value

        Dim id As Integer = Convert.ToInt32(hfIdFactura.Value)

        Dim errorMessage As String = ""
        Dim db As New FacturaDB()

        Dim factura As Models.Factura = db.ConsultarFactura(id, errorMessage)

        If factura Is Nothing Then
            SwalUtils.ShowSwalError(Me, If(errorMessage = "", "No se pudo cargar la factura.", errorMessage))
            Return
        End If

        ddlSuscriptor.SelectedValue = factura.SuscriptorId.ToString()
        txtFecha.Text = factura.Fecha.ToString("yyyy-MM-dd")
        txtConsumo.Text = factura.Consumo.ToString()
        txtTarifa.Text = factura.Tarifa.ToString()
        txtTotal.Text = factura.Total.ToString()
        ddlEstado.SelectedValue = factura.Estado

        btnGuardar.Visible = False
        btnActualizar.Visible = True

    End Sub

    Protected Sub gvFactura_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        e.Cancel = True

        Dim id As Integer = Convert.ToInt32(gvFactura.DataKeys(e.RowIndex).Value)
        Dim errorMessage As String = ""

        Dim db As New FacturaDB()
        Dim resultado = db.EliminarFactura(id, errorMessage)

        If resultado Then
            SwalUtils.ShowSwal(Me, "Factura eliminada")
            gvFactura.DataBind()
        Else
            SwalUtils.ShowSwalError(Me, errorMessage)
        End If
    End Sub



    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs)
        Dim factura As New Models.Factura()
        Dim errorMessage As String = ""

        factura.IdFactura = Convert.ToInt32(hfIdFactura.Value)
        factura.SuscriptorId = Convert.ToInt32(ddlSuscriptor.SelectedValue)
        factura.Fecha = Convert.ToDateTime(txtFecha.Text)
        factura.Consumo = Convert.ToInt32(txtConsumo.Text)
        factura.Tarifa = Convert.ToDecimal(txtTarifa.Text)
        factura.Estado = ddlEstado.SelectedValue

        If Not factura.CalcularTotal(errorMessage) Then
            SwalUtils.ShowSwalError(Me, errorMessage)
            Return
        End If

        txtTotal.Text = factura.Total.ToString()

        Dim db As New FacturaDB()
        Dim resultado = db.ActualizarFactura(factura, errorMessage)

        If resultado Then
            SwalUtils.ShowSwal(Me, "Factura actualizada")
            gvFactura.DataBind()
            btnGuardar.Visible = True
            btnActualizar.Visible = False

            LimpiarCampos()
        Else
            SwalUtils.ShowSwalError(Me, errorMessage)
        End If
    End Sub

    Private Sub LimpiarCampos()

        ddlSuscriptor.SelectedIndex = 0
        txtFecha.Text = ""
        txtConsumo.Text = ""
        txtTarifa.Text = ""
        txtTotal.Text = ""
        ddlEstado.SelectedIndex = 0
        ddlSuscriptor.SelectedIndex = 0
        hfIdFactura.Value = ""

    End Sub
End Class