using System;
using System.Collections.Generic;

namespace MTControl.DAO;

public partial class Result
{
    public int Id { get; set; }

    public int CodProfile { get; set; }

    public string ToPeCategoria { get; set; } = null!;

    public string TopeRegimen { get; set; } = null!;

    public string RelComprasVentas { get; set; } = null!;

    public virtual Profile CodProfileNavigation { get; set; } = null!;
}
