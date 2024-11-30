using System;
using System.Collections.Generic;

namespace PruebaTecnica.Models;

public partial class Usuarios
{
    public int UsuarioId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public virtual ICollection<Inscripciones> Inscripciones { get; set; } = new List<Inscripciones>();

    public virtual ICollection<Intentos> Intentos { get; set; } = new List<Intentos>();

    public virtual ICollection<UsuarioRoles> UsuarioRoles { get; set; } = new List<UsuarioRoles>();
}
