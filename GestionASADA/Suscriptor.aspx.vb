Public Class Suscriptor
    Inherits System.Web.UI.Page

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


        lblResultado.Text = suscriptor.Resumen()
        'Dim errorMessage As String = ""
        'Dim resultado = db.CrearPersona(suscriptor, errorMessage)

        'If resultado Then
        '    SwalUtils.ShowSwal(Me, "Persona creada exitosamente.")
        '    gvPersonas.DataBind()
        'Else
        '    SwalUtils.ShowSwalError(Me, errorMessage)
        'End If
    End Sub
End Class