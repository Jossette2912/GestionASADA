Namespace Models
    Public Class Factura
        Private _idFactura As Integer
        Private _suscriptorId As Integer
        Private _fecha As Date
        Private _consumo As Integer
        Private _tarifa As Decimal
        Private _total As Decimal
        Private _estado As String

        Public Sub New()
        End Sub

        Public Sub New(idFactura As Integer, suscriptorId As Integer, fecha As Date, consumo As Integer, tarifa As Decimal, total As Decimal, estado As String)
            _idFactura = idFactura
            _suscriptorId = suscriptorId
            _fecha = fecha
            _consumo = consumo
            _tarifa = tarifa
            _total = total
            _estado = estado
        End Sub

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

            Try
                If Consumo < 0 OrElse Tarifa < 0 Then
                    errorMessage = "El consumo y la tarifa deben ser valores positivos."
                    Return False
                End If

                Total = Consumo * Tarifa
                Return True

            Catch ex As Exception
                errorMessage = "Error al calcular el total: " & ex.Message
                Return False
            End Try

        End Function
    End Class
End Namespace

