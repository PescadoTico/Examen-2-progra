using System;
using ClinicaUH_Gutierrez.Clases;
using ClinicaUH_Gutierrez.Data;

namespace ClinicaUH_Gutierrez.Forms
{
    public partial class Medicos : System.Web.UI.Page
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
            Medico nuevo = new Medico
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Especialidad = txtEspecialidad.Text
            };

            DatosMedicos.Agregar(nuevo);
            LimpiarCampos();
            CargarGrid();
        }

        private void CargarGrid()
        {
            gvMedicos.DataSource = DatosMedicos.Obtener();
            gvMedicos.DataBind();
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEspecialidad.Text = "";
        }


        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
