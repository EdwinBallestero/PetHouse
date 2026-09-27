using System;
using System.Collections.Generic;

namespace PetHouse.Infraestructure.Models;

public partial class CategoriasServicio
{
    public int CategoriaServicioId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<Servicios> Servicios { get; set; } = new List<Servicios>();
}
