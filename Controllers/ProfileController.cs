using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

using MTControl.DAO;
using MTControl.Models;
using MTControl.Services;
using MTControl.Services.Interface;

using System.Diagnostics;

namespace MTControl.Controllers
{
    public class ProfileController : Controller
    {
        
        private List<Profile> _perfiles = new ();

        private ProfileVM _ProfileVM;
        private readonly IProfilesService _profilesService;
        private readonly ICategoryService _categoryService;
        private readonly IActivityService _activityService;
        private readonly IPurchaseService _purchaseSercice;
        private readonly ISaleService _saleService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IProfileVMService _profileVMService;
        private readonly IPagerService _pagerService;



        public ProfileController ( IProfilesService profilesService
                                , ICategoryService categoryService
                                , IActivityService activityService
                                , IPurchaseService purchaseSercice
                                , ISaleService saleService
                                , IWebHostEnvironment webHostEnvironment
                                , IProfileVMService profileVMService
                                ,IPagerService pagerService)
        {

            _profilesService = profilesService;
            _categoryService = categoryService;
            _activityService = activityService;
            _purchaseSercice = purchaseSercice;
            _saleService = saleService;
            _webHostEnvironment = webHostEnvironment;
            _profileVMService = profileVMService;
            _pagerService = pagerService;
        }

        /// <summary>
        /// Carga la grilla de Perfiles
        /// </summary>
        /// <returns></returns>
        public IActionResult Profiles (int pg=1)
        {
            ProfileVM _ProfileVM = new ProfileVM ();
            _ProfileVM._currentPage = pg;
            _ProfileVM._pager=_pagerService.CalcularProfilePager(_ProfileVM,_profilesService);
            _ProfileVM= _profileVMService.ProfilePagination ( _ProfileVM, _profilesService );
           
            return View ( _ProfileVM );
        }

        /// <summary>
        /// Crea un nuevo perfilVM y lo guarda en la base de datos.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Nuevo ()
        {
            _ProfileVM = _profileVMService.CrearProvileVM ( _activityService, _categoryService );

            return View ( "ProfileC", _ProfileVM );
        }


        /// <summary>
        /// Guarda un perfilVM nuevo o actualizado en la base de datos.
        /// </summary>
        /// <param name="perfilVM"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Guardar ( ProfileVM perfilVM )
        {
            // Cambios al ModelState para validar lo necesario
            ModelStateMod ( perfilVM );

            if (!ModelState.IsValid)
            {
                string mensajeError=ObtenerListaErrores ();
                TempData [ "Mensaje" ] = $"Hubo problemas al guardar el perfil: {mensajeError}. Por favor intentelo nuevamente";
                TempData [ "MensajeColor" ] = "alert alert-danger alert-dismissible";
                string viewName = perfilVM._profile.Codigo == 0 ? "ProfileC" : "ProfileU";
                _ProfileVM = _profileVMService.CrearProvileVM ( _activityService, _categoryService, perfilVM._profile );
                return View ( viewName, _ProfileVM);

            }
            string NombrePdf = _profileVMService.UploadFile ( perfilVM, _webHostEnvironment );
            perfilVM._profile.Constancia = NombrePdf;
            if (perfilVM._profile.Codigo != 0)
            {
                _profilesService.UpdateProfile ( perfilVM._profile );
                TempData [ "Mensaje" ] = $"El Perfil {perfilVM._profile.RazonSocial} fue actualizado correctamente";
            }
            else
            {

                _profilesService.CreateProfile ( perfilVM._profile );
                TempData [ "Mensaje" ] = $"El Perfil {perfilVM._profile.RazonSocial} fue creado correctamente";

            }
            TempData [ "MensajeColor" ] = "alert alert-success alert-dismissible";
            return RedirectToAction ( "Profiles", "Profile" );

        }

        /// <summary>
        /// Recorre el ModelState y obtiene los mensajes de error.
        /// </summary>
        /// <returns>mensajes de error separados por coma</returns>

        /// <summary>
        /// Edita un perfilVM existente y lo carga en la vista de edición.
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Editar ( int Codigo )
        {
            Profile _profile = new Profile ();
            _profile = _profilesService.GetProfileById ( Codigo );
            _ProfileVM = _profileVMService.CrearProvileVM ( _activityService, _categoryService, _profile );
            return View ( "ProfileU", _ProfileVM );
        }
        /// <summary>
        /// Carga la vista para consultar el perfilVM
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Consultar ( int Codigo )
        {
            Profile _profile = new Profile ();
            _profile = _profilesService.GetProfileById ( Codigo );
            return View ( "ProfileR", _profile );
        }
        /// <summary>
        /// Muestra el perfilVM antes de eliminarlo
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
        /// <summary>
        /// Elimina un perfilVM de la base de datos.
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Borrar ( int codigo )
        {
            Profile _perfil= _profilesService.GetProfileById (codigo);
            _profileVMService.DeleteFile(_perfil, _webHostEnvironment);
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
        /// <summary>
        /// Obtiene las ventas totales del perfilVM seleccionado y envia el valor al perfilVM.
        /// </summary>
        /// <param name="perfil"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ObtenerVentas ( ProfileVM perfil )
        {
            decimal totalVentas = _saleService.GetTotalSalesAmount ( perfil._profile );
            perfil._profile.Iibb = totalVentas;
            _ProfileVM = _profileVMService.CrearProvileVM ( _activityService, _categoryService, perfil._profile );
            return View ( "ProfileU", _ProfileVM );
        }
        /// <summary>
        /// Obtiene las compras totales del perfilVM seleccionado y envia el valor al perfilVM.
        /// </summary>
        /// <param name="perfil"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ObtenerCompras ( ProfileVM perfil )
        {
            decimal totalCompras = _purchaseSercice.GetTotalPurchasesAmount ( perfil._profile );
            perfil._profile.Compras = totalCompras;
            _ProfileVM = _profileVMService.CrearProvileVM ( _activityService, _categoryService, perfil._profile );
            return View ( "ProfileU", _ProfileVM );
        }
        #region Privados
        private string ObtenerListaErrores ()
        {
            var errores = ModelState
                   .Values
                   .SelectMany ( v => v.Errors )
                   .Select ( e => e.ErrorMessage );
            string mensajeError = string.Empty;
            mensajeError = string.Join(",", errores);
            return mensajeError;
        }
        /// <summary>
        /// Modifica el Modelstate a validar segun la accion realizada
        /// </summary>
        /// <param name="perfilVM"></param>
        private void ModelStateMod ( ProfileVM perfilVM )
        {
            //Quito los datos del ModelState que no son necesarios para la validación
            List<string> noProfileKeys = ModelState.Keys
                                        .Where ( k => !k.StartsWith ( "_profile." ) )
                                        .ToList ();

            foreach (var k in noProfileKeys)
            {
                ModelState.Remove ( k );
            }
            // si es un perfil nuevo, se valida que tenga el PDF adjunto
            if (perfilVM._profile.Codigo == 0 && perfilVM.DocumentoPDF == null)
            {
                ModelState.AddModelError (
                    nameof ( perfilVM.DocumentoPDF ),
                    "al crear un perfil, debes adjuntar el PDF de la constancia de Inscripíon en ARCA"
                );
            }
        }
        #endregion
    }


}

