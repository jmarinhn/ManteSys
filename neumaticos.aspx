﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="neumaticos.aspx.cs" Inherits="mantenimiento1.neumaticos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <meta charset="utf-8">
    <meta content="width=device-width, initial-scale=1.0" name="viewport">

    <title>Examen Final de Desarrollo de Aplicaciones</title>
    <meta content="Examen Final de Desarrollo de Aplicaciones" name="description">
    <link href="assets/img/favicon.png" rel="icon">
    <link href="assets/img/apple-touch-icon.png" rel="apple-touch-icon">
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i|Raleway:300,300i,400,400i,500,500i,600,600i,700,700i|Poppins:300,300i,400,400i,500,500i,600,600i,700,700i" rel="stylesheet">
    <link href="assets/vendor/aos/aos.css" rel="stylesheet">
    <link href="assets/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <link href="assets/vendor/bootstrap-icons/bootstrap-icons.css" rel="stylesheet">
    <link href="assets/vendor/boxicons/css/boxicons.min.css" rel="stylesheet">
    <link href="assets/vendor/glightbox/css/glightbox.min.css" rel="stylesheet">
    <link href="assets/vendor/remixicon/remixicon.css" rel="stylesheet">
    <link href="assets/vendor/swiper/swiper-bundle.min.css" rel="stylesheet">
    <link href="assets/css/style.css" rel="stylesheet">
</head>
<body>
        <!-- ======= Header ======= -->
    <header id="header" class="fixed-top">
        <div class="container d-flex align-items-center justify-content-between">

            <h1 class="logo"><a href="index.html">ManteSys</a></h1>
            <!-- Uncomment below if you prefer to use an image logo -->
            <!-- <a href="index.html" class="logo"><img src="assets/img/logo.png" alt="" class="img-fluid"></a>-->

            <nav id="navbar" class="navbar">
                <ul>
                    <li><a class="nav-link scrollto active" href="#hero">Inicio</a></li>
                    <li><a class="nav-link scrollto o" href="conductores.aspx">Conductores</a></li>
                    <li><a class="nav-link scrollto" href="dentregav.aspx">Detalle Entrega</a></li>
                    <li><a class="nav-link scrollto" href="detalleconsumo.aspx">Detalle de Consumo</a></li>
                    <li><a class="nav-link scrollto" href="incidentes.aspx">Incidente</a></li>
                    <li><a class="nav-link scrollto" href="mantenimiento.aspx">Mantenimiento</a></li>
                    <li><a class="nav-link scrollto" href="neumaticos.aspx">Neumáticos</a></li>
                    <li><a class="nav-link scrollto" href="repuestos.aspx">Repuestos</a></li>
                    <li><a class="nav-link scrollto" href="salidas.aspx">Salidas</a></li>
                    <li><a class="nav-link scrollto" href="taller.aspx">Taller</a></li>
                    <li><a class="nav-link scrollto" href="vehiculos.aspx">Vehículos</a></li>
                </ul>
                <i class="bi bi-list mobile-nav-toggle"></i>
            </nav><!-- .navbar -->

        </div>
    </header><!-- End Header -->
    
    <main id="main">
        <br /> <br /> <br /> <br />  <br />  <br />
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel1" runat="server">
                <asp:Label ID="Label1" runat="server" Text="Codigo Neumatico"></asp:Label>
                &nbsp;<asp:TextBox ID="txtcodneu" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label2" runat="server" Text="Marca"></asp:Label>
                &nbsp;<asp:TextBox ID="txtmarca" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label3" runat="server" Text="Precio"></asp:Label>
                &nbsp;<asp:TextBox ID="txtprecio" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label4" runat="server" Text="Garantia"></asp:Label>
                &nbsp;<asp:RadioButton ID="rb_si" runat="server" GroupName="garantia" Text="Si" />
                <asp:RadioButton ID="rb_no" runat="server" GroupName="garantia" Text="No" />
                &nbsp;<asp:TextBox ID="txtgarantia" runat="server" Visible="False"></asp:TextBox>
                <br />
                <asp:Label ID="Label5" runat="server" Text="Duracion"></asp:Label>
                &nbsp;<asp:TextBox ID="txtduracion" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label6" runat="server" Text="Presion CONCAR"></asp:Label>
                &nbsp;<asp:TextBox ID="txtconcar" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label7" runat="server" Text="Presion SINCAR"></asp:Label>
                &nbsp;<asp:TextBox ID="txtsincar" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label8" runat="server" Text="Carga Maxima"></asp:Label>
                &nbsp;<asp:TextBox ID="txtcarga" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label9" runat="server" Text="Cantidad"></asp:Label>
                &nbsp;<asp:TextBox ID="txtcantidad" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label10" runat="server" Text="Fecha de Entrega"></asp:Label>
                &nbsp;<asp:TextBox ID="txtfechaentrega" runat="server"></asp:TextBox>
                &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Calendario" />
                <br />
                <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" Visible="False"></asp:Calendar>
                <br />
                <asp:Label ID="Label11" runat="server" Text="ID Vehiculo"></asp:Label>
                &nbsp;<asp:TextBox ID="txtid_vehiculo" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label12" runat="server" Text="Usuario"></asp:Label>
                &nbsp;<asp:TextBox ID="txtusuario" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label13" runat="server" Text="Fecha"></asp:Label>
                &nbsp;<asp:TextBox ID="txtfecha" runat="server"></asp:TextBox>
                &nbsp;<asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Calendario" />
                <br />
                <asp:Calendar ID="Calendar2" runat="server" OnSelectionChanged="Calendar2_SelectionChanged" Visible="False"></asp:Calendar>
                <br />
                <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Guardad" />
                &nbsp;<asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Refrescar" />
                &nbsp;<asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Actualizar" />
                &nbsp;<asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Eliminar" />
                <br />
                <asp:Label ID="Label14" runat="server" Text="Buscar Codigo"></asp:Label>
                &nbsp;<asp:TextBox ID="txtbuscar" runat="server"></asp:TextBox>
                &nbsp;<asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="Buscar" />
                <br />
                <asp:GridView ID="tabla" runat="server" Width="662px">
                </asp:GridView>
            </asp:Panel>
        </div>
    </form>


       

        <div class="container d-md-flex py-4">

            <div class="me-md-auto text-center text-md-start">
                <div class="copyright">
                    &copy; Copyright <strong><span>Grupo #3</span></strong>. Todos los derechos reservados
                </div>
                <div class="credits">
                    Por Guillermo Núñez, Josué Marín y Jeffrey Herrera.
                </div>
            </div>
        </div>
    </footer><!-- End Footer -->

    <div id="preloader"></div>
    <a href="#" class="back-to-top d-flex align-items-center justify-content-center"><i class="bi bi-arrow-up-short"></i></a>

    <!-- Vendor JS Files -->
    <script src="assets/vendor/aos/aos.js"></script>
    <script src="assets/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
    <script src="assets/vendor/glightbox/js/glightbox.min.js"></script>
    <script src="assets/vendor/isotope-layout/isotope.pkgd.min.js"></script>
    <script src="assets/vendor/php-email-form/validate.js"></script>
    <script src="assets/vendor/purecounter/purecounter.js"></script>
    <script src="assets/vendor/swiper/swiper-bundle.min.js"></script>

    <!-- Template Main JS File -->
    <script src="assets/js/main.js"></script>

</body>

</html>
