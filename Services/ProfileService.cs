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
            return _context.Profiles
                .Include(x=>x.Actividad)
                .Include(x=>x.Categoria)
                .ToList();
        }
        public Profile GetProfileById ( int id )
        {
            return _context.Profiles
        .Include ( p => p.Actividad )
        .Include ( p => p.Categoria )
        .FirstOrDefault ( p => p.Codigo == id);
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

    }
}
