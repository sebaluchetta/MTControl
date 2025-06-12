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
        private ProfileVM _profileVM;
        private readonly IProfilesService _profilesService;
        private readonly ICategoryService _categoryService;
        private readonly IActivityService _activityService;


        public ProfileController ( MtcontrolContext _context )
        {
            _DBcontext = _context;
            _profilesService = new ProfileService ( _context );
            _categoryService = new CategoryService ( _context );
            _activityService = new ActivityService ( _context );
        }

        /// <summary>
        /// Carga la grilla de Perfiles
        /// </summary>
        /// <returns></returns>
        public IActionResult Profiles ()
        {
            _perfiles = _profilesService.GetProfiles ();
            return View ( _perfiles );
        }

        /// <summary>
        /// Crea un nuevo perfil y lo guarda en la base de datos.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Nuevo ()
        {
            _profileVM = CrearProvileVM ();

            return View ( "ProfileCR", _profileVM );
        }


        /// <summary>
        /// Guarda un perfil nuevo en la base de datos.
        /// </summary>
        /// <param name="perfil"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Guardar ( Profile perfil )
        {
            if (!ModelState.IsValid)
            {
                _profileVM = CrearProvileVM (perfil);
                TempData [ "Mensaje" ] = $"Hubo problemas al guardar el perfil. Por favor intentelo nuevamente";
                TempData [ "MensajeColor" ] = "alert alert-danger alert-dismissible";
                string viewName = perfil.Codigo == 0 ? "ProfileCR" : "ProfileU";
                return View ( viewName, _profileVM );
                
            }
            if (perfil.Codigo != 0)
            {
                _profilesService.UpdateProfile ( perfil );
                TempData [ "Mensaje" ] = $"El Perfil {perfil.RazonSocial} fue actualizado correctamente";
            }
            else
            {
                perfil = _profilesService.CreateProfile ( perfil );
            TempData [ "Mensaje" ] = $"El Perfil {perfil.RazonSocial} fue creado correctamente";

            }
            TempData [ "MensajeColor" ] = "alert alert-success alert-dismissible";
            return RedirectToAction ( "Profiles", "Profile" );

        }
        /// <summary>
        /// Edita un perfil existente y lo carga en la vista de edición.
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Editar ( int Codigo )
        {
            Profile _profile = new Profile ();
            _profile = _profilesService.GetProfileById ( Codigo );
            _profileVM = CrearProvileVM ( _profile );
            return View ( "ProfileU", _profileVM );
        }

        /// <summary>
        /// Carga la vista para consultar el perfil
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Consultar ( int Codigo )
        {
            Profile _profile = new Profile ();
            _profile = _profilesService.GetProfileById ( Codigo );
            return View ( "ProfileV", _profile );
        }
        /// <summary>
        /// Muestra el perfil antes de eliminarlo
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Eliminar ( int Codigo )
        {
            Profile _profile = new Profile ();
            _profile = _profilesService.GetProfileById ( Codigo );
            ViewBag.Operacion = "Eliminar";

            return View ( "ProfileD", _profile );
        }
        [HttpPost]
        public IActionResult Borrar ( int codigo )
        {

            _profilesService.DeleteProfile ( codigo );


            return RedirectToAction ( "Profiles", "profile" );
        }
        #region metodos privados
        private ProfileVM CrearProvileVM ( Profile pro = null )
        {
            ProfileVM _proVM = new ProfileVM ()
            {
                _profile = pro is null ? new Profile () : pro,
                _activities = _activityService.GetActivities ().Select ( act => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem ()
                {
                    Text = act.Descripcion,
                    Value = act.Id.ToString ()

                } ).ToList (),
                _categories = _categoryService.GetCategories ().Select ( cat => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem ()
                {
                    Text = cat.Letra.ToString (),
                    Value = cat.Id.ToString ()
                } ).ToList ()

            };
            return _proVM;
        }
        #endregion
    }


}
