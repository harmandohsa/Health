<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="Wfrm_NuevaCita.aspx.cs" Inherits="Health.WebForms.Wfrm_NuevaCita" %>
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
                                            <label class="control-label col-sm-2" id="LblEspecialidad" runat="server"></label>
                                            <div class="col-sm-5">
                                                <asp:DropDownList runat="server" ID="CboEspecialidad" AutoPostBack="true" CssClass="select2 select-block-level"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div style="padding-bottom:2em;"></div>
                                    <div class="row">
                                        <div class="col-sm-1">
                                        </div>
                                        <div class="col-sm-12">
                                            <div class="form-group">
                                              




                                                <telerik:RadGrid runat="server" ID="GrdMedicos"  Skin="Vista"
                                                    AutoGenerateColumns="false" Width="100%" AllowSorting="true" AllowFilteringByColumn="true" PageSize="5"
                                                      AllowPaging="true" >
                                                    <PagerStyle Mode="NumericPages" Position="Bottom"/>
                                                    <MasterTableView Caption="" DataKeyNames="UsuarioId,PersonaId,Nombres,Clinica,Telefono,Pais,Direccion">
                                                        <Columns>
                                                            <telerik:GridBoundColumn DataField="UsuarioId" UniqueName="RegionId" Visible="false"  HeaderStyle-Width="125px"></telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="PersonaId" UniqueName="ModuloId" Visible="false" HeaderStyle-Width="125px"></telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="Nombres" AutoPostBackOnFilter="true" FilterControlWidth="200px" CurrentFilterFunction="Contains" UniqueName="Medico" HeaderText="Nombre"  HeaderStyle-Width="425px"></telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="Clinica" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" UniqueName="Usuario" HeaderText="Clinica"  HeaderStyle-Width="200px"></telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="Telefono" UniqueName="Telefono" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"  HeaderText="Telefono" HeaderStyle-Width="100px"></telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="Pais" UniqueName="Pais" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"  HeaderText="País" HeaderStyle-Width="100px"></telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="Direccion" UniqueName="Direccion" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"  HeaderText="Dirección" HeaderStyle-Width="200px"></telerik:GridBoundColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Ver Perfil" ShowFilterIcon="false" AllowFiltering="false"  Visible="true" UniqueName="Editar" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton runat="server" ID="ImgVerPerfil" ImageUrl="~/Imagenes/editar.png" formnovalidate CommandName="CmdPerfil"/>
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
                                </div>
                            </section>
                        </div>
                    </div>
                </div>
                <asp:TextBox runat="server" ID="TxtEspecialidadId" Visible="false" Text="0"></asp:TextBox>
            <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
            <script type="text/javascript">
                function pageLoad() {
                     <%--$('#<%=BtnGrabar.ClientID%>').click(function () {
                         $(this).button('loading').delay(100000).queue(function () {
                             $(this).button('reset');
                             $(this).dequeue();
                             $(this).data('loading-text', 'Cargando...');
                         });
                     });--%>
                    $('#<%=CboEspecialidad.ClientID%>').select2();
                 }
            </script>
            </telerik:RadCodeBlock>
            <telerik:RadWindowManager RenderMode="Lightweight" ID="RadWindowManager1" runat="server" EnableShadow="true" Skin="WebBlue">
            <Windows>
                <telerik:RadWindow RenderMode="Lightweight" ID="RadWindow1" runat="server" ShowContentDuringLoad="false" Width="800px"
                    Height="600px" Title="Telerik RadWindow" Behaviors="Default">
                </telerik:RadWindow>
                <telerik:RadWindow runat="server" ID="RadWindowDetalle" Modal="true"  Height="500px" Width="1050px"  ShowContentDuringLoad="false" Behaviors="Default">
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
