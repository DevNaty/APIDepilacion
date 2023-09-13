using System;
using System.Collections.Generic;

namespace APIDepilacion.Models;

public partial class Sesione
{
    public int IdSesiones { get; set; }

    public int IdCliente { get; set; }

    public int IdZona { get; set; }

    public string Potencia { get; set; } = null!;

    public string Sesion { get; set; } = null!;
}
