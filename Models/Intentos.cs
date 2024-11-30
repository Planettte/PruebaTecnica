using System;
using System.Collections.Generic;

namespace PruebaTecnica.Models;

public partial class Intentos
{
    public int IntentoId { get; set; }

    public int UsuarioId { get; set; }

    public int EvaluacionId { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public double? Calificacion { get; set; }

    public virtual Evaluaciones Evaluacion { get; set; } = null!;

    public virtual ICollection<RespuestasUsuarios> RespuestasUsuarios { get; set; } = new List<RespuestasUsuarios>();

    public virtual Usuarios Usuario { get; set; } = null!;
}
