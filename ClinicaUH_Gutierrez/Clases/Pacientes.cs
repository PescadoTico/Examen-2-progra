using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicaUH_Gutierrez.Clases
{
    public class Paciente
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public int Edad { get; set; } 

    }
}
