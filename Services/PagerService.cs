using MTControl.Services.Interface;
using MTControl.DAO;
using MTControl.Models;
using AspNetCoreGeneratedDocument;
namespace MTControl.Services
{
    public class PagerService : IPagerService
    {
        public Pager CalcularProfilePager ( ProfileVM profileVM, IProfilesService profilesService )
        {
            int pg = profileVM._currentPage < 1 ? 1 : profileVM._currentPage;
            int pageSize = 10;

            profileVM._profiles = new List<Profile> ();
            int totalitems = profilesService.GetProfiles ().Count;
            Pager pager = new Pager ( totalitems, pg, pageSize );
           return pager;
        }


        //public Pager CalcularResultPager ( int pg, ResultVM resultVM, ICalculationService calculationService )
        //{
        //    const int pageSize = 10;
        //    if (pg < 1)
        //    {
        //        pg = 1;
        //    }

        //    resultVM._results = new List<Result>();
        //    int totalitems = calculationService.GetResults ().Count;
        //    Pager pager = new Pager ( totalitems, pg, pageSize );
        //    int skip = (pg - 1) * pageSize;

        //    return pager;
        //}

    }
}


