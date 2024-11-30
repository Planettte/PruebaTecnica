using System;
using System.Collections.Generic;

namespace PruebaTecnica.Models;

public partial class Roles
{
    public int RolId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<UsuarioRoles> UsuarioRoles { get; set; } = new List<UsuarioRoles>();
}
