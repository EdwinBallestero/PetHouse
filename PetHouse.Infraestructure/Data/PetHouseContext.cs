using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetHouse.Infraestructure.Models;

namespace PetHouse.Infraestructure.Data;

public partial class PetHouseContext : DbContext
{
    public PetHouseContext(DbContextOptions<PetHouseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BloqueosHorario> BloqueosHorario { get; set; }

    public virtual DbSet<CategoriasProducto> CategoriasProducto { get; set; }

    public virtual DbSet<CategoriasServicio> CategoriasServicio { get; set; }

    public virtual DbSet<Empleados> Empleados { get; set; }

    public virtual DbSet<Especies> Especies { get; set; }

    public virtual DbSet<EstadosReserva> EstadosReserva { get; set; }

    public virtual DbSet<FacturaDetalles> FacturaDetalles { get; set; }

    public virtual DbSet<Facturas> Facturas { get; set; }

    public virtual DbSet<Horarios> Horarios { get; set; }

    public virtual DbSet<Mascotas> Mascotas { get; set; }

    public virtual DbSet<MetodosPago> MetodosPago { get; set; }

    public virtual DbSet<Notificaciones> Notificaciones { get; set; }

    public virtual DbSet<PreguntasReserva> PreguntasReserva { get; set; }

    public virtual DbSet<Productos> Productos { get; set; }

    public virtual DbSet<Razas> Razas { get; set; }

    public virtual DbSet<Reservas> Reservas { get; set; }

    public virtual DbSet<RespuestasReserva> RespuestasReserva { get; set; }

    public virtual DbSet<Roles> Roles { get; set; }

    public virtual DbSet<Servicios> Servicios { get; set; }

    public virtual DbSet<Sucursales> Sucursales { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    public virtual DbSet<VwIngresosPorSucursal> VwIngresosPorSucursal { get; set; }

    public virtual DbSet<VwProductosMasVendidos> VwProductosMasVendidos { get; set; }

    public virtual DbSet<VwProductosStockBajo> VwProductosStockBajo { get; set; }

    public virtual DbSet<VwReservasDetalle> VwReservasDetalle { get; set; }

    public virtual DbSet<VwServiciosMasReservados> VwServiciosMasReservados { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Modern_Spanish_CI_AS");

        modelBuilder.Entity<BloqueosHorario>(entity =>
        {
            entity.HasKey(e => e.BloqueoId);

            entity.HasIndex(e => new { e.SucursalId, e.Fecha }, "IX_Bloqueos_Sucursal_Fecha");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.HoraFin).HasPrecision(0);
            entity.Property(e => e.HoraInicio).HasPrecision(0);
            entity.Property(e => e.Motivo).HasMaxLength(250);

            entity.HasOne(d => d.Sucursal).WithMany(p => p.BloqueosHorario)
                .HasForeignKey(d => d.SucursalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bloqueos_Sucursales");
        });

        modelBuilder.Entity<CategoriasProducto>(entity =>
        {
            entity.HasKey(e => e.CategoriaProductoId);

            entity.HasIndex(e => e.Nombre, "UQ_CategoriasProducto_Nombre").IsUnique();

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Descripcion).HasMaxLength(200);
            entity.Property(e => e.Nombre).HasMaxLength(80);
        });

        modelBuilder.Entity<CategoriasServicio>(entity =>
        {
            entity.HasKey(e => e.CategoriaServicioId);

            entity.HasIndex(e => e.Nombre, "UQ_CategoriasServicio_Nombre").IsUnique();

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Descripcion).HasMaxLength(200);
            entity.Property(e => e.Nombre).HasMaxLength(80);
        });

        modelBuilder.Entity<Empleados>(entity =>
        {
            entity.HasKey(e => e.EmpleadoId);

            entity.HasIndex(e => e.SucursalId, "IX_Empleados_SucursalId");

            entity.HasIndex(e => e.UsuarioId, "UQ_Empleados_Usuario").IsUnique();

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Cargo).HasMaxLength(80);

            entity.HasOne(d => d.Sucursal).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.SucursalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empleados_Sucursales");

            entity.HasOne(d => d.Usuario).WithOne(p => p.Empleados)
                .HasForeignKey<Empleados>(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empleados_Usuarios");

            entity.HasMany(d => d.Servicio).WithMany(p => p.Empleado)
                .UsingEntity<Dictionary<string, object>>(
                    "EmpleadoServicios",
                    r => r.HasOne<Servicios>().WithMany()
                        .HasForeignKey("ServicioId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_EmpleadoServicios_Servicio"),
                    l => l.HasOne<Empleados>().WithMany()
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_EmpleadoServicios_Empleado"),
                    j =>
                    {
                        j.HasKey("EmpleadoId", "ServicioId");
                    });
        });

        modelBuilder.Entity<Especies>(entity =>
        {
            entity.HasKey(e => e.EspecieId);

            entity.HasIndex(e => e.Nombre, "UQ_Especies_Nombre").IsUnique();

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Descripcion).HasMaxLength(200);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<EstadosReserva>(entity =>
        {
            entity.HasKey(e => e.EstadoReservaId);

            entity.HasIndex(e => e.Nombre, "UQ_EstadosReserva_Nombre").IsUnique();

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Color).HasMaxLength(30);
            entity.Property(e => e.Descripcion).HasMaxLength(200);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<FacturaDetalles>(entity =>
        {
            entity.HasKey(e => e.FacturaDetalleId);

            entity.HasIndex(e => e.ProductoId, "IX_FacturaDetalles_Producto");

            entity.Property(e => e.Cantidad).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Descripcion).HasMaxLength(300);
            entity.Property(e => e.Impuesto).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.TipoDetalle)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Total).HasColumnType("decimal(12, 2)");

            entity.HasOne(d => d.Factura).WithMany(p => p.FacturaDetalles)
                .HasForeignKey(d => d.FacturaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FacturaDetalles_Factura");

            entity.HasOne(d => d.Producto).WithMany(p => p.FacturaDetalles)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK_FacturaDetalles_Producto");

            entity.HasOne(d => d.Servicio).WithMany(p => p.FacturaDetalles)
                .HasForeignKey(d => d.ServicioId)
                .HasConstraintName("FK_FacturaDetalles_Servicio");
        });

        modelBuilder.Entity<Facturas>(entity =>
        {
            entity.HasKey(e => e.FacturaId);

            entity.HasIndex(e => new { e.Fecha, e.SucursalId }, "IX_Facturas_Fecha_Sucursal");

            entity.Property(e => e.EstadoFactura)
                .HasMaxLength(30)
                .HasDefaultValue("Pendiente");
            entity.Property(e => e.Fecha)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Impuesto).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(12, 2)");

            entity.HasOne(d => d.MetodoPago).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.MetodoPagoId)
                .HasConstraintName("FK_Facturas_MetodoPago");

            entity.HasOne(d => d.Reserva).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.ReservaId)
                .HasConstraintName("FK_Facturas_Reserva");

