<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reportes.aspx.cs" Inherits="mantenimiento1.reportes" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

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
                    <li><a class="nav-link scrollto" href="#hero">Inicio</a></li>
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
                    <li><a class="nav-link scrollto active" href="vehiculos.aspx">Reporteria</a></li>
                </ul>
                <i class="bi bi-list mobile-nav-toggle"></i>
            </nav><!-- .navbar -->

        </div>
    </header><!-- End Header -->
    <form id="form1" runat="server">
         <!-- ======= Hero Section ======= -->
        <section id="hero" class="d-flex align-items-center">
            <div class="container position-relative" data-aos="fade-up" data-aos-delay="100">
                <div class="row justify-content-center">
                    <div class="col-xl-7 col-lg-9 text-center">
                        <h1>Grupo 3 Reporteria</h1>
                        <h2>Clase de Desarrollo de Aplicaciones</h2>
                    </div>
                </div>

                <div class="row icon-boxes">
                    <!--Reporte detalle consumo-->
                    <div class="col-md-6 col-lg-3 d-flex align-items-stretch mb-5 mb-lg-0" data-aos="zoom-in" data-aos-delay="200">
                        <div class="icon-box">
                            <div class="icon"><i class="ri-stack-line"></i></div>
                            <h4 class="title">
                                <asp:Button ID="btnReport1" runat="server" BackColor="#2ECC71" BorderColor="Lime" Font-Bold="True" ForeColor="White" OnClick="btnDetCon_Click" Text="Detalle Consumo" />
                            </h4>
                            <p class="description">Reporte del detalle consumo</p>
                            <CR:CrystalReportViewer ID="crDetCon" runat="server" AutoDataBind="true" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" />
                        </div>
                    </div>

                    <div class="col-md-6 col-lg-3 d-flex align-items-stretch mb-5 mb-lg-0" data-aos="zoom-in" data-aos-delay="300">
                        <div class="icon-box">
                            <div class="icon"><i class="ri-palette-line"></i></div>
                            <h4 class="title">
                                <asp:Button ID="Button2" runat="server" BackColor="#2ECC71" BorderColor="Lime" Font-Bold="True" ForeColor="White" OnClick="btnIncidents_Click" Text="Reporte Incidentes" /></h4>
                            <p class="description">Reporte de Incidentes</p>
                            <CR:CrystalReportViewer ID="crIncidents" runat="server" AutoDataBind="true" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" />
                        </div>
                    </div>

                    <div class="col-md-6 col-lg-3 d-flex align-items-stretch mb-5 mb-lg-0" data-aos="zoom-in" data-aos-delay="400">
                        <div class="icon-box">
                            <div class="icon"><i class="ri-command-line"></i></div>
                            <h4 class="title"><asp:Button ID="Button3" runat="server" BackColor="#2ECC71" BorderColor="Lime" Font-Bold="True" ForeColor="White" OnClick="btnMant_Click" Text="Reporte Mantenimientos" /></h4>
                            <p class="description">Reporte de Mantenimientos</p>
                            <CR:CrystalReportViewer ID="crMant" runat="server" AutoDataBind="true" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" />
                        </div>
                    </div>

                    <div class="col-md-6 col-lg-3 d-flex align-items-stretch mb-5 mb-lg-0" data-aos="zoom-in" data-aos-delay="500">
                        <div class="icon-box">
                            <div class="icon"><i class="ri-fingerprint-line"></i></div>
                            <h4 class="title">
                                <asp:Button ID="Button4" runat="server" BackColor="#2ECC71" BorderColor="Lime" Font-Bold="True" ForeColor="White" OnClick="btnSalida_Click" Text="Reporte Salidas" /></h4>
                            <p class="description">Reporte de Salidas</p>
                            <CR:CrystalReportViewer ID="crSalidas" runat="server" AutoDataBind="true" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" />
                        </div>
                    </div>

                </div>
            </div>
        </section>
        <!-- End Hero -->
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
