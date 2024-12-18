using System;
using System.Collections.Generic;

namespace SIGET_WEB.Models;

public partial class Computadore
{
    public int IdComputador { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Modelo { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<Colaboradore> Colaboradores { get; set; } = new List<Colaboradore>();
}
