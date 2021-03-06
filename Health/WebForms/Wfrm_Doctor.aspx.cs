﻿using Health.Clases;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Health.WebForms
{
    public partial class Wfrm_Doctor : System.Web.UI.Page
    {
        Cl_Traductor ClTraductor;
        Cl_Catalogos ClCatalogos;
        Cl_Usuario ClUsuario;
        Cl_Utilitarios ClUtilitarios;
        Cl_Persona ClPersona;
        Cl_Clinica ClClinca;
        Cl_Cliente ClCliente;

        protected void Page_Load(object sender, EventArgs e)
        {
            ClTraductor = new Cl_Traductor();
            ClCatalogos = new Cl_Catalogos();
            ClUsuario = new Cl_Usuario();
            ClUtilitarios = new Cl_Utilitarios();
            ClPersona = new Cl_Persona();
            ClClinca = new Cl_Clinica();
            ClCliente = new Cl_Cliente();

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

                DataSet dsPermisos = ClUsuario.Get_Roles_Forma_Usuario(Convert.ToInt32(Session["UsuarioId"]), 2);
                if (Convert.ToInt32(dsPermisos.Tables["Datos"].Rows[0]["Editar"]) == 0)
                {
                    BtnGrabar.Enabled = false;
                }
                if (Convert.ToInt32(dsPermisos.Tables["Datos"].Rows[0]["Insertar"]) == 0)
                {
                    BtnGrabar.Enabled = false;
                }
                if (Convert.ToInt32(dsPermisos.Tables["Datos"].Rows[0]["Eliminar"]) == 0)
                {

                }
                dsPermisos.Clear();
                Traduce();
                DataSet DsClincas = ClClinca.Get_Clincas(Convert.ToInt32(Session["ClienteId"]));
                if (DsClincas.Tables["Datos"].Rows.Count == 1)
                    GrdDetalle.Columns[7].Visible = false;
                ValidaGrabar();


            }
            TxtIdioma.Value = Session["Idioma"].ToString();
        }

        private void GrdDetalle_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "CmdEditar")
            {
                DataSet dsUsuario = ClUsuario.GetDatosUsuarioId(Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["UsuarioId"].ToString()), Session["Idioma"].ToString());
                TxtUsuarioId.Text = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["UsuarioId"].ToString();
                CboAlias.SelectedValue = dsUsuario.Tables["Datos"].Rows[0]["AliasIid"].ToString();
                CboAlias.SelectedItem.Text = dsUsuario.Tables["Datos"].Rows[0]["aliasper"].ToString();
                TxtNombres.Value = dsUsuario.Tables["Datos"].Rows[0]["Nombres"].ToString();
                TxtApellidos.Value = dsUsuario.Tables["Datos"].Rows[0]["Apellidos"].ToString();
                CboGenero.SelectedValue = dsUsuario.Tables["Datos"].Rows[0]["GeneroId"].ToString();
                CboGenero.SelectedItem.Text = dsUsuario.Tables["Datos"].Rows[0]["generoper"].ToString();
                CboPais.SelectedValue = dsUsuario.Tables["Datos"].Rows[0]["PaisId"].ToString();
                CboPais.SelectedItem.Text = dsUsuario.Tables["Datos"].Rows[0]["paisper"].ToString();
                CboDepartamento.ClearSelection();
                CboMunicipio.ClearSelection();
                CboDepartamento.Items.Clear();
                CboMunicipio.Items.Clear();
                ClUtilitarios.Fill_DropDownAsp(ClCatalogos.Catalogo_Departamento(Session["Idioma"].ToString(), Convert.ToInt32(CboPais.SelectedValue)), CboDepartamento, "Id", "Datos");
                ClUtilitarios.AgregarSeleccioneCombo(CboDepartamento, ClTraductor.BuscaString(Session["Idioma"].ToString(), "49"), Session["Idioma"].ToString());
                CboDepartamento.SelectedValue = dsUsuario.Tables["Datos"].Rows[0]["DepartamentoId"].ToString();
                CboDepartamento.SelectedItem.Text = dsUsuario.Tables["Datos"].Rows[0]["Departamento"].ToString();
                CboMunicipio.ClearSelection();
                CboMunicipio.Items.Clear();
                ClUtilitarios.Fill_DropDownAsp(ClCatalogos.Catalogo_Municipio(Session["Idioma"].ToString(), Convert.ToInt32(CboDepartamento.SelectedValue)), CboMunicipio, "Id", "Datos");
                ClUtilitarios.AgregarSeleccioneCombo(CboMunicipio, ClTraductor.BuscaString(Session["Idioma"].ToString(), "50"), Session["Idioma"].ToString());
                CboMunicipio.SelectedValue = dsUsuario.Tables["Datos"].Rows[0]["MunicipioId"].ToString();
                CboMunicipio.SelectedItem.Text = dsUsuario.Tables["Datos"].Rows[0]["Municipio"].ToString();
                TxtTelCasa.Value = dsUsuario.Tables["Datos"].Rows[0]["Telefono"].ToString();
                TxtTelMovil.Value = dsUsuario.Tables["Datos"].Rows[0]["Telefono_Movil"].ToString();
                TxtCorreo.Value = dsUsuario.Tables["Datos"].Rows[0]["Correo"].ToString();
                TxtCorreoAnt.Text = dsUsuario.Tables["Datos"].Rows[0]["Correo"].ToString();
                TxtIdNo.Value = dsUsuario.Tables["Datos"].Rows[0]["No_Identificacion"].ToString();
                TxtFecNac.Value = string.Format("{0:yyyy-MM-dd}", dsUsuario.Tables["Datos"].Rows[0]["Fecha_Nacimiento"]);
                CboTipoUsuario.SelectedValue = dsUsuario.Tables["Datos"].Rows[0]["Tipo_UsuarioId"].ToString();
                CboTipoUsuario.SelectedItem.Text = dsUsuario.Tables["Datos"].Rows[0]["tipusuarioper"].ToString();
                TxtDireccion.Value = dsUsuario.Tables["Datos"].Rows[0]["direccion"].ToString();
                TxtPersonaId.Text = dsUsuario.Tables["Datos"].Rows[0]["PersonaId"].ToString();

                dsUsuario.Clear();
                BtnGrabar.Visible = true;
            }
            else if (e.CommandName == "CmdEspecialidades")
            {
                RadWindowDetalle.Title = ClTraductor.BuscaString(Session["Idioma"].ToString(), "104");
                RadWindowDetalle.NavigateUrl = "~/WebForms/Wfrm_Especialidades.aspx?Benutzer=" + HttpUtility.UrlEncode(ClUtilitarios.Encrypt(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["UsuarioId"].ToString(), true)) +  "";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "function f(){$find('" + RadWindowDetalle.ClientID + "').show();Sys.Application.remove_load(f);}Sys.Application.add_load(f);", true);
            }
        }

        void ValidaGrabar()
        {
            if (ClUsuario.DoctoresDisponibles(Convert.ToInt32(Session["ClienteId"])) == 0)
            {
                BtnGrabar.Visible = false;
            }
            else
            {
                BtnGrabar.Visible = true;
            }
        }


        private void GrdDetalle_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            ClUtilitarios.LlenaGrid(ClUsuario.Get_Usuarios(3, Convert.ToInt32(Session["ClienteId"])), GrdDetalle, Session["Idioma"].ToString());
            int CntDoc = ClCliente.GetCantidadDoctores(Convert.ToInt32(Session["ClienteId"]));
            int items = GrdDetalle.Items.Count;
            if (items >= CntDoc)
                BtnGrabar.Visible = false;  
        }

        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            if (Valida() == true)
            {
                if (TxtUsuarioId.Text == "")
                {
                    int PersonaId = ClPersona.Get_Max_Persona();
                    int UniversidadId = 0;
                    ClPersona.Insert_Persona(PersonaId, Convert.ToInt32(CboAlias.SelectedValue), TxtNombres.Value, TxtApellidos.Value, Convert.ToInt32(CboGenero.SelectedValue), TxtIdNo.Value, TxtDireccion.Value, Convert.ToInt32(CboMunicipio.SelectedValue), TxtTelCasa.Value, TxtTelMovil.Value, UniversidadId, "", "", Convert.ToDateTime(TxtFecNac.Value));
                    int UsuarioId = ClUsuario.Get_Max_Usuario();
                    string Clave = ClUtilitarios.Encrypt(ClUtilitarios.GenerarPass(6, 10), true);
                    ClUsuario.Insert_Usuario(UsuarioId, Convert.ToInt32(Session["ClienteId"]), Convert.ToInt32(CboTipoUsuario.SelectedValue), TxtCorreo.Value, Clave, PersonaId);
                    ClUsuario.Create_Permisos(UsuarioId, Convert.ToInt32(CboTipoUsuario.SelectedValue));
                    string Asunto = ClTraductor.BuscaString(Session["Idioma"].ToString(), "91");
                    string Mensaje = Mensaje = "<body><table><tr><td>" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "92") + " " + TxtCorreo.Value + " " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "21") + " " + Clave + "</td></tr></table>";
                    ClUtilitarios.EnvioCorreo(TxtCorreo.Value, TxtNombres.Value + " " + TxtApellidos.Value, Asunto, Mensaje, 0, "", "");
                    Limpiar();
                    ClUsuario.Insert_Relacion_Usuario_Clinica(UsuarioId, Convert.ToInt32(Session["ClinicaId"]));
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowPopup('', '" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "76") + "','success','" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "9") + "');", true);
                    GrdDetalle.Rebind();
                }
                else
                {
                    int UsuarioId = Convert.ToInt32(TxtUsuarioId.Text);
                    int PersonaId = Convert.ToInt32(TxtPersonaId.Text);
                    ClUsuario.Update_DatosUsuario(2, UsuarioId, TxtCorreo.Value, "", Convert.ToInt32(CboTipoUsuario.SelectedValue));
                    ClPersona.Update_Persona(PersonaId, Convert.ToInt32(CboAlias.SelectedValue), TxtNombres.Value, TxtApellidos.Value, Convert.ToInt32(CboGenero.SelectedValue), TxtIdNo.Value, TxtDireccion.Value, Convert.ToInt32(CboMunicipio.SelectedValue), TxtTelCasa.Value, TxtTelMovil.Value, 0, "", "", Convert.ToDateTime(TxtFecNac.Value));
                    Limpiar();
                    ClUsuario.Insert_Relacion_Usuario_Clinica(UsuarioId, Convert.ToInt32(Session["ClinicaId"]));
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "ShowPopup('', '" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "76") + "','success','" + ClTraductor.BuscaString(Session["Idioma"].ToString(), "9") + "');", true);
                    GrdDetalle.Rebind();
                }

            }
            ValidaGrabar();
        }

        void Limpiar()
        {
            CboAlias.ClearSelection();
            TxtNombres.Value = "";
            TxtApellidos.Value = "";
            CboGenero.ClearSelection();
            TxtIdNo.Value = "";
            TxtDireccion.Value = "";
            CboMunicipio.ClearSelection();
            CboDepartamento.ClearSelection();
            CboPais.ClearSelection();
            TxtTelCasa.Value = "";
            TxtTelMovil.Value = "";
            TxtCorreo.Value = "";
            TxtFecNac.Value = "";
            CboTipoUsuario.ClearSelection();
            TxtUsuarioId.Text = "";
            TxtCorreoAnt.Text = "";
        }

        bool Valida()
        {
            DivErrr.Visible = false;
            DivNoErr.Visible = false;
            string LblMensaje = "";
            bool HayError = false;


            if (TxtNombres.Value == "")
            {
                if (LblMensaje == "")
                    LblMensaje = ClTraductor.BuscaString(Session["Idioma"].ToString(), "61");
                else
                    LblMensaje = LblMensaje + ", " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "61");
                HayError = true;
            }
            if (TxtApellidos.Value == "")
            {
                if (LblMensaje == "")
                    LblMensaje = ClTraductor.BuscaString(Session["Idioma"].ToString(), "62");
                else
                    LblMensaje = LblMensaje + ", " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "62");
                HayError = true;
            }
            if (TxtIdNo.Value == "")
            {
                if (LblMensaje == "")
                    LblMensaje = ClTraductor.BuscaString(Session["Idioma"].ToString(), "63");
                else
                    LblMensaje = LblMensaje + ", " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "63");
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
            if (TxtTelMovil.Value == "")
            {
                if (LblMensaje == "")
                    LblMensaje = ClTraductor.BuscaString(Session["Idioma"].ToString(), "68");
                else
                    LblMensaje = LblMensaje + ", " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "68");
                HayError = true;
            }
            if (TxtCorreo.Value == "")
            {
                if (LblMensaje == "")
                    LblMensaje = ClTraductor.BuscaString(Session["Idioma"].ToString(), "69");
                else
                    LblMensaje = LblMensaje + ", " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "69");
                HayError = true;
            }

            if (TxtFecNac.Value == "")
            {
                if (LblMensaje == "")
                    LblMensaje = ClTraductor.BuscaString(Session["Idioma"].ToString(), "70");
                else
                    LblMensaje = LblMensaje + ", " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "70");
                HayError = true;
            }
            if (CboTipoUsuario.Text == "" || CboTipoUsuario.SelectedIndex == 0)
            {
                if (LblMensaje == "")
                    LblMensaje = ClTraductor.BuscaString(Session["Idioma"].ToString(), "65");
                else
                    LblMensaje = LblMensaje + ", " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "65");
                HayError = true;
            }
            if ((TxtUsuarioId.Text == "") && (ClUsuario.Existe_Correo(TxtCorreo.Value) == 1))
            {
                if (LblMensaje == "")
                    LblMensaje = ClTraductor.BuscaString(Session["Idioma"].ToString(), "72");
                else
                    LblMensaje = LblMensaje + ", " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "72");
                HayError = true;
            }
            if ((TxtUsuarioId.Text != "") && (TxtCorreo.Value != TxtCorreoAnt.Text) && (ClUsuario.Existe_Correo(TxtCorreo.Value) == 1))
            {
                if (LblMensaje == "")
                    LblMensaje = ClTraductor.BuscaString(Session["Idioma"].ToString(), "72");
                else
                    LblMensaje = LblMensaje + ", " + ClTraductor.BuscaString(Session["Idioma"].ToString(), "72");
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
            DivErrr.Visible = false;
            DivNoErr.Visible = false;
            LblSubTitulo.Text = ClTraductor.BuscaString(Session["Idioma"].ToString(), "104");
            LblAlias.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "42");
            LblNombres.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "43");
            LblApellidos.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "44");
            LblGenero.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "45");
            LblId.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "46");
            LblDireccion.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "47");
            LblPais.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "48");
            LblDepartamento.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "49");
            LblMunicipio.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "50");
            LblTelCasa.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "51");
            LblTelMovil.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "52");
            LblCorreo.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "59");
            LblFecNac.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "60");
            BtnGrabar.Text = ClTraductor.BuscaString(Session["Idioma"].ToString(), "71");
            lblTipoUsuario.InnerText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "89");

            //Combos
            ClUtilitarios.Fill_DropDownAsp(ClCatalogos.Catalogo_Alias(Session["Idioma"].ToString(),2), CboAlias, "Id", "Datos");
            ClUtilitarios.Fill_DropDownAsp(ClCatalogos.Catalogo_Genero(Session["Idioma"].ToString()), CboGenero, "Id", "Datos");
            ClUtilitarios.Fill_DropDownAsp(ClCatalogos.Catalogo_Pais(Session["Idioma"].ToString()), CboPais, "Id", "Datos");
            ClUtilitarios.AgregarSeleccioneCombo(CboPais, ClTraductor.BuscaString(Session["Idioma"].ToString(), "48"), Session["Idioma"].ToString());
            CboMunicipio.Items.Clear();
            CboDepartamento.Items.Clear();
            ClUtilitarios.Fill_DropDownAsp(ClCatalogos.Catalogo_TipoUsuario(Session["Idioma"].ToString(), 2), CboTipoUsuario, "Id", "Datos");
            ClUtilitarios.AgregarSeleccioneCombo(CboTipoUsuario, ClTraductor.BuscaString(Session["Idioma"].ToString(), "89"), Session["Idioma"].ToString());
            TxtIdioma.Value = Session["Idioma"].ToString();
            GrdDetalle.Columns[2].HeaderText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "43");
            GrdDetalle.Columns[3].HeaderText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "84");
            GrdDetalle.Columns[4].HeaderText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "59");
            GrdDetalle.Columns[5].HeaderText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "89");
            GrdDetalle.Columns[6].HeaderText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "93");
            GrdDetalle.Columns[8].HeaderText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "105");
            GrdDetalle.Rebind();
            BtnGrabar.Attributes["data-loading-text"] = ClTraductor.BuscaString(Session["Idioma"].ToString(), "94");
        }
    }
}