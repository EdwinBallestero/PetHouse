using System;
using System.Collections.Generic;

namespace PetHouse.Infraestructure.Models;

public partial class VwIngresosPorSucursal
{
    public int SucursalId { get; set; }

    public string Sucursal { get; set; } = null!;

    public int? CantidadFacturas { get; set; }

    public decimal Ingresos { get; set; }
}
