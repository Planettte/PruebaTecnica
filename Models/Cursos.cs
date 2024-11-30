using System;
using System.Collections.Generic;

namespace PruebaTecnica.Models;

public partial class Cursos
{
    public int CursoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual ICollection<Evaluaciones> Evaluaciones { get; set; } = new List<Evaluaciones>();

    public virtual ICollection<Inscripciones> Inscripciones { get; set; } = new List<Inscripciones>();
}
