using System;

public class Cita
{
    public int NumCita { get; set; }
    public string NumConsultorio { get; set; } 
    public TimeSpan HoraAtencion { get; set; }
    public DateTime FechaAtencion { get; set; }
    public int IDMedico { get; set; }        
    public int CedulaPaciente { get; set; }  
}
