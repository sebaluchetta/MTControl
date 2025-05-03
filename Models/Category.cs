    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
namespace MTControl.Models
{

    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength ( 5 )]
        public Char Letra { get; set; }

        [Column ( TypeName = "money" )]
        public decimal IngresosBrutosCategoria { get; set; }

        [Column ( TypeName = "money" )]
        public decimal PrecioMaximoUnitario { get; set; }

        public bool UltimaCategoria { get; set; }

        public List<Profile> Profiles { get; set; } = new ();
    }

}
