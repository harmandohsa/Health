using Health.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Health.WebForms
{
    public partial class Wfrm_Clinica : System.Web.UI.Page
    {
        Cl_Traductor ClTraductor;
        Cl_Catalogos ClCatalogos;
        Cl_Utilitarios ClUtilitarios;
        Cl_Clinica ClClinica;
        Cl_Usuario ClUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            ClTraductor = new Cl_Traductor();
            ClCatalogos = new Cl_Catalogos();
            ClUtilitarios = new Cl_Utilitarios();
            ClClinica = new Cl_Clinica();
            ClUsuario = new Cl_Usuario();

            ImageButton ImgEng;
            ImgEng = (ImageButton)Master.FindControl("ImgEng");
            ImgEng.Click += ImgEng_Click;

            ImageButton ImgEsp;
            ImgEsp = (ImageButton)Master.FindControl("ImgEsp");
            ImgEsp.Click += ImgEsp_Click;
            CboPais.SelectedIndexChanged += CboPais_SelectedIndexChanged;
            CboDepartamento.SelectedIndexChanged += CboDepartamento_SelectedIndexChanged;
            BtnGrabar.Click += BtnGrabar_Click;
            GrdDetalle.NeedDataSource += GrdDetalle_NeedDataSource;
            GrdDetalle.ItemCommand += GrdDetalle_ItemCommand;

            if (Session["UsuarioId"] == null)
            {
                Response.Redirect("~/Wfrm_Login.aspx");
            }
            else if (!IsPostBack)
            {
                Traduce();
                ValidaGrabar();
            }
        }

        private void GrdDetalle_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "CmdEditar")
            {
                
                DataSet dsClinica = ClClinica.Get_Clinca(Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ClinicaId"]));
                TxtClinicaId.Text = dsClinica.Tables["Datos"].Rows[0]["ClinicaId"].ToString();
                TxtNombre.Value = dsClinica.Tables["Datos"].Rows[0]["Nombre"].ToString();
                TxtDireccion.Value = dsClinica.Tables["Datos"].Rows[0]["Direccion"].ToString();
                CboPais.SelectedValue = dsClinica.Tables["Datos"].Rows[0]["PaisId"].ToString();
                CboPais.SelectedItem.Text = dsClinica.Tables["Datos"].Rows[0]["Pais"].ToString();
                CboDepartamento.ClearSelection();
                CboMunicipio.ClearSelection();
                CboDepartamento.Items.Clear();
                CboMunicipio.Items.Clear();
                ClUtilitarios.Fill_DropDownAsp(ClCatalogos.Catalogo_Departamento(Session["Idioma"].ToString(), Convert.ToInt32(CboPais.SelectedValue)), CboDepartamento, "Id", "Datos");
                ClUtilitarios.AgregarSeleccioneCombo(CboDepartamento, ClTraductor.BuscaString(Session["Idioma"].ToString(), "49"), Session["Idioma"].ToString());
                CboDepartamento.SelectedValue = dsClinica.Tables["Datos"].Rows[0]["DepartamentoId"].ToString();
                CboDepartamento.SelectedItem.Text = dsClinica.Tables["Datos"].Rows[0]["Departamento"].ToString();
                CboMunicipio.ClearSelection();
                CboMunicipio.Items.Clear();
                ClUtilitarios.Fill_DropDownAsp(ClCatalogos.Catalogo_Municipio(Session["Idioma"].ToString(), Convert.ToInt32(CboDepartamento.SelectedValue)), CboMunicipio, "Id", "Datos");
                ClUtilitarios.AgregarSeleccioneCombo(CboMunicipio, ClTraductor.BuscaString(Session["Idioma"].ToString(), "50"), Session["Idioma"].ToString());
                CboMunicipio.SelectedValue = dsClinica.Tables["Datos"].Rows[0]["MunicipioId"].ToString();
                CboMunicipio.SelectedItem.Text = dsClinica.Tables["Datos"].Rows[0]["Municipio"].ToString();
                TxtTelCasa.Value = dsClinica.Tables["Datos"].Rows[0]["Telefono"].ToString();
                dsClinica.Clear();
                BtnGrabar.Visible = true;
            }
        }

        void VerificaClnica()
        {
            int HayClinica = ClClinica.TieneClinica(Convert.ToInt32(Session["ClienteId"]));
            if (HayClinica == 0)
            {
                System.Web.UI.HtmlControls.HtmlGenericControl Menu;
                Menu = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("sidebar");
                Menu.Visible = false;
            }
            else
            {
                System.Web.UI.HtmlControls.HtmlGenericControl Menu;
                Menu = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("sidebar");
                Menu.Visible = true;
            }

        }

        private void GrdDetalle_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            ClUtilitarios.LlenaGrid(ClClinica.Get_Clincas(Convert.ToInt32(Session["ClienteId"])), GrdDetalle, Session["Idioma"].ToString());
        }

        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        private void CboDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboDepartamento.SelectedIndex != 0)
            {
                CboMunicipio.ClearSelection();
                CboMunicipio.Items.Clear();
                ClUtilitarios.Fill_DropDownAsp(ClCatalogos.Catalogo_Municipio(Session["Idioma"].ToString(), Convert.ToInt32(CboDepartamento.SelectedValue)), CboMunicipio, "Id", "Datos");
                ClUtilitarios.AgregarSeleccioneCombo(CboMunicipio, ClTraductor.BuscaString(Session["Idioma"].ToString(), "50"), Session["Idioma"].ToString());
            }
            else
            {
                CboMunicipio.ClearSelection();
                CboMunicipio.Items.Clear();
            }
        }

        private void CboPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboPais.SelectedIndex != 0)
            {
                CboDepartamento.ClearSelection();
                CboMunicipio.ClearSelection();
                CboDepartamento.Items.Clear();
                CboMunicipio.Items.Clear();
                ClUtilitarios.Fill_DropDownAsp(ClCatalogos.Catalogo_Departamento(Session["Idioma"].ToString(), Convert.ToInt32(CboPais.SelectedValue)), CboDepartamento, "Id", "Datos");
                ClUtilitarios.AgregarSeleccioneCombo(CboDepartamento, ClTraductor.BuscaString(Session["Idioma"].ToString(), "49"), Session["Idioma"].ToString());
            }
            else
            {
                CboDepartamento.ClearSelection();
                CboMunicipio.ClearSelection();
                CboDepartamento.Items.Clear();
                CboMunicipio.Items.Clear();
            }
        }

        void ValidaGrabar()
        {
            if (ClClinica.ClinicasDisponibles(Convert.ToInt32(Session["ClienteId"])) == 0)
            {
                BtnGrabar.Visible = false;
            }
            else
            {
                BtnGrabar.Visible = true;
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

        void Grabar()
        {
            if (Valida() == true)
            {
                int ClinicaId = 0;
                if (TxtClinicaId.Text == "")
                {
                    ClinicaId = ClClinica.Get_Max_Clinica();
                    ClClinica.Insert_Clinica(ClinicaId, Convert.ToInt32(Session["ClienteId"]), TxtNombre.Value, TxtDireccion.Value, Convert.ToInt32(CboMunicipio.SelectedValue), TxtTelCasa.Value);
                    ClUsuario.Insert_Relacion_Usuario_Clinica(Convert.ToInt32(Session["UsuarioId"]), ClinicaId);
                }
                else
                {
                    ClinicaId = Convert.ToInt32(TxtClinicaId.Text);
                    ClClinica.Modificar_Clinca(ClinicaId, TxtNombre.Value, TxtDireccion.Value, Convert.ToInt32(CboMunicipio.SelectedValue), TxtTelCasa.Value);
                }
                if (TxtFotoPerfil.UploadedFiles.Count > 0)
                {
                    Stream fileStream = TxtFotoPerfil.UploadedFiles[0].InputStream;
                    byte[] attachmentBytes = new byte[fileStream.Length];
                    fileStream.Read(attachmentBytes, 0, Convert.ToInt32(fileStream.Length));
                    ClClinica.Insert_Foto_Clinica(ClinicaId, attachmentBytes, TxtFotoPerfil.UploadedFiles[0].ContentType, TxtFotoPerfil.UploadedFiles[0].FileName);
                    fileStream.Close();
                }
                Limpiar();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowPopup('', '" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "76") + "','success','" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "9") + "');", true);
                GrdDetalle.Rebind();
                ValidaGrabar();
                VerificaClnica();
            }
        }

        void Limpiar()
        {
            TxtNombre.Value = "";
            TxtDireccion.Value = "";
            CboMunicipio.ClearSelection();
            CboDepartamento.ClearSelection();
            CboPais.ClearSelection();
            TxtTelCasa.Value = "";
            TxtClinicaId.Text = "";
        }

        bool Valida()
        {
            DivErrr.Visible = false;
            DivNoErr.Visible = false;
            string LblMensaje = "";
            bool HayError = false;

            if (TxtNombre.Value == "")
            {
                if (LblMensaje == "")
                    LblMensaje = ClTraductor.BuscaString(Session["Idioma"].ToString(), "61");
                else
                    LblMensaje = LblMensaje + ", " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "61");
                HayError = true;
            }
            if (TxtDireccion.Value == "")
            {
                if (LblMensaje == "")
                    LblMensaje = ClTraductor.BuscaString(Session["Idioma"].ToString(), "64");
                else
                    LblMensaje = LblMensaje + ", " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "64");
                HayError = true;
            }
            if (CboPais.Text == "" || CboPais.SelectedIndex == 0)
            {
                if (LblMensaje == "")
                    LblMensaje = ClTraductor.BuscaString(Session["Idioma"].ToString(), "65");
                else
                    LblMensaje = LblMensaje + ", " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "65");
                HayError = true;
            }
            if (CboDepartamento.Text == "" || CboDepartamento.SelectedIndex == 0)
            {
                if (LblMensaje == "")
                    LblMensaje = ClTraductor.BuscaString(Session["Idioma"].ToString(), "66");
                else
                    LblMensaje = LblMensaje + ", " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "66");
                HayError = true;
            }
            if (CboMunicipio.Text == "" || CboMunicipio.SelectedIndex == 0)
            {
                if (LblMensaje == "")
                    LblMensaje = ClTraductor.BuscaString(Session["Idioma"].ToString(), "67");
                else
                    LblMensaje = LblMensaje + ", " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "67");
                HayError = true;
            }
            if (TxtTelCasa.Value == "")
            {
                if (LblMensaje == "")
                    LblMensaje = ClTraductor.BuscaString(Session["Idioma"].ToString(), "68");
                else
                    LblMensaje = LblMensaje + ", " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "68");
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

            //Combos
            ClUtilitarios.Fill_DropDownAsp(ClCatalogos.Catalogo_Pais(Session["Idioma"].ToString()), CboPais, "Id", "Datos");
            ClUtilitarios.AgregarSeleccioneCombo(CboPais, ClTraductor.BuscaString(Session["Idioma"].ToString(), "48"), Session["Idioma"].ToString());
            CboMunicipio.Items.Clear();
            CboDepartamento.Items.Clear();

            GrdDetalle.Columns[1].HeaderText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "43");
            GrdDetalle.Columns[2].HeaderText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "47");
            GrdDetalle.Columns[3].HeaderText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "93");
            GrdDetalle.Rebind();
            BtnGrabar.Attributes["data-loading-text"] = ClTraductor.BuscaString(Session["Idioma"].ToString(), "94");
            TxtFotoPerfil.Localization.Select = ClTraductor.BuscaString(Session["Idioma"].ToString(), "96");
            TxtFotoPerfil.Localization.Cancel = ClTraductor.BuscaString(Session["Idioma"].ToString(), "98");
            TxtFotoPerfil.Localization.Remove = ClTraductor.BuscaString(Session["Idioma"].ToString(), "97");
        }
    }
}