using System;
using System.Collections.Generic;

namespace PetHouse.Infraestructure.Models;

public partial class Productos
{
    public int ProductoId { get; set; }

    public int CategoriaProductoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public int Stock { get; set; }

    public int StockMinimo { get; set; }

    public string? Marca { get; set; }

    public bool Activo { get; set; }

    public string? ImagenUrl { get; set; }

    public virtual CategoriasProducto CategoriaProducto { get; set; } = null!;

    public virtual ICollection<FacturaDetalles> FacturaDetalles { get; set; } = new List<FacturaDetalles>();
}
