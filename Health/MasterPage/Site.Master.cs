using System;
using Health.Clases;
using System.Data;

namespace Health.MasterPage
{
    public partial class Site : System.Web.UI.MasterPage
    {
        Cl_Persona ClPersona;
        Cl_Traductor ClTraductor;
        Cl_Usuario ClUsuario;
        Cl_Clinica ClClinica;
        protected void Page_Load(object sender, EventArgs e)
        {
            ClPersona = new Cl_Persona();
            ClTraductor = new Cl_Traductor();
            ClUsuario = new Cl_Usuario();
            ClClinica = new Cl_Clinica();

            if (!IsPostBack)
            {
                if (Session["Paciente"].ToString() == "0")
                {
                    if (Session["PersonaId"].ToString() != "")
                    {
                        DataSet DsArchivo = new DataSet();
                        DsArchivo = ClPersona.Get_Datos_Persona(Convert.ToInt32(Session["PersonaId"]), Session["Idioma"].ToString());
                        LblNombreUsuario.Text = DsArchivo.Tables["DATOS"].Rows[0]["Nombre"].ToString();
                        if (DsArchivo.Tables["DATOS"].Rows[0]["Foto_Perfil"].ToString() != "")
                        {
                            byte[] bytes = (byte[])DsArchivo.Tables["DATOS"].Rows[0]["Foto_Perfil"];
                            ImgPerfil.Src = "data:image/png;base64," + Convert.ToBase64String(bytes);
                        }
                        DsArchivo.Clear();

                        if (Convert.ToInt32(Session["ClinicaId"]) > 0)
                        {
                            DataSet DsLogoClinica = new DataSet();
                            DsLogoClinica = ClClinica.Get_Clinca(Convert.ToInt32(Session["ClinicaId"]));
                            LblNomClinica.Text = DsLogoClinica.Tables["DATOS"].Rows[0]["Nombre"].ToString();
                            if (DsLogoClinica.Tables["DATOS"].Rows[0]["Logo"].ToString() != "")
                            {
                                byte[] bytes = (byte[])DsLogoClinica.Tables["DATOS"].Rows[0]["Logo"];
                                ImgLogoClinica.Src = "data:image/png;base64," + Convert.ToBase64String(bytes);
                            }
                            DsLogoClinica.Clear();
                        }
                        Permisos(Convert.ToInt32(Session["UsuarioId"]));
                    }
                    if (Convert.ToInt32(Session["TipoUsuarioId"]) != 5)
                        VerificaClnica();
                }
                Traduce();
            }
        }

        void Traduce()
        {
            LblPerfil.Text = ClTraductor.BuscaString(Session["Idioma"].ToString(), "41");
            lblMenuCambioClave.Text = ClTraductor.BuscaString(Session["Idioma"].ToString(), "30");
            lblMenuClinica.Text = ClTraductor.BuscaString(Session["Idioma"].ToString(), "82");
            lblMenuUsuarios.Text = ClTraductor.BuscaString(Session["Idioma"].ToString(), "84") + "s";
            lblMenuPermisos.Text = ClTraductor.BuscaString(Session["Idioma"].ToString(), "99");
            lblMenuDoc.Text = ClTraductor.BuscaString(Session["Idioma"].ToString(), "104");
        }

        void VerificaClnica()
        {
            int HayClinica = ClClinica.TieneClinica(Convert.ToInt32(Session["ClienteId"]));
            if (HayClinica == 0)
            {
                sidebar.Visible = false;
            }
            else
            {
                sidebar.Visible = true;
            }
        }

        public void Permisos(int UsuarioId)
        {
            ClUsuario = new Cl_Usuario();
            DataSet ds = ClUsuario.Get_Permisos(UsuarioId);
            for (int i = 0; i <= ds.Tables["DATOS"].Rows.Count - 1; i++)
            {
                switch (Convert.ToInt32(ds.Tables["DATOS"].Rows[i]["FormaId"]))
                {
                    case 1: //Perfil
                        LnkPerfil.Visible = true;
                        break;
                    case 2: //Usuarios
                        System.Web.UI.HtmlControls.HtmlGenericControl liMenuUsuarios;
                        liMenuUsuarios = (System.Web.UI.HtmlControls.HtmlGenericControl)FindControl("liMenuUsuarios");
                        liMenuUsuarios.Visible = true;
                        break;
                    case 3: //Permisos
                        System.Web.UI.HtmlControls.HtmlGenericControl liMenuPermisos;
                        liMenuPermisos = (System.Web.UI.HtmlControls.HtmlGenericControl)FindControl("liMenuPermisos");
                        liMenuPermisos.Visible = true;
                        break;
                    case 4: //Cambio de Clave
                        System.Web.UI.HtmlControls.HtmlGenericControl liMenuCambioClave;
                        liMenuCambioClave = (System.Web.UI.HtmlControls.HtmlGenericControl)FindControl("liMenuCambioClave");
                        liMenuCambioClave.Visible = true;
                        break;
                    case 5: //Clincas
                        System.Web.UI.HtmlControls.HtmlGenericControl liMenuClinica;
                        liMenuClinica = (System.Web.UI.HtmlControls.HtmlGenericControl)FindControl("liMenuClinica");
                        liMenuClinica.Visible = true;
                        break;
                    case 6: //Doctores
                        System.Web.UI.HtmlControls.HtmlGenericControl liMenuDoctor;
                        liMenuDoctor = (System.Web.UI.HtmlControls.HtmlGenericControl)FindControl("liMenuDoctor");
                        liMenuDoctor.Visible = true;
                        break;
                }
            }

        }
    }
}