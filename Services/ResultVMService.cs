using MTControl.Services.Interface;
using MTControl.Models;
using MTControl.DAO;
namespace MTControl.Services
{
    public class ResultVMService : IResultVMService
    {

      
      

       

        public ResultVM ResultPagination ( ResultVM resultVM, IResultService resultService )
        {
            int pg = resultVM._currentPage < 1 ? 1 : resultVM._currentPage;
            int skip = resultVM._pager.Skip;
            int PageSize = resultVM._pager.PageSize;
            int TotalResultados = resultService.GetAllResults ().Count;
            resultVM._results = resultService.GetAllResults ()
                .Skip ( skip )
                .Take ( PageSize )
                .ToList ();
            return resultVM;
        }
    }
}