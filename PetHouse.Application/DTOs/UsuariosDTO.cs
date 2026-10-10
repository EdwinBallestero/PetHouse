using System.ComponentModel.DataAnnotations;

namespace PetHouse.Application.DTOs
{
    public class UsuariosDTO
    {
        [Display(Name = "Código")]
        public int UsuarioId { get; set; }

        public int RoleId { get; set; }

        [Display(Name = "Rol")]
        public string? RoleNombre { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Apellidos { get; set; } = string.Empty;

        [Display(Name = "Teléfono")]
        public string? Telefono { get; set; }

        public string Correo { get; set; } = string.Empty;

        [Display(Name = "Dirección")]
        public string? Direccion { get; set; }

        [Display(Name = "Fecha de nacimiento")]
        public DateOnly? FechaNacimiento { get; set; }

        [Display(Name = "Cédula")]
        public string Cedula { get; set; } = string.Empty;

        public bool Activo { get; set; }

        [Display(Name = "Fecha de registro")]
        public DateTime FechaRegistro { get; set; }
    }
}