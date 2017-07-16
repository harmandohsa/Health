using System;
using System.Data;
using System.Data.SqlClient;

namespace Health.Clases
{
    class Cl_Cita
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["Conexion"]);
        DataSet ds = new DataSet();

        public int Get_Max_Cita()
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_Get_Max_Cita", cn);
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

        public void Insert_Cita(int CitaId, int PersonaIdPaciente, int PersonaIdMedico,  DateTime Fecha)
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_Insert_Cita", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CitaId", SqlDbType.Int).Value = CitaId;
                cmd.Parameters.Add("@PersonaIdPaciente", SqlDbType.Int).Value = PersonaIdPaciente;
                cmd.Parameters.Add("@PersonaIdMedico", SqlDbType.Int).Value = PersonaIdMedico;
                cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Fecha;
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
