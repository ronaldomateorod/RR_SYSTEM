using System;
using System.Collections.Generic;

namespace RR_SYSTEM.Models;

public partial class Contrato
{
    public int IdContrato { get; set; }

    public DateTime FechaContratacion { get; set; }

    public string Descripcion { get; set; } = null!;

    public int Tipo { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
