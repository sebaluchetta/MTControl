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

        public ReportController ( MtcontrolContext _context )
        {
            _DBcontext = _context;

        }

        public IActionResult Report ()
        {


            return View ();
        }


    }
}
