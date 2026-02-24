Imports GestionASADA.Utils

Public Class Suscriptor
    Inherits System.Web.UI.Page

    Private db As New SuscriptorDB()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        Dim suscriptor As New Models.Suscriptor()

        'Validar campos obligatorios 
        suscriptor.Tipodocumento = ddlTipoDocumento.SelectedItem.Value
        suscriptor.NumeroDocumento = txtNumId.Text.Trim()
        suscriptor.Nombre = txtNombre.Text.Trim()
        suscriptor.Apellido1 = txtApellido1.Text.Trim()
        suscriptor.Apellido2 = txtApellido2.Text.Trim()
        suscriptor.Direccion = txtDireccion.Text.Trim()
        suscriptor.FechaNacimiento = txtFechaNac.Text.Trim()
        suscriptor.Telefono = txtTelefono.Text.Trim()
        suscriptor.Correo = txtCorreo.Text.Trim()
        suscriptor.Estado = ddlEstado.SelectedItem.Value


        'lblResultado.Text = suscriptor.Resumen()
        Dim errorMessage As String = ""
        Dim resultado = db.CrearSuscriptor(suscriptor, errorMessage)

        If resultado Then
            SwalUtils.ShowSwal(Me, "Suscriptor creado exitosamente.")
            gvSuscriptor.DataBind() 'Actualizar el GridView para mostrar el nuevo suscriptor
        Else
            SwalUtils.ShowSwalError(Me, errorMessage)
        End If
        'End If
    End Sub


    Protected Sub gvSuscriptor_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        e.Cancel = True ' Cancelar la eliminación predeterminada del GridView
        Dim id As Integer = Convert.ToInt32(gvSuscriptor.DataKeys(e.RowIndex).Value)
        Dim errorMessage As String = ""
        Dim resultado = db.EliminarSuscriptor(id, errorMessage)
        If resultado Then
            SwalUtils.ShowSwal(Me, "Suscriptor eliminado exitosamente.")
            gvSuscriptor.DataBind() ' Refrescar el GridView después de eliminar
        Else
            SwalUtils.ShowSwalError(Me, errorMessage)
        End If
    End Sub


    Protected Sub gvSuscriptor_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim selectedRow As GridViewRow = gvSuscriptor.SelectedRow
        Dim id = selectedRow.Cells(1).Text

        Dim errorMessage As String = ""
        'Dim persona As Models.Suscriptor = db.ConsultarSuscriptor(id, errorMessage)
        ddlTipoDocumento.SelectedValue = selectedRow.Cells(2).Text
        txtNumId.Text = selectedRow.Cells(3).Text
        txtNombre.Text = HttpUtility.HtmlDecode(selectedRow.Cells(4).Text)
        txtApellido1.Text = HttpUtility.HtmlDecode(selectedRow.Cells(5).Text)
        txtApellido2.Text = HttpUtility.HtmlDecode(selectedRow.Cells(6).Text)
        txtDireccion.Text = HttpUtility.HtmlDecode(selectedRow.Cells(7).Text)
        txtFechaNac.Text = selectedRow.Cells(8).Text
        txtTelefono.Text = selectedRow.Cells(9).Text
        txtCorreo.Text = HttpUtility.HtmlDecode(selectedRow.Cells(10).Text)
        ddlEstado.SelectedValue = selectedRow.Cells(11).Text
    End Sub
End Class