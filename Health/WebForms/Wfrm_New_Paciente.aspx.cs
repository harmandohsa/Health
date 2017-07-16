using Health.Clases;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Health.WebForms
{
    public partial class Wfrm_New_Paciente : System.Web.UI.Page
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

            BtnGrabar.Click += BtnGrabar_Click;

            ImageButton ImgEsp;
            ImgEsp = (ImageButton)Master.FindControl("ImgEsp");
            ImgEsp.Click += ImgEsp_Click;

            ImageButton ImgEng;
            ImgEng = (ImageButton)Master.FindControl("ImgEng");
            ImgEng.Click += ImgEng_Click;



            Traduce();
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

        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            if (Valida() == true)
            {
                int PersonaId = ClPersona.Get_Max_Persona();
                ClPersona.Insert_Persona_Paciente(PersonaId, TxtNombres.Value, TxtApellidos.Value, Convert.ToInt32(CboGenero.SelectedValue),TxtTelMovil.Value, Convert.ToDateTime(TxtFecNac.Value));
                int UsuarioId = ClUsuario.Get_Max_Usuario();
                string Clave = ClUtilitarios.Encrypt(ClUtilitarios.GenerarPass(6, 10), true);
                ClUsuario.Insert_Usuario(UsuarioId, 0, 5, TxtCorreo.Value, Clave, PersonaId);
                ClUsuario.Create_Permisos(UsuarioId,5);
                string Asunto = ClTraductor.BuscaString(Session["Idioma"].ToString(), "91");
                string Mensaje = "";
                Mensaje = "<body><table><tr><td>" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "92") + " " + TxtCorreo.Value + " " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "21") + " " + Clave + "</td></tr></table>";
                ClUtilitarios.EnvioCorreo(TxtCorreo.Value, TxtNombres.Value + " " + TxtApellidos.Value, Asunto, Mensaje, 0, "", "");
                Session["ClinicaId"] = 0;
                Session["UsuarioId"] = UsuarioId;
                Session["Usuario"] = TxtCorreo.Value;
                Session["PersonaId"] = PersonaId;
                Session["Fase_ClienteId"] = 0;
                Session["CntClinica"] = 0;
                Session["CntDoctor"] = 0;
                Session["ClienteId"] = 0;
                Session["TipoUsuarioId"] = 5;
                Response.Redirect("~/WebForms/Wfrm_Inicio.aspx");
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowPopup('', '" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "76") + "','success','" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "9") + "');", true);
            }
        }

        bool Valida()
        {
            DivErrr.Visible = false;
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
            LblSubTitulo.Text = ClTraductor.BuscaString(Session["Idioma"].ToString(), "108");
            LblNombres.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "43");
            LblApellidos.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "44");
            LblGenero.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "45");
            LblTelMovil.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "52");
            LblCorreo.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "59");
            LblFecNac.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "60");
            BtnGrabar.Text = ClTraductor.BuscaString(Session["Idioma"].ToString(), "71");
            ClUtilitarios.Fill_DropDownAsp(ClCatalogos.Catalogo_Genero(Session["Idioma"].ToString()), CboGenero, "Id", "Datos");
        }

    }
}