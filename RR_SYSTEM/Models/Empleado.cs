using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RR_SYSTEM.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    [DataType(DataType.Date)]
    [DisplayName("Fecha de nacimiento")]
    public DateTime FechaNacimiento { get; set; }

    public string Cedula { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string? Celular { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public string Sexo { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    [DisplayName("Numero de cuenta")]
    public int NumDeCuenta { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int? IdNacionalidadFk { get; set; }

    public int? IdMunicipioFk { get; set; }

    public int? IdPuestoFk { get; set; }

    public int? IdContratoFk { get; set; }

    public int? IdEstadoFk { get; set; }

    public int? CreadoPor { get; set; }

    public int? ModifcadoPor { get; set; }

    public virtual ICollection<Asistencia> Asistencia { get; set; } = new List<Asistencia>();

    public virtual Usuario? CreadoPorNavigation { get; set; }

    public virtual ICollection<EmpleadoDeduccion> EmpleadoDeduccions { get; set; } = new List<EmpleadoDeduccion>();

    public virtual ICollection<EmpleadoPercepcion> EmpleadoPercepcions { get; set; } = new List<EmpleadoPercepcion>();

    public virtual ICollection<EmpleadoProyecto> EmpleadoProyectos { get; set; } = new List<EmpleadoProyecto>();

    public virtual Contrato? IdContratoFkNavigation { get; set; }

    public virtual Estado? IdEstadoFkNavigation { get; set; }

    public virtual Municipio? IdMunicipioFkNavigation { get; set; }

    public virtual Nacionalidade? IdNacionalidadFkNavigation { get; set; }

    public virtual Puesto? IdPuestoFkNavigation { get; set; }

    public virtual ICollection<Licencia> Licencia { get; set; } = new List<Licencia>();

    public virtual Usuario? ModifcadoPorNavigation { get; set; }

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    public virtual ICollection<Permiso> Permisos { get; set; } = new List<Permiso>();

    public virtual ICollection<Proyecto> Proyectos { get; set; } = new List<Proyecto>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}