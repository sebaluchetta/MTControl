using System;
using System.Collections.Generic;

namespace MTControl.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Letra { get; set; } = null!;

    public decimal IngresosBrutosCategoria { get; set; }

    public decimal PrecioMaximoUnitario { get; set; }

    public bool UltimaCategoria { get; set; }

    public virtual ICollection<Profile> Profiles { get; set; } = new List<Profile>();
}
