    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
namespace MTControl.Models
{

    public class Profile
    {
        [Key]
        public int Codigo { get; set; }

        [Required]
        [MaxLength ( 200 )]
        public required string RazonSocial { get; set; }

        [Required]
        [MaxLength ( 20 )]
        public  required string Cuit { get; set; }

        [Required]
        public int CategoriaId { get; set; }

        [Required]
        [ForeignKey ( nameof ( CategoriaId ) )]
        public required Category Categoria { get; set; }

        [Required]
        public int MTActivityId { get; set; }

        [Required]
        [ForeignKey ( nameof ( MTActivityId ) )]
        public required MTActivity Actividad { get; set; }

       
        [Required]
        public required DateTime FechaInicioActividades { get; set; }

        [Required]
        [Column ( TypeName = "money" )]
        public required decimal Iibb { get; set; }

        [Required]
        [Column ( TypeName = "money" )]
        public required decimal Compras { get; set; }
        [Required]
     
        public required bool Activo { get; set; }
    }

}
