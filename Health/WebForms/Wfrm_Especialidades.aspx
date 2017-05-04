<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SitePopUp.Master" AutoEventWireup="true" CodeBehind="Wfrm_Especialidades.aspx.cs" Inherits="Health.WebForms.Wfrm_Especialidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                                        <label class="control-label col-sm-1" id="LblEspecialidad" runat="server"></label>
                                        <div class="col-sm-6">
                                            <asp:DropDownList runat="server" ID="CboEspecialidad" CssClass="select2 select-block-level"></asp:DropDownList>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:Button runat="server" ID="BtnGrabar" data-loading-text="Grabando..."  CssClass="btn btn-primary" />
                                        </div>
                                    </div>
                                    <div style="padding-bottom:1em;"></div>
                                    <div class="row">
                                         <div class="col-sm-1">
                                        </div>
                                        <div class="col-sm-10">
                                            <telerik:RadGrid runat="server" ID="GrdDetalle"  Skin="WebBlue"
                                                AutoGenerateColumns="false" Width="100%" AllowSorting="true" AllowFilteringByColumn="true" PageSize="10"
                                                  AllowPaging="true" >
                                                <PagerStyle Mode="NumericPages" Position="Bottom"/>
                                                <MasterTableView Caption="" DataKeyNames="EspecialidadId,Espe">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="EspecialidadId" UniqueName="EspecialidadId" Visible="false"  HeaderStyle-Width="125px"></telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="Espe" AutoPostBackOnFilter="true" FilterControlWidth="500px" CurrentFilterFunction="Contains" UniqueName="Especialidad" HeaderText="Especialidad"  HeaderStyle-Width="525px"></telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn HeaderText="Quitar" ShowFilterIcon="false" AllowFiltering="false"  Visible="true" UniqueName="Editar" ItemStyle-HorizontalAlign="Center"  HeaderStyle-Width="125px">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton runat="server" ID="ImgEditar" ImageUrl="~/Imagenes/delete.png" formnovalidate CommandName="CmdQuitar"/>
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
                        $('#<%=CboEspecialidad.ClientID%>').select2();
                    }
                </script>
                
            </telerik:RadCodeBlock>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
