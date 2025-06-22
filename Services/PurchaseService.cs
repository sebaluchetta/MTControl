using MTControl.Services.Interface;
using MTControl.Models;
using System.Linq;
namespace MTControl.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly MtcontrolContext _context;
        public PurchaseService ( MtcontrolContext context )
        {
            _context = context;
        }
        /// <summary>
        /// Obtiene todas las compras de la base de datos.
        /// </summary>
        /// <returns></returns>
        public List<Purchase> GetPurchases ()
        {
            return _context.Purchases.ToList ();
        }
        /// <summary>
        /// Obtiene una compra por su ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Purchase GetPurchaseById ( int id )
        {
            return _context.Purchases.FirstOrDefault ( x => x.Id == id );
        }
        /// <summary>
        /// Obtiene las compras de un perfil en el ultimo periodo.
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        public List<Purchase> GetPurchasesbyProfile ( Profile profile )

        {
            DateOnly LimiteInferior = DateOnly.FromDateTime ( DateTime.Now ).AddYears ( -1 );
            bool TieneSeisMeses = profile.FechaInicioActividades.AddMonths ( 6 ) <= DateOnly.FromDateTime ( DateTime.Now ) ? true : false;
            if (!TieneSeisMeses)
            {
                LimiteInferior = profile.FechaInicioActividades;
            }
            List<Purchase> purchases = _context.Purchases.Where ( x =>
            x.CodPerfil == profile.Codigo
            && x.Fecha >= LimiteInferior )
                .ToList ();
            if (purchases == null || purchases.Count == 0)
            {
                return new List<Purchase> ();
            }
            return purchases;
            ;
        }
        /// <summary>
        /// Obtiene el total de ventas de un perfil en el ultimo periodo.
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        public decimal GetTotalPurchasesAmount ( Profile profile )
        {
            decimal TotalPurchasesAmount = GetPurchasesbyProfile ( profile ).Sum ( x => x.Total );

            return TotalPurchasesAmount;
        }
    }
}