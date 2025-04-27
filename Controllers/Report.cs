using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MTControl.Models;

namespace MTControl.Controllers
{
    public class ReportController : Controller
    {
        

        public IActionResult Report()
        {
            return View();
        }
    }
}
