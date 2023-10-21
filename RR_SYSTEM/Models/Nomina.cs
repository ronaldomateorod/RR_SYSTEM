using System;
using System.Collections.Generic;

namespace RR_SYSTEM.Models;

public partial class Nomina
{
    public int IdNomina { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime FechaCorte { get; set; }

    public int? CreadoPor { get; set; }

    public int? ModificadoPor { get; set; }

    public int? IdEstado { get; set; }

    public int? IdProyecto { get; set; }

    public virtual Usuario? CreadoPorNavigation { get; set; }

    public virtual ICollection<DetalleNomina> DetalleNominas { get; set; } = new List<DetalleNomina>();

    public virtual Estado? IdEstadoNavigation { get; set; }

    public virtual Proyecto? IdProyectoNavigation { get; set; }

    public virtual Usuario? ModificadoPorNavigation { get; set; }

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
