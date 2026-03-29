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

        hfIdSuscriptor.Value = gvSuscriptor.DataKeys(gvSuscriptor.SelectedIndex).Value

        Dim id As Integer = Convert.ToInt32(hfIdSuscriptor.Value)

        Dim errorMessage As String = ""
        Dim suscriptor As Models.Suscriptor = db.ConsultarSuscriptor(id, errorMessage)

        If suscriptor Is Nothing Then
            SwalUtils.ShowSwalError(Me, If(errorMessage = "", "No se pudo cargar el suscriptor.", errorMessage))
            Return
        End If

        ddlTipoDocumento.SelectedValue = suscriptor.Tipodocumento
        txtNumId.Text = suscriptor.NumeroDocumento
        txtNombre.Text = suscriptor.Nombre
        txtApellido1.Text = suscriptor.Apellido1
        txtApellido2.Text = suscriptor.Apellido2
        txtDireccion.Text = suscriptor.Direccion
        txtFechaNac.Text = suscriptor.FechaNacimiento.ToString("yyyy-MM-dd")
        txtTelefono.Text = suscriptor.Telefono
        txtCorreo.Text = suscriptor.Correo
        ddlEstado.SelectedValue = suscriptor.Estado

        btnGuardar.Visible = False
        btnActualizar.Visible = True


    End Sub

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs)
        Dim suscriptor As New Models.Suscriptor()
        suscriptor.IdSuscriptor = Convert.ToInt32(hfIdSuscriptor.Value)

        If hfIdSuscriptor.Value = "" Then
            SwalUtils.ShowSwalError(Me, "ID vacío, no se puede actualizar")
            Return
        End If
        'Validar campos obligatorios 
        If txtFechaNac.Text = "" Then
            'lblResultado.Text = "Por favor, complete todos los campos obligatorios."
            Return
        End If

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


        Dim errorMessage As String = ""
        Dim resultado = db.ActualizarSuscriptor(suscriptor, errorMessage)

        If resultado Then
            SwalUtils.ShowSwal(Me, "Persona actualizada exitosamente.")
            gvSuscriptor.DataBind()
            btnGuardar.Visible = True
            btnActualizar.Visible = False
            hfIdSuscriptor.Value = ""
            LimpiarCampos()
        Else
            SwalUtils.ShowSwalError(Me, "Error: " & errorMessage)
        End If


    End Sub

    Private Sub LimpiarCampos()
        txtNumId.Text = ""
        txtNombre.Text = ""
        txtApellido1.Text = ""
        txtApellido2.Text = ""
        txtDireccion.Text = ""
        txtFechaNac.Text = ""
        txtTelefono.Text = ""
        txtCorreo.Text = ""
        ddlTipoDocumento.SelectedIndex = 0
        ddlEstado.SelectedIndex = 0

    End Sub
End Class