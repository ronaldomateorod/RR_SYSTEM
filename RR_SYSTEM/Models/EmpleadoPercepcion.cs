using System;
using System.Collections.Generic;

namespace RR_SYSTEM.Models;

public partial class EmpleadoPercepcion
{
    public int IdPercepcionEmpleado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaAplicacion { get; set; }

    public int? IdEmpleadoFk { get; set; }

    public int? IdPercepcionFk { get; set; }

    public virtual Empleado? IdEmpleadoFkNavigation { get; set; }
}
