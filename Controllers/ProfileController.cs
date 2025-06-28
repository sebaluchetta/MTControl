using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

using MTControl.DAL;
using MTControl.Models;
using MTControl.Services;
using MTControl.Services.Interface;

namespace MTControl.Controllers
{
    public class ProfileController : Controller
    {

        private List<Profile> _perfiles = new ();
     
        private ProfileVM _profileVM;
        private readonly IProfilesService _profilesService;
        private readonly ICategoryService _categoryService;
        private readonly IActivityService _activityService;
        private readonly IPurchaseService _purchaseSercice;
        private readonly ISaleService _saleService;


        public ProfileController (IProfilesService profilesService
                                , ICategoryService categoryService
                                , IActivityService activityService
                                , IPurchaseService purchaseSercice
                                , ISaleService saleService
                                 )
        {
         
            _profilesService = profilesService;
            _categoryService = categoryService;
            _activityService = activityService;
            _purchaseSercice = purchaseSercice;
            _saleService = saleService;
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
        /// Guarda un perfil nuevo o actualizado en la base de datos.
        /// </summary>
        /// <param name="perfil"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Guardar ( Profile perfil )
        {
            if (!ModelState.IsValid)
            {
                _profileVM = CrearProvileVM ( perfil );
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


            return View ( "ProfileD", _profile );
        }
        [HttpPost]
        public IActionResult Borrar ( int codigo )
        {

            _profilesService.DeleteProfile ( codigo, _saleService, _purchaseSercice );
            TempData [ "Mensaje" ] = $"El Perfil fue eliminado correctamente.";
            TempData [ "MensajeColor" ] = "alert alert-success alert-dismissible";

            return RedirectToAction ( "Profiles", "profile" );
        }
        /// <summary>
        /// Busca perfiles según el texto ingresado en el campo de búsqueda. Busca en Codigo, Razon social, Cuit, Categoria y Actividad.
        /// </summary>
        /// <param name="busqueda"></param>
        /// <returns></returns>
        public IActionResult Encontrar ( string busqueda )
        {
            List<Profile> _profiles = new List<Profile> ();
            _profiles = _profilesService.SearchProfiles ( busqueda );
            return View ( "Profiles", _profiles );
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
        [HttpPost]
        public IActionResult ObtenerVentas ( Profile perfil )
        {
            decimal totalVentas = _saleService.GetTotalSalesAmount ( perfil );
            perfil.Iibb = totalVentas;
            _profileVM = CrearProvileVM ( perfil );
            return View ( "ProfileU", _profileVM );
        }
        [HttpPost]
        public IActionResult ObtenerCompras ( Profile perfil )
        {
            decimal totalCompras = _purchaseSercice.GetTotalPurchasesAmount ( perfil );
            perfil.Compras = totalCompras;
            _profileVM = CrearProvileVM ( perfil );
            return View ( "ProfileU", _profileVM );
        }
        #endregion
    }


}
