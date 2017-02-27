<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Wfrm_Login.aspx.cs" Inherits="Health.Wfrm_Login" %>

<!DOCTYPE html>

<html>
<head>
    <title>Health App</title>

    <link href="css/application.css" rel="stylesheet">
    <link rel="shortcut icon" href="img/favicon.png">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">
    <meta charset="utf-8">
    <script>
        /* yeah we need this empty stylesheet here. It's cool chrome & chromium fix
           chrome fix https://code.google.com/p/chromium/issues/detail?id=167083
                      https://code.google.com/p/chromium/issues/detail?id=332189
        */
    </script>
    
</head>
<body>
    <script src="sweetalert-master/dist/sweetalert.min.js"></script>
    <link rel="stylesheet" type="text/css" href="sweetalert-master/dist/sweetalert.css" />
    <script type="text/javascript">
        function ShowPopup(titulo, message, type, textBt) {
        swal({
            title: titulo,
            text: message,
            type: type,
            confirmButtonText: textBt
        });
    };

        function ForgotPass(titulo, mensaje, errormsj) {
            swal({
                title: titulo,
                text: mensaje,
                type: "input",
                showCancelButton: true,
                closeOnConfirm: false,
                animation: "slide-from-top"
            },
            function (inputValue) {
                if (inputValue === false) {
                    return false;
                }
                if (inputValue === "") {
                    swal.showInputError(errormsj);
                    return false
                }
                else {
                    var button = document.getElementById("BtnEnviaClave");
                    var User = inputValue;
                    document.getElementById("txtUsuario").value = inputValue;
                    button.click();
                }
                document.getElementById("txtUsuario").value = '';
            });
        };

</script>

        <div class="single-widget-container">  <%--aqui se puede cambiar la posicion del cuadro de login--%>
            <section class="widget login-widget">
                <div>
                    <img src="Imagenes/LOGO.png" width="350px" height="80px" />
                </div>
                <header class="text-align-center">
                    <h4 runat="server" id="h4Titulo"></h4>
                </header>
                <div>
                    <form class="no-margin"
                           runat="server">
                        <fieldset>
                            <div class="form-search">
                                <asp:ImageButton runat="server" ID="ImgEsp" Width="50px" Height="50px" ImageUrl="~/Imagenes/SpainFlag.png" />
                                <asp:ImageButton runat="server" ID="ImgEng" Width="50px" Height="50px" ImageUrl="~/Imagenes/USAFlag.png" />
                            </div>
                            <div class="form-group">
                                <label runat="server" id="LblUsuario" for="email" ></label>
                                <div class="input-group">
                                    <span class="input-group-addon">
                                        <i class="fa fa-user"></i>
                                    </span>
                                    <input id="txtUsuario" runat="server" class="form-control input-lg input-transparent">
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="password" runat="server" id="LblClave" >Clave</label>

                                <div class="input-group input-group-lg">
                                    <span class="input-group-addon">
                                        <i class="fa fa-lock"></i>
                                    </span>
                                    <input id="txtClave" runat="server" type="password" class="form-control input-lg input-transparent">
                                </div>
                            </div>
                        </fieldset>
                        <div class="form-actions">
                            <button runat="server" id="BtnIngresar" class="btn btn-block btn-lg btn-danger">
                                <span class="small-circle"><i class="fa fa-caret-right"></i></span>
                                <small>Sign In</small>
                            </button>
                            <a class="forgot" runat="server" id="LblForgot" >Forgot Username or Password?</a>
                        </div>
                        <div id="dialog" style="display: none">
                        </div>
                        <asp:Button runat="server" ID="BtnEnviaClave" OnClick="BtnEnviaClave_Click"  style="display: none;"/>
                        
                    </form>
                </div>
                <footer>
                    
                </footer>
            </section>
        </div>
    
<!-- common libraries. required for every page-->
<%--<script src="lib/jquery/dist/jquery.min.js"></script>--%>
<script src="lib/jquery-pjax/jquery.pjax.js"></script>
<script src="lib/bootstrap-sass/assets/javascripts/bootstrap.min.js"></script>
<script src="lib/widgster/widgster.js"></script>
<script src="lib/underscore/underscore.js"></script>

<!-- common application js -->
<script src="js/app.js"></script>
<script src="js/settings.js"></script>



<!-- page specific scripts -->
<script src="js/ui-dialogs.js"></script>
</body>
</html>