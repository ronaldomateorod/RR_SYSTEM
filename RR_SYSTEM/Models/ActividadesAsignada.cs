using System;
using System.Collections.Generic;

namespace RR_SYSTEM.Models;

public partial class ActividadesAsignada
{
    public int IdActividadAsignada { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public int? IdActividad { get; set; }

    public int? IdEstado { get; set; }

    public int? IdEmpleadoProyectoFk { get; set; }

    public virtual Actividade? IdActividadNavigation { get; set; }

    public virtual EmpleadoProyecto? IdEmpleadoProyectoFkNavigation { get; set; }

    public virtual Estado? IdEstadoNavigation { get; set; }
}
