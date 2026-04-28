Public Class Usuario
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Session("Identificacion") Is Nothing Then
            Response.Redirect("~/UILogin/Login.aspx")
        End If

        Dim identificacion As String = Session("Identificacion").ToString()
        hfIdentificacion.Value = identificacion

        If Not IsPostBack Then
            CargarDatos(identificacion)
        End If

    End Sub

    Private Sub CargarDatos(identificacion As String)

        Dim db As New DbHelper()
        Dim errorMessage As String = ""

        Dim query As String = "SELECT * FROM SUSCRIPTOR WHERE IDENTIFICACION = @ID"

        Dim parameters As New Dictionary(Of String, Object) From {
        {"@ID", identificacion}
    }

        Dim dt As DataTable = db.ExecuteQuery(query, parameters, errorMessage)

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            Throw New Exception("NO encontró suscriptor con ID: " & identificacion)
        End If

        txtNombre.Text = dt.Rows(0)("NOMBRE").ToString()
        txtIdentificacion.Text = dt.Rows(0)("IDENTIFICACION").ToString()
        txtDireccion.Text = dt.Rows(0)("DIRECCION").ToString()
        txtTelefono.Text = dt.Rows(0)("TELEFONO").ToString()

    End Sub

End Class