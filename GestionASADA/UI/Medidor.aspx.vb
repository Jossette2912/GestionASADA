Imports GestionASADA.Utils


Public Class Medidor
    Inherits System.Web.UI.Page

    Private db As New MedidorDB()
    Private ReadOnly txtSuscripcion As Object
    Private txtEstado As Object

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnConsultar_Click(sender As Object, e As EventArgs)

    End Sub

    'Protected Sub btnInsertar_Click(sender As Object, e As EventArgs)
    '    Dim medidor As New Models.Medidor()  'objeto persona   

    '    If txtMedidor.Text = "" Then
    '        lblResultado.Text = "rellene los campos"
    '        Return

    '    End If

    '    medidor.Suscriptor = txtSuscriptor.Text.Trim()
    '    medidor.Medidor = txtMedidor.Text.Trim()
    '    medidor.Ubicacion = txtUbicacion.Text.Trim()
    '    medidor.Estado = ddlEstadoActual.SelectedItem.Value

    '    lblResultado.Text = medidor.Resumen()
    '    Dim errorMessage As String = ""
    '    Dim resultado = db.CrearMedidor(medidor, errorMessage)

    '    If resultado Then
    '        SwalUtils.ShowSwal(Me, "El medidor ha sido creado exitosamente.")   'Utils.SwalUtils.ShowSwal(Me, "Medidor creado", "El medidor ha sido creado exitosamente.", "success")
    '        gvMedidores.DataBind()
    '    Else
    '        SwalUtils.ShowSwalError(Me, errorMessage)
    '    End If

    'End Sub


    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        Dim medidor As New Models.Medidor()
        Dim errorMessage As String = ""

        If ddlSuscriptor.SelectedValue = "" Then
            SwalUtils.ShowSwalError(Me, "Seleccione un suscriptor")
            Return
        End If

        medidor.SuscriptorId = Convert.ToInt32(ddlSuscriptor.SelectedValue)
        medidor.Ubicacion = txtUbicacion.Text.Trim()
        medidor.Estado = Convert.ToInt32(ddlEstado.SelectedValue)

        Dim resultado = db.CrearMedidor(medidor, errorMessage)

        If resultado Then
            SwalUtils.ShowSwal(Me, "Medidor guardado")
            gvMedidor.DataBind()
            LimpiarCampos()
        Else
            SwalUtils.ShowSwalError(Me, errorMessage)
        End If
    End Sub

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs)
        Dim medidor As New Models.Medidor()
        Dim errorMessage As String = ""

        medidor.IdMedidor = Convert.ToInt32(hfIdMedidor.Value)
        medidor.SuscriptorId = Convert.ToInt32(ddlSuscriptor.SelectedValue)
        medidor.Ubicacion = txtUbicacion.Text.Trim()
        medidor.Estado = Convert.ToInt32(ddlEstado.SelectedValue)

        Dim resultado = db.ActualizarMedidor(medidor, errorMessage)

        If resultado Then
            SwalUtils.ShowSwal(Me, "Actualizado correctamente")
            gvMedidor.DataBind()
            btnGuardar.Visible = True
            btnActualizar.Visible = False
            LimpiarCampos()
        Else
            SwalUtils.ShowSwalError(Me, errorMessage)
        End If

    End Sub

    Protected Sub gvMedidor_SelectedIndexChanged(sender As Object, e As EventArgs)
        hfIdMedidor.Value = gvMedidor.DataKeys(gvMedidor.SelectedIndex).Value

        Dim id As Integer = Convert.ToInt32(hfIdMedidor.Value)

        Dim errorMessage As String = ""
        Dim db As New MedidorDB()

        Dim medidor As Models.Medidor = db.ConsultarMedidor(id, errorMessage)

        If medidor Is Nothing Then
            SwalUtils.ShowSwalError(Me, If(errorMessage = "", "No se pudo cargar el medidor.", errorMessage))
            Return
        End If

        ddlSuscriptor.SelectedValue = medidor.SuscriptorId.ToString()
        txtUbicacion.Text = medidor.Ubicacion
        ddlEstado.SelectedValue = medidor.Estado.ToString()

        btnGuardar.Visible = False
        btnActualizar.Visible = True


    End Sub

    Protected Sub gvMedidor_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        e.Cancel = True

        Dim id As Integer = Convert.ToInt32(gvMedidor.DataKeys(e.RowIndex).Value)
        Dim errorMessage As String = ""

        Dim db As New MedidorDB()

        If db.TieneConsumos(id) Then
            SwalUtils.ShowSwalError(Me, "No se puede eliminar este medidor porque tiene lecturas registradas.")
            Return
        End If

        Dim resultado = db.EliminarMedidor(id, errorMessage)

        If resultado Then
            SwalUtils.ShowSwal(Me, "Medidor eliminado")
            gvMedidor.DataBind()
        Else
            SwalUtils.ShowSwalError(Me, errorMessage)
        End If

    End Sub

    Private Sub LimpiarCampos()
        ddlSuscriptor.SelectedIndex = 0
        txtUbicacion.Text = ""
        ddlEstado.SelectedIndex = 0
    End Sub

End Class