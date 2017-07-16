using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Health.Clases
{
    public class Cl_Persona
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["Conexion"]);
        DataSet ds = new DataSet();

        public void Insert_Persona(int PersonaId, int AliasId, string Nombres, string Apellidos, int GeneroId, string Noid, string Direccion, int MunicipioId, string Telefono, string Tel_Movil, int UniversidadId, string NoColegiado, string Titulo, DateTime Fecha_Nacimiento)
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_Insert_Persona", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PersonaId", SqlDbType.Int).Value = PersonaId;
                cmd.Parameters.Add("@AliasId", SqlDbType.Int).Value = AliasId;
                cmd.Parameters.Add("@Nombres", SqlDbType.VarChar, 500).Value = Nombres;
                cmd.Parameters.Add("@Apellidos", SqlDbType.VarChar, 500).Value = Apellidos;
                cmd.Parameters.Add("@GeneroId", SqlDbType.Int).Value = GeneroId;
                cmd.Parameters.Add("@No_Identificacion", SqlDbType.VarChar, 500).Value = Noid;
                cmd.Parameters.Add("@Direccion", SqlDbType.VarChar, 500).Value = Direccion;
                cmd.Parameters.Add("@MunicipioId", SqlDbType.Int).Value =  MunicipioId;
                cmd.Parameters.Add("@Telefono", SqlDbType.VarChar, 500).Value = Telefono;
                cmd.Parameters.Add("@Telefono_Movil", SqlDbType.VarChar, 500).Value = Tel_Movil;
                if (UniversidadId == 0)
                    cmd.Parameters.Add("@UniversidadId", SqlDbType.Int).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@UniversidadId", SqlDbType.Int).Value = UniversidadId;
                cmd.Parameters.Add("@Colegiado", SqlDbType.VarChar, 500).Value = NoColegiado;
                cmd.Parameters.Add("@Titulo ", SqlDbType.VarChar, 500).Value = Titulo;
                cmd.Parameters.Add("@Fecha_Nac ", SqlDbType.Date).Value = Fecha_Nacimiento;
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
            }
        }


        public void Insert_Persona_Paciente(int PersonaId, string Nombres, string Apellidos, int GeneroId, string Tel_Movil, DateTime Fecha_Nacimiento)
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_Insert_Persona_Paciente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PersonaId", SqlDbType.Int).Value = PersonaId;
                cmd.Parameters.Add("@Nombres", SqlDbType.VarChar, 500).Value = Nombres;
                cmd.Parameters.Add("@Apellidos", SqlDbType.VarChar, 500).Value = Apellidos;
                cmd.Parameters.Add("@GeneroId", SqlDbType.Int).Value = GeneroId;
                cmd.Parameters.Add("@Telefono_Movil", SqlDbType.VarChar, 500).Value = Tel_Movil;
                cmd.Parameters.Add("@Fecha_Nac ", SqlDbType.Date).Value = Fecha_Nacimiento;
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
            }
        }

        public int Get_Max_Persona()
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_Get_Max_Persona", cn);
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

        public void Insert_Foto_Perfil(int PersonaId, byte[] Archivo, string ContentType, string Nombre_Archivo)
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_Insert_Foto_Perfil", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PersonaId", SqlDbType.Int).Value = PersonaId;
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

        public void Insert_Foto_Titulo(int PersonaId, byte[] Archivo, string ContentType, string Nombre_Archivo)
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_Insert_Foto_Titulo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PersonaId", SqlDbType.Int).Value = PersonaId;
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

        public DataSet Get_Datos_Persona(int PersonaId, string Idioma)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_Get_Datos_Persona", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PersonaId", SqlDbType.Int).Value = PersonaId;
                cmd.Parameters.Add("@idioma", SqlDbType.VarChar, 200).Value = Idioma;
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

        public void Update_Persona(int PersonaId, int AliasId, string Nombres, string Apellidos, int GeneroId, string Noid, string Direccion, int MunicipioId, string Telefono, string Tel_Movil, int UniversidadId, string NoColegiado, string Titulo, DateTime Fecha_Nacimiento)
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_Update_Persona", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PersonaId", SqlDbType.Int).Value = PersonaId;
                cmd.Parameters.Add("@AliasId", SqlDbType.Int).Value = AliasId;
                cmd.Parameters.Add("@Nombres", SqlDbType.VarChar, 500).Value = Nombres;
                cmd.Parameters.Add("@Apellidos", SqlDbType.VarChar, 500).Value = Apellidos;
                cmd.Parameters.Add("@GeneroId", SqlDbType.Int).Value = GeneroId;
                cmd.Parameters.Add("@No_Identificacion", SqlDbType.VarChar, 500).Value = Noid;
                cmd.Parameters.Add("@Direccion", SqlDbType.VarChar, 500).Value = Direccion;
                cmd.Parameters.Add("@MunicipioId", SqlDbType.Int).Value = MunicipioId;
                cmd.Parameters.Add("@Telefono", SqlDbType.VarChar, 500).Value = Telefono;
                cmd.Parameters.Add("@Telefono_Movil", SqlDbType.VarChar, 500).Value = Tel_Movil;
                if (UniversidadId == 0)
                    cmd.Parameters.Add("@UniversidadId", SqlDbType.Int).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@UniversidadId", SqlDbType.Int).Value = UniversidadId;
                cmd.Parameters.Add("@Colegiado", SqlDbType.VarChar, 500).Value = NoColegiado;
                cmd.Parameters.Add("@Titulo ", SqlDbType.VarChar, 500).Value = Titulo;
                cmd.Parameters.Add("@Fecha_Nac ", SqlDbType.Date).Value = Fecha_Nacimiento;
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
            }
        }

        public void Insert_Especialidad(int PersonaId, int EspecialidadId)
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_Insert_Especialidad", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PersonaId", SqlDbType.Int).Value = PersonaId;
                cmd.Parameters.Add("@EspecialidadId", SqlDbType.Int).Value = EspecialidadId;
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
            }
        }

        public DataSet Get_Especialidad_Usuario(int PersonaId, string Idioma)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_Get_Especialidad_Usuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PersonaId", SqlDbType.Int).Value = PersonaId;
                cmd.Parameters.Add("@idioma", SqlDbType.VarChar, 200).Value = Idioma;
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

        public void Delete_Especialidad(int PersonaId, int EspecialidadId)
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_Delete_Especialidad", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PersonaId", SqlDbType.Int).Value = PersonaId;
                cmd.Parameters.Add("@EspecialidadId", SqlDbType.Int).Value = EspecialidadId;
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