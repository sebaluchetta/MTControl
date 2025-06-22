using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MTControl.Models;

public partial class Profile
{
    public int Codigo { get; set; }
    [Required ( ErrorMessage = "El campo {0} es obligatorio" )]
    [Display ( Name = "Razón Social" )]
    public string RazonSocial { get; set; } = null!;
    [Required ( ErrorMessage = "El campo {0} es obligatorio" )]
    [StringLength ( maximumLength: 11, MinimumLength = 11, ErrorMessage = "El {0} debe tener 11 caracteres" )]

    public string Cuit { get; set; } = null!;
    [Required ( ErrorMessage = "El campo {0} es obligatorio" )]
    [Display ( Name = "Categoria" )]
    public int CategoriaId { get; set; }
    [Required ( ErrorMessage = "El campo {0} es obligatorio" )]
    [Display ( Name = "Actividad" )]
    public int ActividadId { get; set; }
    [Required ( ErrorMessage = "El campo {0} es obligatorio" )]
    [Display ( Name = "Fecha Inicio de actividades" )]
    public DateOnly FechaInicioActividades { get; set; }
    [Required ( ErrorMessage = "El campo {0} es obligatorio" )]
    [Display ( Name = "Ingresos brutos del periodo" )]
    public decimal Iibb { get; set; }
    [Required ( ErrorMessage = "El campo {0} es obligatorio" )]
    [Display ( Name = "Compras del periodo" )]
    public decimal Compras { get; set; }

    public bool Activo { get; set; }
    public virtual Activity? Actividad { get; set; }
    public virtual Category? Categoria { get; set; }

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
