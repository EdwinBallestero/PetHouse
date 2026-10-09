using System;
using System.Collections.Generic;

namespace PetHouse.Infraestructure.Models;

public partial class Servicios
{
    public int ServicioId { get; set; }

    public int CategoriaServicioId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public int DuracionMinutos { get; set; }

    public string TamanoMascota { get; set; } = null!;

    public bool RequiereEvaluacion { get; set; }

    public bool Activo { get; set; }

    public string? ImagenUrl { get; set; }

    public virtual CategoriasServicio CategoriaServicio { get; set; } = null!;

    public virtual ICollection<FacturaDetalles> FacturaDetalles { get; set; } = new List<FacturaDetalles>();

    public virtual ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();

    public virtual ICollection<Empleados> Empleado { get; set; } = new List<Empleados>();
}
