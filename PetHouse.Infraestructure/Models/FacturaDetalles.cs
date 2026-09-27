using System;
using System.Collections.Generic;

namespace PetHouse.Infraestructure.Models;

public partial class FacturaDetalles
{
    public int FacturaDetalleId { get; set; }

    public int FacturaId { get; set; }

    public string TipoDetalle { get; set; } = null!;

    public int? ServicioId { get; set; }

    public int? ProductoId { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public decimal Subtotal { get; set; }

    public decimal Impuesto { get; set; }

    public decimal Total { get; set; }

    public virtual Facturas Factura { get; set; } = null!;

    public virtual Productos? Producto { get; set; }

    public virtual Servicios? Servicio { get; set; }
}
