<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="GestionASADA.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Login</title>

    <link href="/Content/bootstrap.min.css" rel="stylesheet" />
    <link href="/Estilos/inicio.css" rel="stylesheet" />
</head>

<body>
<form id="form1" runat="server">

    <div class="auth-wrapper">
        <div class="auth-card text-center">

            <img src="../Imagenes/logo.png" class="logo mb-2" />

            <h2>Sistema ASADA</h2>
            <p class="subtitulo">Iniciar Sesión</p>

            <asp:Label ID="lblError" runat="server" CssClass="alert alert-danger d-block" Visible="False"></asp:Label>

            <div class="mb-3">
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Usuario"></asp:TextBox>
            </div>

            <div class="mb-3">
                <asp:TextBox ID="txtPass" runat="server" CssClass="form-control" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
            </div>

            <div class="d-grid mt-3">
                <asp:Button ID="btnLogin" runat="server" Text="Ingresar"
                    CssClass="btn btn-main"
                    OnClick="btnLogin_Click" />
            </div>

            <div class="mt-3">
                <span class="texto-secundario">¿No tiene cuenta?</span>
                <a href="Registro.aspx">Registrarse</a>
            </div>

        </div>
    </div>

</form>
</body>
</html>



<%--<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="GestionASADA.Login" %>

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

    <!-- 🔥 TU CSS -->
    <link href="/Estilos/fondoGif.css" rel="stylesheet" />

    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
</head>

<body>
    <form id="form1" runat="server">

        <div class="container min-vh-100 d-flex align-items-center justify-content-center">

            <div class="login-card w-100">

                <div class="text-center mb-4">
                    <h2>Sistema ASADA</h2>
                    <p class="subtitulo">Iniciar Sesión</p>
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
                        CssClass="btn btn-login"
                        OnClick="btnLogin_Click" />
                </div>

                <div class="text-center mt-3">
                    <span class="texto-secundario">¿No tiene cuenta?</span>
                    <a href="Registro.aspx">Registrarse</a>
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
</html>--%>
