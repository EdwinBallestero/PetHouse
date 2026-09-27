using System;
using System.Collections.Generic;

namespace PetHouse.Infraestructure.Models;

public partial class Especies
{
    public int EspecieId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<Razas> Razas { get; set; } = new List<Razas>();
}
