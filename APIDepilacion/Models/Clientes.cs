using System;
using System.Collections.Generic;

namespace APIDepilacion.Models;

public partial class Clientes
{
    public int IdCliente { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Telefono { get; set; } = null!;
}
