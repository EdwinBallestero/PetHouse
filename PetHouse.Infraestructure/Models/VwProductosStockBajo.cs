using System;
using System.Collections.Generic;

namespace PetHouse.Infraestructure.Models;

public partial class VwProductosStockBajo
{
    public int ProductoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Categoria { get; set; } = null!;

    public int Stock { get; set; }

    public int StockMinimo { get; set; }

    public decimal Precio { get; set; }

    public string? Marca { get; set; }
}
