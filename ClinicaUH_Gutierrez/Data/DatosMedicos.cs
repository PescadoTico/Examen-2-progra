using ClinicaUH_Gutierrez.Clases;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace ClinicaUH_Gutierrez.Data
{
    public class DatosMedicos
    {
        private static string conexion = ConfigurationManager.ConnectionStrings["ClinicaConnection"].ConnectionString;

        public static void Agregar(Medico medico)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string query = "INSERT INTO Medico (Nombre, Apellido, Especialidad) VALUES (@Nombre, @Apellido, @Especialidad)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nombre", medico.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", medico.Apellido);
                cmd.Parameters.AddWithValue("@Especialidad", medico.Especialidad);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
         
        public static List<Medico> Obtener()
        {
            List<Medico> lista = new List<Medico>();

            using (SqlConnection con = new SqlConnection(conexion))
            {
                string query = "SELECT IDMedico, Nombre, Apellido, Especialidad FROM Medico";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Medico medico = new Medico
                    {
                        IDMedico = reader["IDMedico"].ToString(),
                        Nombre = reader["Nombre"].ToString(),
                        Apellido = reader["Apellido"].ToString(),
                        Especialidad = reader["Especialidad"].ToString()
                    };
                    lista.Add(medico);
                }
                con.Close();
            }

            return lista;
        }
    }
}

