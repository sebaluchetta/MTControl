using System.Diagnostics;

using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;
using MTControl.Services.Interface;
using MTControl.Services;
using MTControl.DAO;

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
