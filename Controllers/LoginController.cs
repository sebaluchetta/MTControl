using System.Diagnostics;



using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using MTControl.Models;
using MTControl.Services;
using MTControl.Services.Interface;

namespace MTControl.Controllers
{
    public class LoginController : Controller
    {
        private List<Image> _imgFooter = new ();
       
        private readonly IImageService _imageService;
        public LoginController ( MtcontrolContext _context )
        {
           
            _imageService = new ImageService ( _context );
        }

        public IActionResult Login()
        {
            _imgFooter = _imageService.GetImages ();
           
            return View (_imgFooter);
        }
        public IActionResult Logout()
        {
            _imgFooter = _imageService.GetImages ();
         
            return View (_imgFooter);
        }
       
    }
}
