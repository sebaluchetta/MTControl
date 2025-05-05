using System.Diagnostics;



using Microsoft.AspNetCore.Mvc;
using MTControl.Models;

namespace MTControl.Controllers
{
    public class LoginController : Controller
    {
     
        

        public IActionResult Index()
        {
            return View("Login");
        }
        


    }
}
