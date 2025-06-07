using MTControl.Services.Interface;
using MTControl.Models;
namespace MTControl.Services
{
    public class ImageService : IImageService
    {
        private readonly MtcontrolContext _context;
        public ImageService ( MtcontrolContext context )
        {
            _context = context;
        }
        public List<Image> GetImages ()
        {
            return _context.Images.ToList ();
        }

        
    }
}