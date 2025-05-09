    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
namespace MTControl.Models
{

    public class Category
    {
      
        public int Id { get; set; }

      
        public Char Letra { get; set; }

      
        public decimal IngresosBrutosCategoria { get; set; }

      
        public decimal PrecioMaximoUnitario { get; set; }

        public bool UltimaCategoria { get; set; }

        public List<Profile> Profiles { get; set; } = new ();
    }

}
