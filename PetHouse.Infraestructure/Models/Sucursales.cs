using System;
using System.Collections.Generic;

namespace PetHouse.Infraestructure.Models;

public partial class Sucursales
{
    public int SucursalId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public string Direccion { get; set; } = null!;

    public bool Activo { get; set; }

    public DateTime FechaRegistro { get; set; }

    public virtual ICollection<BloqueosHorario> BloqueosHorario { get; set; } = new List<BloqueosHorario>();

    public virtual ICollection<Empleados> Empleados { get; set; } = new List<Empleados>();

    public virtual ICollection<Facturas> Facturas { get; set; } = new List<Facturas>();

    public virtual ICollection<Horarios> Horarios { get; set; } = new List<Horarios>();

    public virtual ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();
}
