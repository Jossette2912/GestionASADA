Namespace Models
    Public Class Factura
        Private _idFactura As Integer
        Private _suscriptorId As Integer
        Private _fecha As Date
        Private _consumo As Integer
        Private _tarifa As Decimal
        Private _total As Decimal
        Private _estado As String

        Public Property IdFactura As Integer
            Get
                Return _idFactura
            End Get
            Set(value As Integer)
                _idFactura = value
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

        Public Property Fecha As Date
            Get
                Return _fecha
            End Get
            Set(value As Date)
                _fecha = value
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

        Public Property Tarifa As Decimal
            Get
                Return _tarifa
            End Get
            Set(value As Decimal)
                _tarifa = value
            End Set
        End Property

        Public Property Total As Decimal
            Get
                Return _total
            End Get
            Set(value As Decimal)
                _total = value
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
        Public Function CalcularTotal(ByRef errorMessage As String) As Boolean
            If Consumo >= 0 AndAlso Tarifa > 0 Then
                _total = Consumo * Tarifa
                Return True
            Else
                errorMessage = "Datos inválidos para calcular el total"
                Return False
            End If
        End Function
    End Class



End Namespace

