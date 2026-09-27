using System;
using System.Collections.Generic;

namespace PetHouse.Infraestructure.Models;

public partial class Reservas
{
    public int ReservaId { get; set; }

    public int UsuarioId { get; set; }

    public int MascotaId { get; set; }

    public int SucursalId { get; set; }

    public int ServicioId { get; set; }

    public int EmpleadoId { get; set; }

    public int EstadoReservaId { get; set; }

    public DateOnly FechaReserva { get; set; }

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFin { get; set; }

    public string? Observaciones { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? ConfirmadaFecha { get; set; }

    public DateTime? CanceladaFecha { get; set; }

    public string? MotivoCancelacion { get; set; }

    public bool NotificacionEnviada { get; set; }

    public DateTime? FechaNotificacion { get; set; }

    public virtual Empleados Empleado { get; set; } = null!;

    public virtual EstadosReserva EstadoReserva { get; set; } = null!;

    public virtual ICollection<Facturas> Facturas { get; set; } = new List<Facturas>();

    public virtual Mascotas Mascota { get; set; } = null!;

    public virtual ICollection<Notificaciones> Notificaciones { get; set; } = new List<Notificaciones>();

    public virtual ICollection<RespuestasReserva> RespuestasReserva { get; set; } = new List<RespuestasReserva>();

    public virtual Servicios Servicio { get; set; } = null!;

    public virtual Sucursales Sucursal { get; set; } = null!;

    public virtual Usuarios Usuario { get; set; } = null!;
}
