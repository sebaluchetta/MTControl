using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using MTControl.DAO;
using MTControl.Models;
using MTControl.Services.Interface;

namespace MTControl.Controllers
{
    public class ReportController : Controller
    {


        private readonly ICalculationService _CalculationService;
        private readonly IProfilesService _ProfilesService;
        private readonly ICategoryService _CategoryService;
        private readonly IResultService _ResultService;
        private readonly IResultVMService _ResultVMService;
        private readonly IPagerService _PagerService;


        public ReportController ( IProfilesService profilesService
                                , ICalculationService calculationService
                                , ICategoryService categoryService
                                , IResultService resultService
                                , IResultVMService resultVMService
            , IPagerService pagerService
                                )
        {
            _ProfilesService = profilesService;
            _CalculationService = calculationService;
            _CategoryService = categoryService;
            _ResultService = resultService;
            _ResultVMService = resultVMService;
            _PagerService = pagerService;

        }

        public IActionResult Report ( int pg = 1, int pageSize=5 )
        {
            ResultVM resultVM = new ResultVM ();
            resultVM._currentPage = pg;
            resultVM._pageSize = pageSize;
            resultVM._pager = _PagerService.GetResultPager ( resultVM, _ResultService );
            resultVM= _ResultVMService.ResultPagination ( resultVM, _ResultService );
            return View ( resultVM );
        }
        [HttpGet]
        public IActionResult CalculateReport ( int pg = 1 )
        {
            ResultVM resultVM = new ResultVM ();
            resultVM._currentPage = pg;
            resultVM._pager = _PagerService.GetResultPager ( resultVM, _ResultService );
            List<Profile> profiles = _ProfilesService.GetActiveProfiles ();
            List<Result> report = new List<Result> ();
            report = _CalculationService.GetResults ( profiles, _CategoryService.GetMaxCategory () );
            if (report.Count != 0)
            {
                
                _ResultService.DeleteResults ();
                _ResultService.CreateResults ( report );
            }
            resultVM = _ResultVMService.ResultPagination ( resultVM, _ResultService );

            return View ( "Report", resultVM );
        }


    }
}
