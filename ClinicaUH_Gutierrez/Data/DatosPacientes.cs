using ClinicaUH_Gutierrez.Clases;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace ClinicaUH_Gutierrez.Data
{
    public class DatosPacientes
    {
        private static string conexion = ConfigurationManager.ConnectionStrings["ClinicaConnection"].ConnectionString;

        public static void Agregar(Paciente paciente)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string query = "INSERT INTO Paciente (Cedula, Nombre, Apellido, FechaDeNacimiento, Telefono, Correo, Edad) " +
                               "VALUES (@Cedula, @Nombre, @Apellido, @FechaDeNacimiento, @Telefono, @Correo, @Edad)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Cedula", paciente.Cedula);
                cmd.Parameters.AddWithValue("@Nombre", paciente.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", paciente.Apellido);
                cmd.Parameters.AddWithValue("@FechaDeNacimiento", paciente.FechaDeNacimiento);
                cmd.Parameters.AddWithValue("@Telefono", paciente.Telefono);
                cmd.Parameters.AddWithValue("@Correo", paciente.Correo);
                cmd.Parameters.AddWithValue("@Edad", paciente.Edad);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public static List<Paciente> Obtener()
        {
            List<Paciente> lista = new List<Paciente>();

            using (SqlConnection con = new SqlConnection(conexion))
            {
                string query = "SELECT Cedula, Nombre, Apellido, FechaDeNacimiento, Telefono, Correo, Edad FROM Paciente";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Paciente paciente = new Paciente
                    {
                        Cedula = reader["Cedula"].ToString(),
                        Nombre = reader["Nombre"].ToString(),
                        Apellido = reader["Apellido"].ToString(),
                        FechaDeNacimiento = reader.GetDateTime(reader.GetOrdinal("FechaDeNacimiento")),
                        Telefono = reader["Telefono"].ToString(),
                        Correo = reader["Correo"].ToString(),
                        Edad = Convert.ToInt32(reader["Edad"])
                    };
                    lista.Add(paciente);
                }
                con.Close();
            }

            return lista;
        }

        public static void Eliminar(string id)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string query = "DELETE FROM Paciente WHERE Cedula = @Cedula";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Cedula", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
