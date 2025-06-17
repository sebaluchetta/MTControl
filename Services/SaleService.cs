using MTControl.Services.Interface;
using MTControl.Models;
namespace MTControl.Services
{
    public class SaleService : ISaleService
    {
        private readonly MtcontrolContext _context;
        public SaleService ( MtcontrolContext context )
        {
            _context = context;
        }
        public List<Sale> GetSales ()
        {
            return _context.Sales.ToList ();
        }

        public Sale GetSaleById ( int id )
        {
            return _context.Sales.FirstOrDefault ( x => x.Id == id );
        }
        public List<Sale> GetSalesbyProfile ( int profile_cod )
        {
            return _context.Sales.Where ( x => x.CodPerfil == profile_cod ).ToList ();
        }
    }
}