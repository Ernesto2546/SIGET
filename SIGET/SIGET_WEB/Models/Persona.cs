using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SIGET_WEB.Models;

public partial class Persona
{
    public int IdPersona { get; set; }
    [DisplayName("Documento")]
    [MaxLength(40)]
    public string CedulaPasaporte { get; set; } = null!;
    [MaxLength(20)]
    public string Nombre { get; set; } = null!;
    [MaxLength(20)]
    public string Apellido { get; set; } = null!;
    [MaxLength(10)]
    public string? Telefono { get; set; }

    public string? Direccion { get; set; }
    [DisplayName("Correo Electronico")]
    public string? CorreoElectronico { get; set; }

    public virtual ICollection<Colaboradore> Colaboradores { get; set; } = new List<Colaboradore>();
}
