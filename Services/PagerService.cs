using MTControl.Services.Interface;
using MTControl.DAO;
using MTControl.Models;
using AspNetCoreGeneratedDocument;
namespace MTControl.Services
{
    public class PagerService : IPagerService
    {
        public Pager GetProfilePager ( ProfileVM profileVM, IProfilesService profilesService )
        {
            int pg = profileVM._currentPage < 1 ? 1 : profileVM._currentPage;
            int pageSize = 10;

            profileVM._profiles = new List<Profile> ();
            int totalitems = profilesService.GetProfiles ().Count;
            Pager pager = new Pager ( totalitems, pg, pageSize );
           return pager;
        }


        public Pager GetResultPager ( ResultVM resultVM, IResultService resultService )
        {
            int pg = resultVM._currentPage < 1 ? 1 : resultVM._currentPage;
            int pageSize = 10;

            resultVM._results = new List<Result> ();
            int totalitems = resultService.GetAllResults ().Count;
            Pager pager = new Pager ( totalitems, pg, pageSize );
            return pager;
        }

    }
}


