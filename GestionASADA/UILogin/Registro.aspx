<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Registro.aspx.vb" Inherits="GestionASADA.Registro" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Registro</title>

    <link href="/Content/bootstrap.min.css" rel="stylesheet" />
    <link href="/Estilos/inicio.css" rel="stylesheet" />
</head>

<body>
<form id="form1" runat="server">

    <div class="auth-wrapper">
        <div class="auth-card text-center">

            <img src="../Imagenes/logo.png" class="logo mb-2" />

            <h2>Registro de Usuario</h2>

            <asp:Label ID="lblError" runat="server" CssClass="alert alert-danger d-block" Visible="False"></asp:Label>

            <div class="mb-3">
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Nombre completo"></asp:TextBox>
            </div>

            <div class="mb-3">
                <asp:TextBox ID="txtIdentificacion" runat="server" CssClass="form-control" placeholder="Identificación"></asp:TextBox>
            </div>

            <div class="mb-3">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" placeholder="Correo electrónico"></asp:TextBox>
            </div>

            <div class="mb-3">
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Usuario"></asp:TextBox>
            </div>

            <div class="mb-3">
                <asp:TextBox ID="txtPass" runat="server" CssClass="form-control" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
            </div>
            <div class="mb-3">
    <label for="ddlRol" class="form-label fw-semibold">Rol</label>
    <asp:DropDownList ID="ddlRol" runat="server" CssClass="form-select rounded-3 w-100">
        <asp:ListItem Text="Seleccione un rol" Value="" />
        <asp:ListItem Text="Administrador" Value="Administrador" />
        <asp:ListItem Text="Usuario" Value="Usuario" />
    </asp:DropDownList>
    </div>

            <div class="d-grid mt-3">
                <asp:Button ID="btnRegistrar" runat="server" Text="Registrarse"
                    CssClass="btn btn-main"
                    OnClick="btnRegistrar_Click" />
            </div>

            <div class="mt-3">
                <span class="texto-secundario">¿Ya tiene cuenta?</span>
                <a href="Login.aspx">Iniciar sesión</a>
            </div>

        </div>
    </div>

</form>
</body>
</html>


<%--<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Registro.aspx.vb" Inherits="GestionASADA.Registro" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Registro</title>

    <link href="/Content/bootstrap.min.css" rel="stylesheet" />

    <!-- 🔥 CSS DEL REGISTRO -->
    <link href="/Estilos/registro.css" rel="stylesheet" />

</head>

<body>
    <form id="form1" runat="server">

        <div class="register-wrapper">

            <div class="register-card">

<%--                <!-- 💧 LOGO -->
                <div class="text-center mb-3">
                    <img src="../Imagenes/logo.png" class="logo" />
                </div>--%>

<%--                <h2 class="text-center">Registro de Usuario</h2>

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

                <div class="d-grid mt-3">
                    <asp:Button ID="btnRegistrar" runat="server" Text="Registrarse"
                        CssClass="btn btn-register"
                        OnClick="btnRegistrar_Click" />
                </div>

                <div class="text-center mt-3">
                    <span class="texto-secundario">¿Ya tiene cuenta?</span>
                    <a href="Login.aspx">Iniciar sesión</a>
                </div>

            </div>

        </div>

        <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>

    </form>
</body>
</html>--%>--%>
