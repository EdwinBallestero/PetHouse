using System;
using System.Collections.Generic;

namespace PetHouse.Infraestructure.Models;

public partial class Facturas
{
    public int FacturaId { get; set; }

    public int? ReservaId { get; set; }

    public int UsuarioId { get; set; }

    public int SucursalId { get; set; }

    public int? MetodoPagoId { get; set; }

    public DateTime Fecha { get; set; }

    public decimal Subtotal { get; set; }

    public decimal Impuesto { get; set; }

    public decimal Total { get; set; }

    public string EstadoFactura { get; set; } = null!;

    public virtual ICollection<FacturaDetalles> FacturaDetalles { get; set; } = new List<FacturaDetalles>();

    public virtual MetodosPago? MetodoPago { get; set; }

    public virtual Reservas? Reserva { get; set; }

    public virtual Sucursales Sucursal { get; set; } = null!;

    public virtual Usuarios Usuario { get; set; } = null!;
}
