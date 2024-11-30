using System;
using System.Collections.Generic;

namespace PruebaTecnica.Models;

public partial class Respuestas
{
    public int RespuestaId { get; set; }

    public int PreguntaId { get; set; }

    public string Texto { get; set; } = null!;

    public bool EsCorrecta { get; set; }

    public virtual Preguntas Pregunta { get; set; } = null!;

    public virtual ICollection<RespuestasUsuarios> RespuestasUsuarios { get; set; } = new List<RespuestasUsuarios>();
}
