    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
namespace MTControl.Models
{

    public class CalculationParameters
    {
       
        public List<Category> ListaCategorias { get; set; } 

        
        public List<MTActivity> ListaActividades { get; set; } 

        public decimal IIBBCategoriaMaxima
        {
            get
            {
                return ListaCategorias
                    .FirstOrDefault ( x => x.UltimaCategoria == true )?.IngresosBrutosCategoria ?? 0m;
            }
        }
    }

}
