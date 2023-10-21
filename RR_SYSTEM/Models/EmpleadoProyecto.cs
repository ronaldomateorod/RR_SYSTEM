using System;
using System.Collections.Generic;

namespace RR_SYSTEM.Models;

public partial class EmpleadoProyecto
{
    public int IdEmpleadoProyecto { get; set; }

    public bool? EsEncargado { get; set; }

    public int? IdEmpleado { get; set; }

    public int? IdProyecto { get; set; }

    public virtual ICollection<ActividadesAsignada> ActividadesAsignada { get; set; } = new List<ActividadesAsignada>();

    public virtual Empleado? IdEmpleadoNavigation { get; set; }

    public virtual Proyecto? IdProyectoNavigation { get; set; }
}
