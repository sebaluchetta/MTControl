using MTControl.Models;


namespace MTControl.Services.Interface
{
    public interface ISaleService
    {
        List<Sale> GetSales ();
        Sale GetSaleById ( int id );
        List<Sale> GetSalesbyProfile (Profile profile);
        decimal GetTotalSalesAmount ( Profile profile );
        void DeleteSales(List<Sale> SalesToDelete);

    }

}
