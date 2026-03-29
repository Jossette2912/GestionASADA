Namespace Models

    Public Class Medidor
        Private _idMedidor As Integer
        Private _suscriptorId As Integer
        Private _ubicacion As String
        Private _estado As Integer


        Public Sub New()
        End Sub


        Public Property IdMedidor As Integer
            Get
                Return _idMedidor
            End Get
            Set(value As Integer)
                _idMedidor = value
            End Set
        End Property

        Public Property SuscriptorId As Integer
            Get
                Return _suscriptorId
            End Get
            Set(value As Integer)
                _suscriptorId = value
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

        Public Property Estado As Integer
            Get
                Return _estado
            End Get
            Set(value As Integer)
                _estado = value
            End Set
        End Property
    End Class




End Namespace
