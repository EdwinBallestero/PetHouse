using PetHouse.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHouse.Application.DTOs
{
    public record UsuariosDTO
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
}
