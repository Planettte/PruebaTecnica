using System;
using System.Collections.Generic;

namespace PruebaTecnica.Models;

public partial class Inscripciones
{
    public int InscripcionId { get; set; }

    public int UsuarioId { get; set; }

    public int CursoId { get; set; }

    public DateTime FechaInscripcion { get; set; }

    public virtual Cursos Curso { get; set; } = null!;

    public virtual Usuarios Usuario { get; set; } = null!;
}
