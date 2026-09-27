using System;
using System.Collections.Generic;

namespace PetHouse.Infraestructure.Models;

public partial class Razas
{
    public int RazaId { get; set; }

    public int EspecieId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool Activo { get; set; }

    public virtual Especies Especie { get; set; } = null!;

    public virtual ICollection<Mascotas> Mascotas { get; set; } = new List<Mascotas>();
}
