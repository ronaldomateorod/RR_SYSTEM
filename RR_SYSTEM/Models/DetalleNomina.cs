using System;
using System.Collections.Generic;

namespace RR_SYSTEM.Models;

public partial class DetalleNomina
{
    public int IdDetalleNomina { get; set; }

    public string? Empleado { get; set; }

    public string? Cargo { get; set; }

    public decimal? SueldoBruto { get; set; }

    public decimal? Isr { get; set; }

    public decimal? Afp { get; set; }

    public decimal? Sfs { get; set; }

    public decimal? SueldoNeto { get; set; }

    public decimal? Beneficios { get; set; }

    public decimal? DeduccionesInternas { get; set; }

    public int? IdNomina { get; set; }

    public virtual Nomina? IdNominaNavigation { get; set; }
}
