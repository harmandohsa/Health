﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="Wfrm_Usuarios.aspx.cs" Inherits="Health.WebForms.Wfrm_Usuarios" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
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
                                        <asp:DropDownList runat="server" ID="CboGenero" CssClass="select2 select-block-level"></asp:DropDownList>
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
                                    <asp:DropDownList runat="server" ID="CboDepartamento"  AutoPostBack="true" CssClass="select2 select-block-level"></asp:DropDownList>
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
                                <label class="control-label col-sm-1" id="LblCorreo" runat="server"></label>
                                <div class="col-sm-5">
                                    <input id="TxtCorreo"  runat="server" title="" type="email"  class="form-control input-transparent" >
                                </div>
                            </div>
                        </div>
                        <div style="padding-bottom:1em;"></div>
                        <div class="row">
                            <div class="form-group">
                                <label class="control-label col-sm-1" id="LblFecNac" runat="server"></label>
                                <div class="col-sm-5">
                                    <input id="TxtFecNac"  runat="server" title="" type="date"  class="form-control input-transparent" >
                                </div>
                                <label class="control-label col-sm-1" id="lblTipoUsuario" runat="server"></label>
                                <div class="col-sm-5">
                                    <asp:DropDownList runat="server" ID="CboTipoUsuario" CssClass="select2 select-block-level"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div style="padding-bottom:1em;"></div>
                        <div class="row">
                            <div class="col-sm-4">
                                <asp:Button runat="server" ID="BtnGrabar" data-loading-text="Grabando..."   CssClass="btn btn-primary" />
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
                        <div class="row">
                            <div class="col-sm-1">
                            </div>
                            <div class="col-sm-12">
                               <telerik:RadGrid runat="server" ID="GrdDetalle"  Skin="Material"
                                        AutoGenerateColumns="false" Width="100%" AllowSorting="true" AllowFilteringByColumn="true" PageSize="10"
                                          AllowPaging="true" >
                                        <PagerStyle Mode="Advanced" NextPageText="Siguiente" 
                                            PrevPageText="Anterior" Position="Bottom" 
                                            PageSizeLabelText="Regitros"/>
                                        <MasterTableView Caption="" DataKeyNames="UsuarioId,PersonaId,Nombre,Usuario,Correo,Tipo_Usuario" NoMasterRecordsText="No Hay Registros" ShowFooter="true">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="UsuarioId" UniqueName="RegionId" Visible="false"  HeaderStyle-Width="125px"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="PersonaId" UniqueName="ModuloId" Visible="false" HeaderStyle-Width="125px"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Nombre" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" UniqueName="Nombre" HeaderText="Nombre"  HeaderStyle-Width="425px"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Usuario" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" UniqueName="Usuario" HeaderText="Usuario"  HeaderStyle-Width="200px"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Correo" UniqueName="Correo" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"  HeaderText="Correo" HeaderStyle-Width="100px"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Tipo_USuario" UniqueName="TipoUsuario" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"  HeaderText="Tipo de Usuario" HeaderStyle-Width="100px"></telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn HeaderText="Editar" ShowFilterIcon="false" AllowFiltering="false"  Visible="true" UniqueName="Editar" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:ImageButton runat="server" ID="ImgAnexos" Visible="false" ImageUrl="~/Imagenes/24x24/blank.png" formnovalidate ToolTip="Anexos" CommandName="CmdAnexos"/>
                                                        </ItemTemplate>
                                                </telerik:GridTemplateColumn> 
                                            </Columns>        
                                        </MasterTableView>
                                        <FilterMenu EnableTheming="true">
                                            <CollapseAnimation Duration="200" Type="OutQuint" />
                                        </FilterMenu>
                                    </telerik:RadGrid>
                            </div>
                        </div>
                    </div>
                </section>
                </div>
            </div>
        </div>
        <input id="TxtIdioma" style="visibility:hidden" runat="server" />
        <div style="visibility:hidden;"></div>


        <script src="../lib/jquery/dist/jquery.min.js" type="text/javascript"></script>
        <script src="../lib/bootstrap/dist/js/bootstrap.min.js" type="text/javascript"></script>
        <script src="../lib/datatables/media/js/jquery.dataTables.min.js" type="text/javascript"></script>
        
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="GrdDetalle">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="GrdDetalle" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
        </telerik:RadAjaxLoadingPanel>

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
             }
        </script>
    </telerik:RadCodeBlock>
       
</asp:Content>
