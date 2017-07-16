using System;
using System.Data;
using System.Web.UI.WebControls;
using Health.Clases;
using System.Web;
using System.Web.UI;

namespace Health.WebForms
{
    public partial class Wfrm_NuevaCita : System.Web.UI.Page
    {
        Cl_Usuario ClUsuario;
        Cl_Traductor ClTraductor;
        Cl_Catalogos ClCatalogos;
        Cl_Utilitarios ClUtilitarios;
        Cl_Clinica ClClinica;

        protected void Page_Load(object sender, EventArgs e)
        {
            ClUsuario = new Cl_Usuario();
            ClTraductor = new Cl_Traductor();
            ClCatalogos = new Cl_Catalogos();
            ClUtilitarios = new Cl_Utilitarios();
            ClClinica = new Cl_Clinica();
            GrdMedicos.NeedDataSource += GrdMedicos_NeedDataSource;
            CboEspecialidad.SelectedIndexChanged += CboEspecialidad_SelectedIndexChanged;
            GrdMedicos.ItemCommand += GrdMedicos_ItemCommand;

            ImageButton ImgEng;
            ImgEng = (ImageButton)Master.FindControl("ImgEng");
            ImgEng.Click += ImgEng_Click;

            ImageButton ImgEsp;
            ImgEsp = (ImageButton)Master.FindControl("ImgEsp");
            ImgEsp.Click += ImgEsp_Click;

            if (Session["UsuarioId"] == null)
            {
                Response.Redirect("~/Wfrm_Login.aspx");
            }
            else if (!IsPostBack)
            {

                DataSet dsPermisos = ClUsuario.Get_Roles_Forma_Usuario(Convert.ToInt32(Session["UsuarioId"]), 7);
                if (Convert.ToInt32(dsPermisos.Tables["Datos"].Rows[0]["Editar"]) == 0)
                {
                }
                if (Convert.ToInt32(dsPermisos.Tables["Datos"].Rows[0]["Insertar"]) == 0)
                {
                }
                if (Convert.ToInt32(dsPermisos.Tables["Datos"].Rows[0]["Eliminar"]) == 0)
                {

                }
                dsPermisos.Clear();
                Traduce();
            }

        }

        private void GrdMedicos_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "CmdPerfil")
            {
                RadWindowDetalle.Title = ClTraductor.BuscaString(Session["Idioma"].ToString(), "104");
                RadWindowDetalle.NavigateUrl = "~/WebForms/Wfrm_PerfilDoctor.aspx?Benutzer=" + HttpUtility.UrlEncode(ClUtilitarios.Encrypt(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["UsuarioId"].ToString(), true)) + "&Person=" + HttpUtility.UrlEncode(ClUtilitarios.Encrypt(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["PersonaId"].ToString(), true)) + "";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "function f(){$find('" + RadWindowDetalle.ClientID + "').show();Sys.Application.remove_load(f);}Sys.Application.add_load(f);", true);
            }
            if (e.CommandName == "CmdCita")
            {
                RadWindowDetalle.Title = ClTraductor.BuscaString(Session["Idioma"].ToString(), "104");
                RadWindowDetalle.NavigateUrl = "~/WebForms/Wfrm_PerfilDoctor.aspx?Benutzer=" + HttpUtility.UrlEncode(ClUtilitarios.Encrypt(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["UsuarioId"].ToString(), true)) + "&Person=" + HttpUtility.UrlEncode(ClUtilitarios.Encrypt(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["PersonaId"].ToString(), true)) + "";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "function f(){$find('" + RadWindowDetalle.ClientID + "').show();Sys.Application.remove_load(f);}Sys.Application.add_load(f);", true);
            }
        }

        private void CboEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((CboEspecialidad.SelectedValue != "") || (CboEspecialidad.SelectedValue != "0"))
            {
                TxtEspecialidadId.Text = CboEspecialidad.SelectedValue;
                GrdMedicos.Rebind();
            }
        }

        private void GrdMedicos_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            ClUtilitarios.LlenaGrid(ClClinica.Get_Doctores_Activos(Session["Idioma"].ToString(),Convert.ToInt32(TxtEspecialidadId.Text)), GrdMedicos, Session["Idioma"].ToString());
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
            LblSubTitulo.Text = ClTraductor.BuscaString(Session["Idioma"].ToString(), "109");
            LblEspecialidad.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "111");
            ClUtilitarios.Fill_DropDownAsp(ClCatalogos.Get_Especialidades_Activas(Session["Idioma"].ToString()), CboEspecialidad, "Id", "Datos");
            ClUtilitarios.AgregarSeleccioneCombo(CboEspecialidad, ClTraductor.BuscaString(Session["Idioma"].ToString(), "111"), Session["Idioma"].ToString());
        }


    }
}