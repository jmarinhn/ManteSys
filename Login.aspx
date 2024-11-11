<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="mantenimiento1.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href='https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css' rel="stylesheet"/>
    <link href='https://use.fontawesome.com/releases/v5.8.1/css/all.css' rel="stylesheet"/>
    <title></title>
    <style>
        body {
            margin: 0;
            padding: 0;
            font-family: sans-serif;
            background: linear-gradient(to right, #b92b27, #1565c0)
        }

        .card {
            margin-bottom: 20px;
            border: none
        }

        .box {
            width: 500px;
            padding: 40px;
            position: absolute;
            top: 50%;
            left: 50%;
            background: #191919;
            text-align: center;
            transition: 0.25s;
            margin-top: 100px;
            color:#03e9f4
        }

            .box input[type="text"],
            .box input[type="password"] {
                border: 0;
                background: none;
                display: block;
                margin: 20px auto;
                text-align: center;
                border: 2px solid #3498db;
                padding: 10px 10px;
                width: 250px;
                outline: none;
                color: white;
                border-radius: 24px;
                transition: 0.25s
            }

            .box h1 {
                color: white;
                text-transform: uppercase;
                font-weight: 500
            }

            .box input[type="text"]:focus,
            .box input[type="password"]:focus {
                width: 300px;
                border-color: #2ecc71
            }

            .box .animate {
                border: 0;
                background: none;
                display: block;
                margin: 20px auto;
                text-align: center;
                border: 2px solid #2ecc71;
                padding: 14px 40px;
                outline: none;
                color: #03e9f4;
                border-radius: 24px;
                transition: 0.25s;
                cursor: pointer
            }

                .box .animate:hover {
                    background: #2ecc71;
                    /*background: #03e9f4;*/
                    color: white;
                    border-radius: 5px;
                    box-shadow: 0 0 5px #03e9f4, 0 0 25px #03e9f4, 0 0 50px #03e9f4, 0 0 100px #03e9f4;
                }

        .box .animate span {
            position: absolute;
            display: block;
        }
            .box .animate span:nth-child(1) {
                top: 0;
                left: -100%;
                width: 100%;
                height: 2px;
                background: linear-gradient(90deg, transparent, #03e9f4);
                animation: btn-anim1 1s linear infinite;
            }

        @keyframes btn-anim1 {
            0% {
                left: -100%;
            }

            50%,100% {
                left: 100%;
            }
        }
        .box .animate span:nth-child(2) {
            top: -100%;
            right: 0;
            width: 2px;
            height: 100%;
            background: linear-gradient(180deg, transparent, #03e9f4);
            animation: btn-anim2 1s linear infinite;
            animation-delay: .25s
        }

        @keyframes btn-anim2 {
            0% {
                top: -100%;
            }

            50%,100% {
                top: 100%;
            }
        }

        .box .animate span:nth-child(3) {
            bottom: 0;
            right: -100%;
            width: 100%;
            height: 2px;
            background: linear-gradient(270deg, transparent, #03e9f4);
            animation: btn-anim3 1s linear infinite;
            animation-delay: .5s
        }

        @keyframes btn-anim3 {
            0% {
                right: -100%;
            }

            50%,100% {
                right: 100%;
            }
        }

        .box .animate span:nth-child(4) {
            bottom: -100%;
            left: 0;
            width: 2px;
            height: 100%;
            background: linear-gradient(360deg, transparent, #03e9f4);
            animation: btn-anim4 1s linear infinite;
            animation-delay: .75s
        }

        @keyframes btn-anim4 {
            0% {
                bottom: -100%;
            }

            50%,100% {
                bottom: 100%;
            }
        }

        .box .animate {
            position: relative;
            display: inline-block;
            padding: 10px 20px;
            color: #03e9f4;
            font-size: 16px;
            text-decoration: none;
            text-transform: uppercase;
            overflow: hidden;
            transition: .5s;
            margin-top: 5px;
            letter-spacing: 4px
        }

        .forgot {
            text-decoration: underline
        }

        ul.social-network {
            list-style: none;
            display: inline;
            margin-left: 0 !important;
            padding: 0
        }

            ul.social-network li {
                display: inline;
                margin: 0 5px
            }

        .social-network a.icoFacebook:hover {
            background-color: #3B5998
        }

        .social-network a.icoTwitter:hover {
            background-color: #33ccff
        }

        .social-network a.icoGoogle:hover {
            background-color: #BD3518
        }

            .social-network a.icoFacebook:hover i,
            .social-network a.icoTwitter:hover i,
            .social-network a.icoGoogle:hover i {
                color: #fff
            }

        a.socialIcon:hover,
        .socialHoverClass {
            color: #44BCDD
        }

        .social-circle li a {
            display: inline-block;
            position: relative;
            margin: 0 auto 0 auto;
            border-radius: 50%;
            text-align: center;
            width: 50px;
            height: 50px;
            font-size: 20px
        }

        .social-circle li i {
            margin: 0;
            line-height: 50px;
            text-align: center
        }

        .social-circle li a:hover i,
        .triggeredHover {
            transform: rotate(360deg);
            transition: all 0.2s
        }

        .social-circle i {
            color: #fff;
            transition: all 0.8s;
            transition: all 0.8s
        }
    </style>
</head>
<body>
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <div class="card">
                    <form id="form1" runat="server" class="box">
                        <h1>Bienvenido</h1>
                        <p class="text-muted">Por favor, ingrese su usuario y contrase&ntilde;a!</p>
                        <input type="text" name="" placeholder="Usuario" id="txtUsername" runat="server"/>
                        <input type="password" name="" placeholder="Contrase&ntilde;a" id="txtPassword" runat="server"/>
                        <div><a class="forgot text-muted" href="#">Olvido su contrase&ntilde;a?</a></div>
                        <asp:LinkButton class="animate" id="btnLogin" runat="server" onclick="btnLogin_Click">
                            <span></span>
                            <span></span>
                            <span></span>
                            <span></span>
                            Login
                            <%--<input type="submit" name="" value="Login" href="#"/>--%>
                        </asp:LinkButton>
                    </form>
                </div>
            </div>
        </div>
    </div>
     <script type="text/javascript" src='https://stackpath.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.bundle.min.js'></script>
    <script type="text/javascript" src='https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js'></script>

</body>
</html>
