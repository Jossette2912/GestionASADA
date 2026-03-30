<%@ Page Title="Gestion de Medidor" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Medidor.aspx.vb" Inherits="GestionASADA.Medidor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-container">

        <asp:Label ID="lblTitulo" runat="server" Text="Gestión de Medidores" CssClass="titulo-principal"></asp:Label>

        <%--          https://github.com/DavidCc04/Gestion-ASADA/commits/master/                 --%>
        <div class="form-grid">
            <%--*************************   ID suscriptor    *******************************--%>

            <div class="form-group">
                <asp:Label ID="lblSuscriptor" runat="server" Text="Suscriptor"></asp:Label>

                <asp:DropDownList ID="ddlSuscriptor" runat="server"
                    CssClass="form-control"
                    DataSourceID="SqlDataSourceSuscriptor"
                    DataTextField="DESCRIPCION"
                    DataValueField="SUSCRIPTORID"
                    AppendDataBoundItems="true"
                    AutoPostBack="true">
                    <asp:ListItem Text="Seleccione un suscriptor" Value="" />

                </asp:DropDownList>

                <asp:SqlDataSource ID="SqlDataSourceSuscriptor" runat="server"
                    ConnectionString="<%$ ConnectionStrings:ASADAConnectionString %>"
                    SelectCommand="SELECT 
            SUSCRIPTORID,
            CONCAT(NOMBRE, ' ', PRIMER_APELLIDO, ' ', SEGUNDO_APELLIDO) AS DESCRIPCION
        FROM SUSCRIPTOR"></asp:SqlDataSource>
            <%--* Validacion suscriptor *--%>
<asp:RequiredFieldValidator ID="rfvsuscriptor" runat="server"
    ErrorMessage="Es necesario indicar el ID de suscriptor."
    ControlToValidate="ddlSuscriptor" Display="Dynamic" CssClass="text-danger">
</asp:RequiredFieldValidator>
            </div>

            


            <%--*************************   Ubucacion   *******************************--%>

            <div class="form-group">
                <asp:Label ID="lblUbicacion" runat="server" Text="Ubicación"></asp:Label>
                <asp:TextBox ID="txtUbicacion" runat="server" CssClass="form-control"></asp:TextBox>
                       <%--* Validacion Ubicacion *--%>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                ErrorMessage="Debe indicar la ubicacion del medidor."
                ControlToValidate="txtUbicacion" Display="Dynamic" ForeColor="Red">  
            </asp:RequiredFieldValidator>
                </div>


        </div>


        <%--*************************   Estado   *******************************--%>

        <div class="form-group">
            <asp:Label ID="lblEstado" runat="server" Text="Estado"></asp:Label>

            <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control">
                <asp:ListItem Text="Seleccione un estado" Value="" />
                <asp:ListItem Text="Activo" Value="1" />
                <asp:ListItem Text="Inactivo" Value="2" />
            </asp:DropDownList>
       <%--* Validacion Estado *--%>
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
    ErrorMessage="Es necesario indicar el estado del medidor."
    ControlToValidate="ddlEstado" InitialValue="" Display="Dynamic" CssClass="text-danger"> 
</asp:RequiredFieldValidator>
            </div>


        
        <br />
        <br />

        <%--<asp:Label ID="lblResultado" runat="server" Text="Resultado:" CssClass="control-label"></asp:Label>--%>

        <%--Agrega una linea en blanco     <hr class="my-3" />                  --%>
        <%--<br />                                          Espacio sin linea      --%>
        <hr style="border-top: 2px solid #333;" />
        <%--  Agrega una linea Gruesa--%>



        <%--  ********************************    Solo botones ******************************************** --%>


        <asp:HiddenField ID="hfIdMedidor" runat="server" />

        <asp:Button ID="btnGuardar" runat="server" Text="Guardar"
            CssClass="btn btn-primary my-2"
            OnClick="btnGuardar_Click" />

        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar"
            CssClass="btn btn-warning"
            OnClick="btnActualizar_Click"
            Visible="false" />

        <div class="table-wrapper">

            <asp:GridView ID="gvMedidor" runat="server"
                CssClass="table table-striped table-hover"
                HeaderStyle-CssClass="table-primary"
                AutoGenerateColumns="False"
                DataKeyNames="MEDIDORID"
                DataSourceID="SqlDataSourceMedidorGrid"
                OnSelectedIndexChanged="gvMedidor_SelectedIndexChanged"
                OnRowDeleting="gvMedidor_RowDeleting">

                <Columns>


                    <asp:CommandField ShowSelectButton="True"
                        ControlStyle-CssClass="btn btn-primary"
                        SelectText="<i class='bi bi-pencil'></i>" />


                    <asp:BoundField DataField="MEDIDORID" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="DESCRIPCION" HeaderText="Suscriptor" />
                    <asp:BoundField DataField="UBICACION" HeaderText="Ubicación" />
                    <asp:BoundField DataField="ESTADO" HeaderText="Estado" />


                    <asp:CommandField ShowDeleteButton="True"
                        ControlStyle-CssClass="btn btn-danger"
                        DeleteText="<i class='bi bi-trash'></i>" />

                </Columns>

            </asp:GridView>

        </div>


        <asp:SqlDataSource ID="SqlDataSource1" runat="server"
            ConnectionString="<%$ ConnectionStrings:ASADAConnectionString %>"
            SelectCommand="
                SELECT 
                    SUSCRIPTORID,
                    CONCAT(NOMBRE, ' ', PRIMER_APELLIDO, ' ', SEGUNDO_APELLIDO) AS DESCRIPCION
                FROM SUSCRIPTOR"></asp:SqlDataSource>


        <asp:SqlDataSource ID="SqlDataSourceMedidorGrid" runat="server"
            ConnectionString="<%$ ConnectionStrings:ASADAConnectionString %>"
            SelectCommand="
                SELECT 
                    M.MEDIDORID,
                    M.UBICACION,
                    M.ESTADO,
                    CONCAT(S.NOMBRE, ' ', S.PRIMER_APELLIDO, ' ', S.SEGUNDO_APELLIDO) AS DESCRIPCION
                FROM MEDIDOR M
                INNER JOIN SUSCRIPTOR S ON M.SUSCRIPTORID = S.SUSCRIPTORID"></asp:SqlDataSource>

    </div>

</asp:Content>


