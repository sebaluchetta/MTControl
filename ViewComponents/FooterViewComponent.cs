using Microsoft.AspNetCore.Mvc;

using MTControl.Models;
using MTControl.Services.Interface;
using MTControl.Services;

namespace MTControl.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private List<Image> _imgFooter = new ();

        private readonly IImageService _imageService;
        public FooterViewComponent ( MtcontrolContext _context )
        {

            _imageService = new ImageService ( _context );
        }
        public IViewComponentResult Invoke ()
        {
            _imgFooter = _imageService.GetImages ();
            return View ( _imgFooter );
        }
    }
}
