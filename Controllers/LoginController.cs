using System.Diagnostics;



using Microsoft.AspNetCore.Mvc;
using MTControl.Models;

namespace MTControl.Controllers
{
    public class LoginController : Controller
    {
        private List<Image> _imgFooter = new ();
        public LoginController ()
        {
            _imgFooter.Add ( new Image { src = "/img/facebook.svg", url = "https://www.facebook.com/MTC", alt = "Facebook" } );
            _imgFooter.Add ( new Image { src = "/img/x.svg", url = "https://www.x.com/MTC", alt = "X" } );
            _imgFooter.Add ( new Image { src = "/img/whastapp.svg", url = "https://wa.link/MTcontrol", alt = "Whatsapp" } );
            _imgFooter.Add ( new Image { src = "/img/instagram.svg", url = "https://www.instagram.com/MTC", alt = "Instagram" } );
            _imgFooter.Add ( new Image { src = "/img/mail.svg", url = "mailto:mtc@yopmail.com", alt = "Email" } );
          
        }

        public IActionResult Login()
        {

            TempData["ImgFooter"] = _imgFooter;
            return View ();
        }
        public IActionResult Logout()
        {

            TempData["ImgFooter"] = _imgFooter;
            return View();
        }

    }
}
