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

    Protected Sub btnInsertar_Click(sender As Object, e As EventArgs)
        Dim medidor As New Models.Medidor()  'objeto persona   

        If txtMedidor.Text = "" Then
            lblResultado.Text = "rellene los campos"
            Return

        End If

        medidor.Suscriptor = txtSuscriptor.Text.Trim()
        medidor.Medidor = txtMedidor.Text.Trim()
        medidor.Ubicacion = txtUbicacion.Text.Trim()
        medidor.Estado = ddlEstadoActual.SelectedItem.Value

        lblResultado.Text = medidor.Resumen()
        Dim errorMessage As String = ""
        Dim resultado = db.CrearMedidor(medidor, errorMessage)

        If resultado Then
            SwalUtils.ShowSwal(Me, "El medidor ha sido creado exitosamente.")   'Utils.SwalUtils.ShowSwal(Me, "Medidor creado", "El medidor ha sido creado exitosamente.", "success")
            gvMedidores.DataBind()
        Else
            SwalUtils.ShowSwalError(Me, errorMessage)
        End If

    End Sub

    Protected Sub gvMedidores_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)

        e.Cancel = True

        Dim Suscriptor As Integer = Convert.ToInt32(gvMedidores.DataKeys(e.RowIndex).Value)
        Dim errorMessage As String = ""
        Dim resultado = db.eliminarMedidor(Suscriptor, errorMessage)
        If resultado Then
            SwalUtils.ShowSwal(Me, "El medidor ha sido eliminado exitosamente.")
            gvMedidores.DataBind()
        Else
            SwalUtils.ShowSwalError(Me, errorMessage)
        End If
    End Sub

End Class