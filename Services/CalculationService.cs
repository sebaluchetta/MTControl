using MTControl.Services.Interface;
using MTControl.Models;
using System.ComponentModel;

namespace MTControl.Services
{
    public class CalculationService : ICalculationService
    {
        private readonly MtcontrolContext _context;
        public CalculationService ( MtcontrolContext context )
        {
            _context = context;
        }
        /// <summary>
        /// Calcula los resultados para cada perfil en base a las categorías y actividades asignadas, y devuelve una lista de resultados.
        /// </summary>
        /// <param name="profiles"></param>
        /// <param name="MaxCat"></param>
        /// <returns></returns>
        public List<Result> GetResults ( List<Profile> profiles, Category MaxCat )
        {
            List<Result> results = new List<Result> ();
            foreach (Profile profile in profiles)
            {
                Result result = new Result
                {
                    Profile = profile,
                    TopeCat = GetTopeCatResult ( profile ),
                    TopeReg = GeTotTopeRegResult ( profile, MaxCat ),
                    RelComprasVentas = GetRelComprasVentasResult ( profile )
                };
                results.Add ( result );
            }
            return results;
        }

        #region Private
        /// <summary>
        /// Calcula la relación entre compras y ventas del perfil, lo compara con el % legal y devuelve un mensaje con el resultado.
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        private string GetRelComprasVentasResult ( Profile profile )
        {
            decimal ventas = profile.Iibb;
            decimal compras = profile.Compras;
            decimal ratio = ventas != 0 ? compras / ventas * 100m : 0m;
            decimal limite = profile.Actividad.Porcentaje;

            if (ratio <= limite)
            {
                return $"<i class=\"bi bi-check-circle-fill alert-success\"></i>La relación entre compras y ventas es {ratio}%, no supera el límite establecido por la ley de {limite}%.";
            }
            else
            {
                return $"<i class=\"bi bi-x-circle-fill alert-danger\"></i>La relacion entre compras y ventas es {ratio}%, supera el límite establecido por la ley de {limite}%, por lo tanto se encuentra excluído del régimen.";
            }

        }
        /// <summary>
        /// Compara los IIBB del periodo con el límite de ingresos brutos de la categoría máxima, y devuelve un mensaje con el resultado.
        /// </summary>
        /// <param name="profile"></param>
        /// <param name="maxCat"></param>
        /// <returns></returns>
        private string GeTotTopeRegResult ( Profile profile, Category maxCat )
        {
            if (profile.Iibb <= maxCat.IngresosBrutosCategoria)
            {
                return $"<i class=\"bi bi-check-circle-fill alert-success\"></i>Los ingresos brutos del periodo (${profile.Iibb}) no superan el límite del régimen (${maxCat.IngresosBrutosCategoria}).";
            }
            else
            {
                return $"<i class=\"bi bi-x-circle-fill alert-danger\"></i>Los ingresos brutos del periodo (${profile.Iibb}) superan el límite del régimen (${maxCat.IngresosBrutosCategoria}), por lo tanto se encuentra excluído del régimen.";
            }

        }
        /// <summary>
        /// Compara los ingresos brutos del perfil con el límite de la categoría asignada, y devuelve un mensaje con el resultado.
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        private string GetTopeCatResult ( Profile profile )
        {
            if (profile.FechaInicioActividades.AddMonths ( 6 ) <= DateOnly.FromDateTime ( DateTime.Now ))
            {
                return "<i class=\"bi bi-check-circle-fill alert-success\"></i>El perfil no puede ser evaluado, ya que la fecha de inicio de actividades es menor a 6 meses.";
            }
            if (profile.Iibb <= profile.Categoria.IngresosBrutosCategoria)
            {
                return $"<i class=\"bi bi-check-circle-fill alert-success\"></i>Los ingresos brutos del periodo (${profile.Iibb}) no superan el límite de la categoría {profile.Categoria.Letra} (${profile.Categoria.IngresosBrutosCategoria}).";

            }
            else
            {
                return $"<i class=\"bi bi-check-circle-fill alert-danger\"></i>Los ingresos brutos del periodo (${profile.Iibb}) superan el límite de la categoría {profile.Categoria.Letra} (${profile.Categoria.IngresosBrutosCategoria}).";

            }

        }


        #endregion
    }
}