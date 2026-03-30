<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Factura.aspx.vb" Inherits="GestionASADA.Factura" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-container">

        <asp:Label ID="lblTitulo" runat="server" Text="Gestión de Facturas" CssClass="titulo-principal"></asp:Label>

        <div class="form-grid">

            <div class="form-group">
                <asp:Label ID="lblSuscriptor" runat="server" Text="Suscriptor"></asp:Label>



                <asp:DropDownList ID="ddlSuscriptor" runat="server"
                    CssClass="form-control"
                    DataSourceID="SqlDataSourceSuscriptor"
                    DataTextField="DESCRIPCION"
                    DataValueField="SUSCRIPTORID"
                    AutoPostBack="true"
                    AppendDataBoundItems="true"
                    OnSelectedIndexChanged="ddlSuscriptor_SelectedIndexChanged">
                    <asp:ListItem Text="Seleccione un suscriptor" Value="" />
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvSuscriptor" runat="server"
                    ErrorMessage="Es necesario seleccionar un Suscriptor"
                    ControlToValidate="ddlSuscriptor" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>


            <div class="form-group">
                <asp:Label ID="lblFecha" runat="server" Text="Fecha"></asp:Label>
                <asp:TextBox ID="txtFecha" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvFecha" runat="server"
                    ErrorMessage="Es necesario indicar la fecha."
                    ControlToValidate="txtFecha" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>


            <div class="form-group">
                <asp:Label ID="lblConsumo" runat="server" Text="Consumo"></asp:Label>
                <asp:TextBox ID="txtConsumo" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="lblTarifa" runat="server" Text="Tarifa"></asp:Label>
                <asp:TextBox ID="txtTarifa" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvTarifa" runat="server"
                    ErrorMessage="Es necesario indicar la tarifa."
                    ControlToValidate="txtFecha" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>


            <div class="form-group">
                <asp:Label ID="lblTotal" runat="server" Text="Total"></asp:Label>
                <asp:TextBox ID="txtTotal" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="lblEstado" runat="server" Text="Estado"></asp:Label>

                <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Pendiente" Value="Pendiente" />
                    <asp:ListItem Text="Pagado" Value="Pagado" />
                </asp:DropDownList>
            </div>

        </div>

        <asp:HiddenField ID="hfIdFactura" runat="server" />

        <asp:Button ID="btnGuardar" runat="server" Text="Guardar"
            CssClass="btn btn-primary my-2"
            OnClick="btnGuardar_Click" />
        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar"
            CssClass="btn btn-primary my-2"
            OnClick="btnActualizar_Click" Visible="false" />

        <div class="table-wrapper">

            <asp:GridView ID="gvFactura" runat="server"
                CssClass="table table-striped table-hover"
                HeaderStyle-CssClass="table-primary"
                AutoGenerateColumns="False"
                DataKeyNames="FACTURAID"
                DataSourceID="SqlDataSourceFactura"
                OnSelectedIndexChanged="gvFactura_SelectedIndexChanged"
                OnRowDeleting="gvFactura_RowDeleting">

                <Columns>
                    <asp:CommandField ShowSelectButton="True"
                        ControlStyle-CssClass="btn btn-primary"
                        SelectText="<i class='bi bi-pencil'></i>" />
                    <asp:BoundField DataField="FACTURAID" HeaderText="ID" />
                    <asp:BoundField DataField="DESCRIPCION" HeaderText="Suscriptor" />
                    <asp:BoundField DataField="FECHA" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="CONSUMO" HeaderText="Consumo" />
                    <asp:BoundField DataField="TARIFA" HeaderText="Tarifa" />
                    <asp:BoundField DataField="TOTAL" HeaderText="Total" />
                    <asp:BoundField DataField="ESTADO" HeaderText="Estado" />
                    <asp:CommandField ShowDeleteButton="True"
                        ControlStyle-CssClass="btn btn-danger"
                        DeleteText="<i class='bi bi-trash'></i>" />
                </Columns>

            </asp:GridView>

        </div>
        <asp:SqlDataSource ID="SqlDataSourceSuscriptor" runat="server"
            ConnectionString="<%$ ConnectionStrings:ASADAConnectionString %>"
            SelectCommand="
                SELECT 
                    SUSCRIPTORID,
                    CONCAT(NOMBRE, ' ', PRIMER_APELLIDO, ' ', SEGUNDO_APELLIDO) AS DESCRIPCION
                FROM SUSCRIPTOR"></asp:SqlDataSource>

        <asp:SqlDataSource ID="SqlDataSourceFactura" runat="server"
            ConnectionString="<%$ ConnectionStrings:ASADAConnectionString %>"
            SelectCommand="
                SELECT 
    F.FACTURAID,
    F.FECHA,
    F.CONSUMO,
    F.TARIFA,
    F.TOTAL,
    F.ESTADO,
    CONCAT(S.NOMBRE, ' ', S.PRIMER_APELLIDO, ' ', S.SEGUNDO_APELLIDO) AS DESCRIPCION
FROM FACTURA F
INNER JOIN SUSCRIPTOR S ON F.SUSCRIPTORID = S.SUSCRIPTORID"></asp:SqlDataSource>

    </div>
</asp:Content>
