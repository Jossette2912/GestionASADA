<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Registro.aspx.vb" Inherits="GestionASADA.Registro" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Registro</title>

    <link href="/Content/bootstrap.min.css" rel="stylesheet" />
    <link href="/Estilos/Home.css" rel="stylesheet" />
    <link href="/Estilos/fondoGif.css" rel="stylesheet" />

    <style>
        body {
            background-color: #f4f6f9;
        }

        .register-card {
            max-width: 450px;
            margin: auto;
            padding: 30px;
            border-radius: 15px;
            background: white;
            box-shadow: 0 10px 25px rgba(0,0,0,0.1);
        }

        .register-card h2 {
            margin-bottom: 20px;
        }

        .form-control, .form-select {
            border-radius: 10px;
            height: 45px;
        }

        .btn-register {
            background-color: #1ECECB;
            border: none;
            border-radius: 10px;
            height: 45px;
            font-weight: bold;
        }

        .btn-register:hover {
            background-color: #159f9c;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">

        <div class="container d-flex align-items-center justify-content-center" style="min-height: 100vh;">

            <div class="register-card">

                <h2 class="text-center">Registro de Usuario</h2>

                <asp:Label ID="lblError" runat="server" CssClass="alert alert-danger d-block" Visible="False"></asp:Label>

                <div class="mb-3">
                    <label>Nombre completo</label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <label>Identificación</label>
                    <asp:TextBox ID="txtIdentificacion" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <label>Correo electrónico</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <label>Usuario</label>
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <label>Contraseña</label>
                    <asp:TextBox ID="txtPass" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <label>Rol</label>
                    <asp:DropDownList ID="ddlRol" runat="server" CssClass="form-select">
                        <asp:ListItem Text="Seleccione un rol" Value="" />
                        <asp:ListItem Text="Administrador" Value="Administrador" />
                        <asp:ListItem Text="Usuario" Value="Usuario" />
                    </asp:DropDownList>
                </div>

                <div class="d-grid mt-3">
                    <asp:Button ID="btnRegistrar" runat="server" Text="Registrarse"
                        CssClass="btn btn-register" OnClick="btnRegistrar_Click" />
                </div>

                <div class="text-center mt-3">
                    <span>¿Ya tiene cuenta?</span>
                    <a href="Login.aspx">Iniciar sesión</a>
                </div>

            </div>

        </div>

        <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>

    </form>
</body>
</html>
