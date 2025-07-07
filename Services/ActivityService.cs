using MTControl.Services.Interface;
using MTControl.DAO;
namespace MTControl.Services
{
    public class ActivityService : IActivityService
    {
        private readonly MtcontrolContext _context;
        public ActivityService ( MtcontrolContext context )
        {
            _context = context;
        }
        public List<Activity> GetActivities ()
        {
            return _context.Activities.ToList ();
        }

        public Activity GetActivityById ( int id )
        {
            return _context.Activities.FirstOrDefault ( x => x.Id == id );
        }
    }
}