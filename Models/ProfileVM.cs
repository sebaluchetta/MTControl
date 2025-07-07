using Microsoft.AspNetCore.Mvc.Rendering;

using MTControl.DAO;

using System.ComponentModel.DataAnnotations;

namespace MTControl.Models
{
    public class ProfileVM
    {
        public Profile _profile { get; set; }
        public List<Profile> _profiles { get; set; }
        public Pager _pager { get; set; }
        public int _currentPage { get; set; }
        public string? controller { get; set; }= "Profile";
        public string? action { get; set; } = "Profiles";    

        public IFormFile? DocumentoPDF { get; set; }
        public List<SelectListItem> _activities { get; set; }
        public List<SelectListItem> _categories { get; set; }

    }
}
