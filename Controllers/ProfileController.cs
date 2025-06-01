using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

using MTControl.Models;
using MTControl.Services;
using MTControl.Services.Interface;

namespace MTControl.Controllers
{
    public class ProfileController : Controller
    {
     
        private List<Profile> _perfiles = new ();
        private readonly MtcontrolContext _DBcontext;
      
        private readonly IProfilesService _profilesService;



        public ProfileController ( MtcontrolContext _context )
        {
            _DBcontext = _context;
           
            _profilesService = new ProfileService ( _context );
        }

        /// <summary>
        /// Carga la grilla de Perfiles
        /// </summary>
        /// <returns></returns>
        public IActionResult Profiles ()
        {
            
            _perfiles = _profilesService.GetProfiles ();

            TempData [ "Perfiles" ] = _perfiles;
            return View ();
        }

        /// <summary>
        /// Crea un nuevo perfil y lo guarda en la base de datos.
        /// </summary>
        /// <returns></returns>
        public IActionResult Nuevo ()
        {
          

            return View ( "ProfileCR");
        }
        /// <summary>
        /// Guarda un perfil nuevo en la base de datos.
        /// </summary>
        /// <param name="perfil"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Guardar ( Profile perfil )
        {
            if (perfil.Codigo != 0)
            {
                _profilesService.UpdateProfile ( perfil );
                TempData [ "Mensaje" ] = $"El Perfil {perfil.RazonSocial} fue actualizado correctamente";
                return RedirectToAction ( "Profiles", "Profile" );
            }
            perfil = _profilesService.CreateProfile ( perfil );
            TempData [ "Mensaje" ] = $"El Perfil {perfil.RazonSocial} fue guardado correctamente";
            return RedirectToAction ( "Profiles", "Profile" );
        }
        /// <summary>
        /// Edita un perfil existente y lo carga en la vista de edición.
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Editar ( int Codigo )
        {
           

            if (Codigo != 0)
            {
                Profile _profile = new Profile ();
                _profile = _profilesService.GetProfileById ( Codigo );
                TempData [ "Profile" ] = _profile;
                return View ( "ProfileU");
            }
            return RedirectToAction ( "Profiles", "Profiles" );

        }
        [HttpPost]
        public IActionResult Consultar ( int Codigo )
        {

            if (Codigo != 0)
            {
              
                Profile _profile = new Profile ();
                _profile = _profilesService.GetProfileById ( Codigo );
                TempData [ "Profile" ] = _profile;
                return View ( "ProfileV");
            }
            return RedirectToAction ( "Profiles", "Profiles" );
        }

        public IActionResult Eliminar ( int Codigo )
        {
            
            _profilesService.DeleteProfile ( Codigo );
            return View ( "Profiles");
        }
      
    }


}
