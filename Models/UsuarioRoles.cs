using System;
using System.Collections.Generic;

namespace PruebaTecnica.Models;

public partial class UsuarioRoles
{
    public int UsuarioRolId { get; set; }

    public int UsuarioId { get; set; }

    public int RolId { get; set; }

    public virtual Roles Rol { get; set; } = null!;

    public virtual Usuarios Usuario { get; set; } = null!;
}
