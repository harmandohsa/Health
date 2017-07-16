using System;
using System.Web;
using System.Web.UI;
using Health.Clases;
using System.Data;

namespace Health
{
    public partial class Wfrm_Login : System.Web.UI.Page
    {
        Cl_Traductor ClTraductor;
        Cl_Usuario ClUsuario;
        Cl_Utilitarios ClUtilitarios;
        protected void Page_Load(object sender, EventArgs e)
        {
            ClTraductor = new Cl_Traductor();
            ClUsuario = new Cl_Usuario();
            ClUtilitarios = new Cl_Utilitarios();



            ImgEng.Click += ImgEng_Click;
            ImgEsp.Click += ImgEsp_Click;
            BtnIngresar.ServerClick += BtnIngresar_ServerClick;
            LblForgot.ServerClick += LblForgot_ServerClick;
            BtnCrearUsuario.ServerClick += BtnCrearUsuario_ServerClick;

            if (!IsPostBack)
            {
                string Clave = ClUtilitarios.Encrypt("1", true);
                Session["Idioma"] = "es-GT";
                Traducir();
            }
        }

        private void BtnCrearUsuario_ServerClick(object sender, EventArgs e)
        {
            Session["Paciente"] = "1";
            Response.Redirect("~/WebForms/Wfrm_New_Paciente.aspx");
        }

        private void LblForgot_ServerClick(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ForgotPass('" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "4") + "','" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "17") + "',  '" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "8") + "');", true);
        }

        private void BtnIngresar_ServerClick(object sender, EventArgs e)
        {
            Ingreso();
        }

