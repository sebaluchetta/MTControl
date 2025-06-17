using System;
using System.Collections.Generic;

namespace MTControl.Models;

public partial class Purchase
{
    public int Id { get; set; }

    public DateOnly Fecha { get; set; }

    public string Tipo { get; set; } = null!;

    public int PuntoDeVenta { get; set; }

    public int Numero { get; set; }

    public int CodPerfil { get; set; }

    public decimal Total { get; set; }

    public virtual Profile CodPerfilNavigation { get; set; } = null!;
}
