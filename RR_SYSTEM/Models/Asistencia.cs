using System;
using System.Collections.Generic;

namespace RR_SYSTEM.Models;

public partial class Asistencia
{
    public int IdAsistencia { get; set; }

    public DateTime FechaEntrada { get; set; }

    public DateTime FechaSalida { get; set; }

    public int? IdProyecto { get; set; }

    public int? IdEmpleado { get; set; }

    public int? IdEstado { get; set; }

    public virtual ICollection<Hora> Horas { get; set; } = new List<Hora>();

    public virtual Empleado? IdEmpleadoNavigation { get; set; }

    public virtual Estado? IdEstadoNavigation { get; set; }

    public virtual Proyecto? IdProyectoNavigation { get; set; }
}