        void Ingreso()
        {
            Session["Paciente"] = "0";
            if (txtUsuario.Value == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "10") + "', '" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "8") + "','error','" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "9") + "');", true);
            }
            else if (txtClave.Value == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "10") + "', '" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "11") + "','error','" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "9") + "');", true);
            }
            else if (ClUsuario.ExisteUsuario(txtUsuario.Value) == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "10") + "', '" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "12") + "','error','" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "9") + "');", true);
            }
            else
            {
                int TipoUsuarioId = ClUsuario.Get_TipoUsuario(txtUsuario.Value);
                DataSet DatosUsuario = ClUsuario.GetDatosUsuario(txtUsuario.Value.ToString());
                if (txtClave.Value != ClUtilitarios.Decrypt(DatosUsuario.Tables["Datos"].Rows[0]["Clave"].ToString(), true))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "10") + "', '" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "13") + "','error','" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "9") + "');", true);
                    DatosUsuario.Clear();
                }
                else if (DatosUsuario.Tables["Datos"].Rows[0]["Estatus_UsuarioId"].ToString() == "2")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "10") + "', '" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "14") + "','error','" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "9") + "');", true);
                    DatosUsuario.Clear();
                }
                else if ((TipoUsuarioId != 5) &&  ((Convert.ToDateTime(DatosUsuario.Tables["Datos"].Rows[0]["Fecha_Alta"]) > ClUtilitarios.FechaDB())))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "10") + "', '" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "15") + "','error','" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "9") + "');", true);
                    DatosUsuario.Clear();
                }
                else if ((TipoUsuarioId != 5) && ((Convert.ToDateTime(DatosUsuario.Tables["Datos"].Rows[0]["Fecha_Vence"]) < ClUtilitarios.FechaDB())))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "10") + "', '" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "16") + "','error','" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "9") + "');", true);
                    DatosUsuario.Clear();
                }
                else
                {
                    if (TipoUsuarioId != 5)
                    {
                        Session["UsuarioId"] = DatosUsuario.Tables["Datos"].Rows[0]["UsuarioId"].ToString();
                        Session["Usuario"] = DatosUsuario.Tables["Datos"].Rows[0]["Usuario"].ToString();
                        Session["PersonaId"] = DatosUsuario.Tables["Datos"].Rows[0]["PersonaId"].ToString();
                        Session["Fase_ClienteId"] = DatosUsuario.Tables["Datos"].Rows[0]["Fase_ClienteId"].ToString();
                        Session["CntClinica"] = DatosUsuario.Tables["Datos"].Rows[0]["CntClinica"].ToString();
                        Session["CntDoctor"] = DatosUsuario.Tables["Datos"].Rows[0]["CntDoctor"].ToString();
                        Session["ClienteId"] = DatosUsuario.Tables["Datos"].Rows[0]["ClienteId"].ToString();
                        Session["TipoUsuarioId"] = DatosUsuario.Tables["Datos"].Rows[0]["Tipo_UsuarioId"].ToString();
                    }
                    else
                    {
                        Session["UsuarioId"] = DatosUsuario.Tables["Datos"].Rows[0]["UsuarioId"].ToString();
                        Session["Usuario"] = DatosUsuario.Tables["Datos"].Rows[0]["Usuario"].ToString();
                        Session["PersonaId"] = DatosUsuario.Tables["Datos"].Rows[0]["PersonaId"].ToString();
                        Session["Fase_ClienteId"] = 0;
                        Session["CntClinica"] = 0;
                        Session["CntDoctor"] = 0;
                        Session["ClienteId"] = 0;
                        Session["TipoUsuarioId"] = DatosUsuario.Tables["Datos"].Rows[0]["Tipo_UsuarioId"].ToString();
                    }
                    


                    if (DatosUsuario.Tables["Datos"].Rows[0]["Cambio_Clave"].ToString() == "1")
                    {
                        DatosUsuario.Clear();
                        Response.Redirect("WebForms/Wfrm_CambioClave.aspx?appel=" + HttpUtility.UrlEncode(ClUtilitarios.Encrypt("1", true) + ""));
                    }
                    else
                    {
                        DatosUsuario.Clear();
                        DataSet DsRelacion_Usuario_Clinica = ClUsuario.Get_Relacion_Clinica_Usuario(Convert.ToInt32(Session["UsuarioId"]));
                        int CntClinicasUsuario = DsRelacion_Usuario_Clinica.Tables["Datos"].Rows.Count;
                        if (CntClinicasUsuario == 0)
                        {
                            Session["ClinicaId"] = 0;
                        }
                        else if (CntClinicasUsuario == 1)
                        {
                            Session["ClinicaId"] = DsRelacion_Usuario_Clinica.Tables["Datos"].Rows[0]["ClinicaId"].ToString();
                        }
                        DsRelacion_Usuario_Clinica.Clear();
                        Response.Redirect("~/WebForms/Wfrm_Inicio.aspx");
                    }
                        
                    
                }
                    
            }
            
        }

        private void ImgEsp_Click(object sender, ImageClickEventArgs e)
        {
            Session["Idioma"] = "es-GT";
            Traducir();
        }

        private void ImgEng_Click(object sender, ImageClickEventArgs e)
        {
            Session["Idioma"] = "en-US";
            Traducir();
        }

        void Traducir()
        {
            LblUsuario.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "1");
            h4Titulo.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "2");
            LblClave.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "3");
            LblForgot.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "4");
            BtnIngresar.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "5");
            ImgEsp.ToolTip = ClTraductor.BuscaString(Session["Idioma"].ToString(), "6");
            ImgEng.ToolTip = ClTraductor.BuscaString(Session["Idioma"].ToString(), "7");
            BtnCrearUsuario.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "107");
        }

        void EnviarClave(string Usuario)
        {
            if (ClUsuario.ExisteUsuario(Usuario) == 0)
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "10") + "', '" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "12") + "','error','" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "9") + "');", true);
            else
            {
                string Clave = ClUtilitarios.GenerarPass(6, 10);
                ClUsuario.CambiaClave(Usuario,ClUtilitarios.Encrypt(Clave,true),1);
                DataSet DatosUsuario = ClUsuario.GetDatosUsuario(Usuario);
                string Asunto = ClTraductor.BuscaString(Session["Idioma"].ToString(), "19");
                string Mensaje = Mensaje = "<body><table><tr><td>" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "20") + " " + Usuario + " " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "21") + " " + Clave + "</td></tr></table>";
                ClUtilitarios.EnvioCorreo(DatosUsuario.Tables["Datos"].Rows[0]["CorreoEnv"].ToString(), DatosUsuario.Tables["Datos"].Rows[0]["Persona"].ToString(), Asunto,Mensaje, 0, "", "");
                DatosUsuario.Clear();
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('', '" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "22") + "','success','" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "9") + "');", true);
            }
                
        }

        protected void BtnEnviaClave_Click(object sender, EventArgs e)
        {
            EnviarClave(txtUsuario.Value);
        }
    }
}