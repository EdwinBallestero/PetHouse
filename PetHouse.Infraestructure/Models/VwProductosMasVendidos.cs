using System;
using System.Collections.Generic;

namespace PetHouse.Infraestructure.Models;

public partial class VwProductosMasVendidos
{
    public int ProductoId { get; set; }

    public string Producto { get; set; } = null!;

    public decimal? CantidadVendida { get; set; }

    public decimal? Ingresos { get; set; }
}
