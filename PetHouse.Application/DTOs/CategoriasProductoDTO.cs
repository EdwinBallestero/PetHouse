
namespace PetHouse.Application.DTOs
{
    public class CategoriasProductoDTO
    {
        public int CategoriaProductoId { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string? Descripcion { get; set; }

        public bool Activo { get; set; }
    }
}
