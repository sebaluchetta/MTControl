using MTControl.Services.Interface;
using MTControl.Models;
using MTControl.DAO;
namespace MTControl.Services
{
    public class ProfileVMService : IProfileVMService
    {

        public ProfileVM CrearProvileVM ( IActivityService activityService, ICategoryService categoryService, Profile pro = null )
        {
            ProfileVM _proVM = new ProfileVM ()
            {
                _profile = pro is null ? new Profile () : pro,
                _activities = activityService.GetActivities ().Select ( act => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem ()
                {
                    Text = act.Descripcion,
                    Value = act.Id.ToString ()

                } ).ToList (),
                _categories = categoryService.GetCategories ().Select ( cat => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem ()
                {
                    Text = cat.Letra.ToString (),
                    Value = cat.Id.ToString ()
                } ).ToList (),
                DocumentoPDF = null
            };
            return _proVM;
        }
        /// <summary>
        /// Guarda el archivo PDF en la carpeta Constancias y devuelve el nombre del archivo.
        /// </summary>
        /// <param name="profileVM"></param>
        /// <param name="webHostEnvironment"></param>
        /// <returns></returns>
        public string UploadFile ( ProfileVM profileVM, IWebHostEnvironment webHostEnvironment )
        {
            string nombreArchivo = string.Empty;
            if (profileVM.DocumentoPDF is not null)
            {
                string uploadDir = Path.Combine ( webHostEnvironment.WebRootPath, "Constancias" );
                nombreArchivo = Guid.NewGuid ().ToString () + " - " + profileVM._profile.Cuit + profileVM.DocumentoPDF.FileName;
                string filePath = Path.Combine ( uploadDir, nombreArchivo );
                using (FileStream stream = new FileStream ( filePath, FileMode.Create ))
                {
                    profileVM.DocumentoPDF.CopyTo ( stream );
                }
            }
            else
            {
                nombreArchivo = profileVM._profile.Constancia ?? string.Empty;
            }
            return nombreArchivo;
        }
        /// <summary>
        /// Elimina el archivo PDF de la carpeta Constancias si existe.
        /// </summary>
        /// <param name="profile"></param>
        /// <param name="webHostEnvironment"></param>
        public void DeleteFile ( Profile profile, IWebHostEnvironment webHostEnvironment )
        {
            string nombreArchivo = string.Empty;
            if (profile.Constancia is not null)
            {
                nombreArchivo = profile.Constancia.Trim();
                string uploadDir = Path.Combine ( webHostEnvironment.WebRootPath, "Constancias" );
                string filePath = Path.Combine ( uploadDir, nombreArchivo );
                if (System.IO.File.Exists ( filePath ))
                {
                    System.IO.File.Delete ( filePath );
                }
            }
        }
        public List<Profile> GetProfiles ( IProfilesService profilesService )
        {
            return profilesService.GetProfiles ();
        }
        public ProfileVM ProfilePagination ( ProfileVM profileVM, IProfilesService profilesService )
        {
            int pg = profileVM._currentPage < 1 ? 1 : profileVM._currentPage;
            int skip = profileVM._pager.Skip;
            int PageSize = profileVM._pager.PageSize;
            int TotalPerfiles = GetProfiles ( profilesService ).Count;
            profileVM._profiles = GetProfiles ( profilesService )
                .Skip ( skip )
                .Take ( PageSize )
                .ToList ();
            return profileVM;
        }


    }
}