using System;
using System.Web.UI.WebControls;
using Health.Clases;

namespace Health.WebForms
{
    public partial class Wfrm_Inicio : System.Web.UI.Page
    {
        Cl_Traductor ClTraductor;
        Cl_Utilitarios ClUtilitarios;

        protected void Page_Load(object sender, EventArgs e)
        {
            ClTraductor = new Cl_Traductor();
            ClUtilitarios = new Cl_Utilitarios();

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
                BgClinica.Attributes.Add("data-badge", "1");
                BgDoctor.Attributes.Add("data-badge", "2");
                BgUsuarios.Attributes.Add("data-badge", "3");
                BgPaciente.Attributes.Add("data-badge", "4");
                BgCita.Attributes.Add("data-badge", "5");
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
            lblTitDash1.Text = ClTraductor.BuscaString(Session["Idioma"].ToString(), "77");
            wExpand.Title = ClTraductor.BuscaString(Session["Idioma"].ToString(), "78");
            wCollapse.Title = ClTraductor.BuscaString(Session["Idioma"].ToString(), "79");
            wClose.Title = ClTraductor.BuscaString(Session["Idioma"].ToString(), "80");
            ImgClinica.ToolTip = ClTraductor.BuscaString(Session["Idioma"].ToString(), "81") + " " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "82");
            ImgDoctor.ToolTip  = ClTraductor.BuscaString(Session["Idioma"].ToString(), "81") + " " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "83");
            ImgUsuario.ToolTip = ClTraductor.BuscaString(Session["Idioma"].ToString(), "81") + " " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "84");
            ImgPaciente.ToolTip = ClTraductor.BuscaString(Session["Idioma"].ToString(), "81") + " " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "85");
            ImgCita.ToolTip = ClTraductor.BuscaString(Session["Idioma"].ToString(), "81") + " " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "86");
        }
    }
}