using MTControl.Models;


namespace MTControl.Services.Interface
{
    public interface IPagerService
    {
        Pager GetProfilePager (  ProfileVM profileVM, IProfilesService profilesService );
        Pager GetResultPager ( ResultVM resultVM, IResultService resultService );


    }
}
