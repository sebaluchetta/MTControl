using System;
using System.Collections.Generic;

namespace MTControl.Models;

public partial class Activity
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal Porcentaje { get; set; }

    public virtual ICollection<Profile> Profiles { get; set; } = new List<Profile>();
}
