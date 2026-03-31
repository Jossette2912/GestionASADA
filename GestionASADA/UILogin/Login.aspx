<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="GestionASADA.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Iniciar Sesión</title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />

    <style>
        /* FONDO GIF */
        body {
            position: relative;
            margin: 0;
        }

        body::before {
            content: "";
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background: url('/Imagenes/luzrefractadaslow.gif') no-repeat center center;
            background-size: cover;
            z-index: -2;
        }

         🔥 CAPA OSCURA 
        body::after {
            content: "";
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background: rgba(0, 0, 0, 0.5);
            z-index: -1;
        }

        /*  TARJETA LOGIN */
        .login-card {
            background: rgba(255, 255, 255, 0.92);
            border-radius: 20px;
            padding: 30px;
            box-shadow: 0 10px 30px rgba(0,0,0,0.3);
        }

        .form-floating > .form-control {
            height: 55px;
        }

        .btn-login {
            background-color: #1ECECB;
            border: none;
            border-radius: 10px;
            font-weight: bold;
        }

        .btn-login:hover {
            background-color: #159f9c;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">

        <div class="container min-vh-100 d-flex align-items-center justify-content-center">

            <div class="login-card w-100" style="max-width: 400px;">

                <div class="text-center mb-4">
                    <h2 class="fw-bold">Sistema ASADA</h2>
                    <p class="text-muted">Iniciar Sesión</p>
                </div>

                <asp:Label ID="lblError" runat="server" CssClass="alert alert-danger d-block" Visible="False"></asp:Label>

                <div class="form-floating mb-3">
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Usuario"></asp:TextBox>
                    <label for="txtUsername">Usuario</label>
                </div>

                <div class="form-floating mb-3">
                    <asp:TextBox ID="txtPass" runat="server" CssClass="form-control" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
                    <label for="txtPass">Contraseña</label>
                </div>

                <div class="d-grid mt-3">
                    <asp:Button ID="btnLogin" runat="server" Text="Ingresar"
                        CssClass="btn btn-lg text-white btn-login"
                        OnClick="btnLogin_Click" />
                </div>

                <div class="text-center mt-3">
                    <span class="text-muted">¿No tiene cuenta?</span>
                    <a href="Registro.aspx" class="fw-bold" style="color:#1ECECB;">Registrarse</a>
                </div>

            </div>

        </div>

        <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    </form>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/jquery") %>
        <%: Scripts.Render("~/bundles/bootstrap") %>
    </asp:PlaceHolder>
</body>
</html>
