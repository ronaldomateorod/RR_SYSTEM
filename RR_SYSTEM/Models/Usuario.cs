using System;
using System.Collections.Generic;

namespace RR_SYSTEM.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public int? IdEmpleado { get; set; }

    public int? IdEstado { get; set; }

    public virtual ICollection<Empleado> EmpleadoCreadoPorNavigations { get; set; } = new List<Empleado>();

    public virtual ICollection<Empleado> EmpleadoModifcadoPorNavigations { get; set; } = new List<Empleado>();

    public virtual Empleado? IdEmpleadoNavigation { get; set; }

    public virtual Estado? IdEstadoNavigation { get; set; }

    public virtual ICollection<Nomina> NominaCreadoPorNavigations { get; set; } = new List<Nomina>();

    public virtual ICollection<Nomina> NominaModificadoPorNavigations { get; set; } = new List<Nomina>();

    public virtual ICollection<Pago> PagoCreadoPorNavigations { get; set; } = new List<Pago>();

    public virtual ICollection<Pago> PagoModifcadoPorNavigations { get; set; } = new List<Pago>();

    public virtual ICollection<UsuarioRol> UsuarioRols { get; set; } = new List<UsuarioRol>();
}
