using MTControl.Models;


namespace MTControl.Services.Interface
{
    public interface IPurchaseService
    {
        List<Purchase> GetPurchases ();
        Purchase GetPurchaseById ( int id );
        List<Purchase> GetPurchasesbyProfile (int profile_cod);

    }

}
