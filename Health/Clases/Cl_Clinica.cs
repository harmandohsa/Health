using System;
using System.Data;
using System.Data.SqlClient;

namespace Health.Clases
{
    public class Cl_Clinica
    {

        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["Conexion"]);
        DataSet ds = new DataSet();

        public int TieneClinica(int ClienteId)
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_TieneClinica", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@ClienteId", SqlDbType.VarChar, 200).Value = ClienteId;
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

        public int ClinicasDisponibles(int ClienteId)
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_ClinicasDisponibles", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@ClienteId", SqlDbType.VarChar, 200).Value = ClienteId;
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

        public int Get_Max_Clinica()
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_Get_Max_Clinica", cn);
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

        public void Insert_Clinica(int ClinicaId, int ClienteId, string Nombres, string Direccion, int MunicipioId, string Telefono)
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_Insert_Clinca", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ClinicaId", SqlDbType.Int).Value = ClinicaId;
                cmd.Parameters.Add("@ClienteId", SqlDbType.Int).Value = ClienteId;
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 500).Value = Nombres;
                cmd.Parameters.Add("@Direccion", SqlDbType.VarChar, 500).Value = Direccion;
                cmd.Parameters.Add("@MunicipioId", SqlDbType.Int).Value = MunicipioId;
                cmd.Parameters.Add("@Telefono", SqlDbType.VarChar, 500).Value = Telefono;
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
            }
        }

        public void Modificar_Clinca(int ClinicaId, string Nombres, string Direccion, int MunicipioId, string Telefono)
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_Modificar_Clinca", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ClinicaId", SqlDbType.Int).Value = ClinicaId;
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 500).Value = Nombres;
                cmd.Parameters.Add("@Direccion", SqlDbType.VarChar, 500).Value = Direccion;
                cmd.Parameters.Add("@MunicipioId", SqlDbType.Int).Value = MunicipioId;
                cmd.Parameters.Add("@Telefono", SqlDbType.VarChar, 500).Value = Telefono;
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
            }
        }

        public void Insert_Foto_Clinica(int ClinicaId, byte[] Archivo, string ContentType, string Nombre_Archivo)
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_Insert_Foto_Clinica", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ClinicaId", SqlDbType.Int).Value = ClinicaId;
                cmd.Parameters.Add("@ContentType", SqlDbType.VarChar, 200).Value = ContentType;
                cmd.Parameters.Add("@Nombre_Archivo", SqlDbType.VarChar, 200).Value = Nombre_Archivo;
                cmd.Parameters.AddWithValue("@File", SqlDbType.VarBinary).Value = Archivo;
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
            }
        }

        public DataSet Get_Clincas(int ClienteId)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_Get_Clincas", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ClienteId", SqlDbType.Int).Value = ClienteId;
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

        public DataSet Get_Clinca(int ClinicaId)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_Get_Clinca", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ClinicaId", SqlDbType.Int).Value = ClinicaId;
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

        public DataSet Get_Doctores_Activos(string Idioma, int EspecialidadId)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand cmd = new SqlCommand("Sp_Get_Doctores_Activos", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Idioma", SqlDbType.VarChar, 10).Value = Idioma;
                cmd.Parameters.Add("@EspecialidadId", SqlDbType.Int).Value = EspecialidadId;
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