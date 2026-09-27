using System;
using System.Collections.Generic;

namespace PetHouse.Infraestructure.Models;

public partial class Empleados
{
    public int EmpleadoId { get; set; }

    public int UsuarioId { get; set; }

    public int SucursalId { get; set; }

    public string Cargo { get; set; } = null!;

    public DateOnly FechaIngreso { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();

    public virtual Sucursales Sucursal { get; set; } = null!;

    public virtual Usuarios Usuario { get; set; } = null!;

    public virtual ICollection<Servicios> Servicio { get; set; } = new List<Servicios>();
}
