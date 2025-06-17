using MTControl.Services.Interface;
using MTControl.Models;
namespace MTControl.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly MtcontrolContext _context;
        public PurchaseService ( MtcontrolContext context )
        {
            _context = context;
        }
        public List<Purchase> GetPurchases ()
        {
            return _context.Purchases.ToList ();
        }

        public Purchase GetPurchaseById ( int id )
        {
            return _context.Purchases.FirstOrDefault ( x => x.Id == id );
        }
        public List<Purchase> GetPurchasesbyProfile ( int profile_cod )
        {
            return _context.Purchases.Where ( x => x.CodPerfil == profile_cod ).ToList ();
        }
    }
}