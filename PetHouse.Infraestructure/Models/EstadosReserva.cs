using System;
using System.Collections.Generic;

namespace PetHouse.Infraestructure.Models;

public partial class EstadosReserva
{
    public int EstadoReservaId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? Color { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();
}
