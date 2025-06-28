using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

using MTControl.DAL;
using MTControl.Services;
using MTControl.Services.Interface;

namespace MTControl.Controllers
{
    public class InicioController : Controller
    {
        

      



        public InicioController ( MtcontrolContext _context )
        {
           
      
        }

        public IActionResult Index()
        {
           
           
            return View();
        }

       
    }
}

