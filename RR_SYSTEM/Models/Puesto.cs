using System;
using System.Collections.Generic;

namespace RR_SYSTEM.Models;

public partial class Puesto
{
    public int IdPuesto { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
