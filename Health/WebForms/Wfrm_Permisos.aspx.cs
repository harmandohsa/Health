using System;
using System.Data;
using System.Web.UI.WebControls;
using Health.Clases;
using Telerik.Web.UI;

namespace Health.WebForms
{
    public partial class Wfrm_Permisos : System.Web.UI.Page
    {
        Cl_Traductor ClTraductor;
        Cl_Usuario ClUsuario;
        Cl_Utilitarios ClUtilitarios;
        protected void Page_Load(object sender, EventArgs e)
        {
            ClTraductor = new Cl_Traductor();
            ClUsuario = new Cl_Usuario();
            ClUtilitarios = new Cl_Utilitarios();

            ImageButton ImgEng;
            ImgEng = (ImageButton)Master.FindControl("ImgEng");
            ImgEng.Click += ImgEng_Click;

            ImageButton ImgEsp;
            ImgEsp = (ImageButton)Master.FindControl("ImgEsp");
            ImgEsp.Click += ImgEsp_Click;

            GrdDetalle.NeedDataSource += GrdDetalle_NeedDataSource;
            GrdDetalle.ItemCommand += GrdDetalle_ItemCommand;
            GrdPErmisos.NeedDataSource += GrdPErmisos_NeedDataSource;
            GrdPErmisos.ItemDataBound += GrdPErmisos_ItemDataBound;

            if (Session["UsuarioId"] == null)
            {
                Response.Redirect("~/Wfrm_Login.aspx");
            }
            else if (!IsPostBack)
            {

                DataSet dsPermisos = ClUsuario.Get_Roles_Forma_Usuario(Convert.ToInt32(Session["UsuarioId"]), 3);
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

        private void GrdPErmisos_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if ((e.Item.ItemType == GridItemType.Item) || (e.Item.ItemType == GridItemType.AlternatingItem))
            {
                GridDataItem item = e.Item as GridDataItem;

                string ConsultarOp =  item.GetDataKeyValue("Consultar").ToString(); 

                CheckBox Consultar;
                Consultar = (CheckBox)item.FindControl("ChkConsultar");
                if (ConsultarOp == "1")
                {
                    Consultar.Checked = true;

                }


                string InsertarOp = item.GetDataKeyValue("Insertar").ToString();
                CheckBox Insertar;
                Insertar = (CheckBox)item.FindControl("ChkInsertar");
                if (InsertarOp == "1")
                {

                    Insertar.Checked = true;

                }

                string EditarOp = item.GetDataKeyValue("Editar").ToString();
                CheckBox Editar;
                Editar = (CheckBox)item.FindControl("ChkEditar");
                if (EditarOp == "1")
                {

                    Editar.Checked = true;

                }

                string EliminarOp = item.GetDataKeyValue("Eliminar").ToString();
                CheckBox Eliminar;
                Eliminar = (CheckBox)item.FindControl("ChkEliminar");
                if (EliminarOp == "1")
                {

                    Eliminar.Checked = true;
                }
               
            }
        }

        private void GrdPErmisos_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            if (TxtUsuarioId.Text != "")
                ClUtilitarios.LlenaGrid(ClUsuario.Get_Roles_Usuario(Convert.ToInt32(TxtUsuarioId.Text), Session["Idioma"].ToString()), GrdPErmisos, Session["Idioma"].ToString());
        }

        private void GrdDetalle_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "CmdPermisos")
            {
                LblUsuario.Text = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["Nombre"].ToString();
                TxtUsuarioId.Text = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["UsuarioId"].ToString();
                GrdPErmisos.Rebind();
            }
        }

        private void GrdDetalle_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            
            ClUtilitarios.LlenaGrid(ClUsuario.Get_Usuarios(1, Convert.ToInt32(Session["ClienteId"])), GrdDetalle, Session["Idioma"].ToString());
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
            LblSubTitulo.Text = ClTraductor.BuscaString(Session["Idioma"].ToString(), "99");
            LblUsuarioE.Text = ClTraductor.BuscaString(Session["Idioma"].ToString(), "1") + ":";
            GrdDetalle.Columns[2].HeaderText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "87");
            GrdDetalle.Columns[3].HeaderText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "1");
            GrdDetalle.Columns[4].HeaderText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "59");
            GrdDetalle.Columns[5].HeaderText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "89");
            GrdDetalle.Columns[6].HeaderText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "99");
            GrdDetalle.Rebind();
            GrdPErmisos.Columns[1].HeaderText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "100");
            GrdPErmisos.Columns[3].HeaderText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "101");
            GrdPErmisos.Columns[5].HeaderText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "102");
            GrdPErmisos.Columns[7].HeaderText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "93");
            GrdPErmisos.Columns[9].HeaderText = ClTraductor.BuscaString(Session["Idioma"].ToString(), "103");
            GrdPErmisos.Rebind();
        }

        protected void ChkConsultar_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ChkConsultar = (CheckBox)sender;
            GridDataItem item = (GridDataItem)ChkConsultar.Parent.Parent;
            int Permiso = 0;
            if (ChkConsultar.Checked == true)
                Permiso = 1;
            else
                Permiso = 0;
            ClUsuario.Actuliza_Rol_Usuario(Convert.ToInt32(TxtUsuarioId.Text), Convert.ToInt32(item.GetDataKeyValue("FormaId")), Permiso, 1);
        }

        protected void ChkInsertar_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ChkInsertar = (CheckBox)sender;
            GridDataItem item = (GridDataItem)ChkInsertar.Parent.Parent;
            int Permiso = 0;
            if (ChkInsertar.Checked == true)
                Permiso = 1;
            else
                Permiso = 0;
            ClUsuario.Actuliza_Rol_Usuario(Convert.ToInt32(TxtUsuarioId.Text), Convert.ToInt32(item.GetDataKeyValue("FormaId")), Permiso, 2);
        }

        protected void ChkEditar_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ChkEditar = (CheckBox)sender;
            GridDataItem item = (GridDataItem)ChkEditar.Parent.Parent;
            int Permiso = 0;
            if (ChkEditar.Checked == true)
                Permiso = 1;
            else
                Permiso = 0;
            ClUsuario.Actuliza_Rol_Usuario(Convert.ToInt32(TxtUsuarioId.Text), Convert.ToInt32(item.GetDataKeyValue("FormaId")), Permiso, 3);
        }

        protected void ChkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ChkEliminar = (CheckBox)sender;
            GridDataItem item = (GridDataItem)ChkEliminar.Parent.Parent;
            int Permiso = 0;
            if (ChkEliminar.Checked == true)
                Permiso = 1;
            else
                Permiso = 0;
            ClUsuario.Actuliza_Rol_Usuario(Convert.ToInt32(TxtUsuarioId.Text), Convert.ToInt32(item.GetDataKeyValue("FormaId")), Permiso, 4);
        }
    }
}