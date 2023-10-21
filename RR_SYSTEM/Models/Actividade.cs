using System;
using System.Collections.Generic;

namespace RR_SYSTEM.Models;

public partial class Actividade
{
    public int IdActividad { get; set; }

    public string? Descripcion { get; set; }

    public decimal? TarifaMinima { get; set; }

    public bool? PagadaPorHora { get; set; }

    public virtual ICollection<ActividadesAsignada> ActividadesAsignada { get; set; } = new List<ActividadesAsignada>();
}
