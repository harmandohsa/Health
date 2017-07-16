<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="Wfrm_Inicio.aspx.cs" Inherits="Health.WebForms.Wfrm_Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content container">
        
        <h2 class="page-title"><%--<asp:Label runat="server" ID="LblTitulo"></asp:Label>--%></h2>
        <div class="row">
            <div class="col-md-12">
                <section class="widget">
                    <%--<header>
                        <h4><i class="fa fa-user"></i><small>  </small></h4>
                    </header>--%>
                    <div class="body">
                        <fieldset class="mt-sm">
                            <legend><asp:Label runat="server" Text="Dashboard" ID="LblSubTitulo"></asp:Label></legend>
                        </fieldset>
                        <div class="row">
                            <div class="col-lg-10">
                                <section class="widget" runat="server" id="DashUno">
                                    <header>
                                        <h4>
                                            <asp:Label runat="server" ID="lblTitDash1"></asp:Label>
                                        </h4>
                                        <div class="widget-controls">
                                            <a data-widgster="expand" runat="server" id="wExpand" title="Expand" href="#"><i class="glyphicon glyphicon-chevron-up"></i></a>
                                            <a data-widgster="collapse" runat="server" id="wCollapse" title="Collapse" href="#"><i class="glyphicon glyphicon-chevron-down"></i></a>
                                            <a data-widgster="close" title="Close" runat="server" id="wClose" href="#"><i class="glyphicon glyphicon-remove"></i></a>
                                        </div>
                                    </header>
                                    <div style="padding-bottom:1em;"></div>
                                    <div class="body no-margin">
                                        <a runat="server" id="BgClinica" class="badge1"><asp:ImageButton PostBackUrl="~/WebForms/Wfrm_Clinica.aspx" runat="server" ID="ImgClinica" ImageUrl="~/Imagenes/hospital.png" /></a>
                                        <asp:Label runat="server" Text="***" ForeColor="Transparent"></asp:Label>
                                        <a runat="server" id="BgDoctor" class="badge1"><asp:ImageButton runat="server" ID="ImgDoctor" ImageUrl="~/Imagenes/doctor.png" /></a>
                                        <asp:Label runat="server" Text="***" ForeColor="Transparent"></asp:Label>
                                        <a runat="server" id="BgUsuarios" class="badge2"><asp:ImageButton PostBackUrl="~/WebForms/Wfrm_Usuarios.aspx" runat="server" ID="ImgUsuario" ImageUrl="~/Imagenes/empleado.png" /></a>
                                        <asp:Label runat="server" Text="***" ForeColor="Transparent"></asp:Label>
                                        <a runat="server" id="BgPaciente" class="badge2"><asp:ImageButton runat="server" ID="ImgPaciente" ImageUrl="~/Imagenes/paciente.png" /></a>
                                        <asp:Label runat="server" Text="***" ForeColor="Transparent"></asp:Label>
                                        <a runat="server" id="BgCita" class="badge2"><asp:ImageButton runat="server" ID="ImgCita" ImageUrl="~/Imagenes/cita.png" /></a>
                                    </div>
                                </section>
                                <section class="widget" runat="server" id="DashPaciente" visible="false">
                                    <header>
                                        <h4>
                                            <asp:Label runat="server" ID="LblTitPaciente"></asp:Label>
                                        </h4>
                                        <div class="widget-controls">
                                            <a data-widgster="expand" runat="server" id="wExpandp" title="Expand" href="#"><i class="glyphicon glyphicon-chevron-up"></i></a>
                                            <a data-widgster="collapse" runat="server" id="wCollapsep" title="Collapse" href="#"><i class="glyphicon glyphicon-chevron-down"></i></a>
                                            <a data-widgster="close" title="Close" runat="server" id="wClosep" href="#"><i class="glyphicon glyphicon-remove"></i></a>
                                        </div>
                                    </header>
                                    <div style="padding-bottom:1em;"></div>
                                    <div class="body no-margin">
                                        <a runat="server" id="A1" class="badge1"><asp:ImageButton PostBackUrl="~/WebForms/Wfrm_NuevaCita.aspx"  runat="server" ID="ImgCitaPaciente" ImageUrl="~/Imagenes/date.png" /></a>
                                        <asp:Label runat="server" Text="***" ForeColor="Transparent"></asp:Label>
                                    </div>
                                </section>
                            </div>
                        </div>
                    </div>
                </section>
                </div>
            </div>
        </div>
       
</asp:Content>
