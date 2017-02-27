﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace Health.Clases
{
    public class Cl_Usuario
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["Conexion"]);
        DataSet ds = new DataSet();

        public int ExisteUsuario(string Usuario)
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_ExisteUsuario", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 200).Value = Usuario;
                cmd.Parameters.Add("@Resul", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                cn.Close();
                return Convert.ToInt32(cmd.Parameters["@Resul"].Value);
            }
            catch (Exception ex)
            {
                cn.Close();
                return 0;
            }
        }

        public DataSet GetDatosUsuario(string Usuario)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_GetDatosUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 200).Value = Usuario;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds, "DATOS");
                cn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                cn.Close();
                return ds;
            }
        }

        public void CambiaClave(string Usuario, string Clave, int CambiaPass)
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_CambiaClave", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar,500).Value = Usuario;
                cmd.Parameters.Add("@Clave", SqlDbType.VarChar,500).Value = Clave;
                cmd.Parameters.Add("@CambiaPass", SqlDbType.Int).Value = CambiaPass;
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
            }
        }

        public int Existe_Correo(string Correo)
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_Existe_Correo", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Correo", SqlDbType.VarChar, 200).Value = Correo;
                cmd.Parameters.Add("@Resul", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                cn.Close();
                return Convert.ToInt32(cmd.Parameters["@Resul"].Value);
            }
            catch (Exception ex)
            {
                cn.Close();
                return 0;
            }
        }

        public void Actualiza_PersonaID_Usuario(int PersonaId, int UsuarioId)
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_Actualiza_PersonaID_Usuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PersonaId", SqlDbType.Int).Value = PersonaId;
                cmd.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
            }
        }

        public void Update_DatosUsuario(int UsuarioId, string Correo, string Usuario)
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_Update_DatosUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
                cmd.Parameters.Add("@Correo", SqlDbType.VarChar, 500).Value = Correo;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 500).Value = Usuario;
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
            }
        }

        public DataSet Get_Permisos(int UsuarioId)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_Get_Permisos", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds, "DATOS");
                cn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                cn.Close();
                return ds;
            }
        }

        public DataSet Get_Roles_Forma_Usuario(int UsuarioId, int FormaId)
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_Get_Roles_Forma_Usuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
                cmd.Parameters.Add("@FormaId", SqlDbType.Int).Value = FormaId;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds, "DATOS");
                cn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                cn.Close();
                return ds;
            }
        }

        public int Get_Max_Usuario()
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_Get_Max_Usuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Resul", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                cn.Close();
                return Convert.ToInt32(cmd.Parameters["@Resul"].Value);
            }
            catch (Exception ex)
            {
                cn.Close();
                return 0;
            }
        }

        public void Insert_Usuario(int UsuarioId, int ClienteId, int TipoUsuarioId, string Correo, string Clave, int PersonaId)
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_Insert_Usuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
                cmd.Parameters.Add("@ClienteId", SqlDbType.Int).Value = ClienteId;
                cmd.Parameters.Add("@TipoUsuarioId", SqlDbType.Int).Value = TipoUsuarioId;
                cmd.Parameters.Add("@Correo", SqlDbType.VarChar, 500).Value = Correo;
                cmd.Parameters.Add("@Clave", SqlDbType.VarChar, 500).Value = Clave;
                cmd.Parameters.Add("@PersonaId", SqlDbType.Int).Value = PersonaId;
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
            }
        }

        public void Create_Permisos(int UsuarioId, int TipoUsuarioId)
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_Create_Permisos", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
                cmd.Parameters.Add("@Tipo_Usuario_Id", SqlDbType.Int).Value = TipoUsuarioId;
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
            }
        }

        public DataSet Get_Usuarios(int Tipo)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand cmd = new SqlCommand("Sp_Get_Usuarios", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Tipo", SqlDbType.Int).Value = Tipo;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds, "DATOS");
                cn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                cn.Close();
                return ds;
            }
        }
    }
}