using System;
using System.Data;
using System.Data.SqlClient;

namespace Health.Clases
{
    public class Cl_Catalogos
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["Conexion"]);
        DataSet ds = new DataSet();
        public DataSet Catalogo_Alias(string Idioma, int Tipo)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_Catalogo_Alias", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Tipo", SqlDbType.Int).Value = Tipo;
                cmd.Parameters.Add("@Idioma", SqlDbType.VarChar, 10).Value = Idioma;
                SqlDataAdapter  adp = new SqlDataAdapter(cmd);
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

        public DataSet Catalogo_Genero(string Idioma)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_Catalogo_Genero", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Idioma", SqlDbType.VarChar, 10).Value = Idioma;
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

        public DataSet Catalogo_Pais(string Idioma)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_Catalogo_Pais", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Idioma", SqlDbType.VarChar, 10).Value = Idioma;
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

        public DataSet Catalogo_Departamento(string Idioma, int PaisId)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_Catalogo_Departamento", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Idioma", SqlDbType.VarChar, 10).Value = Idioma;
                cmd.Parameters.Add("@PaisId", SqlDbType.Int).Value = PaisId;
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

        public DataSet Catalogo_Municipio(string Idioma, int DepartamentoId)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_Catalogo_Municipio", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Idioma", SqlDbType.VarChar, 10).Value = Idioma;
                cmd.Parameters.Add("@DepartamentoId", SqlDbType.Int).Value = DepartamentoId;
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

        public DataSet Catalogo_Universidad(string Idioma, int PaisId)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_Catalogo_Universidad", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Idioma", SqlDbType.VarChar, 10).Value = Idioma;
                cmd.Parameters.Add("@PaisId", SqlDbType.Int).Value = PaisId;
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

        public DataSet Catalogo_TipoUsuario(string Idioma, int Tipo)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_Catalogo_TipoUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Idioma", SqlDbType.VarChar, 10).Value = Idioma;
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

        public DataSet Catalogo_Especialidades(string Idioma)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_Catalogo_Especialidades", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Idioma", SqlDbType.VarChar, 10).Value = Idioma;
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