using System;
using System.Collections.Generic;

namespace PruebaTecnica.Models;

public partial class RespuestasUsuarios
{
    public int RespuestaUsuarioId { get; set; }

    public int IntentoId { get; set; }

    public int PreguntaId { get; set; }

    public int? RespuestaId { get; set; }

    public string? RespuestaAbierta { get; set; }

    public virtual Intentos Intento { get; set; } = null!;

    public virtual Preguntas Pregunta { get; set; } = null!;

    public virtual Respuestas? Respuesta { get; set; }
}
