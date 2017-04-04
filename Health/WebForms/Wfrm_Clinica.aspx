<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="Wfrm_Clinica.aspx.cs" Inherits="Health.WebForms.Wfrm_Clinica" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
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
                                            <telerik:RadAsyncUpload MaxFileSize="2097152" DisableChunkUpload="true" Skin="Bootstrap"  runat="server" ID="TxtFotoPerfil" Localization-Cancel="Cancelar" Localization-Select="Buscar" Localization-Remove="Quitar" MaxFileInputsCount="1" AllowedFileExtensions=".jpg" />
                                        </div>
                                    </div>
                                </div>
                                <div style="padding-bottom:1em;"></div>
                                <div class="row">
                                    <div class="col-sm-4">
                                        <asp:Button runat="server" ID="BtnGrabar" data-loading-text="Grabando..."  CssClass="btn btn-primary" />
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
                                       <telerik:RadGrid runat="server" ID="GrdDetalle"  Skin="WebBlue"
                                            AutoGenerateColumns="false" Width="100%" AllowSorting="true" AllowFilteringByColumn="true" PageSize="10"
                                                AllowPaging="true" >
                                            <PagerStyle Mode="NumericPages" Position="Bottom"/>
                                            <MasterTableView Caption="" DataKeyNames="ClinicaId,Nombre,Direccion">
                                                <Columns>
                                                    <telerik:GridBoundColumn DataField="ClinicaId" UniqueName="ClinicaId" Visible="false"  HeaderStyle-Width="125px"></telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="Nombre" AutoPostBackOnFilter="true" FilterControlWidth="400px" CurrentFilterFunction="Contains" UniqueName="Nombre" HeaderText="Nombre"  HeaderStyle-Width="425px"></telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="Direccion" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" FilterControlWidth="400px" UniqueName="Direccion" HeaderText="Direccion"  HeaderStyle-Width="425px"></telerik:GridBoundColumn>
                                                    <telerik:GridTemplateColumn HeaderText="Editar" ShowFilterIcon="false" AllowFiltering="false"  Visible="true" UniqueName="Editar" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:ImageButton runat="server" ID="ImgEditar" ImageUrl="~/Imagenes/editar.png"  formnovalidate CommandName="CmdEditar"/>
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
                            $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
                        }
                    </script>
                </telerik:RadCodeBlock>
            <asp:TextBox runat="server" Visible="false" ID="TxtClinicaId"></asp:TextBox>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
