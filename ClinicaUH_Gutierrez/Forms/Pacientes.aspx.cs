using System;
using ClinicaUH_Gutierrez.Clases;
using ClinicaUH_Gutierrez.Data;

namespace ClinicaUH_Gutierrez.Forms
{
    public partial class Pacientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrid();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Paciente nuevo = new Paciente
            {
                Cedula = txtCedula.Text,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                FechaDeNacimiento = DateTime.Parse(txtFechaDeNacimiento.Text),
                Telefono = txtTelefono.Text,
                Correo = txtCorreo.Text,
                Edad = int.Parse(txtEdad.Text)
            };

            DatosPacientes.Agregar(nuevo);
            LimpiarCampos();
            CargarGrid();
        }

        private void CargarGrid()
        {
            gvPacientes.DataSource = DatosPacientes.Obtener();
            gvPacientes.DataBind();
        }

        private void LimpiarCampos()
        {
            txtCedula.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtFechaDeNacimiento.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            txtEdad.Text = "";
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