            entity.HasOne(d => d.Sucursal).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.SucursalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Facturas_Sucursal");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Facturas_Usuario");
        });

        modelBuilder.Entity<Horarios>(entity =>
        {
            entity.HasKey(e => e.HorarioId);

            entity.HasIndex(e => new { e.SucursalId, e.DiaSemana }, "IX_Horarios_Sucursal_Dia");

            entity.HasIndex(e => new { e.SucursalId, e.DiaSemana, e.HoraInicio, e.HoraFin }, "UQ_Horarios").IsUnique();

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.HoraFin).HasPrecision(0);
            entity.Property(e => e.HoraInicio).HasPrecision(0);

            entity.HasOne(d => d.Sucursal).WithMany(p => p.Horarios)
                .HasForeignKey(d => d.SucursalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Horarios_Sucursales");
        });

        modelBuilder.Entity<Mascotas>(entity =>
        {
            entity.HasKey(e => e.MascotaId);

            entity.HasIndex(e => e.UsuarioId, "IX_Mascotas_UsuarioId");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Alergias).HasMaxLength(500);
            entity.Property(e => e.CaracteristicasEspeciales).HasMaxLength(500);
            entity.Property(e => e.Color).HasMaxLength(80);
            entity.Property(e => e.Descripcion).HasMaxLength(250);
            entity.Property(e => e.Nombre).HasMaxLength(80);
            entity.Property(e => e.Peso).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Raza).WithMany(p => p.Mascotas)
                .HasForeignKey(d => d.RazaId)
                .HasConstraintName("FK_Mascotas_Razas");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Mascotas)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Mascotas_Usuarios");
        });

        modelBuilder.Entity<MetodosPago>(entity =>
        {
            entity.HasKey(e => e.MetodoPagoId);

            entity.HasIndex(e => e.Nombre, "UQ_MetodosPago_Nombre").IsUnique();

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Notificaciones>(entity =>
        {
            entity.HasKey(e => e.NotificacionId);

            entity.HasIndex(e => new { e.FechaProgramada, e.Enviada }, "IX_Notificaciones_Pendientes");

            entity.Property(e => e.Canal).HasMaxLength(30);
            entity.Property(e => e.FechaEnvio).HasPrecision(0);
            entity.Property(e => e.FechaProgramada).HasPrecision(0);
            entity.Property(e => e.Mensaje).HasMaxLength(500);
            entity.Property(e => e.Tipo).HasMaxLength(50);

            entity.HasOne(d => d.Reserva).WithMany(p => p.Notificaciones)
                .HasForeignKey(d => d.ReservaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notificaciones_Reserva");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Notificaciones)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notificaciones_Usuario");
        });

        modelBuilder.Entity<PreguntasReserva>(entity =>
        {
            entity.HasKey(e => e.PreguntaId);

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Obligatoria).HasDefaultValue(true);
            entity.Property(e => e.Pregunta).HasMaxLength(300);
            entity.Property(e => e.TipoRespuesta)
                .HasMaxLength(30)
                .HasDefaultValue("Texto");
        });

        modelBuilder.Entity<Productos>(entity =>
        {
            entity.HasKey(e => e.ProductoId);

            entity.HasIndex(e => e.CategoriaProductoId, "IX_Productos_CategoriaId");

            entity.HasIndex(e => e.Nombre, "UQ_Productos_Nombre").IsUnique();

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Descripcion).HasMaxLength(300);
            entity.Property(e => e.ImagenUrl)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("imagen_url");
            entity.Property(e => e.Marca).HasMaxLength(80);
            entity.Property(e => e.Nombre).HasMaxLength(120);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.StockMinimo).HasDefaultValue(5);

            entity.HasOne(d => d.CategoriaProducto).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CategoriaProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Productos_Categorias");
        });

        modelBuilder.Entity<Razas>(entity =>
        {
            entity.HasKey(e => e.RazaId);

            entity.HasIndex(e => e.EspecieId, "IX_Razas_EspecieId");

            entity.HasIndex(e => new { e.EspecieId, e.Nombre }, "UQ_Razas_Especie_Nombre").IsUnique();

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Descripcion).HasMaxLength(200);
            entity.Property(e => e.Nombre).HasMaxLength(80);

            entity.HasOne(d => d.Especie).WithMany(p => p.Razas)
                .HasForeignKey(d => d.EspecieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Razas_Especies");
        });

        modelBuilder.Entity<Reservas>(entity =>
        {
            entity.HasKey(e => e.ReservaId);

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("TR_Reservas_EvitarBloqueos");
                    tb.HasTrigger("TR_Reservas_EvitarSolapamiento");
                });

            entity.HasIndex(e => new { e.EmpleadoId, e.FechaReserva, e.HoraInicio }, "IX_Reservas_Empleado_Fecha");

            entity.HasIndex(e => new { e.FechaReserva, e.SucursalId, e.HoraInicio }, "IX_Reservas_Fecha_Sucursal");

            entity.HasIndex(e => new { e.MascotaId, e.FechaReserva }, "IX_Reservas_Mascota");

            entity.Property(e => e.CanceladaFecha).HasPrecision(0);
            entity.Property(e => e.ConfirmadaFecha).HasPrecision(0);
            entity.Property(e => e.FechaCreacion)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.FechaNotificacion).HasPrecision(0);
            entity.Property(e => e.HoraFin).HasPrecision(0);
            entity.Property(e => e.HoraInicio).HasPrecision(0);
            entity.Property(e => e.MotivoCancelacion).HasMaxLength(300);
            entity.Property(e => e.Observaciones).HasMaxLength(500);

            entity.HasOne(d => d.Empleado).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservas_Empleados");

            entity.HasOne(d => d.EstadoReserva).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.EstadoReservaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservas_Estados");

            entity.HasOne(d => d.Mascota).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.MascotaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservas_Mascotas");

            entity.HasOne(d => d.Servicio).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.ServicioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservas_Servicios");

            entity.HasOne(d => d.Sucursal).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.SucursalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservas_Sucursales");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservas_Usuarios");
        });

        modelBuilder.Entity<RespuestasReserva>(entity =>
        {
            entity.HasKey(e => e.RespuestaId);

            entity.HasIndex(e => new { e.ReservaId, e.PreguntaId }, "UQ_Respuestas_Reserva_Pregunta").IsUnique();

            entity.Property(e => e.Respuesta).HasMaxLength(500);

            entity.HasOne(d => d.Pregunta).WithMany(p => p.RespuestasReserva)
                .HasForeignKey(d => d.PreguntaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Respuestas_Pregunta");

            entity.HasOne(d => d.Reserva).WithMany(p => p.RespuestasReserva)
                .HasForeignKey(d => d.ReservaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Respuestas_Reserva");
        });

        modelBuilder.Entity<Roles>(entity =>
        {
            entity.HasKey(e => e.RoleId);

            entity.HasIndex(e => e.Nombre, "UQ_Roles_Nombre").IsUnique();

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Descripcion).HasMaxLength(200);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Servicios>(entity =>
        {
            entity.HasKey(e => e.ServicioId);

            entity.HasIndex(e => e.CategoriaServicioId, "IX_Servicios_CategoriaId");

            entity.HasIndex(e => e.Nombre, "UQ_Servicios_Nombre").IsUnique();

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Descripcion).HasMaxLength(300);
            entity.Property(e => e.ImagenUrl)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("imagen_url");
            entity.Property(e => e.Nombre).HasMaxLength(120);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TamanoMascota)
                .HasMaxLength(20)
                .HasDefaultValue("Todos");

            entity.HasOne(d => d.CategoriaServicio).WithMany(p => p.Servicios)
                .HasForeignKey(d => d.CategoriaServicioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Servicios_Categorias");
        });

        modelBuilder.Entity<Sucursales>(entity =>
        {
            entity.HasKey(e => e.SucursalId);

            entity.HasIndex(e => e.Nombre, "UQ_Sucursales_Nombre").IsUnique();

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Correo).HasMaxLength(150);
            entity.Property(e => e.Descripcion).HasMaxLength(250);
            entity.Property(e => e.Direccion).HasMaxLength(250);
            entity.Property(e => e.FechaRegistro)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(25);
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.UsuarioId);

            entity.HasIndex(e => e.RoleId, "IX_Usuarios_RoleId");

            entity.HasIndex(e => e.Correo, "UQ_Usuarios_Correo").IsUnique();

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Apellidos).HasMaxLength(80);
            entity.Property(e => e.Cedula)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.Correo).HasMaxLength(150);
            entity.Property(e => e.Direccion).HasMaxLength(250);
            entity.Property(e => e.FechaRegistro)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Nombre).HasMaxLength(80);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Telefono).HasMaxLength(25);

            entity.HasOne(d => d.Role).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuarios_Roles");
        });

        modelBuilder.Entity<VwIngresosPorSucursal>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_IngresosPorSucursal");

            entity.Property(e => e.Ingresos).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.Sucursal).HasMaxLength(100);
        });

        modelBuilder.Entity<VwProductosMasVendidos>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ProductosMasVendidos");

            entity.Property(e => e.CantidadVendida).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.Ingresos).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.Producto).HasMaxLength(120);
        });

        modelBuilder.Entity<VwProductosStockBajo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ProductosStockBajo");

            entity.Property(e => e.Categoria).HasMaxLength(80);
            entity.Property(e => e.Marca).HasMaxLength(80);
            entity.Property(e => e.Nombre).HasMaxLength(120);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<VwReservasDetalle>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ReservasDetalle");

            entity.Property(e => e.Cliente).HasMaxLength(161);
            entity.Property(e => e.Empleado).HasMaxLength(161);
            entity.Property(e => e.Especie).HasMaxLength(50);
            entity.Property(e => e.EstadoReserva).HasMaxLength(50);
            entity.Property(e => e.HoraFin).HasPrecision(0);
            entity.Property(e => e.HoraInicio).HasPrecision(0);
            entity.Property(e => e.Mascota).HasMaxLength(80);
            entity.Property(e => e.Observaciones).HasMaxLength(500);
            entity.Property(e => e.PrecioServicio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Raza).HasMaxLength(80);
            entity.Property(e => e.Servicio).HasMaxLength(120);
            entity.Property(e => e.Sucursal).HasMaxLength(100);
            entity.Property(e => e.TelefonoCliente).HasMaxLength(25);
        });

        modelBuilder.Entity<VwServiciosMasReservados>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ServiciosMasReservados");

            entity.Property(e => e.Servicio).HasMaxLength(120);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
