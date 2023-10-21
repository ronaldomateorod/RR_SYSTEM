using System;
using System.Collections.Generic;

namespace RR_SYSTEM.Models;

public partial class Municipio
{
    public int IdMunicipio { get; set; }

    public string Nombre { get; set; } = null!;

    public int? IdProvinciaFk { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    public virtual Provincia? IdProvinciaFkNavigation { get; set; }
}
