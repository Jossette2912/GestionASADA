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
           AutoPostBack="true">
           <asp:ListItem Text="Seleccione un suscriptor" Value="" />

</asp:DropDownList>

<asp:SqlDataSource ID="SqlDataSourceSuscriptor" runat="server"
    ConnectionString="<%$ ConnectionStrings:ASADAConnectionString %>"
    SelectCommand="SELECT 
            SUSCRIPTORID,
            CONCAT(NOMBRE, ' ', PRIMER_APELLIDO, ' ', SEGUNDO_APELLIDO) AS DESCRIPCION
        FROM SUSCRIPTOR">
</asp:SqlDataSource>
    </div>

    <%--* Validacion suscriptor *--%>
    <asp:RequiredFieldValidator ID="rfvsuscriptor" runat="server"
        ErrorMessage="Es necesario indicar el ID de suscriptor."
        ControlToValidate="ddlSuscriptor" Display="Dynamic" CssClass="text-danger">
    </asp:RequiredFieldValidator>


    <%--*************************   ID Medidor    *******************************--%>
    
<%--    <div class="form-group">
        <asp:Label ID="lblMedidor" runat="server" Text="ID de Medidor" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="txtMedidor" runat="server" placeholder="0001" CssClass="form-control"></asp:TextBox>
    </div>--%>

    <%--* Validacion medidor *--%>
<%--    <asp:RequiredFieldValidator ID="rfvmedidor" runat="server"
        ErrorMessage="Es necesario indicar el ID de Medidor."
        ControlToValidate="txtMedidor" Display="Dynamic" CssClass="text-danger">
    </asp:RequiredFieldValidator>--%>
    

    <%--*************************   Ubucacion   *******************************--%>
  
    <div class="form-group">
                <asp:Label ID="lblUbicacion" runat="server" Text="Ubicación"></asp:Label>
                <asp:TextBox ID="txtUbicacion" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

        <%--* Validacion Ubicacion *--%>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
            ErrorMessage="Debe indicar la ubicacion del medidor."
            ControlToValidate="txtUbicacion" Display="Dynamic" ForeColor="Red">  
        </asp:RequiredFieldValidator> 
    </div>


    <%--*************************   Estado   *******************************--%>
  
    <div class="form-group">
                <asp:Label ID="lblEstado" runat="server" Text="Estado"></asp:Label>

                <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Activo" Value="1" />
                    <asp:ListItem Text="Inactivo" Value="2" />
                </asp:DropDownList>
            </div>

        
    <%--* Validacion Estado *--%>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
        ErrorMessage="Es necesario indicar el estado del medidor."
        ControlToValidate="ddlEstado" InitialValue=""  Display="Dynamic"  CssClass="text-danger"> 
    </asp:RequiredFieldValidator>
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

        <!-- 🔹 DataSource Suscriptor -->
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"
            ConnectionString="<%$ ConnectionStrings:ASADAConnectionString %>"
            SelectCommand="
                SELECT 
                    SUSCRIPTORID,
                    CONCAT(NOMBRE, ' ', PRIMER_APELLIDO, ' ', SEGUNDO_APELLIDO) AS DESCRIPCION
                FROM SUSCRIPTOR">
        </asp:SqlDataSource>

        <!-- 🔹 DataSource Grid -->
        <asp:SqlDataSource ID="SqlDataSourceMedidorGrid" runat="server"
            ConnectionString="<%$ ConnectionStrings:ASADAConnectionString %>"
            SelectCommand="
                SELECT 
                    M.MEDIDORID,
                    M.UBICACION,
                    M.ESTADO,
                    CONCAT(S.NOMBRE, ' ', S.PRIMER_APELLIDO, ' ', S.SEGUNDO_APELLIDO) AS DESCRIPCION
                FROM MEDIDOR M
                INNER JOIN SUSCRIPTOR S ON M.SUSCRIPTORID = S.SUSCRIPTORID">
        </asp:SqlDataSource>

    </div>

    <%--  *******************************    cuadro para los botones   ************************************** --%>



   



    <%-- <div class="card p-4" style="background-color:#8fa2bd;">
            
            <div class="row mb-3">
                <div class="col-6">
                    <asp:Button ID="Button1" runat="server" Text="CONSULTAR" CssClass="btn btn-light w-100" />
                </div>
                <div class="col-6">
                    <asp:Button ID="Button2" runat="server" Text="LIMPIAR" CssClass="btn btn-light w-100" />
                </div>
            </div>

            <div class="row mb-3">
                <div class="col-6">
                    <asp:Button ID="Button3" runat="server" Text="MODIFICAR" CssClass="btn btn-light w-100" />
                </div>
                <div class="col-6">
                    <asp:Button ID="btnEliminar" runat="server" Text="ELIMINAR" CssClass="btn btn-light w-100" />
                </div>
            </div>

            <div class="row">
                <div class="col-6">
                    <asp:Button ID="Button4" runat="server" Text="INSERTAR" CssClass="btn btn-light w-100" />
                </div>
                <div class="col-6">
                    <asp:Button ID="btnAtras" runat="server" Text="ATRAS" CssClass="btn btn-success w-100" />
                </div>
            </div>--%>


   <%-- ********************************************************************************************************************** --%>

  
    
    <%--<asp:GridView ID="gvMedidores" runat="server" AutoGenerateColumns="False" DataKeyNames="Suscriptor" DataSourceID="SqlDataSource2" OnRowDeleting="gvMedidores_RowDeleting">
        <Columns>
            <asp:BoundField DataField="Suscriptor" HeaderText="Suscriptor" ReadOnly="True" SortExpression="Suscriptor" />
            <asp:BoundField DataField="Medidor" HeaderText="Medidor" SortExpression="Medidor" />
            <asp:BoundField DataField="Ubicacion" HeaderText="Ubicacion" SortExpression="Ubicacion" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />

        </Columns>
    </asp:GridView>


    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ASADAConnectionString %>" ProviderName="<%$ ConnectionStrings:ASADAConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [Medidor]"></asp:SqlDataSource>


  

        </div>--%>
</asp:Content>


