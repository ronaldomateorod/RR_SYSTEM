using System;
using System.Collections.Generic;

namespace RR_SYSTEM.Models;

public partial class Licencia
{
    public int IdLicencia { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public int? IdEmpleado { get; set; }

    public virtual Empleado? IdEmpleadoNavigation { get; set; }
}
