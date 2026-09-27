using System;
using System.Collections.Generic;

namespace PetHouse.Infraestructure.Models;

public partial class BloqueosHorario
{
    public int BloqueoId { get; set; }

    public int SucursalId { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly? HoraInicio { get; set; }

    public TimeOnly? HoraFin { get; set; }

    public string Motivo { get; set; } = null!;

    public bool TodoElDia { get; set; }

    public bool Activo { get; set; }

    public virtual Sucursales Sucursal { get; set; } = null!;
}
