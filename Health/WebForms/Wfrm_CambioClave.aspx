<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="Wfrm_CambioClave.aspx.cs" Inherits="Health.WebForms.Wfrm_CambioClave" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content container">
        <h2 class="page-title"><%--<asp:Label runat="server" ID="LblTitulo"></asp:Label>--%></h2>
        <div class="row">
            <div class="col-md-8">
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
                                    <label class="control-label col-sm-3" id="LblContActual" runat="server"></label>
                                    <div class="col-sm-5"><input id="TxtPassActual" name="TxtPassActual" runat="server" type="password"  title=""  class="form-control input-transparent"></div>
                                </div>
                            </div>
                            <div style="padding-bottom:1em;"></div>
                            <div class="row">
                                <div class="form-group">
                                    <label class="control-label col-sm-3" id="LblNuevaCont" runat="server"></label>
                                    <div class="col-sm-5"><input id="TxtPassNueva"  runat="server" title="" type="password"  class="form-control input-transparent" ></div>
                                </div>
                            </div>
                            <div style="padding-bottom:1em;"></div>
                            <div class="row">
                                <div class="form-group">
                                    <label class="control-label col-sm-3" id="LblConfCont" runat="server"></label>
                                    <div class="col-sm-5"><input id="TxtPassConfNueva"   runat="server" title="" type="password"  class="form-control input-transparent" ></div>
                                </div>
                            </div>
                        </fieldset>
                        <div style="padding-bottom:1em;"></div>
                        <div class="row">
                            <div class="col-sm-4">
                                <asp:Button runat="server" ID="BtnChangePass" CssClass="btn btn-primary" />
                                <%--<button type="submit" id="BtnCambiaClave" runat="server" class="btn btn-primary"></button>--%>
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
</asp:Content>
