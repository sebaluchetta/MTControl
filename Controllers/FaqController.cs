using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using MTControl.DAO;
using MTControl.Services;
using MTControl.Services.Interface;

namespace MTControl.Controllers
{
    public class FaqsController : Controller
    {
       
      
        public FaqsController ( MtcontrolContext _context )
        {
           
      
        }
        public IActionResult Faqs ()
        {
            
          
            return View ( );
        }
       
    }
}
