namespace PetHouse.Application.DTOs
{
    public class RolesDTO
    {
        public int RoleId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public bool Activo { get; set; }
    }
}