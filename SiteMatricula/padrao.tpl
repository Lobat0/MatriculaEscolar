<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>AdminLTE | Dashboard</title>
        <meta content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no' name='viewport'>
        <!-- JQuery 12 -->
        <link href="../view/css/jQueryUI/jquery-ui.min.css" rel="stylesheet" type="text/css" />
        <!-- bootstrap 3.0.2 -->
        <link href="../view/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
        <!-- font Awesome -->
        <link href="../view/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
        <!-- Ionicons -->
        <link href="../view/css/ionicons.min.css" rel="stylesheet" type="text/css" /> 
        <!-- jvectormap -->
        <link href="../view/css/jvectormap/jquery-jvectormap-1.2.2.css" rel="stylesheet" type="text/css" />
        <!-- bootstrap wysihtml5 - text editor -->
        <link href="../view/css/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css" rel="stylesheet" type="text/css" />
        <!-- Theme style -->
        <link href="../view/css/AdminLTE.css" rel="stylesheet" type="text/css" />

    </head>
    <body class="skin-black">
        <header class="header">
            <a class="logo">
                Site NovaEra
            </a>
            <nav class="navbar navbar-static-top" role="navigation">
                <a href="#" class="navbar-btn sidebar-toggle" data-toggle="offcanvas" role="button">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </a>
                <div class="navbar-right">
                    <ul class="nav navbar-nav">
                        
                        
                        <li class="dropdown user user-menu">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                                <i class="glyphicon glyphicon-user"></i>
                                <span>{$smarty.session.logado.freg_nome} <i class="caret"></i></span>
                            </a>
                            <ul class="dropdown-menu">
                               
                                <li class="user-footer">
                                    <div class="pull-left">
                                        <h5>Deseja sair da sua conta?</h4>
                                        </div>
                                    <div class="pull-right">
                                        <a href="padrao.php?pag=finalizar" class="btn btn-default btn-flat">Sair</a>
                                    </div>
                                </li>
                            </ul>
                        </li>
                    </ul>
                </div>
            </nav>
        </header>
        <div class="wrapper row-offcanvas row-offcanvas-left">
            <aside class="left-side sidebar-offcanvas">
                <section class="sidebar">
                    <ul class="sidebar-menu">
                        <li class="active">
                            <a href="padrao.php">
                                <i class="fa fa-home"></i> <span>Principal</span>
                            </a>
                        </li>
                        {if !$smarty.get.idsis|default:''}
                        <li class="treeview">
                            <a href="#">
                                <i class="fa fa-list-alt"></i>
                                <span>Formularios</span>
                                <i class="fa fa-angle-left pull-right"></i>
                            </a>
                            <ul class="treeview-menu">
                                <li><a href="padrao.php?pag=seguro_vida"><i class="fa fa-angle-double-right"></i> Seguro de Vida</a></li>
                                <li><a href="padrao.php?pag=seguro_automovel"><i class="fa fa-angle-double-right"></i> Seguro de Automovel</a></li>
                                <li><a href="padrao.php?pag=seguro_residencia"><i class="fa fa-angle-double-right"></i> Seguro de Residencia</a></li>
                                <li><a href="padrao.php?pag=seguro_empresa"><i class="fa fa-angle-double-right"></i> Seguro de Empresarial</a></li>
                            </ul>
                        </li>
                        <li>
                            <a href="padrao.php?pag=fale_conosco">
                                <i class="fa fa-phone-square"></i> <span>Fale Conosco</span>
                            </a>
                        </li>
                        <li>
                            
                            <a data-toggle="modal" data-target="#myModalSenha" style="cursor: pointer;">
                                <i class="fa fa-lock"></i> <span>Mudar Senha</span>
                            </a>
                        </li>
                        {/if}
                    </ul>
                </section>
            </aside>
            <aside class="right-side">
                
                <section class="content">
                       
                    {include file = $content }
                                    
                </section>
            </aside>
        </div>   
        
        <div id="myModalSenha" class="modal fade" role="dialog">
            <div class="modal-dialog">

                <div class="modal-content">
                    <form id="formMudarSenha" name="formMudarSenha" action="padrao.php?pag=upSenha" method="post">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Alterar Senha</h4>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                                <label for="senha">Senha</label>
                                <input id='senha' name="senha" type="password" class="form-control" placeholder="Senha">
                            </div>
                            <div class="form-group">
                                <label for="csenha">Confirmar Senha</label>
                                <input id='csenha' name="csenha" type="password" class="form-control" placeholder="Confirmar Senha">
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="submit" class="btn btn-primary" id="btnMudarSenha" >Salvar</button>
                            <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>
                        </div>
                    </form>
                </div>

            </div>
        </div>

        <!-- jQuery 2.0.2 -->
        <script src="http://ajax.googleapis.com/ajax/libs/jquery/2.0.2/jquery.min.js"></script>
        <!-- jQuery UI 1.10.3 -->
        <script src="../view/css/jQueryUI/jquery-ui.min.js" type="text/javascript"></script>
        <!-- Bootstrap -->
        <script src="../view/js/bootstrap.min.js" type="text/javascript"></script>      
        <!-- InputMask -->
        <script src="../view/js/plugins/input-mask/jquery.inputmask.js" type="text/javascript"></script>
        <script src="../view/js/plugins/input-mask/jquery.inputmask.date.extensions.js" type="text/javascript"></script>
        <script src="../view/js/plugins/input-mask/jquery.inputmask.extensions.js" type="text/javascript"></script>
        <!--Scripts-->
        <script src="../view/js/padrao.js" type="text/javascript"></script>  
        <script src="../view/js/plugins/jquery.maskmoney/dist/jquery.maskMoney.js" type="text/javascript"></script>
        <!-- Sparkline -->
        <script src="../view/js/plugins/sparkline/jquery.sparkline.min.js" type="text/javascript"></script>
        <!-- jvectormap -->
        <script src="../view/js/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js" type="text/javascript"></script>
        <script src="../view/js/plugins/jvectormap/jquery-jvectormap-world-mill-en.js" type="text/javascript"></script>
        <!-- fullCalendar -->
        <script src="../view/js/plugins/fullcalendar/fullcalendar.min.js" type="text/javascript"></script>
        <!-- jQuery Knob Chart -->
        <script src="../view/js/plugins/jqueryKnob/jquery.knob.js" type="text/javascript"></script>
        <!-- daterangepicker -->
        <script src="../view/js/plugins/daterangepicker/daterangepicker.js" type="text/javascript"></script>
        <!-- Bootstrap WYSIHTML5 -->
        <script src="../view/js/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js" type="text/javascript"></script>
        <!-- iCheck -->
        <script src="../view/js/plugins/iCheck/icheck.min.js" type="text/javascript"></script>    
        <!-- AdminLTE App -->
        <script src="../view/js/AdminLTE/app.js" type="text/javascript"></script>   
        
    </body>
</html>