using Health.Clases;
using System;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;

namespace Health.WebForms
{
    public partial class Wfrm_Usuarios : System.Web.UI.Page
    {
        Cl_Traductor ClTraductor;
        Cl_Catalogos ClCatalogos;
        Cl_Usuario ClUsuario;
        Cl_Utilitarios ClUtilitarios;
        Cl_Persona ClPersona;

        protected void Page_Load(object sender, EventArgs e)
        {
            ClTraductor = new Cl_Traductor();
            ClCatalogos = new Cl_Catalogos();
            ClUsuario = new Cl_Usuario();
            ClUtilitarios = new Cl_Utilitarios();
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

            if (Session["UsuarioId"] == null)
            {
                Response.Redirect("~/Wfrm_Login.aspx");
            }
            else if (!IsPostBack)
            {
                Traduce();
                DataSet dsPermisos = ClUsuario.Get_Roles_Forma_Usuario(Convert.ToInt32(Session["UsuarioId"]), 2);
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
            CargaUsuarios();
            TxtIdioma.Value = Session["Idioma"].ToString();


        }

        

        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            
            if (Valida() == true)
            {

                int PersonaId = ClPersona.Get_Max_Persona();
                int UniversidadId = 0;
                ClPersona.Insert_Persona(PersonaId, Convert.ToInt32(CboAlias.SelectedValue), TxtNombres.Value, TxtApellidos.Value, Convert.ToInt32(CboGenero.SelectedValue), TxtIdNo.Value, TxtDireccion.Value, Convert.ToInt32(CboMunicipio.SelectedValue), TxtTelCasa.Value, TxtTelMovil.Value, UniversidadId, "", "", Convert.ToDateTime(TxtFecNac.Value));
                int UsuarioId = ClUsuario.Get_Max_Usuario();
                string Clave = ClUtilitarios.Encrypt(ClUtilitarios.GenerarPass(6, 10), true);
                ClUsuario.Insert_Usuario(UsuarioId, Convert.ToInt32(Session["ClienteId"]), Convert.ToInt32(CboTipoUsuario.SelectedValue), TxtCorreo.Value, Clave, PersonaId);
                ClUsuario.Create_Permisos(UsuarioId, Convert.ToInt32(CboTipoUsuario.SelectedValue));
                string Asunto = ClTraductor.BuscaString(Session["Idioma"].ToString(), "91");
                string Mensaje = Mensaje = "<body><table><tr><td>" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "92") + " " + TxtCorreo.Value + " " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "21") + " " + Clave + "</td></tr></table>";
                ClUtilitarios.EnvioCorreo(TxtCorreo.Value, TxtNombres.Value + " " + TxtApellidos.Value, Asunto, Mensaje, 0, "", "");
                Limpiar();
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('', '" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "76") + "','success','" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "9") + "');", true);
                CargaUsuarios();
            }
        }

        void Limpiar()
        {
            CboAlias.ClearSelection();
            TxtNombres.Value = "";
            TxtApellidos.Value = "";
            CboGenero.ClearSelection();
            TxtIdNo.Value = "";
            TxtDireccion.Value = "";
            CboMunicipio.ClearSelection();
            CboDepartamento.ClearSelection();
            CboPais.ClearSelection();
            TxtTelCasa.Value = "";
            TxtTelMovil.Value = "";
            TxtCorreo.Value = "";
            TxtFecNac.Value = "";
            CboTipoUsuario.ClearSelection();
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
            if (CboTipoUsuario.Text == "" || CboTipoUsuario.SelectedIndex == 0)
            {
                if (LblMensaje == "")
                    LblMensaje = ClTraductor.BuscaString(Session["Idioma"].ToString(), "65");
                else
                    LblMensaje = LblMensaje + ", " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "65");
                HayError = true;
            }
            if (ClUsuario.Existe_Correo(TxtCorreo.Value) == 1)
            {
                if (LblMensaje == "")
                    LblMensaje = ClTraductor.BuscaString(Session["Idioma"].ToString(), "72");
                else
                    LblMensaje = LblMensaje + ", " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "72");
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

        void CargaUsuarios()
        {
            DataSet ds = ClUsuario.Get_Usuarios(1);
            GrdLGE.DataSource = ds;
            GrdLGE.DataMember = "Datos";
            GrdLGE.DataBind();
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
            LblSubTitulo.Text = ClTraductor.BuscaString(Session["Idioma"].ToString(), "84") + "s";
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
            LblCorreo.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "59");
            LblFecNac.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "60");
            BtnGrabar.Text = ClTraductor.BuscaString(Session["Idioma"].ToString(), "71");
            lblTipoUsuario.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "89");

            //Combos
            ClUtilitarios.Fill_DropDownAsp(ClCatalogos.Catalogo_Alias(Session["Idioma"].ToString()), CboAlias, "Id", "Datos");
            ClUtilitarios.Fill_DropDownAsp(ClCatalogos.Catalogo_Genero(Session["Idioma"].ToString()), CboGenero, "Id", "Datos");
            ClUtilitarios.Fill_DropDownAsp(ClCatalogos.Catalogo_Pais(Session["Idioma"].ToString()), CboPais, "Id", "Datos");
            ClUtilitarios.AgregarSeleccioneCombo(CboPais, ClTraductor.BuscaString(Session["Idioma"].ToString(), "48"), Session["Idioma"].ToString());
            CboMunicipio.Items.Clear();
            CboDepartamento.Items.Clear();
            ClUtilitarios.Fill_DropDownAsp(ClCatalogos.Catalogo_TipoUsuario(Session["Idioma"].ToString(),1), CboTipoUsuario, "Id", "Datos");
            ClUtilitarios.AgregarSeleccioneCombo(CboTipoUsuario, ClTraductor.BuscaString(Session["Idioma"].ToString(), "89"), Session["Idioma"].ToString());
            TxtIdioma.Value = Session["Idioma"].ToString();
        }
    }
}