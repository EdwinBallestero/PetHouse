using System;
using System.Collections.Generic;

namespace PetHouse.Infraestructure.Models;

public partial class VwReservasDetalle
{
    public int ReservaId { get; set; }

    public DateOnly FechaReserva { get; set; }

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFin { get; set; }

    public string Cliente { get; set; } = null!;

    public string? TelefonoCliente { get; set; }

    public string Mascota { get; set; } = null!;

    public string? Especie { get; set; }

    public string? Raza { get; set; }

    public string Servicio { get; set; } = null!;

    public decimal PrecioServicio { get; set; }

    public string Sucursal { get; set; } = null!;

    public string Empleado { get; set; } = null!;

    public string EstadoReserva { get; set; } = null!;

    public string? Observaciones { get; set; }
}
