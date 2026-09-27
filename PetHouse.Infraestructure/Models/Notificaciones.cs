using System;
using System.Collections.Generic;

namespace PetHouse.Infraestructure.Models;

public partial class Notificaciones
{
    public int NotificacionId { get; set; }

    public int ReservaId { get; set; }

    public int UsuarioId { get; set; }

    public string Tipo { get; set; } = null!;

    public DateTime FechaProgramada { get; set; }

    public DateTime? FechaEnvio { get; set; }

    public string Canal { get; set; } = null!;

    public bool Enviada { get; set; }

    public string? Mensaje { get; set; }

    public virtual Reservas Reserva { get; set; } = null!;

    public virtual Usuarios Usuario { get; set; } = null!;
}
