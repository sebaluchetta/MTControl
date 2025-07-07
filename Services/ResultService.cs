using MTControl.Services.Interface;
using MTControl.DAO;
using Microsoft.EntityFrameworkCore;

namespace MTControl.Services
{
    public class ResultService : IResultService
    {
        private readonly MtcontrolContext _context;
        public ResultService ( MtcontrolContext context )
        {
            _context = context;
        }

        public void CreateResults ( List<Result> results )
        {
            _context.Results.AddRange ( results );
            _context.SaveChanges ();
        }

        public List<Result> GetAllResults ()
        {
            return _context.Results
     .Include ( r => r.CodProfileNavigation )
         .ThenInclude ( p => p.Categoria )
     .Include ( r => r.CodProfileNavigation )
         .ThenInclude ( p => p.Actividad )
     .ToList ();
        }

        public void DeleteResults ()
        {
            _context.Results.RemoveRange(_context.Results);
            _context.SaveChanges ();
        }
    }
}