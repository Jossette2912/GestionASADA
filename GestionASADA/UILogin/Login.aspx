<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="GestionASADA.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Login</title>

    <link href="/Content/bootstrap.min.css" rel="stylesheet" />
    <link href="/Estilos/Home.css" rel="stylesheet" />

    <style>
        body {
            background-color: #f4f6f9;
        }

        .login-card {
            max-width: 400px;
            margin: auto;
            padding: 30px;
            border-radius: 15px;
            background: white;
            box-shadow: 0 10px 25px rgba(0,0,0,0.1);
        }

        .login-card h2 {
            margin-bottom: 25px;
        }

        .form-control {
            border-radius: 10px;
            height: 45px;
        }

        .btn-login {
            background-color: #1ECECB;
            border: none;
            border-radius: 10px;
            height: 45px;
            font-weight: bold;
        }

        .btn-login:hover {
            background-color: #159f9c;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">

        <div class="container d-flex align-items-center justify-content-center" style="min-height: 100vh;">

            <div class="login-card">

                <h2 class="text-center">ASADA</h2>

                <asp:Label ID="lblError" runat="server" CssClass="alert alert-danger d-block" Visible="False"></asp:Label>

                <div class="mb-3">
                    <label>Usuario</label>
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <label>Contraseña</label>
                    <asp:TextBox ID="txtPass" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                </div>

                <div class="d-grid mt-3">
                    <asp:Button ID="btnLogin" runat="server" Text="Ingresar"
                        CssClass="btn btn-login" OnClick="btnLogin_Click" />
                </div>

                <div class="text-center mt-3">
                    <span>¿No tiene cuenta?</span>
                    <a href="Registro.aspx">Registrarse</a>
                </div>

            </div>

        </div>

    </form>
</body>
</html>
