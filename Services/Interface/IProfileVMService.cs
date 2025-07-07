using MTControl.DAO;
using MTControl.Models;

using System.Net;


namespace MTControl.Services.Interface
{
    public interface IProfileVMService
    {
       public ProfileVM CrearProvileVM (  IActivityService activityService, ICategoryService categoryService, Profile pro = null );
        public string UploadFile ( ProfileVM profileVM, IWebHostEnvironment webHostEnvironment );
        public void DeleteFile ( Profile profile, IWebHostEnvironment webHostEnvironment );
        public List<Profile> GetProfiles (IProfilesService profilesService);
        public ProfileVM ProfilePagination ( ProfileVM profileVM, IProfilesService profilesService );
    }
}
