using MTControl.DAO;

namespace MTControl.Services.Interface
{
    public interface IActivityService
    {
        List<Activity> GetActivities ();
        Activity GetActivityById ( int id );
    }
}
