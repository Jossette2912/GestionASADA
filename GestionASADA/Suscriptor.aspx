<%@ Page Title="Suscriptor" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Suscriptor.aspx.vb" Inherits="GestionASADA.Suscriptor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblGestionSuscriptores" runat="server" Text="Sistema de Gestión de Suscriptores de la ASADA"></asp:Label>
    <asp:Label ID="lblDatos" runat="server" Text="Datos"></asp:Label>


    <div class="form-group">
        <asp:Label ID="lblTipoDoc" runat="server" Text="Tipo de Documento" CssClass="control-label"></asp:Label>

        <asp:DropDownList ID="ddlTipoDocumento" runat="server" CssClass="form-control">
            <asp:ListItem Text="Seleccione el tipo de documento" Value="" />
            <asp:ListItem Text="Cédula Fisica" Value="1"></asp:ListItem>
            <asp:ListItem Text="Cédula Jurídica" Value="2" />
            <asp:ListItem Text="Pasaporte" Value="3" />
        </asp:DropDownList>
    </div>

    <asp:RequiredFieldValidator ID="rfvTipoDocumento" runat="server"
        ErrorMessage="Es necesario seleccionar un tipo de documento"
        ControlToValidate="ddlTipoDocumento" Display="Dynamic"></asp:RequiredFieldValidator>

    <div class="form-group">
        <asp:Label ID="lblNumId" runat="server" Text="Número de identificación:" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="txtNumId" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
    </div>
    <asp:RequiredFieldValidator ID="rfvNumId" runat="server"
        ErrorMessage="Es necesario indicar el número de identificación"
        ControlToValidate="txtNumId" Display="Dynamic"></asp:RequiredFieldValidator>

    <div class="form-group">
        <asp:Label ID="lblNombre" runat="server" Text="Nombre:" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="txtNombre" runat="server" placeholder="Jossette" CssClass="form-control"></asp:TextBox>
    </div>
    <asp:RequiredFieldValidator ID="rfvNombre" runat="server"
        ErrorMessage="Es necesario indicar el nombre."
        ControlToValidate="txtNombre" Display="Dynamic"></asp:RequiredFieldValidator>

    <div class="form-group">
        <asp:Label ID="lblApellido1" runat="server" Text="Primer Apellido" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="txtApellido1" runat="server" placeholder="Garcia" CssClass="form-control"></asp:TextBox>
    </div>

    <asp:RequiredFieldValidator ID="rfvApellido1" runat="server"
        ErrorMessage="Es necesario indicar el primer apellido."
        ControlToValidate="txtApellido1" Display="Dynamic"></asp:RequiredFieldValidator>


    <div class="form-group">
        <asp:Label ID="lblApellido2" runat="server" Text="Segundo Apellido" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="txtApellido2" runat="server" placeholder="Garcia" CssClass="form-control"></asp:TextBox>
    </div>

    <asp:RequiredFieldValidator ID="rfvApellido2" runat="server"
        ErrorMessage="Es necesario indicar el segundo apellido"
        ControlToValidate="txtApellido2" Display="Dynamic"></asp:RequiredFieldValidator>


    <div class="form-group">
        <asp:Label ID="lblDireccion" runat="server" Text="Dirección completa:" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="txtDireccion" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
    </div>

    <asp:RequiredFieldValidator ID="rfvDireccion" runat="server"
        ErrorMessage="Es necesario indicar la dirección completa"
        ControlToValidate="txtDireccion" Display="Dynamic"></asp:RequiredFieldValidator>


    <div class="form-group">
        <asp:Label ID="lblFechaNac" runat="server" Text="Fecha Nacimiento" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="txtFechaNac" runat="server" placeholder="29/12/96" CssClass="form-control" TextMode="Date"></asp:TextBox>
    </div>

    <asp:RequiredFieldValidator ID="rfvFechaNac" runat="server"
        ErrorMessage="Es necesario indicar la fecha de nacimiento"
        ControlToValidate="txtFechaNac" Display="Dynamic"></asp:RequiredFieldValidator>

    <div class="form-group">
        <asp:Label ID="lblTelefono" runat="server" Text="Número de teléfono:" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="txtTelefono" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
    </div>
    <asp:RequiredFieldValidator ID="rfvTelefono" runat="server"
        ErrorMessage="Es necesario indicar el número de telefono."
        ControlToValidate="txtTelefono" Display="Dynamic"></asp:RequiredFieldValidator>


    <div class="form-group">
        <asp:Label ID="lblCorreo" runat="server" Text="Correo" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="txtCorreo" runat="server" placeholder="jkgarciag@edu.uc.ac.cr" CssClass="form-control"></asp:TextBox>
    </div>
    <asp:RequiredFieldValidator ID="rfvCorreo" runat="server"
        ErrorMessage="Es necesario indicar el correo"
        ControlToValidate="txtCorreo" Display="Dynamic"></asp:RequiredFieldValidator>



    <div class="form-group">
        <asp:Label ID="lblEstado" runat="server" Text="Estado:" CssClass="control-label"></asp:Label>

        <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control">
            <asp:ListItem Text="Seleccione el estado" Value="" />
            <asp:ListItem Text="Activo" Value="1"></asp:ListItem>
            <asp:ListItem Text="Inactivo" Value="2" />
        </asp:DropDownList>
    </div>

    <asp:Label ID="lblResultado" runat="server" Text="Resultado" CssClass="control-label"></asp:Label>
     <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary my-2" OnClick="btnGuardar_Click" />





</asp:Content>

