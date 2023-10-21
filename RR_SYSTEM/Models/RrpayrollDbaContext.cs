using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RR_SYSTEM.Models;

public partial class RrpayrollDbaContext : DbContext
{
    public RrpayrollDbaContext()
    {
    }

    public RrpayrollDbaContext(DbContextOptions<RrpayrollDbaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actividade> Actividades { get; set; }

    public virtual DbSet<ActividadesAsignada> ActividadesAsignadas { get; set; }

    public virtual DbSet<Asistencia> Asistencias { get; set; }

    public virtual DbSet<Contrato> Contratos { get; set; }

    public virtual DbSet<Deduccione> Deducciones { get; set; }

    public virtual DbSet<DetalleNomina> DetalleNominas { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<EmpleadoDeduccion> EmpleadoDeduccions { get; set; }

    public virtual DbSet<EmpleadoPercepcion> EmpleadoPercepcions { get; set; }

    public virtual DbSet<EmpleadoProyecto> EmpleadoProyectos { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Hora> Horas { get; set; }

    public virtual DbSet<Licencia> Licencias { get; set; }

    public virtual DbSet<Municipio> Municipios { get; set; }

    public virtual DbSet<Nacionalidade> Nacionalidades { get; set; }

    public virtual DbSet<Nomina> Nominas { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Percepcione> Percepciones { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<Provincia> Provincias { get; set; }

    public virtual DbSet<Proyecto> Proyectos { get; set; }

    public virtual DbSet<Puesto> Puestos { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioRol> UsuarioRols { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=localhost;Integrated Security=true;Initial Catalog=RRPAYROLL_DBA;TrustServerCertificate=True;MultipleActiveResultSets=true;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actividade>(entity =>
        {
            entity.HasKey(e => e.IdActividad).HasName("PK__Activida__5EAF86A4D45AFD43");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.TarifaMinima).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<ActividadesAsignada>(entity =>
        {
            entity.HasKey(e => e.IdActividadAsignada).HasName("PK__Activida__30766FF8BDF359A6");

            entity.Property(e => e.FechaFin).HasColumnType("date");
            entity.Property(e => e.FechaInicio).HasColumnType("date");
            entity.Property(e => e.IdEmpleadoProyectoFk).HasColumnName("IdEmpleadoProyectoFK");

            entity.HasOne(d => d.IdActividadNavigation).WithMany(p => p.ActividadesAsignada)
                .HasForeignKey(d => d.IdActividad)
                .HasConstraintName("FK__Actividad__IdAct__66603565");

            entity.HasOne(d => d.IdEmpleadoProyectoFkNavigation).WithMany(p => p.ActividadesAsignada)
                .HasForeignKey(d => d.IdEmpleadoProyectoFk)
                .HasConstraintName("FK__Actividad__IdEmp__68487DD7");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.ActividadesAsignada)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("FK__Actividad__IdEst__6754599E");
        });

        modelBuilder.Entity<Asistencia>(entity =>
        {
            entity.HasKey(e => e.IdAsistencia).HasName("PK__Asistenc__3956DEE69E087C5F");

            entity.Property(e => e.FechaEntrada).HasColumnType("date");
            entity.Property(e => e.FechaSalida).HasColumnType("date");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Asistencia)
                .HasForeignKey(d => d.IdEmpleado)
                .HasConstraintName("FK__Asistenci__IdEmp__6C190EBB");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Asistencia)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("FK__Asistenci__IdEst__6D0D32F4");

            entity.HasOne(d => d.IdProyectoNavigation).WithMany(p => p.Asistencia)
                .HasForeignKey(d => d.IdProyecto)
                .HasConstraintName("FK__Asistenci__IdPro__6B24EA82");
        });

        modelBuilder.Entity<Contrato>(entity =>
        {
            entity.HasKey(e => e.IdContrato).HasName("PK__Contrato__8569F05A61BF1F9D");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.FechaContratacion).HasColumnType("datetime");
        });

        modelBuilder.Entity<Deduccione>(entity =>
        {
            entity.HasKey(e => e.IdDeduccion).HasName("PK__Deduccio__5EDD827B6FF70E47");

            entity.Property(e => e.Descripcion).IsUnicode(false);
            entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Tipo)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DetalleNomina>(entity =>
        {
            entity.HasKey(e => e.IdDetalleNomina).HasName("PK__DetalleN__117BAAF1FACE2947");

            entity.ToTable("DetalleNomina");

            entity.Property(e => e.Afp)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("AFP");
            entity.Property(e => e.Beneficios).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Cargo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DeduccionesInternas).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Empleado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Isr)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("ISR");
            entity.Property(e => e.Sfs)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("SFS");
            entity.Property(e => e.SueldoBruto).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.SueldoNeto).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.IdNominaNavigation).WithMany(p => p.DetalleNominas)
                .HasForeignKey(d => d.IdNomina)
                .HasConstraintName("FK__DetalleNo__IdNom__75A278F5");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__Empleado__CE6D8B9EA68F0FA8");

            entity.HasIndex(e => e.Codigo, "UQ__Empleado__06370DAC82B51EAA").IsUnique();

            entity.HasIndex(e => e.Cedula, "UQ__Empleado__B4ADFE38C53EDA05").IsUnique();

            entity.HasIndex(e => e.NumDeCuenta, "UQ__Empleado__C112A0ACB90A2F5C").IsUnique();

            entity.Property(e => e.Apellido)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Cedula)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.Celular)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.Codigo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Direccion).IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaNacimiento).HasColumnType("date");
            entity.Property(e => e.IdContratoFk).HasColumnName("IdContratoFK");
            entity.Property(e => e.IdEstadoFk).HasColumnName("IdEstadoFK");
            entity.Property(e => e.IdMunicipioFk).HasColumnName("IdMunicipioFK");
            entity.Property(e => e.IdNacionalidadFk).HasColumnName("IdNacionalidadFK");
            entity.Property(e => e.IdPuestoFk).HasColumnName("IdPuestoFK");
            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Telefono)
                .HasMaxLength(12)
                .IsUnicode(false);

            entity.HasOne(d => d.CreadoPorNavigation).WithMany(p => p.EmpleadoCreadoPorNavigations)
                .HasForeignKey(d => d.CreadoPor)
                .HasConstraintName("FK__Empleados__Cread__09A971A2");

            entity.HasOne(d => d.IdContratoFkNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdContratoFk)
                .HasConstraintName("FK__Empleados__IdCon__48CFD27E");

            entity.HasOne(d => d.IdEstadoFkNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdEstadoFk)
                .HasConstraintName("FK__Empleados__IdEst__49C3F6B7");

            entity.HasOne(d => d.IdMunicipioFkNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdMunicipioFk)
                .HasConstraintName("FK__Empleados__IdMun__46E78A0C");

            entity.HasOne(d => d.IdNacionalidadFkNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdNacionalidadFk)
                .HasConstraintName("FK__Empleados__IdNac__45F365D3");

            entity.HasOne(d => d.IdPuestoFkNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdPuestoFk)
                .HasConstraintName("FK__Empleados__IdPue__47DBAE45");

            entity.HasOne(d => d.ModifcadoPorNavigation).WithMany(p => p.EmpleadoModifcadoPorNavigations)
                .HasForeignKey(d => d.ModifcadoPor)
                .HasConstraintName("FK__Empleados__Modif__0A9D95DB");
        });

        modelBuilder.Entity<EmpleadoDeduccion>(entity =>
        {
            entity.HasKey(e => e.IdDeduccionEmpleado).HasName("PK__Empleado__FC911C802D6A5852");

            entity.ToTable("EmpleadoDeduccion");

            entity.Property(e => e.FechaAplicacion).HasColumnType("date");
            entity.Property(e => e.FechaCreacion).HasColumnType("date");

            entity.HasOne(d => d.IdEmpleadoFkNavigation).WithMany(p => p.EmpleadoDeduccions)
                .HasForeignKey(d => d.IdEmpleadoFk)
                .HasConstraintName("FK__EmpleadoD__IdEmp__08B54D69");
        });

        modelBuilder.Entity<EmpleadoPercepcion>(entity =>
        {
            entity.HasKey(e => e.IdPercepcionEmpleado).HasName("PK__Empleado__E3706838871D0064");

            entity.ToTable("EmpleadoPercepcion");

            entity.Property(e => e.FechaAplicacion).HasColumnType("date");
            entity.Property(e => e.FechaCreacion).HasColumnType("date");

            entity.HasOne(d => d.IdEmpleadoFkNavigation).WithMany(p => p.EmpleadoPercepcions)
                .HasForeignKey(d => d.IdEmpleadoFk)
                .HasConstraintName("FK__EmpleadoP__IdEmp__03F0984C");
        });

        modelBuilder.Entity<EmpleadoProyecto>(entity =>
        {
            entity.HasKey(e => e.IdEmpleadoProyecto).HasName("PK__Empleado__55DF72510B91D6A7");

            entity.ToTable("EmpleadoProyecto");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.EmpleadoProyectos)
                .HasForeignKey(d => d.IdEmpleado)
                .HasConstraintName("FK__EmpleadoP__IdEmp__628FA481");

            entity.HasOne(d => d.IdProyectoNavigation).WithMany(p => p.EmpleadoProyectos)
                .HasForeignKey(d => d.IdProyecto)
                .HasConstraintName("FK__EmpleadoP__IdPro__6383C8BA");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PK__Estados__FBB0EDC13A951AF1");

            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Hora>(entity =>
        {
            entity.HasKey(e => e.IdHora).HasName("PK__Horas__5FEB39EBEA140D39");

            entity.Property(e => e.EmpleadoNombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdAsistenciaFkNavigation).WithMany(p => p.Horas)
                .HasForeignKey(d => d.IdAsistenciaFk)
                .HasConstraintName("FK__Horas__IdAsisten__7F2BE32F");
        });

        modelBuilder.Entity<Licencia>(entity =>
        {
            entity.HasKey(e => e.IdLicencia).HasName("PK__Licencia__0F8D118D3079E340");

            entity.Property(e => e.FechaFin).HasColumnType("date");
            entity.Property(e => e.FechaInicio).HasColumnType("date");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Licencia)
                .HasForeignKey(d => d.IdEmpleado)
                .HasConstraintName("FK__Licencias__IdEmp__4F7CD00D");
        });

        modelBuilder.Entity<Municipio>(entity =>
        {
            entity.HasKey(e => e.IdMunicipio).HasName("PK__Municipi__61005978375B578D");

            entity.Property(e => e.IdProvinciaFk).HasColumnName("IdProvinciaFK");
            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .IsUnicode(false);

            entity.HasOne(d => d.IdProvinciaFkNavigation).WithMany(p => p.Municipios)
                .HasForeignKey(d => d.IdProvinciaFk)
                .HasConstraintName("FK__Municipio__IdPro__3C69FB99");
        });

        modelBuilder.Entity<Nacionalidade>(entity =>
        {
            entity.HasKey(e => e.IdNacionalidad).HasName("PK__Nacional__021E36BE46BC7E7D");

            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Nomina>(entity =>
        {
            entity.HasKey(e => e.IdNomina).HasName("PK__Nominas__02F9D722E139D18D");

            entity.Property(e => e.FechaCorte).HasColumnType("date");
            entity.Property(e => e.FechaCreacion).HasColumnType("date");

            entity.HasOne(d => d.CreadoPorNavigation).WithMany(p => p.NominaCreadoPorNavigations)
                .HasForeignKey(d => d.CreadoPor)
                .HasConstraintName("FK__Nominas__CreadoP__6FE99F9F");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Nominas)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("FK__Nominas__IdEstad__71D1E811");

            entity.HasOne(d => d.IdProyectoNavigation).WithMany(p => p.Nominas)
                .HasForeignKey(d => d.IdProyecto)
                .HasConstraintName("FK__Nominas__IdProye__72C60C4A");

            entity.HasOne(d => d.ModificadoPorNavigation).WithMany(p => p.NominaModificadoPorNavigations)
                .HasForeignKey(d => d.ModificadoPor)
                .HasConstraintName("FK__Nominas__Modific__70DDC3D8");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.IdPago).HasName("PK__Pagos__FC851A3AC8943A6A");

            entity.Property(e => e.Comision).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Emisor)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Empleado)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.IdEmpleadoFk).HasColumnName("IdEmpleadoFK");
            entity.Property(e => e.IdEstadoFk).HasColumnName("IdEstadoFK");
            entity.Property(e => e.IdNominaFk).HasColumnName("IdNominaFK");
            entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TipoPago)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.CreadoPorNavigation).WithMany(p => p.PagoCreadoPorNavigations)
                .HasForeignKey(d => d.CreadoPor)
                .HasConstraintName("FK__Pagos__CreadoPor__7B5B524B");

            entity.HasOne(d => d.IdEmpleadoFkNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdEmpleadoFk)
                .HasConstraintName("FK__Pagos__IdEmplead__787EE5A0");

            entity.HasOne(d => d.IdEstadoFkNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdEstadoFk)
                .HasConstraintName("FK__Pagos__IdEstadoF__7A672E12");

            entity.HasOne(d => d.IdNominaFkNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdNominaFk)
                .HasConstraintName("FK__Pagos__IdNominaF__797309D9");

            entity.HasOne(d => d.ModifcadoPorNavigation).WithMany(p => p.PagoModifcadoPorNavigations)
                .HasForeignKey(d => d.ModifcadoPor)
                .HasConstraintName("FK__Pagos__Modifcado__7C4F7684");
        });

        modelBuilder.Entity<Percepcione>(entity =>
        {
            entity.HasKey(e => e.IdPercepcion).HasName("PK__Percepci__9248C5C9F995F6EC");

            entity.Property(e => e.Descripcion).IsUnicode(false);
            entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.IdPermiso).HasName("PK__Permisos__0D626EC81657975E");

            entity.Property(e => e.Descripcion).IsUnicode(false);
            entity.Property(e => e.FechaEmision).HasColumnType("date");
            entity.Property(e => e.FechaSolicitud).HasColumnType("date");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Permisos)
                .HasForeignKey(d => d.IdEmpleado)
                .HasConstraintName("FK__Permisos__IdEmpl__4CA06362");
        });

        modelBuilder.Entity<Provincia>(entity =>
        {
            entity.HasKey(e => e.IdProvincia).HasName("PK__Provinci__EED74455A0ADB83D");

            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Proyecto>(entity =>
        {
            entity.HasKey(e => e.IdProyecto).HasName("PK__Proyecto__F488867305F70D99");

            entity.Property(e => e.Cliente).IsUnicode(false);
            entity.Property(e => e.Descripcion).IsUnicode(false);
            entity.Property(e => e.FechaEntrega).HasColumnType("date");
            entity.Property(e => e.FechaInicio).HasColumnType("date");
            entity.Property(e => e.Localizacion).IsUnicode(false);
            entity.Property(e => e.Nombre).IsUnicode(false);

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Proyectos)
                .HasForeignKey(d => d.IdEmpleado)
                .HasConstraintName("FK__Proyectos__IdEmp__5DCAEF64");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Proyectos)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("FK__Proyectos__IdEst__5CD6CB2B");
        });

        modelBuilder.Entity<Puesto>(entity =>
        {
            entity.HasKey(e => e.IdPuesto).HasName("PK__Puestos__ADAC6B9C549E60D5");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(70)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Roles__2A49584C3D03F30A");

            entity.HasIndex(e => e.Rol, "UQ__Roles__CAF005143A8AB145").IsUnique();

            entity.Property(e => e.Rol)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__5B65BF97A95C9C60");

            entity.Property(e => e.Contrasena)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdEmpleado)
                .HasConstraintName("FK__Usuarios__IdEmpl__5535A963");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("FK__Usuarios__IdEsta__5629CD9C");
        });

        modelBuilder.Entity<UsuarioRol>(entity =>
        {
            entity.HasKey(e => e.IdUsuarioRol).HasName("PK__UsuarioR__6806BF4ABBFDB4AA");

            entity.ToTable("UsuarioRol");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.UsuarioRols)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__UsuarioRo__IdRol__59FA5E80");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.UsuarioRols)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__UsuarioRo__IdUsu__59063A47");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
