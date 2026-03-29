Namespace Models
    Public Class Consumo
        Private _idConsumo As Integer
        Private _medidorId As Integer
        Private _fechaLectura As Date
        Private _lecturaAnterior As Integer
        Private _lecturaActual As Integer
        Private _consumo As Integer

        Public Sub New()
        End Sub

        Public Sub New(medidorId As Integer, fechaLectura As Date, lecturaAnterior As Integer, lecturaActual As Integer)
            Me.MedidorId = medidorId
            Me.FechaLectura = fechaLectura
            Me.LecturaAnterior = lecturaAnterior
            Me.LecturaActual = lecturaActual
        End Sub

        Public Function CalcularConsumo(ByRef errorMessage As String) As Boolean
            If LecturaActual >= LecturaAnterior Then
                _consumo = LecturaActual - LecturaAnterior
                Return True
            Else
                errorMessage = "La lectura actual no puede ser menor que la anterior."
                Return False
            End If
        End Function

        Public Property IdConsumo As Integer
            Get
                Return _idConsumo
            End Get
            Set(value As Integer)
                _idConsumo = value
            End Set
        End Property

        Public Property MedidorId As Integer
            Get
                Return _medidorId
            End Get
            Set(value As Integer)
                _medidorId = value
            End Set
        End Property

        Public Property FechaLectura As Date
            Get
                Return _fechaLectura
            End Get
            Set(value As Date)
                _fechaLectura = value
            End Set
        End Property

        Public Property LecturaAnterior As Integer
            Get
                Return _lecturaAnterior
            End Get
            Set(value As Integer)
                _lecturaAnterior = value
            End Set
        End Property

        Public Property LecturaActual As Integer
            Get
                Return _lecturaActual
            End Get
            Set(value As Integer)
                _lecturaActual = value
            End Set
        End Property

        Public Property Consumo As Integer
            Get
                Return _consumo
            End Get
            Set(value As Integer)
                _consumo = value
            End Set
        End Property
    End Class
End Namespace


