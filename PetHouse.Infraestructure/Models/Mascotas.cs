using System;
using System.Collections.Generic;

namespace PetHouse.Infraestructure.Models;

public partial class Mascotas
{
    public int MascotaId { get; set; }

    public int UsuarioId { get; set; }

    public int? RazaId { get; set; }

    public string Nombre { get; set; } = null!;

    public DateOnly? FechaNacimiento { get; set; }

    public string? Sexo { get; set; }

    public decimal? Peso { get; set; }

    public string? Color { get; set; }

    public string? Descripcion { get; set; }

    public string? Alergias { get; set; }

    public string? CaracteristicasEspeciales { get; set; }

    public bool Activo { get; set; }

    public virtual Razas? Raza { get; set; }

    public virtual ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();

    public virtual Usuarios Usuario { get; set; } = null!;
}
