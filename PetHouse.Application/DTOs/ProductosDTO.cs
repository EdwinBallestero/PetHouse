
namespace PetHouse.Application.DTOs
{
    public class ProductosDTO
    {
        public int ProductoId { get; set; }

        public int CategoriaProductoId { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string? Descripcion { get; set; }

        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public int StockMinimo { get; set; }

        public string? Marca { get; set; }

        public bool Activo { get; set; }

        public string? ImagenUrl { get; set; }

        public string? NombreCategoria { get; set; }
    }
}
