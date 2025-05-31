using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MTControl.Models;
using MTControl.Services;
using MTControl.Services.Interface;

namespace MTControl.Controllers
{
    public class InicioController : Controller
    {
        

        private List<Image> _imgFooter = new List<Image> ();
        
        private readonly IImageService _imageService;



        public InicioController ( MtcontrolContext _context )
        {
           
            _imageService = new ImageService ( _context );
        }

        public IActionResult Index()
        {
            _imgFooter = _imageService.GetImages (); 
           
            return View(_imgFooter);
        }

       
    }
}

