    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
namespace MTControl.Models
{

    public class MTActivity
    {
      
        public int Id { get; set; }

       
        public  string Descripcion { get; set; }

      
        public  decimal PorcentajeComprasVentas { get; set; }
    }
}
