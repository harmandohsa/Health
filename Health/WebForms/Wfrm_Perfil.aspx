<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="Wfrm_Perfil.aspx.cs" Inherits="Health.WebForms.Wfrm_Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:UpdatePanel runat="server" UpdateMode="Always">
    <ContentTemplate>
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
                                <legend><asp:Label runat="server" ID="LblSubTitulo"></asp:Label></legend>
                            </fieldset>
                            <fieldset>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="control-label col-sm-1" id="LblAlias" runat="server"></label>
                                        <div class="col-sm-3">
                                            <asp:DropDownList runat="server" ID="CboAlias" CssClass="select2 select-block-level"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div style="padding-bottom:1em;"></div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="control-label col-sm-1" id="LblNombres" runat="server"></label>
                                        <div class="col-sm-5"><input id="TxtNombres"  runat="server" title="" class="form-control input-transparent" ></div>
                                        <label class="control-label col-sm-1" id="LblApellidos" runat="server"></label>
                                        <div class="col-sm-5"><input id="TxtApellidos"  runat="server" title="" class="form-control input-transparent" ></div>
                                    </div>
                                </div>
                                <div style="padding-bottom:1em;"></div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="control-label col-sm-1" id="LblGenero" runat="server"></label>
                                        <div class="col-sm-5">
                                            <asp:DropDownList runat="server" ID="CboGenero" AutoPostBack="true" CssClass="select2 select-block-level"></asp:DropDownList>
                                        </div>
                                        <label class="control-label col-sm-1" id="LblId" runat="server"></label>
                                        <div class="col-sm-5"><input id="TxtIdNo"  runat="server" title="" class="form-control input-transparent" ></div>
                                    </div>
                                </div>
                                <div style="padding-bottom:1em;"></div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="control-label col-sm-1" id="LblDireccion" runat="server"></label>
                                        <div class="col-sm-11"><input id="TxtDireccion"  runat="server" title="" class="form-control input-transparent" ></div>
                                    </div>
                                </div>
                            </fieldset>
                            <div style="padding-bottom:1em;"></div>
                            <div class="row">
                                <div class="form-group">
                                    <label class="control-label col-sm-1" id="LblPais" runat="server"></label>
                                    <div class="col-sm-5">
                                        <asp:DropDownList runat="server" ID="CboPais" AutoPostBack="true" CssClass="select2 select-block-level"></asp:DropDownList>
                                    </div>
                                    <label class="control-label col-sm-1" id="LblDepartamento" runat="server"></label>
                                    <div class="col-sm-5">
                                        <asp:DropDownList runat="server" ID="CboDepartamento" AutoPostBack="true" CssClass="select2 select-block-level"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div style="padding-bottom:1em;"></div>
                            <div class="row">
                                <div class="form-group">
                                    <label class="control-label col-sm-1" id="LblMunicipio" runat="server"></label>
                                    <div class="col-sm-5">
                                        <asp:DropDownList runat="server" ID="CboMunicipio" CssClass="select2 select-block-level"></asp:DropDownList>
                                    </div>
                                    <label class="control-label col-sm-1" id="LblTelCasa" runat="server"></label>
                                    <div class="col-sm-5">
                                        <input id="TxtTelCasa"  runat="server" title="" type="number" class="form-control input-transparent" >
                                    </div>
                                </div>
                            </div>
                            <div style="padding-bottom:1em;"></div>
                            <div class="row">
                                <div class="form-group">
                                    <label class="control-label col-sm-1" id="LblTelMovil" runat="server"></label>
                                    <div class="col-sm-5">
                                        <input id="TxtTelMovil"  runat="server" title="" type="number" class="form-control input-transparent" >
                                    </div>
                                    <label class="control-label col-sm-1" id="LblUniversidad" runat="server"></label>
                                    <div class="col-sm-5">
                                        <asp:DropDownList runat="server" ID="CboUniverisidad" CssClass="select2 select-block-level"></asp:DropDownList>
                                    
                                    </div>
                                </div>
                            </div>
                            <div style="padding-bottom:1em;"></div>
                            <div class="row">
                                <div class="form-group">
                                    <label class="control-label col-sm-1" id="LblNoColegiado" runat="server"></label>
                                    <div class="col-sm-5">
                                        <input id="TxtNoCol"  runat="server" title=""  class="form-control input-transparent" >
                                    </div>
                                    <label class="control-label col-sm-1" id="LblTitulo" runat="server"></label>
                                    <div class="col-sm-5">
                                        <input id="TxtTitulo"  runat="server" title=""  class="form-control input-transparent" >
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group">
                                    <label class="control-label col-sm-1" id="LblCorreo" runat="server"></label>
                                    <div class="col-sm-5">
                                        <input id="TxtCorreo"  runat="server" title="" type="email"  class="form-control input-transparent" >
                                    </div>
                                    <label class="control-label col-sm-1" id="LblFecNac" runat="server"></label>
                                    <div class="col-sm-5">
                                        <input id="TxtFecNac"  runat="server" title="" type="date"  class="form-control input-transparent" >
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group">
                                    <label class="control-label col-sm-1" id="lblUsuario" runat="server"></label>
                                    <div class="col-sm-5">
                                        <input id="TxtUsuario"  runat="server" title=""   class="form-control input-transparent" >
                                    </div>
                                </div>
                            </div>
                            <div style="padding-bottom:1em;"></div>
                            <div class="row">
                                <div class="form-group">
                                    <label class="control-label col-sm-1" id="LblFotoPerfil" runat="server"></label>
                                    <div class="col-sm-5">
                                        <telerik:RadAsyncUpload MaxFileSize="2097152" DisableChunkUpload="true" Skin="Bootstrap"  runat="server" ID="TxtFotoPerfil" Localization-Cancel="Cancelar" Localization-Select="Buscar" Localization-Remove="Quitar" MaxFileInputsCount="1" AllowedFileExtensions=".jpg" />
                                    </div>
                                    <label class="control-label col-sm-1" id="LblFotoTitulo" runat="server"></label>
                                    <div class="col-sm-5">
                                        <telerik:RadAsyncUpload MaxFileSize="2097152" DisableChunkUpload="true" Skin="Bootstrap"  runat="server" ID="TxtFotoTitulo" Localization-Cancel="Cancelar" Localization-Select="Buscar" Localization-Remove="Quitar" MaxFileInputsCount="1" AllowedFileExtensions=".jpg" />
                                    </div>
                                </div>
                            </div>
                            <div style="padding-bottom:1em;"></div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <asp:Button runat="server" ID="BtnGrabar" data-loading-text="Grabando..." CssClass="btn btn-primary" />
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
                            <div class="row" runat="server" id="DivNoErr" visible="false">
                                <div class="col-sm-10">
                                    <div class="alert alert-success fade in">
                                        <a href="#" class="close" data-dismiss="alert">&times;</a>
                                        <asp:Label runat="server" ID="LblNoErrorMsg"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                    </div>
                </div>
            </div>
            <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                <script type="text/javascript">
                    function pageLoad() {
                            $('#<%=BtnGrabar.ClientID%>').click(function () {
                                $(this).button('loading').delay(100000).queue(function () {
                                    $(this).button('reset');
                                    $(this).dequeue();
                                    $(this).data('loading-text', 'Cargando...');
                                });
                            });
                        $('#<%=CboPais.ClientID%>').select2();
                        $('#<%=CboDepartamento.ClientID%>').select2();
                        $('#<%=CboMunicipio.ClientID%>').select2();
                        $('#<%=CboUniverisidad.ClientID%>').select2();
                        $('#<%=CboGenero.ClientID%>').select2();
                        $('#<%=CboAlias.ClientID%>').select2();
                    }
                </script>
                
            </telerik:RadCodeBlock>
            <asp:TextBox runat="server" ID="TxtCorreoOriginal" Visible="false"></asp:TextBox>
            <asp:TextBox runat="server" ID="TxtUsuarioOriginal" Visible="false"></asp:TextBox>
    </ContentTemplate>
</asp:UpdatePanel>
   
</asp:Content>
