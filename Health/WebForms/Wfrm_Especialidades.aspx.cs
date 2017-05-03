using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Health.Clases;
using System.Data;

namespace Health.WebForms
{
    public partial class Wfrm_Especialidades : System.Web.UI.Page
    {
        Cl_Traductor ClTraductor;
        Cl_Catalogos ClCatalogos;
        Cl_Utilitarios ClUtilitarios;
        Cl_Persona ClPersona;
        Cl_Usuario ClUsuario;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            ClTraductor = new Cl_Traductor();
            ClCatalogos = new Cl_Catalogos();
            ClUtilitarios = new Cl_Utilitarios();
            ClPersona = new Cl_Persona();
            ClUsuario = new Cl_Usuario();

            BtnGrabar.Click += BtnGrabar_Click;
            GrdDetalle.NeedDataSource += GrdDetalle_NeedDataSource;

            if (Session["UsuarioId"] == null)
            {
                Response.Redirect("~/Wfrm_Login.aspx");
            }
            else if (!IsPostBack)
            {
                Traduce();
            }

        }

        private void GrdDetalle_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            
        }

        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            int UsuarioId = Convert.ToInt32(ClUtilitarios.Decrypt(HttpUtility.UrlDecode(Request.QueryString["Benutzer"].ToString()), true));
            DataSet ds = ClUsuario.GetDatosUsuarioId(UsuarioId, Session["Idioma"].ToString());
            int PersonaId = Convert.ToInt32(ds.Tables["Datos"].Rows[0]["PersonaId"]);
            ClPersona.Insert_Especialidad(PersonaId,Convert.ToInt32(CboEspecialidad.SelectedValue));
        }

        void Traduce()
        {
            LblSubTitulo.Text = ClTraductor.BuscaString(Session["Idioma"].ToString(), "105");
            ClUtilitarios.Fill_DropDownAsp(ClCatalogos.Catalogo_Especialidades(Session["Idioma"].ToString()),CboEspecialidad,"Id","Datos");
            BtnGrabar.Text = ClTraductor.BuscaString(Session["Idioma"].ToString(), "106");
        }

    }
}