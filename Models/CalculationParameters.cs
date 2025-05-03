    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
namespace MTControl.Models
{

    public class CalculationParameters
    {
        [NotMapped]
        public List<Category> ListaCategorias { get; set; } = new ();

        [NotMapped]
        public List<MTActivity> ListaActividades { get; set; } = new ();

        [NotMapped]
        [Column ( TypeName = "money" )]
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
