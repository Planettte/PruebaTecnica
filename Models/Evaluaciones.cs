using System;
using System.Collections.Generic;

namespace PruebaTecnica.Models;

public partial class Evaluaciones
{
    public int EvaluacionId { get; set; }

    public int CursoId { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFin { get; set; }

    public virtual Cursos Curso { get; set; } = null!;

    public virtual ICollection<Intentos> Intentos { get; set; } = new List<Intentos>();

    public virtual ICollection<Preguntas> Pregunta { get; set; } = new List<Preguntas>();
}
