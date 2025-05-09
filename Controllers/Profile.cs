using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

using MTControl.Models;

namespace MTControl.Controllers
{
    public class ProfileController : Controller
    {
        private List<Image> _imgFooter = new();
        private List<Profile> _perfiles = new();
      

        public ProfileController()
        {
            _imgFooter.Add(new Image { src = "/img/facebook.svg", url = "https://www.facebook.com/MTC", alt = "Facebook" });
            _imgFooter.Add(new Image { src = "/img/x.svg", url = "https://www.x.com/MTC", alt = "X" });
            _imgFooter.Add(new Image { src = "/img/whastapp.svg", url = "https://wa.link/MTcontrol", alt = "Whatsapp" });
            _imgFooter.Add(new Image { src = "/img/instagram.svg", url = "https://www.instagram.com/MTC", alt = "Instagram" });
            _imgFooter.Add(new Image { src = "/img/mail.svg", url = "mailto:mtc@yopmail.com", alt = "Email" });
            _perfiles.Add(new Profile
              {
                  Codigo = 1,
                  RazonSocial = "Juan Subira",
                  Cuit = "20-32113739-4",
                  Categoria = "A",
                  Actividad = "Venta de cosas muebles",
                  FechaInicioActividades = new DateTime(2000, 12, 01),
                  Iibb = 20000000.00m,
                  Compras = 4000000.00m,
                  Activo = true
              });
            _perfiles.Add(new Profile
            {
                Codigo = 2,
                RazonSocial = "María Torres",
                Cuit = "27-28563214-8",
                Categoria = "C",
                Actividad = "Locación de servicios",
                FechaInicioActividades = new DateTime(2018, 10, 01),
                Iibb = 15500000.00m,
                Compras = 2750000.00m,
                Activo = true
            });
            _perfiles.Add(new Profile
            {
                Codigo = 3,
                RazonSocial = "Carlos Méndez",
                Cuit = "23-33456789-0",
                Categoria = "H",
                Actividad = "Venta de cosas muebles",
                FechaInicioActividades = new DateTime(2020, 02, 01),
                Iibb = 18200000.00m,
                Compras = 3600000.00m,
                Activo = false
            });
           

        }

        public IActionResult Profiles()
        {
            ViewData["ImgFooter"] = _imgFooter;
            ViewData["Perfiles"] = _perfiles;
            return View();
        }
        public IActionResult Nuevo()
        {
            ViewData["ImgFooter"] = _imgFooter;
            return View("ProfileCrud");
        }
        [HttpPost]
        public IActionResult Guardar()
        {
            ViewData["Perfiles"] = _perfiles;
            ViewData["ImgFooter"] = _imgFooter;
            return View("Profiles");
        }

        public IActionResult Editar()
        {


            ViewData["ImgFooter"] = _imgFooter;
            return View("ProfileCrud");
        }
        public IActionResult Eliminar()
        {
            ViewData["ImgFooter"] = _imgFooter;
            ViewData["Perfiles"] = _perfiles;
            return View("Profiles");
        }

    }


}
