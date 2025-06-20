using MTControl.Services.Interface;
using MTControl.Models;
using Microsoft.EntityFrameworkCore;
namespace MTControl.Services
{
    public class ProfileService : IProfilesService
    {

        private readonly MtcontrolContext _context;
        public ProfileService ( MtcontrolContext context )
        {
            _context = context;
        }
        public List<Profile> GetProfiles ()
        {
            List<Profile> _profiles = new List<Profile> ();
            _profiles = _context.Profiles
                .Include ( x => x.Actividad )
                .Include ( x => x.Categoria )
             //   .Include ( x => x.Sales )
             //   .Include ( x => x.Purchases )
                .ToList ();
            //_profiles.ForEach ( x => x.Iibb = GetTotalSalesAmount ( x ) );
            //_profiles.ForEach ( x => x.Compras = GetTotalPurchasesAmount ( x ) );
            return _profiles;
        }
        public Profile GetProfileById ( int id )
        {
            Profile pro = _context.Profiles
        .Include ( p => p.Actividad )
        .Include ( p => p.Categoria )
     //   .Include ( x => x.Sales )
     //   .Include ( x => x.Purchases )
        .FirstOrDefault ( p => p.Codigo == id );
            //pro.Iibb = GetTotalSalesAmount ( pro );
            //pro.Compras = GetTotalPurchasesAmount ( pro );

            return pro;
        }
        public Profile CreateProfile ( Profile profile )
        {
            _context.Profiles.Add ( profile );
            _context.SaveChanges ();
            return profile;
        }
        public Profile UpdateProfile ( Profile profile )
        {
            _context.Profiles.Update ( profile );
            _context.SaveChanges ();
            return profile;
        }
        public void DeleteProfile ( int id )
        {
            var profile = _context.Profiles.FirstOrDefault ( p => p.Codigo == id );
            if (profile != null)
            {
                _context.Profiles.Remove ( profile );
                _context.SaveChanges ();
            }
        }
        public List<Profile> SearchProfiles (string busqueda)
        {
            List<Profile> _profiles = new List<Profile> ();

            if (!string.IsNullOrEmpty ( busqueda ))
            {
                _profiles = GetProfiles().Where ( p =>
                    // x Código (convierte a texto)
                    p.Codigo.ToString ().Contains ( busqueda, StringComparison.OrdinalIgnoreCase )
                    // x Razón Social
                    || p.RazonSocial.Contains ( busqueda, StringComparison.OrdinalIgnoreCase )
                    // x CUIT
                    || p.Cuit.Contains ( busqueda, StringComparison.OrdinalIgnoreCase )
                    // x Categoría (letra)
                    || p.Categoria.Letra.Contains ( busqueda, StringComparison.OrdinalIgnoreCase )
                    // x Actividad (descripción)
                    || p.Actividad.Descripcion.Contains ( busqueda, StringComparison.OrdinalIgnoreCase )
                     ).ToList ();
            }
            else
            {
                _profiles = GetProfiles ();
            }
            return _profiles;
        }
        ///// <summary>
        ///// Obtiene el Total de ventas de un perfil en el ultimo periodo.
        ///// </summary>
        ///// <param name="profile"></param>
        ///// <returns></returns>
        //private decimal GetTotalSalesAmount ( Profile profile )
        //{
        //    decimal TotalVentas = 0m;
        //    //Si el perfil tiene menos o 5 meses, tomo la fecha de inicio de actividades como limite inferior, sino tomo un año hacia atras.
        //    DateOnly LimiteInferior = CalcularLimiteInferior ( profile );
        //    //Obtengo las ventas del perfil en el ultimo periodo.
        //    List<Sale> sales = profile.Sales.ToList();
        //    if (sales == null || sales.Count == 0)
        //    {
        //        return 0m;
        //    }
        //    List<Sale> UltimoPeriodo = sales.Where ( x =>
        //    x.Fecha >= LimiteInferior ).ToList ();
        //    if (UltimoPeriodo == null || UltimoPeriodo.Count == 0)
        //    {
        //        return 0m;
        //    }
        //    //Sumo el total de las ventas del ultimo periodo.
        //    TotalVentas = UltimoPeriodo.Sum ( x => x.Total );

        //    return TotalVentas;
        //}
        //private decimal GetTotalPurchasesAmount ( Profile profile )
        //{
        //    decimal TotalCompras = 0m;
        //    //Si el perfil tiene menos o 5 meses, tomo la fecha de inicio de actividades como limite inferior, sino tomo un año hacia atras.
        //    DateOnly LimiteInferior = CalcularLimiteInferior ( profile );
        //    //Obtengo las Compras del perfil en el ultimo periodo.
        //    List<Purchase> Purchases = profile.Purchases.ToList ();
        //    if (Purchases == null || Purchases.Count == 0)
        //    {
        //        return 0m;
        //    }
        //    List<Purchase> UltimoPeriodo = Purchases.Where ( x =>
        //    x.Fecha >= LimiteInferior ).ToList ();
        //    if (UltimoPeriodo == null || UltimoPeriodo.Count == 0)
        //    {
        //        return 0m;
        //    }
        //    //Sumo el total de las Compras del ultimo periodo.
        //    TotalCompras = UltimoPeriodo.Sum ( x => x.Total );

        //    return TotalCompras;
        //}
        ///// <summary>
        ///// Calcula Si el perfil tiene menos de 6 meses de antigüedad, y devuelve el límite inferior para las compras y ventas del perfil.
        ///// </summary>
        ///// <param name="profile"></param>
        ///// <returns></returns>
        //private static DateOnly CalcularLimiteInferior ( Profile profile )
        //{
        //    DateOnly LimiteInferior = DateOnly.FromDateTime ( DateTime.Now ).AddYears ( -1 );
        //    bool TieneSeisMeses = profile.FechaInicioActividades.AddMonths ( 6 ) <= DateOnly.FromDateTime ( DateTime.Now ) ? true : false;
        //    if (!TieneSeisMeses)
        //    {
        //        LimiteInferior = profile.FechaInicioActividades;
        //    }

        //    return LimiteInferior;
        //}
    }
}

