using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using MTControl.Models;
using MTControl.Services;
using MTControl.Services.Interface;

namespace MTControl.Controllers
{
    public class ReportController : Controller
    {
        private List<Image> _imgFooter = new ();
        private readonly MtcontrolContext _DBcontext;
        private readonly IImageService _imageService;
        public ReportController ( MtcontrolContext _context )
        {
            _DBcontext = _context;
            _imageService = new ImageService ( _context );
        }

        public IActionResult Report()
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
