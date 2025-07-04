using Microsoft.AspNetCore.Mvc.Rendering;

using System.ComponentModel.DataAnnotations;

namespace MTControl.Models
{
    public class ProfileVM
    {
        public Profile _profile {  get; set; }

       
        public IFormFile? DocumentoPDF { get; set; }
        public List<SelectListItem> _activities { get; set; }
        public List<SelectListItem> _categories { get; set; }

    }
}
