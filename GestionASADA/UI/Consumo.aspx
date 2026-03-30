<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Consumo.aspx.vb" Inherits="GestionASADA.Consumo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-container">
        <asp:Label ID="lblTitulo" runat="server" Text="Gestión de Consumo" CssClass="titulo-principal"></asp:Label>
        <div class="form-grid">
            <div class="form-group">
                <asp:Label ID="lblMedidor" runat="server" Text="Medidor"></asp:Label>
                <asp:DropDownList ID="ddlMedidor" runat="server" CssClass="form-control" DataSourceID="SqlDataSourceMedidor" DataTextField="DESCRIPCION"  AppendDataBoundItems="true"
                    DataValueField="MEDIDORID" AutoPostBack="true" OnSelectedIndexChanged="ddlMedidor_SelectedIndexChanged">
                    <asp:ListItem Text="Seleccione un medidor" Value="" />
                </asp:DropDownList>

                <asp:SqlDataSource ID="SqlDataSourceMedidor" runat="server"
                    ConnectionString="<%$ ConnectionStrings:ASADAConnectionString %>"
                    SelectCommand="SELECT * FROM VW_MEDIDOR_DESCRIPCION"></asp:SqlDataSource>
                <asp:RequiredFieldValidator ID="rfvMedidor" runat="server"
    ErrorMessage="Es necesario seleccionar un medidor"

    ControlToValidate="ddlMedidor" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <asp:Label ID="lblFecha" runat="server" Text="Fecha Lectura"></asp:Label>
                <asp:TextBox ID="txtFecha" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvFecha" runat="server"
    ErrorMessage="Es necesario seleccionar la fecha"
    ControlToValidate="txtFecha" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <asp:Label ID="lblAnterior" runat="server" Text="Lectura Anterior"></asp:Label>
                <asp:TextBox ID="txtAnterior" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblActual" runat="server" Text="Lectura Actual"></asp:Label>
                <asp:TextBox ID="txtActual" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvActual" runat="server"
    ErrorMessage="Es necesario indicar la lectura actual"
    ControlToValidate="txtActual" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>
        <asp:HiddenField ID="hfIdConsumo" runat="server" />

        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-primary" />
        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" CssClass="btn btn-warning" Visible="false" />

        <div class="table-wrapper">
            <asp:GridView ID="gvConsumo" runat="server" AutoGenerateColumns="False"
                CssClass="table table-striped table-hover"
                HeaderStyle-CssClass="table-primary"
                DataKeyNames="CONSUMOID"
                OnSelectedIndexChanged="gvConsumo_SelectedIndexChanged"
                OnRowDeleting="gvConsumo_RowDeleting" DataSourceID="SqlDataSource1">

                <Columns>
                    <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="btn btn-primary" SelectText="<i class='bi bi-pencil'>" />
                    <asp:BoundField DataField="CONSUMOID" HeaderText="CONSUMOID" InsertVisible="False" ReadOnly="True" SortExpression="CONSUMOID" />
                    <asp:BoundField DataField="MEDIDORID" HeaderText="MEDIDORID" SortExpression="MEDIDORID" />
                    <asp:BoundField DataField="FECHALECTURA" HeaderText="FECHALECTURA" SortExpression="FECHALECTURA" DataFormatString="{0:dd/MM/yyyy}"/>
                    <asp:BoundField DataField="LECTURAANTERIOR" HeaderText="LECTURAANTERIOR" SortExpression="LECTURAANTERIOR" />
                    <asp:BoundField DataField="LECTURAACTUAL" HeaderText="LECTURAACTUAL" SortExpression="LECTURAACTUAL" />
                    <asp:BoundField DataField="CONSUMO" HeaderText="CONSUMO" SortExpression="CONSUMO" />
                    <asp:CommandField ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger" DeleteText="<i class='bi bi-trash'>" />
                </Columns>

            </asp:GridView>
        </div>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ASADAConnectionString %>" SelectCommand="SELECT * FROM [CONSUMO]"></asp:SqlDataSource>

    </div>
</asp:Content>
