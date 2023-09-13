using System;
using System.Collections.Generic;

namespace APIDepilacion.Models;

public partial class Turno
{
    public int IdTurno { get; set; }

    public int IdCliente { get; set; }

    public DateTime Dia { get; set; }

    public DateTime Hora { get; set; }
}
