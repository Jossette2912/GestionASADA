'La clase persona pertenece a Models, esto es para que no de conflicto
'con la clase persona que se encuentra en el proyecto de GestionASADA, esta clase se
'utiliza para representar a los suscriptores de las ASADA
Namespace Models
    Public Class Suscriptor
        Private _nombre As String
        Private _apellido1 As String
        Private _apellido2 As String
        Private _tipodocumento As String
        Private _numeroDocumento As String
        Private _fechaNacimiento As Date
        Private _correo As String
        Private _direccion As String
        Private _telefono As Integer
        Private _estado As String


        'Constructor Vacio
        Public Sub New()
        End Sub

        Public Sub New(nombre As String, apellido1 As String, apellido2 As String, tipodocumento As String, numeroDocumento As String, fechaNacimiento As Date, correo As String, direccion As String, telefono As Integer, estado As String)
            Me.Nombre = nombre
            Me.Apellido1 = apellido1
            Me.Apellido2 = apellido2
            Me.Tipodocumento = tipodocumento
            Me.NumeroDocumento = numeroDocumento
            Me.FechaNacimiento = fechaNacimiento
            Me.Correo = correo
            Me.Direccion = direccion
            Me.Telefono = telefono
            Me.Estado = estado
        End Sub

        Public Property Nombre As String
            Get
                Return _nombre
            End Get
            Set(value As String)
                _nombre = value
            End Set
        End Property

        Public Property Apellido1 As String
            Get
                Return _apellido1
            End Get
            Set(value As String)
                _apellido1 = value
            End Set
        End Property

        Public Property Apellido2 As String
            Get
                Return _apellido2
            End Get
            Set(value As String)
                _apellido2 = value
            End Set
        End Property

        Public Property Tipodocumento As String
            Get
                Return _tipodocumento
            End Get
            Set(value As String)
                _tipodocumento = value
            End Set
        End Property

        Public Property NumeroDocumento As String
            Get
                Return _numeroDocumento
            End Get
            Set(value As String)
                _numeroDocumento = value
            End Set
        End Property

        Public Property FechaNacimiento As Date
            Get
                Return _fechaNacimiento
            End Get
            Set(value As Date)
                _fechaNacimiento = value
            End Set
        End Property

        Public Property Correo As String
            Get
                Return _correo
            End Get
            Set(value As String)
                _correo = value
            End Set
        End Property

        Public Property Direccion As String
            Get
                Return _direccion
            End Get
            Set(value As String)
                _direccion = value
            End Set
        End Property

        Public Property Telefono As Integer
            Get
                Return _telefono
            End Get
            Set(value As Integer)
                _telefono = value
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

        'Public Function Resumen() As String
        '    Return $"Nombre: {Nombre} {Apellido1} {Apellido2} - {Correo}"
        'End Function
    End Class
End Namespace

