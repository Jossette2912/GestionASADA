<%@ Page Title="EN CONSTRUCCIÓN" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Usuario.aspx.vb" Inherits="GestionASADA.Usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <div class="form-container">

    <h2 class="titulo-principal">Mi Información</h2>

    <div class="form-grid">

        <div class="form-group">
            <asp:Label runat="server" Text="Nombre"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label runat="server" Text="Identificación"></asp:Label>
            <asp:TextBox ID="txtIdentificacion" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label runat="server" Text="Dirección"></asp:Label>
            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label runat="server" Text="Teléfono"></asp:Label>
            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
        </div>

    </div>

    <!-- 🔑 IDENTIFICACION -->
    <asp:HiddenField ID="hfIdentificacion" runat="server" />

    <!-- 💧 CONSUMO -->
    <h3 class="mt-4">Historial de Consumo</h3>

    <asp:GridView ID="gvConsumo" runat="server"
        CssClass="table table-striped"
        AutoGenerateColumns="False"
        DataSourceID="SqlDataSourceConsumo">

        <Columns>
            <asp:BoundField DataField="FECHALECTURA" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="LECTURAANTERIOR" HeaderText="Anterior" />
            <asp:BoundField DataField="LECTURAACTUAL" HeaderText="Actual" />
            <asp:BoundField DataField="CONSUMO" HeaderText="Consumo" />
        </Columns>

    </asp:GridView>

    <!-- 💰 FACTURAS -->
    <h3 class="mt-4">Facturas</h3>

    <asp:GridView ID="gvFactura" runat="server"
        CssClass="table table-striped"
        AutoGenerateColumns="False"
        DataSourceID="SqlDataSourceFactura">

        <Columns>
            <asp:BoundField DataField="FECHA" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="CONSUMO" HeaderText="Consumo" />
            <asp:BoundField DataField="TARIFA" HeaderText="Tarifa" />
            <asp:BoundField DataField="TOTAL" HeaderText="Total" />
            <asp:BoundField DataField="ESTADO" HeaderText="Estado" />
        </Columns>

    </asp:GridView>

    <!-- 🔹 DATA SOURCES -->

    <!-- CONSUMO -->
    <asp:SqlDataSource ID="SqlDataSourceConsumo" runat="server"
        ConnectionString="<%$ ConnectionStrings:ASADAConnectionString %>"
        SelectCommand="
        SELECT C.*
        FROM CONSUMO C
        INNER JOIN MEDIDOR M ON C.MEDIDORID = M.MEDIDORID
        INNER JOIN SUSCRIPTOR S ON M.SUSCRIPTORID = S.SUSCRIPTORID
        WHERE S.IDENTIFICACION = @ID">

        <SelectParameters>
            <asp:ControlParameter Name="ID" ControlID="hfIdentificacion" PropertyName="Value" />
        </SelectParameters>

    </asp:SqlDataSource>

    <!-- FACTURA -->
    <asp:SqlDataSource ID="SqlDataSourceFactura" runat="server"
        ConnectionString="<%$ ConnectionStrings:ASADAConnectionString %>"
        SelectCommand="
        SELECT F.*
        FROM FACTURA F
        INNER JOIN SUSCRIPTOR S ON F.SUSCRIPTORID = S.SUSCRIPTORID
        WHERE S.IDENTIFICACION = @ID">

        <SelectParameters>
            <asp:ControlParameter Name="ID" ControlID="hfIdentificacion" PropertyName="Value" />
        </SelectParameters>

    </asp:SqlDataSource>

</div>
</asp:Content>
