using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using MTControl.DAL;
using MTControl.Services;
using MTControl.Services.Interface;

namespace MTControl.Controllers
{
    public class LoginController : Controller
    {
       
        
        public LoginController ( MtcontrolContext _context )
        {
           
        }

        public IActionResult Login()
        {
         
           
            return View ();
        }
        public IActionResult Logout()
        {
         
         
            return View ();
        }
       
    }
}
