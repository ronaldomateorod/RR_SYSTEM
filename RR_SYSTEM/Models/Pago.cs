using System;
using System.Collections.Generic;

namespace RR_SYSTEM.Models;

public partial class Pago
{
    public int IdPago { get; set; }

    public DateTime Fecha { get; set; }

    public decimal Monto { get; set; }

    public string Empleado { get; set; } = null!;

    public string Emisor { get; set; } = null!;

    public string TipoPago { get; set; } = null!;

    public decimal Comision { get; set; }

    public int? IdEmpleadoFk { get; set; }

    public int? IdNominaFk { get; set; }

    public int? IdEstadoFk { get; set; }

    public int? CreadoPor { get; set; }

    public int? ModifcadoPor { get; set; }

    public virtual Usuario? CreadoPorNavigation { get; set; }

    public virtual Empleado? IdEmpleadoFkNavigation { get; set; }

    public virtual Estado? IdEstadoFkNavigation { get; set; }

    public virtual Nomina? IdNominaFkNavigation { get; set; }

    public virtual Usuario? ModifcadoPorNavigation { get; set; }
}
