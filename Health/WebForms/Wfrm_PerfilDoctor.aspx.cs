using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Health.Clases;

namespace Health.WebForms
{
    public partial class Wfrm_PerfilDoctor : System.Web.UI.Page
    {
        Cl_Persona ClPersona;
        Cl_Utilitarios ClUtilitarios;
        Cl_Traductor ClTraductor;
        Cl_Usuario ClUsuario;
        Cl_Cita ClCita;
        protected void Page_Load(object sender, EventArgs e)
        {
            ClPersona = new Cl_Persona();
            ClUtilitarios = new Cl_Utilitarios();
            ClTraductor = new Cl_Traductor();
            ClUsuario = new Cl_Usuario();
            ClCita = new Cl_Cita();

            BtnGrabar.Click += BtnGrabar_Click;

            if (Session["UsuarioId"] == null)
            {
                Response.Redirect("~/Wfrm_Login.aspx");
            }
            else if (!IsPostBack)
            {
                int PersonaId = Convert.ToInt32(ClUtilitarios.Decrypt(HttpUtility.UrlDecode(Request.QueryString["Person"].ToString()), true));
                DataSet DsArchivo = new DataSet();
                DsArchivo = ClPersona.Get_Datos_Persona(Convert.ToInt32(PersonaId), Session["Idioma"].ToString());
                //LblNombreUsuario.Text = DsArchivo.Tables["DATOS"].Rows[0]["Nombre"].ToString();
                if (DsArchivo.Tables["DATOS"].Rows[0]["Foto_Perfil"].ToString() != "")
                {
                    byte[] bytes = (byte[])DsArchivo.Tables["DATOS"].Rows[0]["Foto_Perfil"];
                    ImgPerfil.Src = "data:image/png;base64," + Convert.ToBase64String(bytes);
                    

                }
                LblNombreDato.InnerText = DsArchivo.Tables["DATOS"].Rows[0]["Nombres"] + " " + DsArchivo.Tables["DATOS"].Rows[0]["Apellidos"];
                DsArchivo.Clear();
                DataSet dsEspecialidad = ClPersona.Get_Especialidad_Usuario(PersonaId, Session["Idioma"].ToString());
                if (dsEspecialidad.Tables["Datos"].Rows.Count > 0)
                {
                    string Especialidades = "";
                    for (int i = 0; i < dsEspecialidad.Tables["Datos"].Rows.Count; i++)
                    {
                        if (Especialidades == "")
                            Especialidades = dsEspecialidad.Tables["Datos"].Rows[i]["Espe"].ToString();
                        else
                            Especialidades = Especialidades + ", " + dsEspecialidad.Tables["Datos"].Rows[i]["Espe"].ToString();
                    }
                    LblEspecialidadesDato.InnerText = Especialidades;
                }
                else
                    LblEspecialidadesDato.InnerText = "";
                Traduce();

                var localDateTime = DateTime.Now.ToString("yyyy-MM-dd");
                TxtFecCita.Value = localDateTime;

                var localTime = DateTime.Now.ToString("HH:mm");
                TxtHoraCita.Value = localTime;

            }
                
        }

        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            if (ValidaCita() == true)
            {
                int CitaId = ClCita.Get_Max_Cita();
                string Fecha = string.Format("{0:MM/dd/yyyy}", TxtFecCita.Value);
                string Hora = string.Format("{0:HH:mm:ss tt}", TxtHoraCita.Value);
                DateTime FecCita = Convert.ToDateTime(Fecha + Hora);
                ClCita.Insert_Cita(CitaId, Convert.ToInt32(Session["PersonaId"]), Convert.ToInt32(ClUtilitarios.Decrypt(HttpUtility.UrlDecode(Request.QueryString["Person"].ToString()), true)), FecCita);
            }
        }

        bool ValidaCita()
        {
            DivErrr.Visible = false;
            string Mensaje = "";
            bool HayError = false;

            if (TxtFecCita.Value == "")
            {
                if (Mensaje == "")
                    Mensaje = ClTraductor.BuscaString(Session["Idioma"].ToString(), "117");
                else
                    Mensaje = Mensaje + ", " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "117");
                HayError = true;
            }
            if (TxtHoraCita.Value == "")
            {
                if (Mensaje == "")
                    Mensaje = ClTraductor.BuscaString(Session["Idioma"].ToString(), "118");
                else
                    Mensaje = Mensaje + ", " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "118");
                HayError = true;
            }
            if ((TxtFecCita.Value != "") && (Convert.ToDateTime(TxtFecCita.Value) < DateTime.Now))
            {
                if (Mensaje == "")
                    Mensaje = ClTraductor.BuscaString(Session["Idioma"].ToString(), "119");
                else
                    Mensaje = Mensaje + ", " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "119");
                HayError = true;
            }
            if (HayError == true)
            {
                DivErrr.Visible = true;
                LblErrMsg.Text = Mensaje;
                return false;
            }
            else
                return true;
        }

        void Traduce()
        {
            LblTitulo.Text = ClTraductor.BuscaString(Session["Idioma"].ToString(), "113");
            LblNombre.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "87");
            LblEspecialidades.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "105");
            lblTituloCita.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "114");
            LblFecha.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "115");
            lblHora.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "116");
            BtnGrabar.Text = ClTraductor.BuscaString(Session["Idioma"].ToString(), "71");
        }
    }
}