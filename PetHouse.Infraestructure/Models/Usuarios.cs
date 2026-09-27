using System;
using System.Collections.Generic;

namespace PetHouse.Infraestructure.Models;

public partial class Usuarios
{
    public int UsuarioId { get; set; }

    public int RoleId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string? Telefono { get; set; }

    public string Correo { get; set; } = null!;

    public string? Direccion { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public string Password { get; set; } = null!;

    public bool Activo { get; set; }

    public DateTime FechaRegistro { get; set; }

    public string Cedula { get; set; } = null!;

    public virtual Empleados? Empleados { get; set; }

    public virtual ICollection<Facturas> Facturas { get; set; } = new List<Facturas>();

    public virtual ICollection<Mascotas> Mascotas { get; set; } = new List<Mascotas>();

    public virtual ICollection<Notificaciones> Notificaciones { get; set; } = new List<Notificaciones>();

    public virtual ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();

    public virtual Roles Role { get; set; } = null!;
}
