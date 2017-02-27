<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="Wfrm_Clinica.aspx.cs" Inherits="Health.WebForms.Wfrm_Clinica" %>
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
                                    <label class="control-label col-sm-1" id="LblNombres" runat="server"></label>
                                    <div class="col-sm-8"><input id="TxtNombre"  runat="server" title="" class="form-control input-transparent" ></div>
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
                                <label class="control-label col-sm-1" id="LblFotoLogo" runat="server"></label>
                                <div class="col-sm-5">
                                    <input id="TxtFotoPerfil"  runat="server" title="" type="file"  class="form-control input-transparent" >
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
                        <div style="padding-bottom:1em;"></div>
                        <div class="row">
                            <div class="col-sm-1">
                            </div>
                            <div class="col-sm-8">
                                <table id="datatable-table" class="table table-striped table-hover">
                                   <thead>
                                        <tr>
                                            <th>Id</th>
                                            <th>Name</th>
                                            <th class="no-sort hidden-xs">Info</th>
                                            <th class="hidden-xs">Description</th>
                                            <th class="hidden-xs">Date</th>
                                            <th class="no-sort">Status</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>1</td>
                                            <td><span class="fw-semi-bold">Algerd</span></td>
                                            <td class="hidden-xs">
                                                <small>
                                                    <span class="fw-semi-bold">Type:</span>
                                                    &nbsp; JPEG
                                                </small>
                                                <br>
                                                <small>
                                                    <span class="fw-semi-bold">Dimensions:</span>
                                                    &nbsp; 200x150
                                                </small>
                                            </td>
                                            <td class="hidden-xs"><a href="#">Palo Alto</a></td>
                                            <td class="hidden-xs">June 27, 2013</td>
                                            <td class="width-150">
                                                <div class="progress progress-sm mt-xs">
                                                    <div class="progress-bar progress-bar-success" style="width: 29%;"></div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>2</td>
                                            <td><span class="fw-semi-bold">Vitaut</span></td>
                                            <td class="hidden-xs">
                                                <small>
                                                    <span class="fw-semi-bold">Type:</span>
                                                    &nbsp; PNG
                                                </small>
                                                <br>
                                                <small>
                                                    <span class="fw-semi-bold">Dimensions:</span>
                                                    &nbsp; 6433x4522
                                                </small>
                                            </td>
                                            <td class="hidden-xs"><a href="#">Vilnia</a></td>
                                            <td class="hidden-xs">January 1, 1442</td>
                                            <td class="width-150">
                                                <div class="progress progress-sm mt-xs">
                                                    <div class="progress-bar progress-bar-danger" style="width: 19%;"></div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>3</td>
                                            <td><span class="fw-semi-bold">Honar</span></td>
                                            <td class="hidden-xs">
                                                <small>
                                                    <span class="fw-semi-bold">Type:</span>
                                                    &nbsp; AVI
                                                </small>
                                                <br>
                                                <small>
                                                    <span class="fw-semi-bold">Dimensions:</span>
                                                    &nbsp; 1440x980
                                                </small>
                                            </td>
                                            <td class="hidden-xs"><a href="#">Berlin</a></td>
                                            <td class="hidden-xs">August 6, 2013</td>
                                            <td class="width-150">
                                                <div class="progress progress-sm mt-xs">
                                                    <div class="progress-bar progress-bar-gray-light" style="width: 49%;"></div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>4</td>
                                            <td><span class="fw-semi-bold">Jack</span></td>
                                            <td class="hidden-xs">
                                                <small>
                                                    <span class="fw-semi-bold">Type:</span>
                                                    &nbsp; PNG
                                                </small>
                                                <br>
                                                <small>
                                                    <span class="fw-semi-bold">Dimensions:</span>
                                                    &nbsp; 12x43
                                                </small>
                                            </td>
                                            <td class="hidden-xs"><a href="#">San Francisco</a></td>
                                            <td class="hidden-xs">August 19, 2013</td>
                                            <td class="width-150">
                                                <div class="progress progress-sm mt-xs">
                                                    <div class="progress-bar" style="width: 69%;"></div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>5</td>
                                            <td><span class="fw-semi-bold">Leon</span></td>
                                            <td class="hidden-xs">
                                                <small>
                                                    <span class="fw-semi-bold">Type:</span>
                                                    &nbsp; MP4
                                                </small>
                                                <br>
                                                <small>
                                                    <span class="fw-semi-bold">Dimensions:</span>
                                                    &nbsp; 800x480
                                                </small>
                                            </td>
                                            <td class="hidden-xs"><a href="#">Brasilia</a></td>
                                            <td class="hidden-xs">October 1, 2013</td>
                                            <td class="width-150">
                                                <div class="progress progress-sm mt-xs">
                                                    <div class="progress-bar progress-bar-gray-light" style="width: 9%;"></div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>6</td>
                                            <td><span class="fw-semi-bold">Max</span></td>
                                            <td class="hidden-xs">
                                                <small>
                                                    <span class="fw-semi-bold">Type:</span>
                                                    &nbsp; TXT
                                                </small>
                                                <br>
                                                <small>
                                                    <span class="fw-semi-bold">Dimensions:</span>
                                                    &nbsp; -
                                                </small>
                                            </td>
                                            <td class="hidden-xs"><a href="#">Helsinki</a></td>
                                            <td class="hidden-xs">October 29, 2013</td>
                                            <td class="width-150">
                                                <div class="progress progress-sm mt-xs">
                                                    <div class="progress-bar progress-bar-warning" style="width: 38%;"></div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>7</td>
                                            <td><span class="fw-semi-bold">Pol</span></td>
                                            <td class="hidden-xs">
                                                <small>
                                                    <span class="fw-semi-bold">Type:</span>
                                                    &nbsp; MOV
                                                </small>
                                                <br>
                                                <small>
                                                    <span class="fw-semi-bold">Dimensions:</span>
                                                    &nbsp; 640x480
                                                </small>
                                            </td>
                                            <td class="hidden-xs"><a href="#">Radashkovichi</a></td>
                                            <td class="hidden-xs">November 11, 2013</td>
                                            <td class="width-150">
                                                <div class="progress progress-sm mt-xs">
                                                    <div class="progress-bar progress-bar-danger" style="width: 83%;"></div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>8</td>
                                            <td><span class="fw-semi-bold">Chrishna</span></td>
                                            <td class="hidden-xs">
                                                <small>
                                                    <span class="fw-semi-bold">Type:</span>
                                                    &nbsp; DOC
                                                </small>
                                                <br>
                                                <small>
                                                    <span class="fw-semi-bold">Dimensions:</span>
                                                    &nbsp; -
                                                </small>
                                            </td>
                                            <td class="hidden-xs"><a href="#">Mumbai</a></td>
                                            <td class="hidden-xs">December 2, 2013</td>
                                            <td class="width-150">
                                                <div class="progress progress-sm mt-xs">
                                                    <div class="progress-bar progress-bar-info" style="width: 40%;"></div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>9</td>
                                            <td><span class="fw-semi-bold">Leslie</span></td>
                                            <td class="hidden-xs">
                                                <small>
                                                    <span class="fw-semi-bold">Type:</span>
                                                    &nbsp; AVI
                                                </small>
                                                <br>
                                                <small>
                                                    <span class="fw-semi-bold">Dimensions:</span>
                                                    &nbsp; 4820x2140
                                                </small>
                                            </td>
                                            <td class="hidden-xs"><a href="#">Singapore</a></td>
                                            <td class="hidden-xs">December 6, 2013</td>
                                            <td class="width-150">
                                                <div class="progress progress-sm mt-xs">
                                                    <div class="progress-bar progress-bar-warning" style="width: 18%;"></div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>10</td>
                                            <td><span class="fw-semi-bold">David</span></td>
                                            <td class="hidden-xs">
                                                <small>
                                                    <span class="fw-semi-bold">Type:</span>
                                                    &nbsp; XML
                                                </small>
                                                <br>
                                                <small>
                                                    <span class="fw-semi-bold">Dimensions:</span>
                                                    &nbsp; -
                                                </small>
                                            </td>
                                            <td class="hidden-xs"><a href="#">Portland</a></td>
                                            <td class="hidden-xs">December 13, 2013</td>
                                            <td class="width-150">
                                                <div class="progress progress-sm mt-xs">
                                                    <div class="progress-bar progress-bar-gray-light" style="width: 54%;"></div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>19</td>
                                            <td><span class="fw-semi-bold">Uladz'</span></td>
                                            <td class="hidden-xs">
                                                <small>
                                                    <span class="fw-semi-bold">Type:</span>
                                                    &nbsp; JPEG
                                                </small>
                                                <br>
                                                <small>
                                                    <span class="fw-semi-bold">Dimensions:</span>
                                                    &nbsp; 2200x1600
                                                </small>
                                            </td>
                                            <td class="hidden-xs"><a href="#">Mahileu</a></td>
                                            <td class="hidden-xs">December 7, 2013</td>
                                            <td class="width-150">
                                                <div class="progress progress-sm mt-xs">
                                                    <div class="progress-bar progress-bar-gray-light" style="width: 0%;"></div>
                                                </div>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                           
                        </div>
                    </div>
                </section>
                </div>
            </div>
        </div>
</asp:Content>
