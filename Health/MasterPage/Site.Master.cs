﻿using System;
using Health.Clases;
using System.Data;

namespace Health.MasterPage
{
    public partial class Site : System.Web.UI.MasterPage
    {
        Cl_Persona ClPersona;
        Cl_Traductor ClTraductor;
        Cl_Usuario ClUsuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            ClPersona = new Cl_Persona();
            ClTraductor = new Cl_Traductor();
            ClUsuario = new Cl_Usuario();

            if (!IsPostBack)
            {
                if (Session["PersonaId"].ToString() != "")
                {
                    DataSet DsArchivo = new DataSet();
                    DsArchivo = ClPersona.Get_Datos_Persona(Convert.ToInt32(Session["PersonaId"]));
                    LblNombreUsuario.Text = DsArchivo.Tables["DATOS"].Rows[0]["Nombre"].ToString();
                    if (DsArchivo.Tables["DATOS"].Rows[0]["Foto_Perfil"].ToString() != "")
                    {
                        byte[] bytes = (byte[])DsArchivo.Tables["DATOS"].Rows[0]["Foto_Perfil"];
                        ImgPerfil.Src = "data:image/png;base64," + Convert.ToBase64String(bytes);
                    }
                    DsArchivo.Clear();
                    Permisos(Convert.ToInt32(Session["UsuarioId"]));
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
                }
            }

        }
    }
}