using System;
using System.Collections.Generic;

namespace PetHouse.Infraestructure.Models;

public partial class RespuestasReserva
{
    public int RespuestaId { get; set; }

    public int ReservaId { get; set; }

    public int PreguntaId { get; set; }

    public string Respuesta { get; set; } = null!;

    public virtual PreguntasReserva Pregunta { get; set; } = null!;

    public virtual Reservas Reserva { get; set; } = null!;
}
