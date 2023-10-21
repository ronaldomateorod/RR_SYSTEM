using System;
using System.Collections.Generic;

namespace RR_SYSTEM.Models;

public partial class Role
{
    public int IdRol { get; set; }

    public string Rol { get; set; } = null!;

    public virtual ICollection<UsuarioRol> UsuarioRols { get; set; } = new List<UsuarioRol>();
}
