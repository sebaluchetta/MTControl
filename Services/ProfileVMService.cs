using MTControl.Services.Interface;
using MTControl.Models;
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
        public string UploadFile ( ProfileVM profileVM, IWebHostEnvironment webHostEnvironment )
        {
            string nombreArchivo = string.Empty;
            if (profileVM.DocumentoPDF is not null)
            {
                string uploadDir=Path.Combine ( webHostEnvironment.WebRootPath, "Constancias" );
                nombreArchivo = Guid.NewGuid().ToString()+ " - "+profileVM._profile.Cuit+profileVM.DocumentoPDF.FileName;
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
        public void DeleteFile (Profile profile, IWebHostEnvironment webHostEnvironment )
        {
            string nombreArchivo = profile.Constancia;
            
                string uploadDir = Path.Combine ( webHostEnvironment.WebRootPath, "Constancias" );
                string filePath = Path.Combine ( uploadDir, nombreArchivo );
            if (!string.IsNullOrEmpty ( nombreArchivo ) && System.IO.File.Exists ( filePath ))
            {
                System.IO.File.Delete ( filePath );
            }
        }

    }
}