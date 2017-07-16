<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="Wfrm_New_Paciente.aspx.cs" Inherits="Health.WebForms.Wfrm_New_Paciente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Always">
        <ContentTemplate>
                <div class="content container">
                    <div class="row">
                        <div class="col-md-12">
                            <section class="widget">
                                <div class="body">
                                    <fieldset class="mt-sm">
                                        <legend><asp:Label runat="server" ID="LblSubTitulo"></asp:Label></legend>
                                    </fieldset>
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
                                            <label class="control-label col-sm-1" id="LblFecNac" runat="server"></label>
                                            <div class="col-sm-5">
                                                <input id="TxtFecNac"  runat="server" title="" type="date"  class="form-control input-transparent" >
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
                    $('#<%=CboGenero.ClientID%>').select2();
                }

             
            </script>
        </telerik:RadCodeBlock>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
