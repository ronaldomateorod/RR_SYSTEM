using System;
using System.Collections.Generic;

namespace RR_SYSTEM.Models;

public partial class Proyecto
{
    public int IdProyecto { get; set; }

    public string Nombre { get; set; } = null!;

    public string Cliente { get; set; } = null!;

    public string? Localizacion { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaEntrega { get; set; }

    public string? Descripcion { get; set; }

    public int? IdEstado { get; set; }

    public int? IdEmpleado { get; set; }

    public virtual ICollection<Asistencia> Asistencia { get; set; } = new List<Asistencia>();

    public virtual ICollection<EmpleadoProyecto> EmpleadoProyectos { get; set; } = new List<EmpleadoProyecto>();

    public virtual Empleado? IdEmpleadoNavigation { get; set; }

    public virtual Estado? IdEstadoNavigation { get; set; }

    public virtual ICollection<Nomina> Nominas { get; set; } = new List<Nomina>();
}
