using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using MTControl.Models;
using MTControl.Services;
using MTControl.Services.Interface;

namespace MTControl.Controllers
{
    public class ReportController : Controller
    {

        private readonly MtcontrolContext _DBcontext;
        private readonly ICalculationService _CalculationService;
        private readonly IProfilesService _ProfilesService;
        private readonly ICategoryService _CategoryService;

        public ReportController ( MtcontrolContext _context )
        {
            _DBcontext = _context;
            _CalculationService = new CalculationService(_context);
            _ProfilesService = new ProfileService(_context);
            _CategoryService = new CategoryService(_context);
        }

        public IActionResult Report ()
        {
            return View ();
        }
        [HttpGet]
        public IActionResult CalculateReport()
        {
            List<Profile> profiles = _ProfilesService.GetActiveProfiles ();
            List<Result> report = new List<Result> ();
            report = _CalculationService.GetResults ( profiles, _CategoryService.GetMaxCategory () );
            return View ( "Report",report );
        }


    }
}
