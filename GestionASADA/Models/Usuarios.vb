Namespace Models
    Public Class Usuarios
        Private _IdPersona As Integer
        Private _Username As String
        Private _PasswordHash As String
        Private _Rol As String
        Private _Activo As Boolean

        Public Sub New()
        End Sub
        Public Sub New(idpersona As Integer, username As String, passwordhash As String, rol As String, activo As Boolean)
            Me.IdPersona = idpersona
            Me.Username = username
            Me.PasswordHash = passwordhash
            Me.Rol = rol
            Me.Activo = activo

        End Sub
        Public Property IdPersona As Integer
            Get
                Return _IdPersona
            End Get
            Set(value As Integer)
                _IdPersona = value
            End Set
        End Property

        Public Property Username As String
            Get
                Return _Username
            End Get
            Set(value As String)
                _Username = value
            End Set
        End Property

        Public Property PasswordHash As String
            Get
                Return _PasswordHash
            End Get
            Set(value As String)
                _PasswordHash = value
            End Set
        End Property

        Public Property Rol As String
            Get
                Return _Rol
            End Get
            Set(value As String)
                _Rol = value
            End Set
        End Property

        Public Property Activo As Boolean
            Get
                Return _Activo
            End Get
            Set(value As Boolean)
                _Activo = value
            End Set
        End Property
    End Class
End Namespace

