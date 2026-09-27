using System;
using System.Collections.Generic;

namespace PetHouse.Infraestructure.Models;

public partial class VwServiciosMasReservados
{
    public int ServicioId { get; set; }

    public string Servicio { get; set; } = null!;

    public int? CantidadReservas { get; set; }
}
