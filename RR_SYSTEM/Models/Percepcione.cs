﻿using System;
using System.Collections.Generic;

namespace RR_SYSTEM.Models;

public partial class Percepcione
{
    public int IdPercepcion { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Monto { get; set; }
}
