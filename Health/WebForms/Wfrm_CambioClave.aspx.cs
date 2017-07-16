using System;
using Health.Clases;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.UI;

namespace Health.WebForms
{
    public partial class Wfrm_CambioClave : System.Web.UI.Page
    {
        Cl_Traductor ClTraductor;
        Cl_Usuario ClUsuario;
        Cl_Utilitarios ClUtilitarios;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            

            ClTraductor = new Cl_Traductor();
            ClUsuario = new Cl_Usuario();
            ClUtilitarios = new Cl_Utilitarios();

            if (ClUtilitarios.Decrypt(HttpUtility.UrlDecode(Request.QueryString["appel"].ToString()), true) == "1")
            {
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

            

            ImageButton ImgEng;
            ImgEng = (ImageButton)Master.FindControl("ImgEng");
            ImgEng.Click += ImgEng_Click;

            ImageButton ImgEsp;
            ImgEsp = (ImageButton)Master.FindControl("ImgEsp");
            ImgEsp.Click += ImgEsp_Click;

            BtnChangePass.Click += BtnChangePass_Click;
            
            
            

            if (Session["UsuarioId"] == null)
            {
                Response.Redirect("~/Wfrm_Login.aspx");
            }
            else if (!IsPostBack)
            {
                Traduce();
                if (ClUtilitarios.Decrypt(HttpUtility.UrlDecode(Request.QueryString["appel"].ToString()), true) == "2")
                {
                    DataSet dsPermisos = ClUsuario.Get_Roles_Forma_Usuario(Convert.ToInt32(Session["UsuarioId"]), 2);
                    if (Convert.ToInt32(dsPermisos.Tables["Datos"].Rows[0]["Editar"]) == 0)
                    {
                        BtnChangePass.Enabled = false;
                    }
                    if (Convert.ToInt32(dsPermisos.Tables["Datos"].Rows[0]["Insertar"]) == 0)
                    {
                        BtnChangePass.Enabled = false;
                    }
                    if (Convert.ToInt32(dsPermisos.Tables["Datos"].Rows[0]["Eliminar"]) == 0)
                    {

                    }
                    dsPermisos.Clear();
                }
                
            }

        }

        private void BtnChangePass_Click(object sender, EventArgs e)
        {
            DivErrr.Visible = false;
            DivNoErr.Visible = false;
            if (Valida() == true)
            {
                
                DataSet DsDatosUsuario = ClUsuario.GetDatosUsuario(Session["Usuario"].ToString());
                string Clave = ClUtilitarios.Decrypt(DsDatosUsuario.Tables["Datos"].Rows[0]["Clave"].ToString(), true);
                DsDatosUsuario.Clear();
                if (TxtPassActual.Value != Clave)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowPopup('" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "10") + "', '" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "35") + "','error','" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "9") + "');", true);
                }
                else if (TxtPassNueva.Value != TxtPassConfNueva.Value)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowPopup('" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "10") + "', '" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "36") + "','error','" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "9") + "');", true);
                }
                else
                {
                    if (ClUtilitarios.Decrypt(HttpUtility.UrlDecode(Request.QueryString["appel"].ToString()), true) == "1")
                    {
                        ClUsuario.CambiaClave(Session["Usuario"].ToString(), ClUtilitarios.Encrypt(TxtPassNueva.Value,true), 0);
                        if ((Session["Fase_ClienteId"].ToString()  == "1"))
                            Response.Redirect("~/WebForms/Wfrm_Perfil.aspx?appel=" + HttpUtility.UrlEncode(ClUtilitarios.Encrypt("1", true) + ""));
                        else if  ((Session["Fase_ClienteId"].ToString() == "0") || (Session["Fase_ClienteId"].ToString() == "2"))
                            Response.Redirect("~/WebForms/Wfrm_Inicio.aspx");
                    }
                    else
                    {
                        ClUsuario.CambiaClave(Session["Usuario"].ToString(), ClUtilitarios.Encrypt(TxtPassNueva.Value, true), 0);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowPopup('" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "76") + "', '" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "40") + "','success','" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "9") + "');", true);
                    }
                        
                }
                
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
            DivNoErr.Visible = false;
            DivErrr.Visible = false;
            LblSubTitulo.Text = ClTraductor.BuscaString(Session["Idioma"].ToString(), "30");
            LblContActual.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "31");
            LblNuevaCont.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "32");
            LblConfCont.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "33");
            BtnChangePass.Text = ClTraductor.BuscaString(Session["Idioma"].ToString(), "34");
        }

        bool Valida()
        {
            DivErrr.Visible = false;
            string lblMensaje = "";
            bool HayError = false;

            if (TxtPassActual.Value == "")
            {
                if (lblMensaje == "")
                    lblMensaje = ClTraductor.BuscaString(Session["Idioma"].ToString(), "37");
                else
                    lblMensaje = lblMensaje + ", " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "37");
                HayError = true;
            }
            if (TxtPassNueva.Value == "")
            {
                if (lblMensaje == "")
                    lblMensaje = ClTraductor.BuscaString(Session["Idioma"].ToString(), "38");
                else
                    lblMensaje = lblMensaje + ", " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "38");
                HayError = true;
            }
            if (TxtPassConfNueva.Value == "")
            {
                if (lblMensaje == "")
                    lblMensaje = ClTraductor.BuscaString(Session["Idioma"].ToString(), "39");
                else
                    lblMensaje = lblMensaje + ", " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "39");
                HayError = true;
            }

            if (HayError == true)
            {
                DivErrr.Visible = true;
                LblErrMsg.Text = lblMensaje;
                return false;
            }
            else
                return true;
        }
    }
}