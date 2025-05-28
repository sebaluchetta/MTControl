using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using MTControl.Models;
using MTControl.Services;
using MTControl.Services.Interface;

namespace MTControl.Controllers
{
    public class FaqsController : Controller
    {
        private readonly MtcontrolContext _DBcontext;
        private readonly IImageService _imageService;

        private List<Image> _imgFooter = new ();
        public FaqsController ( MtcontrolContext _context )
        {
            _DBcontext = _context;
            _imageService = new ImageService ( _context );
        }
        public IActionResult Faqs ()
        {
            _imgFooter = CargarImagenes ();
            TempData [ "ImgFooter" ] = _imgFooter;
            return View ();
        }
        private List<Image> CargarImagenes ()
        {
            return _imageService.GetImages ();
        }
    }
}
