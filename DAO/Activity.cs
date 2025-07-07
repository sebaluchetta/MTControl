using System;
using System.Collections.Generic;

namespace MTControl.DAO;

public partial class Activity
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal Porcentaje { get; set; }
}
