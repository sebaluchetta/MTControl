using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MTControl.Models;

namespace MTControl.Controllers
{
    public class ProfileController : Controller
    {
       

        public IActionResult Profiles()
        {
            return View();
        }

    }
}
