using MTControl.Services.Interface;
using MTControl.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Security.AccessControl;
namespace MTControl.Services
{
    public class ProfileService : IProfilesService
    {

        private readonly MtcontrolContext _context;
      
        public ProfileService ( MtcontrolContext context )
        {
            _context = context;
           
        }
        #region GETTERS
        /// <summary>
        /// Obtiene la lista de perfiles con sus respectivas actividades y categorías.
        /// </summary>
        /// <returns></returns>
        public List<Profile> GetProfiles ()
        {
            List<Profile> _profiles = new List<Profile> ();
            _profiles = _context.Profiles
                .Include ( x => x.Actividad )
                .Include ( x => x.Categoria )
           
                .ToList ();
            
            return _profiles;
        }
        /// <summary>
        ///Obtiene un perfil por su ID, incluyendo sus actividades y categorías.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Profile GetProfileById ( int id )
        {
            Profile pro = _context.Profiles
        .Include ( p => p.Actividad )
        .Include ( p => p.Categoria )
        .FirstOrDefault ( p => p.Codigo == id );
  
            return pro;
        }
        /// <summary>
        /// Obtiene una lista de perfiles activos
        /// </summary>
        /// <returns></returns>
        public List<Profile>GetActiveProfiles ()
        {
            return GetProfiles().Where(x=>x.Activo == true ).ToList ();
        }
        #endregion

        #region CRUD
        /// <summary>
        /// Crea un nuevo perfil y lo guarda en la base de datos.
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        public Profile CreateProfile ( Profile profile )
        {
            _context.Profiles.Add ( profile );
            _context.SaveChanges ();
            return profile;
        }
        /// <summary>
        /// Actualiza un perfil existente en la base de datos.
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        public Profile UpdateProfile ( Profile profile )
        {
            _context.Profiles.Update ( profile );
            _context.SaveChanges ();
            return profile;
        }
        /// <summary>
        /// Elimina un perfil de la base de datos por su ID.
        /// </summary>
        /// <param name="id"></param>
        public void DeleteProfile ( int id, ISaleService saleService, IPurchaseService purchaseService)
        {
             ISaleService _saleService = saleService;
            IPurchaseService _purchaseSercice = purchaseService;
            var profile = _context.Profiles.FirstOrDefault ( p => p.Codigo == id );
            if (profile != null)
            {
                List<Sale> sales = _saleService.GetSales().Where(x=>x.CodPerfil==id).ToList();
                List<Purchase> purchases=_purchaseSercice.GetPurchases().Where(p => p.CodPerfil == id).ToList();
                // Elimina las ventas asociadas al perfil
                if(sales != null && sales.Count > 0)
                {
                    _saleService.DeleteSales(sales);
                }
                // Elimina las compras asociadas al perfil
                if (purchases != null && purchases.Count > 0)
                {
                    _purchaseSercice.DeletePurchases(purchases);
                }
                _context.Profiles.Remove ( profile );
                _context.SaveChanges ();
            }
        }
        #endregion
        /// <summary>
        /// Busca perfiles por un término de búsqueda en varios campos, incluyendo Código, Razón Social, CUIT, Categoría y Actividad.
        /// </summary>
        /// <param name="busqueda"></param>
        /// <returns></returns>
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
     
    }
}

