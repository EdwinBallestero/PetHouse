using System;
using System.Collections.Generic;

namespace PetHouse.Infraestructure.Models;

public partial class Horarios
{
    public int HorarioId { get; set; }

    public int SucursalId { get; set; }

    public byte DiaSemana { get; set; }

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFin { get; set; }

    public bool Activo { get; set; }

    public virtual Sucursales Sucursal { get; set; } = null!;
}
