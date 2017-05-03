using Health.Clases;
using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Health.WebForms
{
    public partial class Wfrm_Perfil : System.Web.UI.Page
    {
        Cl_Traductor ClTraductor;
        Cl_Catalogos ClCatalogos;
        Cl_Utilitarios ClUtilitarios;
        Cl_Cliente Clcliente;
        Cl_Usuario ClUsuario;
        Cl_Persona ClPersona;
        protected void Page_Load(object sender, EventArgs e)
        {
            ClTraductor = new Cl_Traductor();
            ClCatalogos = new Cl_Catalogos();
            ClUtilitarios = new Cl_Utilitarios();
            Clcliente = new Cl_Cliente();
            ClUsuario = new Cl_Usuario();
            ClPersona = new Cl_Persona();

            ImageButton ImgEng;
            ImgEng = (ImageButton)Master.FindControl("ImgEng");
            ImgEng.Click += ImgEng_Click;

            ImageButton ImgEsp;
            ImgEsp = (ImageButton)Master.FindControl("ImgEsp");
            ImgEsp.Click += ImgEsp_Click;

            CboPais.SelectedIndexChanged += CboPais_SelectedIndexChanged;
            CboDepartamento.SelectedIndexChanged += CboDepartamento_SelectedIndexChanged;
            BtnGrabar.Click += BtnGrabar_Click;
            CboPaisUni.SelectedIndexChanged += CboPaisUni_SelectedIndexChanged1;

            if (Session["UsuarioId"] == null)
            {
                Response.Redirect("~/Wfrm_Login.aspx");
            }
            else if (!IsPostBack)
            {

                Traduce();
                if (ClUtilitarios.Decrypt(HttpUtility.UrlDecode(Request.QueryString["appel"].ToString()), true) == "1")
                {
                    CargaDatosCliente();
                    System.Web.UI.HtmlControls.HtmlGenericControl sidebar;
                    sidebar = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("sidebar");
                    sidebar.Visible = false;

                    System.Web.UI.HtmlControls.HtmlGenericControl liMensajes;
                    liMensajes = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("liMensajes");
                    liMensajes.Visible = false;

                    System.Web.UI.HtmlControls.HtmlGenericControl liTickets;
                    liTickets = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("liTickets");
                    liTickets.Visible = false;

                    System.Web.UI.HtmlControls.HtmlGenericControl liPerfil;
                    liPerfil = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("liPerfil");
                    liPerfil.Visible = false;
                }
                else if (ClUtilitarios.Decrypt(HttpUtility.UrlDecode(Request.QueryString["appel"].ToString()), true) == "2")
                {
                    CargaDatosPersona(Convert.ToInt32(Session["PersonaId"]));
                    DataSet dsPermisos = ClUsuario.Get_Roles_Forma_Usuario(Convert.ToInt32(Session["UsuarioId"]), 1);
                    if (Convert.ToInt32(dsPermisos.Tables["Datos"].Rows[0]["Editar"]) == 0)
                    {
                        BtnGrabar.Enabled = false;
                    }
                    if (Convert.ToInt32(dsPermisos.Tables["Datos"].Rows[0]["Insertar"]) == 0)
                    {
                        BtnGrabar.Enabled = false;
                    }
                    if (Convert.ToInt32(dsPermisos.Tables["Datos"].Rows[0]["Eliminar"]) == 0)
                    {

                    }
                    dsPermisos.Clear();
                }
            }
        }

        private void CboPaisUni_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (CboPaisUni.SelectedIndex != 0)
            {
                ClUtilitarios.Fill_DropDownAsp(ClCatalogos.Catalogo_Universidad(Session["Idioma"].ToString(), Convert.ToInt32(CboPaisUni.SelectedValue)), CboUniverisidad, "Id", "Datos");
                ClUtilitarios.AgregarSeleccioneCombo(CboUniverisidad, ClTraductor.BuscaString(Session["Idioma"].ToString(), "53"), Session["Idioma"].ToString());
            }
            else
            {
                CboUniverisidad.Items.Clear();
                CboUniverisidad.ClearSelection();
            }
        }

        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            if (Valida() == true)
            {
                if (Convert.ToInt32(Session["Fase_ClienteId"]) == 1)
                {
                    
                    int PersonaId = ClPersona.Get_Max_Persona();
                    int UniversidadId = 0;
                    if (CboUniverisidad.SelectedIndex > 0)
                        UniversidadId = Convert.ToInt32(CboUniverisidad.SelectedValue);
                    ClPersona.Insert_Persona(PersonaId, Convert.ToInt32(CboAlias.SelectedValue), TxtNombres.Value, TxtApellidos.Value, Convert.ToInt32(CboGenero.SelectedValue), TxtIdNo.Value, TxtDireccion.Value, Convert.ToInt32(CboMunicipio.SelectedValue), TxtTelCasa.Value, TxtTelMovil.Value, UniversidadId, TxtNoCol.Value, TxtTitulo.Value, Convert.ToDateTime(TxtFecNac.Value));
                    Clcliente.Update_Estado_Fase_Cliente(Convert.ToInt32(Session["ClienteId"]));
                    ClUsuario.Actualiza_PersonaID_Usuario(PersonaId, Convert.ToInt32(Session["UsuarioId"]));
                    ClUsuario.Update_DatosUsuario(1,Convert.ToInt32(Session["UsuarioId"]), TxtCorreo.Value, TxtUsuario.Value,0);
                    ClUsuario.Create_Permisos(Convert.ToInt32(Session["UsuarioId"]), 1);
                    Session["PersonaId"] = PersonaId;
                    if (TxtFotoPerfil.UploadedFiles.Count > 0)
                    {
                        Stream fileStream = TxtFotoPerfil.UploadedFiles[0].InputStream;
                        byte[] attachmentBytes = new byte[fileStream.Length];
                        fileStream.Read(attachmentBytes, 0, Convert.ToInt32(fileStream.Length));
                        ClPersona.Insert_Foto_Perfil(PersonaId, attachmentBytes, TxtFotoPerfil.UploadedFiles[0].ContentType, TxtFotoPerfil.UploadedFiles[0].FileName);
                        fileStream.Close();
                    }
                    if (TxtFotoTitulo.UploadedFiles.Count > 0)
                    {
                        Stream fileStream = TxtFotoTitulo.UploadedFiles[0].InputStream;
                        byte[] attachmentBytes = new byte[fileStream.Length];
                        fileStream.Read(attachmentBytes, 0, Convert.ToInt32(fileStream.Length));
                        ClPersona.Insert_Foto_Titulo(PersonaId, attachmentBytes, TxtFotoTitulo.UploadedFiles[0].ContentType, TxtFotoTitulo.UploadedFiles[0].FileName);
                        fileStream.Close();
                    }
                    Response.Redirect("~/WebForms/Wfrm_Inicio.aspx");
                }
                else
                {
                    int UniversidadId = 0;
                    if (CboUniverisidad.SelectedIndex > 0)
                        UniversidadId = Convert.ToInt32(CboUniverisidad.SelectedValue);
                    ClPersona.Update_Persona(Convert.ToInt32(Session["PersonaId"]), Convert.ToInt32(CboAlias.SelectedValue), TxtNombres.Value, TxtApellidos.Value, Convert.ToInt32(CboAlias.SelectedValue), TxtIdNo.Value, TxtDireccion.Value, Convert.ToInt32(CboMunicipio.SelectedValue), TxtTelCasa.Value, TxtTelMovil.Value, UniversidadId, TxtNoCol.Value, TxtTitulo.Value, Convert.ToDateTime(TxtFecNac.Value));
                    ClUsuario.Update_DatosUsuario(1,Convert.ToInt32(Session["UsuarioId"]), TxtCorreo.Value, TxtUsuario.Value,0);
                    if (TxtFotoPerfil.UploadedFiles.Count > 0)
                    {
                        Stream fileStream = TxtFotoPerfil.UploadedFiles[0].InputStream;
                        byte[] attachmentBytes = new byte[fileStream.Length];
                        fileStream.Read(attachmentBytes, 0, Convert.ToInt32(fileStream.Length));
                        ClPersona.Insert_Foto_Perfil(Convert.ToInt32(Session["PersonaId"]), attachmentBytes, TxtFotoPerfil.UploadedFiles[0].ContentType, TxtFotoPerfil.UploadedFiles[0].FileName);
                        fileStream.Close();
                    }
                    if (TxtFotoTitulo.UploadedFiles.Count > 0)
                    {
                        Stream fileStream = TxtFotoTitulo.UploadedFiles[0].InputStream;
                        byte[] attachmentBytes = new byte[fileStream.Length];
                        fileStream.Read(attachmentBytes, 0, Convert.ToInt32(fileStream.Length));
                        ClPersona.Insert_Foto_Titulo(Convert.ToInt32(Session["PersonaId"]), attachmentBytes, TxtFotoTitulo.UploadedFiles[0].ContentType, TxtFotoTitulo.UploadedFiles[0].FileName);
                        fileStream.Close();
                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "CloseWindow", "ShowPopup('" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "76") + "', '" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "76") + "','success','" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "9") + "');", true);
                }
            }
        }

        void CargaDatosCliente()
        {
            DataSet DsDatoCliente = Clcliente.GetDatosCliente(Convert.ToInt32(Session["ClienteId"]));
            TxtNombres.Value = DsDatoCliente.Tables["Datos"].Rows[0]["Nombres"].ToString();
            TxtApellidos.Value = DsDatoCliente.Tables["Datos"].Rows[0]["Apellidos"].ToString();
            TxtIdNo.Value = DsDatoCliente.Tables["Datos"].Rows[0]["No_Identificacion"].ToString();
            TxtDireccion.Value = DsDatoCliente.Tables["Datos"].Rows[0]["Direccion"].ToString();
            CboPais.SelectedValue = DsDatoCliente.Tables["Datos"].Rows[0]["PaisId"].ToString();
            CboPais.Text = DsDatoCliente.Tables["Datos"].Rows[0]["Pais"].ToString();
            ClUtilitarios.Fill_DropDownAsp(ClCatalogos.Catalogo_Departamento(Session["Idioma"].ToString(), Convert.ToInt32(CboPais.SelectedValue)), CboDepartamento, "Id", "Datos");
            ClUtilitarios.AgregarSeleccioneCombo(CboDepartamento, ClTraductor.BuscaString(Session["Idioma"].ToString(), "49"), Session["Idioma"].ToString());
            ClUtilitarios.Fill_DropDownAsp(ClCatalogos.Catalogo_Universidad(Session["Idioma"].ToString(), Convert.ToInt32(CboPais.SelectedValue)), CboUniverisidad, "Id", "Datos");
            ClUtilitarios.AgregarSeleccioneCombo(CboUniverisidad, ClTraductor.BuscaString(Session["Idioma"].ToString(), "53"), Session["Idioma"].ToString());
            CboDepartamento.SelectedValue = DsDatoCliente.Tables["Datos"].Rows[0]["DepartamentoId"].ToString();
            CboDepartamento.Text = DsDatoCliente.Tables["Datos"].Rows[0]["Departamento"].ToString();
            ClUtilitarios.Fill_DropDownAsp(ClCatalogos.Catalogo_Municipio(Session["Idioma"].ToString(), Convert.ToInt32(CboDepartamento.SelectedValue)), CboMunicipio, "Id", "Datos");
            ClUtilitarios.AgregarSeleccioneCombo(CboMunicipio, ClTraductor.BuscaString(Session["Idioma"].ToString(), "50"), Session["Idioma"].ToString());
            CboMunicipio.SelectedValue = DsDatoCliente.Tables["Datos"].Rows[0]["MunicipioId"].ToString();
            CboMunicipio.Text = DsDatoCliente.Tables["Datos"].Rows[0]["Municipio"].ToString();
            TxtTelCasa.Value = DsDatoCliente.Tables["Datos"].Rows[0]["Telefono"].ToString();
            TxtTelMovil.Value = DsDatoCliente.Tables["Datos"].Rows[0]["Telefono_Movil"].ToString();
            TxtCorreo.Value = DsDatoCliente.Tables["Datos"].Rows[0]["Correo"].ToString();
            TxtUsuario.Value = Session["Usuario"].ToString();
            TxtCorreoOriginal.Text = DsDatoCliente.Tables["Datos"].Rows[0]["Correo"].ToString();
            TxtUsuarioOriginal.Text = Session["Usuario"].ToString();
            DsDatoCliente.Clear();

        }


        void CargaDatosPersona(int PersonaId)
        {
            DataSet DsDatosPersona = ClPersona.Get_Datos_Persona(PersonaId, Session["Idioma"].ToString());
            CboAlias.SelectedValue = DsDatosPersona.Tables["Datos"].Rows[0]["AliasIid"].ToString();
            CboGenero.SelectedValue = DsDatosPersona.Tables["Datos"].Rows[0]["GeneroId"].ToString();
            if (Session["Idioma"].ToString() == "es-GT")
            {
                CboAlias.Text = DsDatosPersona.Tables["Datos"].Rows[0]["Alias"].ToString();
                CboGenero.Text = DsDatosPersona.Tables["Datos"].Rows[0]["Genero"].ToString();
            }
            else if (Session["Idioma"].ToString() == "en-US")
            {
                CboAlias.Text = DsDatosPersona.Tables["Datos"].Rows[0]["AliasIng"].ToString();
                CboGenero.Text = DsDatosPersona.Tables["Datos"].Rows[0]["GeneroIng"].ToString();
            }
            TxtNombres.Value = DsDatosPersona.Tables["Datos"].Rows[0]["Nombres"].ToString();
            TxtApellidos.Value = DsDatosPersona.Tables["Datos"].Rows[0]["Apellidos"].ToString();
            TxtIdNo.Value = DsDatosPersona.Tables["Datos"].Rows[0]["No_Identificacion"].ToString();
            TxtDireccion.Value = DsDatosPersona.Tables["Datos"].Rows[0]["Direccion"].ToString();
            CboPais.SelectedValue = DsDatosPersona.Tables["Datos"].Rows[0]["PaisDireccionId"].ToString();
            CboPais.Text = DsDatosPersona.Tables["Datos"].Rows[0]["PaisDirec"].ToString();
            ClUtilitarios.Fill_DropDownAsp(ClCatalogos.Catalogo_Departamento(Session["Idioma"].ToString(), Convert.ToInt32(CboPais.SelectedValue)), CboDepartamento, "Id", "Datos");
            ClUtilitarios.AgregarSeleccioneCombo(CboDepartamento, ClTraductor.BuscaString(Session["Idioma"].ToString(), "49"), Session["Idioma"].ToString());

            CboPaisUni.SelectedValue = DsDatosPersona.Tables["Datos"].Rows[0]["PaisUniId"].ToString();
            CboPaisUni.Text = DsDatosPersona.Tables["Datos"].Rows[0]["PaisUni"].ToString();
            ClUtilitarios.Fill_DropDownAsp(ClCatalogos.Catalogo_Universidad(Session["Idioma"].ToString(), Convert.ToInt32(CboPaisUni.SelectedValue)), CboUniverisidad, "Id", "Datos");
            ClUtilitarios.AgregarSeleccioneCombo(CboUniverisidad, ClTraductor.BuscaString(Session["Idioma"].ToString(), "53"), Session["Idioma"].ToString());
            CboDepartamento.SelectedValue = DsDatosPersona.Tables["Datos"].Rows[0]["DepartamentoId"].ToString();
            CboDepartamento.Text = DsDatosPersona.Tables["Datos"].Rows[0]["Departamento"].ToString();
            ClUtilitarios.Fill_DropDownAsp(ClCatalogos.Catalogo_Municipio(Session["Idioma"].ToString(), Convert.ToInt32(CboDepartamento.SelectedValue)), CboMunicipio, "Id", "Datos");
            ClUtilitarios.AgregarSeleccioneCombo(CboMunicipio, ClTraductor.BuscaString(Session["Idioma"].ToString(), "50"), Session["Idioma"].ToString());
            CboMunicipio.SelectedValue = DsDatosPersona.Tables["Datos"].Rows[0]["MunicipioId"].ToString();
            CboMunicipio.Text = DsDatosPersona.Tables["Datos"].Rows[0]["Municipio"].ToString();
            TxtTelCasa.Value = DsDatosPersona.Tables["Datos"].Rows[0]["Telefono"].ToString();
            TxtTelMovil.Value = DsDatosPersona.Tables["Datos"].Rows[0]["Telefono_Movil"].ToString();
            TxtCorreo.Value = DsDatosPersona.Tables["Datos"].Rows[0]["Correo"].ToString();
            TxtUsuario.Value = Session["Usuario"].ToString();
            TxtCorreoOriginal.Text = DsDatosPersona.Tables["Datos"].Rows[0]["Correo"].ToString();
            TxtUsuarioOriginal.Text = Session["Usuario"].ToString();
            TxtFecNac.Value = string.Format("{0:yyyy-MM-dd}", DsDatosPersona.Tables["Datos"].Rows[0]["Fecha_Nacimiento"]) ;
            if (DsDatosPersona.Tables["Datos"].Rows[0]["Universidad"].ToString() != "")
            {
                CboUniverisidad.SelectedValue = DsDatosPersona.Tables["Datos"].Rows[0]["UniversidadId"].ToString();
                CboUniverisidad.Text = DsDatosPersona.Tables["Datos"].Rows[0]["Universidad"].ToString();
            }
            DsDatosPersona.Clear();

        }



        private void CboDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboDepartamento.SelectedIndex != 0)
            {
                CboMunicipio.ClearSelection();
                CboMunicipio.Items.Clear();
                ClUtilitarios.Fill_DropDownAsp(ClCatalogos.Catalogo_Municipio(Session["Idioma"].ToString(), Convert.ToInt32(CboDepartamento.SelectedValue)), CboMunicipio, "Id", "Datos");
                ClUtilitarios.AgregarSeleccioneCombo(CboMunicipio, ClTraductor.BuscaString(Session["Idioma"].ToString(), "50"), Session["Idioma"].ToString());
            }
            else
            {
                CboMunicipio.ClearSelection();
                CboMunicipio.Items.Clear();
            }
        }

        private void CboPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboPais.SelectedIndex != 0)
            {
                CboDepartamento.ClearSelection();
                CboMunicipio.ClearSelection();
                CboDepartamento.Items.Clear();
                CboMunicipio.Items.Clear();
                ClUtilitarios.Fill_DropDownAsp(ClCatalogos.Catalogo_Departamento(Session["Idioma"].ToString(), Convert.ToInt32(CboPais.SelectedValue)), CboDepartamento, "Id", "Datos");
                ClUtilitarios.AgregarSeleccioneCombo(CboDepartamento, ClTraductor.BuscaString(Session["Idioma"].ToString(), "49"), Session["Idioma"].ToString());
                
            }
            else
            {
                CboDepartamento.ClearSelection();
                CboMunicipio.ClearSelection();
                CboDepartamento.Items.Clear();
                CboMunicipio.Items.Clear();
                
            }
            
        }


        private void ImgEsp_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Session["Idioma"] = "es-GT";
            Traduce();
        }

        private void ImgEng_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Session["Idioma"] = "en-US";
            Traduce();
        }
        void Traduce()
        {
            DivErrr.Visible = false;
            DivNoErr.Visible = false;
            LblSubTitulo.Text = ClTraductor.BuscaString(Session["Idioma"].ToString(), "41");
            LblAlias.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "42");
            LblNombres.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "43");
            LblApellidos.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "44");
            LblGenero.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "45");
            LblId.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "46");
            LblDireccion.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "47");
            LblPais.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "48");
            LblDepartamento.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "49");
            LblMunicipio.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "50");
            LblTelCasa.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "51");
            LblTelMovil.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "52");
            LblUniversidad.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "53");
            LblNoColegiado.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "54");
            LblTitulo.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "56");
            LblFotoPerfil.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "57");
            LblFotoTitulo.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "58");
            LblCorreo.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "59");
            LblFecNac.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "60");
            BtnGrabar.Text = ClTraductor.BuscaString(Session["Idioma"].ToString(), "71");
            lblUsuario.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "1");
            LblPaisUni.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "48") + " " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "53");

            //Combos
            ClUtilitarios.Fill_DropDownAsp(ClCatalogos.Catalogo_Alias(Session["Idioma"].ToString(),1), CboAlias, "Id", "Datos");
            ClUtilitarios.Fill_DropDownAsp(ClCatalogos.Catalogo_Genero(Session["Idioma"].ToString()), CboGenero, "Id", "Datos");
            ClUtilitarios.Fill_DropDownAsp(ClCatalogos.Catalogo_Pais(Session["Idioma"].ToString()), CboPais, "Id", "Datos");
            ClUtilitarios.AgregarSeleccioneCombo(CboPais, ClTraductor.BuscaString(Session["Idioma"].ToString(), "48"), Session["Idioma"].ToString());
            CboMunicipio.Items.Clear();
            CboDepartamento.Items.Clear();
            ClUtilitarios.Fill_DropDownAsp(ClCatalogos.Catalogo_Pais(Session["Idioma"].ToString()), CboPaisUni, "Id", "Datos");
            ClUtilitarios.AgregarSeleccioneCombo(CboPaisUni, ClTraductor.BuscaString(Session["Idioma"].ToString(), "48"), Session["Idioma"].ToString());
            CboUniverisidad.Items.Clear();
            BtnGrabar.Attributes["data-loading-text"] = ClTraductor.BuscaString(Session["Idioma"].ToString(), "94");
            TxtFotoPerfil.Localization.Select = ClTraductor.BuscaString(Session["Idioma"].ToString(), "96");
            TxtFotoPerfil.Localization.Cancel = ClTraductor.BuscaString(Session["Idioma"].ToString(), "98");
            TxtFotoPerfil.Localization.Remove = ClTraductor.BuscaString(Session["Idioma"].ToString(), "97");
            TxtFotoTitulo.Localization.Select = ClTraductor.BuscaString(Session["Idioma"].ToString(), "96");
            TxtFotoTitulo.Localization.Cancel = ClTraductor.BuscaString(Session["Idioma"].ToString(), "98");
            TxtFotoTitulo.Localization.Remove = ClTraductor.BuscaString(Session["Idioma"].ToString(), "97");
        }

        bool Valida()
        {
            DivErrr.Visible = false;
            DivNoErr.Visible = false;
            string LblMensaje = "";
            bool HayError = false;


            if (TxtNombres.Value == "")
            {
                if (LblMensaje == "")
                    LblMensaje = ClTraductor.BuscaString(Session["Idioma"].ToString(), "61");
                else
                    LblMensaje = LblMensaje + ", " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "61");
                HayError = true;
            }
            if (TxtApellidos.Value == "")
            {
                if (LblMensaje == "")
                    LblMensaje = ClTraductor.BuscaString(Session["Idioma"].ToString(), "62");
                else
                    LblMensaje = LblMensaje + ", " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "62");
                HayError = true;
            }
            if (TxtIdNo.Value == "")
            {
                if (LblMensaje == "")
                    LblMensaje = ClTraductor.BuscaString(Session["Idioma"].ToString(), "63");
                else
                    LblMensaje = LblMensaje + ", " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "63");
                HayError = true;
            }
            if (TxtDireccion.Value == "")
            {
                if (LblMensaje == "")
                    LblMensaje = ClTraductor.BuscaString(Session["Idioma"].ToString(), "64");
                else
                    LblMensaje = LblMensaje + ", " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "64");
                HayError = true;
            }
            if (CboPais.Text == "" || CboPais.SelectedIndex == 0)
            {
                if (LblMensaje == "")
                    LblMensaje = ClTraductor.BuscaString(Session["Idioma"].ToString(), "65");
                else
                    LblMensaje = LblMensaje + ", " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "65");
                HayError = true;
            }
            if (CboDepartamento.Text == "" || CboDepartamento.SelectedIndex == 0)
            {
                if (LblMensaje == "")
                    LblMensaje = ClTraductor.BuscaString(Session["Idioma"].ToString(), "66");
                else
                    LblMensaje = LblMensaje + ", " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "66");
                HayError = true;
            }
            if (CboMunicipio.Text == "" || CboMunicipio.SelectedIndex == 0)
            {
                if (LblMensaje == "")
                    LblMensaje = ClTraductor.BuscaString(Session["Idioma"].ToString(), "67");
                else
                    LblMensaje = LblMensaje + ", " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "67");
                HayError = true;
            }
            if (TxtTelMovil.Value == "")
            {
                if (LblMensaje == "")
                    LblMensaje = ClTraductor.BuscaString(Session["Idioma"].ToString(), "68");
                else
                    LblMensaje = LblMensaje + ", " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "68");
                HayError = true;
            }
            if (TxtCorreo.Value == "")
            {
                if (LblMensaje == "")
                    LblMensaje = ClTraductor.BuscaString(Session["Idioma"].ToString(), "69");
                else
                    LblMensaje = LblMensaje + ", " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "69");
                HayError = true;
            }
            if (TxtFecNac.Value == "")
            {
                if (LblMensaje == "")
                    LblMensaje = ClTraductor.BuscaString(Session["Idioma"].ToString(), "70");
                else
                    LblMensaje = LblMensaje + ", " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "70");
                HayError = true;
            }
            if ((TxtCorreo.Value != TxtCorreoOriginal.Text) &&  (ClUsuario.Existe_Correo(TxtCorreo.Value) == 1))
            {
                if (LblMensaje == "")
                    LblMensaje = ClTraductor.BuscaString(Session["Idioma"].ToString(), "72");
                else
                    LblMensaje = LblMensaje + ", " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "72");
                HayError = true;
            }
            if ((TxtUsuario.Value != TxtUsuarioOriginal.Text) && (ClUsuario.ExisteUsuario(TxtUsuario.Value) == 1))
            {
                if (LblMensaje == "")
                    LblMensaje = ClTraductor.BuscaString(Session["Idioma"].ToString(), "72");
                else
                    LblMensaje = LblMensaje + ", " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "72");
                HayError = true;
            }
            
            if ((TxtFotoPerfil.UploadedFiles.Count > 0) && (TxtFotoPerfil.MaxFileSize > 2097152))
            {
                if (LblMensaje == "")
                    LblMensaje = ClTraductor.BuscaString(Session["Idioma"].ToString(), "74");
                else
                    LblMensaje = LblMensaje + ", " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "74");
                HayError = true;
            }
            if ((TxtFotoTitulo.UploadedFiles.Count > 0) && (TxtFotoTitulo.MaxFileSize > 2097152))
            {
                if (LblMensaje == "")
                    LblMensaje = ClTraductor.BuscaString(Session["Idioma"].ToString(), "75");
                else
                    LblMensaje = LblMensaje + ", " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "75");
                HayError = true;
            }
            if (HayError == true)
            {
                DivErrr.Visible = true;
                LblErrMsg.Text = LblMensaje;
                return false;
            }
            else
                return true;
               

        }
    }
}