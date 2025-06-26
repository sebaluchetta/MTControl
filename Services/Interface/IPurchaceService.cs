using MTControl.Models;


namespace MTControl.Services.Interface
{
    public interface IPurchaseService
    {
        List<Purchase> GetPurchases ();
        Purchase GetPurchaseById ( int id );
        List<Purchase> GetPurchasesbyProfile (Profile profile);
        decimal GetTotalPurchasesAmount ( Profile profile );
      void DeletePurchases(List<Purchase> PurchasesToDelete);
    }

}
