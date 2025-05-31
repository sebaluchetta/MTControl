using MTControl.Models;


namespace MTControl.Services.Interface
{
    public interface IProfilesService
    {
        List<Profile> GetProfiles ();
        Profile GetProfileById ( int id );
        Profile CreateProfile ( Profile profile );
        Profile UpdateProfile ( Profile profile );
        void DeleteProfile ( int id );
        
    }
}
