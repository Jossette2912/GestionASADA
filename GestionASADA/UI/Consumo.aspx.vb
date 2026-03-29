Imports GestionASADA.Utils

Public Class Consumo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        Dim consumo As New Models.Consumo()
        Dim errorMessage As String = ""

        consumo.MedidorId = Convert.ToInt32(ddlMedidor.SelectedValue)
        consumo.FechaLectura = Convert.ToDateTime(txtFecha.Text)
        consumo.LecturaAnterior = Convert.ToInt32(txtAnterior.Text)
        consumo.LecturaActual = Convert.ToInt32(txtActual.Text)

        If Not consumo.CalcularConsumo(errorMessage) Then
            SwalUtils.ShowSwalError(Me, errorMessage)
            Return
        End If

        Dim db As New ConsumoDB()
        Dim resultado = db.CrearConsumo(consumo, errorMessage)

        If resultado Then
            SwalUtils.ShowSwal(Me, "Consumo guardado")
            gvConsumo.DataBind()
        Else
            SwalUtils.ShowSwalError(Me, errorMessage)
        End If

    End Sub

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs)
        Dim consumo As New Models.Consumo()
        Dim errorMessage As String = ""

        consumo.IdConsumo = Convert.ToInt32(hfIdConsumo.Value)
        consumo.MedidorId = Convert.ToInt32(ddlMedidor.SelectedValue)
        consumo.FechaLectura = Convert.ToDateTime(txtFecha.Text)
        consumo.LecturaAnterior = Convert.ToInt32(txtAnterior.Text)
        consumo.LecturaActual = Convert.ToInt32(txtActual.Text)

        If Not consumo.CalcularConsumo(errorMessage) Then
            SwalUtils.ShowSwalError(Me, errorMessage)
            Return
        End If

        Dim db As New ConsumoDB()
        Dim resultado = db.ActualizarConsumo(consumo, errorMessage)

        If resultado Then
            SwalUtils.ShowSwal(Me, "Actualizado correctamente")
            gvConsumo.DataBind()
            btnGuardar.Visible = True
            btnActualizar.Visible = False
        Else
            SwalUtils.ShowSwalError(Me, errorMessage)
        End If
    End Sub

    Protected Sub gvConsumo_SelectedIndexChanged(sender As Object, e As EventArgs)
        hfIdConsumo.Value = gvConsumo.DataKeys(gvConsumo.SelectedIndex).Value

        txtAnterior.Text = gvConsumo.SelectedRow.Cells(4).Text
        txtActual.Text = gvConsumo.SelectedRow.Cells(5).Text

        btnGuardar.Visible = False
        btnActualizar.Visible = True
    End Sub

    Protected Sub gvConsumo_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        e.Cancel = True

        Dim id As Integer = Convert.ToInt32(gvConsumo.DataKeys(e.RowIndex).Value)
        Dim errorMessage As String = ""

        Dim db As New ConsumoDB()
        Dim resultado = db.EliminarConsumo(id, errorMessage)

        If resultado Then
            SwalUtils.ShowSwal(Me, "Eliminado correctamente")
            gvConsumo.DataBind()
        Else
            SwalUtils.ShowSwalError(Me, errorMessage)
        End If
    End Sub

    Protected Sub ddlMedidor_SelectedIndexChanged(sender As Object, e As EventArgs)
        If ddlMedidor.SelectedValue = "" Then
            txtAnterior.Text = ""
            Return
        End If

        Dim medidorId As Integer = Convert.ToInt32(ddlMedidor.SelectedValue)
        Dim errorMessage As String = ""

        Dim query As String = "
        SELECT TOP 1 LECTURAACTUAL 
        FROM CONSUMO 
        WHERE MEDIDORID = @MEDIDORID 
        ORDER BY FECHALECTURA DESC"

        Dim parameters As New Dictionary(Of String, Object) From {
            {"@MEDIDORID", medidorId}
        }

        Dim dt As DataTable = (New DbHelper()).ExecuteQuery(query, parameters, errorMessage)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            txtAnterior.Text = dt.Rows(0)("LECTURAACTUAL").ToString()
        Else
            txtAnterior.Text = "0"
        End If
    End Sub
End Class