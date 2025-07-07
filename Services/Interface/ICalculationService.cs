using MTControl.DAO;
using MTControl.Models;


namespace MTControl.Services.Interface
{
    public interface ICalculationService
    {
        List<Result>GetResults(List<Profile> profiles, Category MaxCat);
       

    }

}
