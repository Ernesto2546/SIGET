using System;
using System.Collections.Generic;

namespace SIGET_WEB.Models;

public partial class Colaboradore
{
    public int IdColaborador { get; set; }

    public int? IdPersona { get; set; }

    public int? IdDepartamento { get; set; }

    public int? IdComputador { get; set; }

    public virtual Computadore? IdComputadorNavigation { get; set; }

    public virtual Departamento? IdDepartamentoNavigation { get; set; }

    public virtual Persona? IdPersonaNavigation { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
