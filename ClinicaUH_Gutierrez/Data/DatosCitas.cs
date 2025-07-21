using ClinicaUH_Gutierrez.Clases;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace ClinicaUH_Gutierrez.Data
{
    public class DatosCitas
    {
        private static string conexion = ConfigurationManager.ConnectionStrings["ClinicaConnection"].ConnectionString;

        public static void Agregar(Cita cita)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string query = @"INSERT INTO Cita (NumConsultorio, HoraAtencion, FechaAtencion, IDMedico, CedulaPaciente)
                                 VALUES (@NumConsultorio, @HoraAtencion, @FechaAtencion, @IDMedico, @CedulaPaciente)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@NumConsultorio", cita.NumConsultorio);
                cmd.Parameters.AddWithValue("@HoraAtencion", cita.HoraAtencion);
                cmd.Parameters.AddWithValue("@FechaAtencion", cita.FechaAtencion);
                cmd.Parameters.AddWithValue("@IDMedico", cita.IDMedico);
                cmd.Parameters.AddWithValue("@CedulaPaciente", cita.CedulaPaciente);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public static List<Cita> Obtener()
        {
            List<Cita> lista = new List<Cita>();

            using (SqlConnection con = new SqlConnection(conexion))
            {
                string query = "SELECT NumCita, NumConsultorio, HoraAtencion, FechaAtencion, IDMedico, CedulaPaciente FROM Cita";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Cita cita = new Cita();

                    cita.NumCita = Convert.ToInt32(reader["NumCita"]);
                    cita.NumConsultorio = reader["NumConsultorio"].ToString();

                    object horaObj = reader["HoraAtencion"];
                    if (horaObj is TimeSpan)
                        cita.HoraAtencion = (TimeSpan)horaObj;
                    else if (TimeSpan.TryParse(horaObj.ToString(), out TimeSpan horaParsed))
                        cita.HoraAtencion = horaParsed;
                    else
                        cita.HoraAtencion = TimeSpan.Zero; 

                    cita.FechaAtencion = Convert.ToDateTime(reader["FechaAtencion"]);
                    cita.IDMedico = Convert.ToInt32(reader["IDMedico"]);
                    cita.CedulaPaciente = Convert.ToInt32(reader["CedulaPaciente"]);

                    lista.Add(cita);
                }
                con.Close();
            }

            return lista;
        }

        public static void Eliminar(int numCita)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string query = "DELETE FROM Cita WHERE NumCita = @NumCita";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@NumCita", numCita);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
