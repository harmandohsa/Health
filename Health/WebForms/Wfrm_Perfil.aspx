<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="Wfrm_Perfil.aspx.cs" Inherits="Health.WebForms.Wfrm_Perfil" %>
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
                                    <input id="TxtFotoPerfil"  runat="server" title="" type="file"  class="form-control input-transparent" >
                                </div>
                                <label class="control-label col-sm-1" id="LblFotoTitulo" runat="server"></label>
                                <div class="col-sm-5">
                                    <input id="TxtFotoTitulo"  runat="server" title="" type="file" class="form-control input-transparent" >
                                </div>
                            </div>
                        </div>
                        <div style="padding-bottom:1em;"></div>
                        <div class="row">
                            <div class="col-sm-4">
                                <asp:Button runat="server" ID="BtnGrabar" CssClass="btn btn-primary" />
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
    <asp:TextBox runat="server" ID="TxtCorreoOriginal" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" ID="TxtUsuarioOriginal" Visible="false"></asp:TextBox>
</asp:Content>
