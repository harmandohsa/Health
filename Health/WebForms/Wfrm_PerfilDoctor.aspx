<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SitePopUp.Master" AutoEventWireup="true" CodeBehind="Wfrm_PerfilDoctor.aspx.cs" Inherits="Health.WebForms.Wfrm_PerfilDoctor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../assets/global/plugins/bootstrap-timepicker/css/bootstrap-timepicker.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div class="content container">
            <div class="row">
            
            <div class="col-lg-12">
                <section class="widget large">
                    <div class="body">
                        <div class="row">
                            <div class="col-md-3">
                                <img runat="server" id="ImgPerfil" title="" height="250" width="250">
                            </div>
                            <div class="col-md-1">

                            </div>
                            <div class="col-md-4">
                                <h3><asp:Label runat="server" ID="LblTitulo"></asp:Label></h3>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="control-label col-sm-3" id="LblNombre" runat="server"></label>
                                        <div class="col-sm-10">
                                            <label class="control-label col-sm-10" id="LblNombreDato" style="font-weight:bold" runat="server"></label>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="control-label col-sm-3" id="LblEspecialidades" runat="server"></label>
                                        <div class="col-sm-10">
                                            <label class="control-label col-sm-10" id="LblEspecialidadesDato" style="font-weight:bold" runat="server"></label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="row">
                                    <div class="form-group">
                                        <h3><label class="control-label col-sm-8" id="lblTituloCita" runat="server"></label></h3>
                                    </div>
                                    
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="control-label col-sm-3" id="LblFecha" runat="server"></label>
                                        <div class="col-sm-7">
                                            <input id="TxtFecCita"  runat="server" title="" type="date"  class="form-control input-transparent" />

                                        </div>
                                    </div>
                                </div>
                                <div style="padding-bottom:1em;"></div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="control-label col-sm-3" id="lblHora" runat="server"></label>
                                        <div class="col-sm-7">
                                            <input id="TxtHoraCita"  runat="server" title="" type="time" class="form-control input-transparent" />
                                             <input id="TxtHoraFinal" type="text" class="form-control timepicker timepicker-no-seconds" ClientIDMode="Static" runat="server"/>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <div class="col-sm-6">
                                            <asp:Button runat="server" ID="BtnGrabar" data-loading-text="Grabando..." CssClass="btn btn-primary" />
                                        </div>
                                    </div>
                                </div>
                                <div style="padding-bottom:1em;"></div>
                                <div class="row" runat="server" id="DivErrr" visible="false">
                                    <div class="col-sm-10">
                                        <div class="alert alert-danger fade in">
                                            <a href="#" class="close" data-dismiss="alert">&times;</a>
                                            <asp:Label runat="server" ID="LblErrMsg"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>    
                    </div>
                </section>
            </div>
        </div>
    </div>
            <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                <script src="../assets/global/plugins/bootstrap-timepicker/js/bootstrap-timepicker.js" type="text/javascript"></script>
                <script src="../lib/jquery/dist/jquery.min.js"></script>
                <script type="text/javascript">
                    $(document).ready(function ($X) {
                        $X('.timepicker').timepicker({
                            format: 'HH:MM',
                            autoclose: true,
                            clearBtn: true
                        });
                    });
                </script>
                
                
            </telerik:RadCodeBlock>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
