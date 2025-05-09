    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
namespace MTControl.Models
{

    public class Profile
    {
       
        public int Codigo { get; set; }

        
        public  string RazonSocial { get; set; }

        
        public   string Cuit { get; set; }

        
        public  string Categoria { get; set; }

        
        public  string Actividad { get; set; }

       
        
        public  DateTime FechaInicioActividades { get; set; }

        
        public  decimal Iibb { get; set; }

        
        public  decimal Compras { get; set; }
        
     
        public  bool Activo { get; set; }
    }

}
