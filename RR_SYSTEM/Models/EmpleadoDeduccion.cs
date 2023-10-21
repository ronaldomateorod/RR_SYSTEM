using System;
using System.Collections.Generic;

namespace RR_SYSTEM.Models;

public partial class EmpleadoDeduccion
{
    public int IdDeduccionEmpleado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaAplicacion { get; set; }

    public int? IdEmpleadoFk { get; set; }

    public virtual Empleado? IdEmpleadoFkNavigation { get; set; }
}
