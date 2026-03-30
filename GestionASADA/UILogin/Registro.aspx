<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Registro.aspx.vb" Inherits="GestionASADA.Registro" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Registro de Usuario</title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <style>
        .form-floating > .form-control {
            height: 58px;
            min-height: 58px;
            padding: 1rem 0.75rem;
        }

        .form-floating > label {
            padding: 1rem 0.75rem;
        }

        .form-select {
            height: 58px;
        }
    </style>
</head>
<body class="bg-light">
    <form id="form1" runat="server">
        <div class="container min-vh-100 d-flex align-items-center justify-content-center py-4">
            <div class="card shadow-lg border-0 rounded-4 w-100" style="max-width: 500px;">

                <div class="card-header text-center text-white rounded-top-4 border-0 py-4"
                    style="background: linear-gradient(135deg, #1ECECB, #159f9c);">
                    <h2 class="mb-1 fw-bold">Registro de Usuario</h2>
                    <p class="mb-0 small">Complete la información para crear la cuenta</p>
                </div>

                <div class="card-body p-4">
                    <div class="mx-auto w-100" style="max-width: 420px;">

                        <asp:Label ID="lblError" runat="server" CssClass="alert alert-danger d-block" Visible="False"></asp:Label>

                        <div class="form-floating mb-3">
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control rounded-3" placeholder="Nombre completo"></asp:TextBox>
                            <label for="txtNombre">Nombre completo</label>
                        </div>

                        <div class="form-floating mb-3">
                            <asp:TextBox ID="txtIdentificacion" runat="server" CssClass="form-control rounded-3" placeholder="Identificación"></asp:TextBox>
                            <label for="txtIdentificacion">Identificación</label>
                        </div>

                        <div class="form-floating mb-3">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control rounded-3" TextMode="Email" placeholder="Correo electrónico"></asp:TextBox>
                            <label for="txtEmail">Correo electrónico</label>
                        </div>

                        <div class="form-floating mb-3">
                            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control rounded-3" placeholder="Nombre de usuario"></asp:TextBox>
                            <label for="txtUsername">Nombre de usuario</label>
                        </div>

                        <div class="form-floating mb-3">
                            <asp:TextBox ID="txtPass" runat="server" CssClass="form-control rounded-3" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
                            <label for="txtPass">Contraseña</label>
                        </div>

                        <div class="mb-3">
                            <label for="ddlRol" class="form-label fw-semibold">Rol</label>
                            <asp:DropDownList ID="ddlRol" runat="server" CssClass="form-select rounded-3 w-100">
                                <asp:ListItem Text="Seleccione un rol" Value="" />
                                <asp:ListItem Text="Administrador" Value="Administrador" />
                                <asp:ListItem Text="Usuario" Value="Usuario" />
                            </asp:DropDownList>
                        </div>

                        <div class="d-grid mt-4">
                            <asp:Button ID="btnRegistrar" runat="server" Text="Registrarse" OnClick="btnRegistrar_Click"
                                CssClass="btn btn-lg text-white fw-bold rounded-3"
                                Style="background-color: #E76862;" />
                        </div>
                    </div>
                </div>

                <div class="card-footer bg-white text-center border-0 pb-4">
                    <span class="text-muted">¿Ya tiene cuenta?</span>
                    <a href="Login.aspx" class="text-decoration-none fw-bold ms-1" style="color: #1ECECB;">Iniciar sesión</a>
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
