using System;
using System.Collections.Generic;

namespace PetHouse.Infraestructure.Models;

public partial class Roles
{
    public int RoleId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<Usuarios> Usuarios { get; set; } = new List<Usuarios>();
}
