using System;
using System.Collections.Generic;

namespace MTControl.Models;

public partial class Profile
{
    public int Codigo { get; set; }

    public string RazonSocial { get; set; } = null!;

    public long Cuit { get; set; }

    public int Categoria { get; set; }

    public int Actividad { get; set; }

    public DateOnly FechaInicioActividades { get; set; }

    public decimal Iibb { get; set; }

    public decimal Compras { get; set; }

    public bool Activo { get; set; }
}
