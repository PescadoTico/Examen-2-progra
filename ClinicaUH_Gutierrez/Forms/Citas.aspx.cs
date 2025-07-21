using System;
using ClinicaUH_Gutierrez.Clases;
using ClinicaUH_Gutierrez.Data;

namespace ClinicaUH_Gutierrez.Forms
{
    public partial class Citas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrid();
                lblError.Visible = false; // Oculta mensaje error inicial
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;

            // Validar y convertir todos los campos
            if (!TimeSpan.TryParse(txtHoraAtencion.Text, out TimeSpan hora))
            {
                MostrarError("Formato incorrecto en Hora de Atención. Use HH:mm");
                return;
            }

            if (!DateTime.TryParse(txtFechaAtencion.Text, out DateTime fecha))
            {
                MostrarError("Formato incorrecto en Fecha de Atención. Use formato válido");
                return;
            }

            if (!int.TryParse(txtIDMedico.Text, out int idMedico))
            {
                MostrarError("ID Médico debe ser un número entero");
                return;
            }

            if (!int.TryParse(txtCedula.Text, out int cedula))
            {
                MostrarError("Cédula debe ser un número entero");
                return;
            }

            try
            {
                Cita nueva = new Cita
                {
                    NumConsultorio = txtNumConsultorio.Text,
                    HoraAtencion = hora,
                    FechaAtencion = fecha,
                    IDMedico = idMedico,
                    CedulaPaciente = cedula
                };

                DatosCitas.Agregar(nueva);
                LimpiarCampos();
                CargarGrid();
            }
            catch (Exception ex)
            {
                MostrarError("Error al agregar la cita: " + ex.Message);
            }
        }

        private void MostrarError(string mensaje)
        {
            lblError.Text = mensaje;
            lblError.Visible = true;
        }

        private void CargarGrid()
        {
            try
            {
                gvCitas.DataSource = DatosCitas.Obtener();
                gvCitas.DataBind();
                lblError.Visible = false;
            }
            catch (Exception ex)
            {
                MostrarError("Error al cargar las citas: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtNumConsultorio.Text = "";
            txtHoraAtencion.Text = "";
            txtFechaAtencion.Text = "";
            txtIDMedico.Text = "";
            txtCedula.Text = "";
        }
    }
}
