    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
namespace MTControl.Models
{

    public class MTActivity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength ( 200 )]
        public required string Descripcion { get; set; }

        [Required]
        [Range ( 0, 1 )]
        public required decimal PorcentajeComprasVentas { get; set; }
    }
}
