using System.Diagnostics;

using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;
using MTControl.Models;
using MTControl.Services.Interface;
using MTControl.Services;

namespace MTControl.Controllers
{
    public class AboutController : Controller
    {
      



        public AboutController ( MtcontrolContext _context )
        {
           
            
        }
      
        public IActionResult About()
        {
            
           
            return View ();
        }
      


    }
}
