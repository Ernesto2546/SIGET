using System;
using System.Collections.Generic;

namespace SIGET_WEB.Models;

public partial class Departamento
{
    public int IdDepartamento { get; set; }

    public string Departamento1 { get; set; } = null!;

    public virtual ICollection<Colaboradore> Colaboradores { get; set; } = new List<Colaboradore>();
}
