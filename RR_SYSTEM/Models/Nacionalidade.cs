using System;
using System.Collections.Generic;

namespace RR_SYSTEM.Models;

public partial class Nacionalidade
{
    public int IdNacionalidad { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
