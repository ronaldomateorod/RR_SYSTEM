using System;
using System.Collections.Generic;

namespace RR_SYSTEM.Models;

public partial class UsuarioRol
{
    public int IdUsuarioRol { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdRol { get; set; }

    public virtual Role? IdRolNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
