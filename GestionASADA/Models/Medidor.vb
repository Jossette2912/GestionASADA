Namespace Models

    Public Class Medidor

        Private _suscriptor As String
        Private _medidor As Integer
        Private _ubicacion As String
        Private _estado As String


        Public Sub New()
        End Sub

        Public Sub New(medidor As Integer, suscriptor As String, ubicacion As String, estado As String)

            _suscriptor = suscriptor
            _medidor = medidor
            _ubicacion = ubicacion
            _estado = estado

        End Sub

        Public Property Suscriptor As String
            Get
                Return _suscriptor
            End Get
            Set(value As String)
                _suscriptor = value
            End Set
        End Property

        Public Property Medidor As Integer
            Get
                Return _medidor
            End Get
            Set(value As Integer)
                _medidor = value
            End Set
        End Property

        Public Property Ubicacion As String
            Get
                Return _ubicacion
            End Get
            Set(value As String)
                _ubicacion = value
            End Set
        End Property

        Public Property Estado As String
            Get
                Return _estado
            End Get
            Set(value As String)
                _estado = value
            End Set
        End Property


        Public Function Resumen() As String
            Return $"Medidor: {Suscriptor} -  {Medidor} - {Ubicacion} - {Estado}"
        End Function

    End Class




End Namespace
