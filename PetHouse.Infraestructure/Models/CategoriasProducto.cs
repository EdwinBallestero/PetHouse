using System;
using System.Collections.Generic;

namespace PetHouse.Infraestructure.Models;

public partial class CategoriasProducto
{
    public int CategoriaProductoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<Productos> Productos { get; set; } = new List<Productos>();
}
