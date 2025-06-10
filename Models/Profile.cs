using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MTControl.Models;

public partial class Profile
{
    public int Codigo { get; set; }
    [Required ( ErrorMessage = "El campo {0} es obligatorio" )]

    public string RazonSocial { get; set; } = null!;
    [Required ( ErrorMessage = "El campo {0} es obligatorio" )]
    [StringLength ( maximumLength: 11, MinimumLength = 11, ErrorMessage = "El {0} debe tener 11 caracteres" )]
    
    public string Cuit { get; set; } = null!;
    [Required ( ErrorMessage = "El campo {0} es obligatorio" )]
    
    public int CategoriaId { get; set; }
    [Required ( ErrorMessage = "El campo {0} es obligatorio" )]
    
    public int ActividadId { get; set; }
    [Required ( ErrorMessage = "El campo {0} es obligatorio" )]
    
    public DateOnly FechaInicioActividades { get; set; }
    [Required ( ErrorMessage = "El campo {0} es obligatorio" )]
    
    public decimal Iibb { get; set; }
    [Required ( ErrorMessage = "El campo {0} es obligatorio" )]
    
    public decimal Compras { get; set; }

    public bool? Activo { get; set; }
    public virtual Activity? Actividad { get; set; }
    public virtual Category? Categoria { get; set; }
}
