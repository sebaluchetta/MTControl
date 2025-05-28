using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

using MTControl.Models;
using MTControl.Services;
using MTControl.Services.Interface;

namespace MTControl.Controllers
{
    public class ProfileController : Controller
    {
        private List<Image> _imgFooter = new();
        private List<Profile> _perfiles = new();
        private readonly MtcontrolContext _DBcontext;
        private readonly IImageService _imageService;



        public ProfileController ( MtcontrolContext _context )
        {
            _DBcontext = _context;
            _imageService = new ImageService ( _context );
        }

        public IActionResult Profiles()
        {
            _imgFooter = CargarImagenes ();
            _perfiles = CargarPerfiles ();
            TempData ["ImgFooter"] = _imgFooter;
            TempData["Perfiles"] = _perfiles;
            return View();
        }

        private List<Profile> CargarPerfiles ()
        {
            return _DBcontext.Profiles.ToList ();    
        }

        public IActionResult Nuevo()
        {
            TempData["ImgFooter"] = CargarImagenes();
            return View("ProfileCrud");
        }
        [HttpPost]
        public IActionResult Guardar(Profile perfil)
        {
            perfil = NuevoPerfil ( perfil );
            _perfiles.Add ( perfil );
            TempData["Perfiles"] = _perfiles;
            TempData["ImgFooter"] = CargarImagenes ();
            TempData[ "Mensaje" ] = $"El Perfil {perfil.RazonSocial} fue guardado correctamente";  
            return View("Profiles");
        }

        public IActionResult Editar()
        {
            TempData["ImgFooter"] = CargarImagenes ()  ;
            return View("ProfileCrud");
        }
        public IActionResult Eliminar()
        {
            TempData["ImgFooter"] = CargarImagenes ();
            TempData["Perfiles"] = _perfiles;
            return View("Profiles");
        }
        #region Metodos Privados    
        private Profile NuevoPerfil ( Profile perfil)
        {
            perfil.Codigo = Math.Min(_perfiles.Max (p => p.Codigo ) + 1, 1000 );
            perfil.Activo = true;
            return perfil;
        }
        private List<Image> CargarImagenes ()
        {
            return _imageService.GetImages ();
        }

        #endregion
    }


}
