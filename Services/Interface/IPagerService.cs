using MTControl.Models;


namespace MTControl.Services.Interface
{
    public interface IPagerService
    {
        Pager CalcularProfilePager (  ProfileVM profileVM, IProfilesService profilesService );
    //    Pager CalcularViewPager ( int pg, ResultVM resultVM, ICalculationService calculationService );


    }
}
