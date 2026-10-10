using System.ComponentModel.DataAnnotations;

namespace PetHouse.web.Models
{
    public class UsuarioViewModel
    {
        public int UsuarioId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un rol.")]
        [Display(Name = "Rol")]
        public int RoleId { get; set; }

        [Display(Name = "Rol")]
        public string? RoleNombre { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Los apellidos son obligatorios.")]
        public string Apellidos { get; set; } = string.Empty;

        [Display(Name = "Teléfono")]
        public string? Telefono { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo no es válido.")]
        public string Correo { get; set; } = string.Empty;

        [Display(Name = "Dirección")]
        public string? Direccion { get; set; }

        [Display(Name = "Fecha de nacimiento")]
        public DateOnly? FechaNacimiento { get; set; }

        [Required(ErrorMessage = "La cédula es obligatoria.")]
        [Display(Name = "Cédula")]
        public string Cedula { get; set; } = string.Empty;

        public bool Activo { get; set; } = true;

        [Display(Name = "Fecha de registro")]
        public DateTime FechaRegistro { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string? Password { get; set; }
    }
}