using MTControl.DAO;

namespace MTControl.Services.Interface
{
    public interface IProfilesService
    {
        List<Profile> GetProfiles ();
        List<Profile> GetActiveProfiles ();
        List<Profile> SearchProfiles (string busqueda);
        Profile GetProfileById ( int id );
        Profile CreateProfile ( Profile profile );
        Profile UpdateProfile ( Profile profile );
        void DeleteProfile ( int id, ISaleService saleService, IPurchaseService purchaseService );

        
    }
}
