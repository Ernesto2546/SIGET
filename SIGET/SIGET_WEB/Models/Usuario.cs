using System;
using System.Collections.Generic;

namespace SIGET_WEB.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public int? IdColaborador { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Rol { get; set; }

    public virtual Colaboradore? IdColaboradorNavigation { get; set; }
}
