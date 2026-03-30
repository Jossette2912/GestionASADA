<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Home.aspx.vb" Inherits="GestionASADA.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Estilos/Home.css" rel="stylesheet" />
<div class="form-container">

    <h2 class="titulo-principal text-center">
        Sistema de Gestión ASADA
    </h2>

    <div class="menu-grid">

        <a href="/UI/Suscriptor.aspx" class="menu-card">
            <div class="icon">👤</div>
            <h4>Suscriptores</h4>
            <p>Gestión de suscriptores</p>
        </a>

        <a href="/UI/Medidor.aspx" class="menu-card">
            <div class="icon">🔧</div>
            <h4>Medidores</h4>
            <p>Gestión de medidores</p>
        </a>

        <a href="/UI/Consumo.aspx" class="menu-card">
            <div class="icon">💧</div>
            <h4>Consumo</h4>
            <p>Registro de consumo</p>
        </a>

        <a href="/UI/Factura.aspx" class="menu-card">
            <div class="icon">💰</div>
            <h4>Facturación</h4>
            <p>Gestión de facturas</p>
        </a>

    </div>

</div>

</asp:Content>
