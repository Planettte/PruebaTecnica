using System;
using System.Collections.Generic;

namespace PruebaTecnica.Models;

public partial class Preguntas
{
    public int PreguntaId { get; set; }

    public int EvaluacionId { get; set; }

    public string Texto { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public virtual Evaluaciones Evaluacion { get; set; } = null!;

    public virtual ICollection<Respuestas> Respuesta { get; set; } = new List<Respuestas>();

    public virtual ICollection<RespuestasUsuarios> RespuestasUsuarios { get; set; } = new List<RespuestasUsuarios>();
}
