using System;
using System.Collections.Generic;

namespace RR_SYSTEM.Models;

public partial class Permiso
{
    public int IdPermiso { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaSolicitud { get; set; }

    public DateTime? FechaEmision { get; set; }

    public int? IdEmpleado { get; set; }

    public virtual Empleado? IdEmpleadoNavigation { get; set; }
}
