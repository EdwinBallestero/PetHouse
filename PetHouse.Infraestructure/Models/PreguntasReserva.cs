using System;
using System.Collections.Generic;

namespace PetHouse.Infraestructure.Models;

public partial class PreguntasReserva
{
    public int PreguntaId { get; set; }

    public string Pregunta { get; set; } = null!;

    public string TipoRespuesta { get; set; } = null!;

    public bool Obligatoria { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<RespuestasReserva> RespuestasReserva { get; set; } = new List<RespuestasReserva>();
}
