using System.Diagnostics;

using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;
using MTControl.Models;
using MTControl.Services.Interface;
using MTControl.Services;

namespace MTControl.Controllers
{
    public class AboutController : Controller
    {
        private List<Image> _imgFooter = new ();
      
        private readonly IImageService _imageService;



        public AboutController ( MtcontrolContext _context )
        {
           
            _imageService = new ImageService ( _context );
        }
      
        public IActionResult About()
        {
            _imgFooter = _imageService.GetImages ();
           
            return View (_imgFooter);
        }
      


    }
}
