﻿using System;
using System.Collections.Generic;

namespace MTControl.DAO;

public partial class Category
{
    public int Id { get; set; }

    public string Letra { get; set; } = null!;

    public decimal IngresosBrutosCategoria { get; set; }

    public decimal PrecioMaximoUnitario { get; set; }

    public bool UltimaCategoria { get; set; }
}
