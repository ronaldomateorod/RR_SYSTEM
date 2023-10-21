using System;
using System.Collections.Generic;

namespace RR_SYSTEM.Models;

public partial class Deduccione
{
    public int IdDeduccion { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Monto { get; set; }

    public double? Porcentaje { get; set; }

    public string? Tipo { get; set; }
}
