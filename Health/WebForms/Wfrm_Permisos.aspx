<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="Wfrm_Permisos.aspx.cs" Inherits="Health.WebForms.Wfrm_Permisos" %>
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
                                        <div class="col-sm-1">
                                        </div>
                                        <div class="col-md-12">
                                            <telerik:RadGrid runat="server" ID="GrdDetalle"  Skin="WebBlue"
                                                AutoGenerateColumns="false" Width="100%" AllowSorting="true" AllowFilteringByColumn="true" PageSize="10"
                                                  AllowPaging="true" >
                                                <PagerStyle Mode="NumericPages" Position="Bottom"/>
                                                <MasterTableView Caption="" DataKeyNames="UsuarioId,PersonaId,Nombre,Usuario,Correo,Tipo_Usuario">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="UsuarioId" UniqueName="RegionId" Visible="false"  HeaderStyle-Width="125px"></telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PersonaId" UniqueName="ModuloId" Visible="false" HeaderStyle-Width="125px"></telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="Nombre" AutoPostBackOnFilter="true" FilterControlWidth="400px" CurrentFilterFunction="Contains" UniqueName="Nombre" HeaderText="Nombre"  HeaderStyle-Width="425px"></telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="Usuario" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" UniqueName="Usuario" HeaderText="Usuario"  HeaderStyle-Width="200px"></telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="Correo" UniqueName="Correo" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"  HeaderText="Correo" HeaderStyle-Width="100px"></telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="Tipo_Usuario" UniqueName="TipoUsuario" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"  HeaderText="Tipo de Usuario" HeaderStyle-Width="100px"></telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn HeaderText="Permisos" ShowFilterIcon="false" AllowFiltering="false"  Visible="true" UniqueName="Editar" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton runat="server" ID="ImgPermisos" ImageUrl="~/Imagenes/lock.png" formnovalidate CommandName="CmdPermisos"/>
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
                                    <div class="row">
                                        <div class="col-sm-2">
                                            <h2><strong><asp:Label runat="server" ID="LblUsuarioE"></asp:Label></strong></h2>
                                        </div>
                                        <div class="col-sm-7">
                                            <h2><strong><asp:Label runat="server" id="LblUsuario"></asp:Label></strong></h2>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-1">
                                        </div>
                                        <div class="col-sm-12">
                                            <telerik:RadGrid runat="server" ID="GrdPErmisos"  Skin="WebBlue"
                                                AutoGenerateColumns="false" Width="100%" AllowSorting="true" AllowFilteringByColumn="true" PageSize="10"
                                                  AllowPaging="true" >
                                                <PagerStyle Mode="NumericPages" Position="Bottom"/>
                                                <MasterTableView Caption="" DataKeyNames="Forma,FormaId,Consultar,Insertar,Editar,Eliminar">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="FormaId" UniqueName="FormaId" Visible="false" HeaderStyle-Width="125px"></telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="Forma" AutoPostBackOnFilter="true" FilterControlWidth="400px" CurrentFilterFunction="Contains" UniqueName="Nombre" HeaderText="Nombre"  HeaderStyle-Width="425px"></telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="Consultar" UniqueName="Consultar" Visible="false" HeaderStyle-Width="125px"></telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn HeaderText="Consultar" ShowFilterIcon="false" AllowFiltering="false"  DataField="Consultar" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" UniqueName="Cons">
                                                            <ItemTemplate>
                                                                <asp:CheckBox runat="server" ID="ChkConsultar" AutoPostBack="true" OnCheckedChanged="ChkConsultar_CheckedChanged"  />
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridBoundColumn DataField="Insertar" UniqueName="Insertar" Visible="false" HeaderStyle-Width="125px"></telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn HeaderText="Insertar"  ShowFilterIcon="false" AllowFiltering="false"  DataField="Insertar" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" UniqueName="Ins">
                                                            <ItemTemplate>
                                                                <asp:CheckBox runat="server" ID="ChkInsertar" AutoPostBack="true" OnCheckedChanged="ChkInsertar_CheckedChanged" xmlns:asp="#unknown" />
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridBoundColumn DataField="Editar" UniqueName="Editar" Visible="false" HeaderStyle-Width="125px"></telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn HeaderText="Editar" ShowFilterIcon="false" AllowFiltering="false"  DataField="Editar" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" UniqueName="Edit">
                                                            <ItemTemplate>
                                                                <asp:CheckBox runat="server" ID="ChkEditar" AutoPostBack="true" OnCheckedChanged="ChkEditar_CheckedChanged" />
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridBoundColumn DataField="Eliminar" UniqueName="Eliminar" Visible="false" HeaderStyle-Width="125px"></telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn HeaderText="Eliminar" ShowFilterIcon="false" AllowFiltering="false"  DataField="Eliminar" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" UniqueName="Del">
                                                            <ItemTemplate>
                                                                <asp:CheckBox runat="server" ID="ChkEliminar" AutoPostBack="true" OnCheckedChanged="ChkEliminar_CheckedChanged"  />
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
            <asp:TextBox runat="server" ID="TxtUsuarioId" Visible="false"></asp:TextBox>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
