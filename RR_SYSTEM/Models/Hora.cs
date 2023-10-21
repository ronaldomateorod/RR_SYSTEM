using System;
using System.Collections.Generic;

namespace RR_SYSTEM.Models;

public partial class Hora
{
    public int IdHora { get; set; }

    public string? EmpleadoNombre { get; set; }

    public double? HorasTrabajadas { get; set; }

    public double? HorasNormales { get; set; }

    public double? HorasExtras { get; set; }

    public int? IdAsistenciaFk { get; set; }

    public virtual Asistencia? IdAsistenciaFkNavigation { get; set; }
}
