using Health.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Health.WebForms
{
    public partial class Wfrm_Clinica : System.Web.UI.Page
    {
        Cl_Traductor ClTraductor;

        protected void Page_Load(object sender, EventArgs e)
        {
            ClTraductor = new Cl_Traductor();

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
                Traduce();
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
            LblSubTitulo.Text = ClTraductor.BuscaString(Session["Idioma"].ToString(), "82");
            LblNombres.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "87");
            LblDireccion.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "47");
            LblPais.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "48");
            LblDepartamento.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "49");
            LblMunicipio.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "50");
            LblTelCasa.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "51");
            LblFotoLogo.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "88");
            BtnGrabar.Text = ClTraductor.BuscaString(Session["Idioma"].ToString(), "71");
        }
    }
}