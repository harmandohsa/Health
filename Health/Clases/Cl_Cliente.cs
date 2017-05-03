using System;
using System.Data;
using System.Data.SqlClient;

namespace Health.Clases
{
    public class Cl_Cliente
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["Conexion"]);
        DataSet ds = new DataSet();
        string a = "";
        public DataSet GetDatosCliente(int ClienteId)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_GetDatosCliente", cn);
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

        public void Update_Estado_Fase_Cliente(int ClienteId)
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_Update_Estado_Fase_Cliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ClienteId", SqlDbType.Int).Value = ClienteId;
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
            }
        }

    }
}