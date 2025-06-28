using MTControl.Services.Interface;
using MTControl.Models;
using MTControl.DAL;
namespace MTControl.Services
{
    public class SaleService : ISaleService
    {
        private readonly MtcontrolContext _context;
        public SaleService(MtcontrolContext context)
        {
            _context = context;

        }
        /// <summary>
        /// Trae todas las ventas de la base de datos.
        /// </summary>
        /// <returns></returns>
        public List<Sale> GetSales()
        {
            return _context.Sales.ToList();
        }
        /// <summary>
        /// Obtiene una venta por su ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Sale GetSaleById(int id)
        {
            return _context.Sales.FirstOrDefault(x => x.Id == id);
        }
        /// <summary>
        /// Obtiene las ventas de un perfil en el ultimo periodo.
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        public List<Sale> GetSalesbyProfile(Profile profile)
        {
            DateOnly LimiteInferior = DateOnly.FromDateTime(DateTime.Now).AddYears(-1);
            bool TieneSeisMeses = profile.FechaInicioActividades.AddMonths(6) <= DateOnly.FromDateTime(DateTime.Now) ? true : false;
            if (!TieneSeisMeses)
            {
                LimiteInferior = profile.FechaInicioActividades;
            }
            List<Sale> sales = _context.Sales.Where(x =>
            x.CodPerfil == profile.Codigo
            && x.Fecha >= LimiteInferior)
                .ToList();
            if (sales == null || sales.Count == 0)
            {
                return new List<Sale>();
            }

            return sales;

        }
        /// <summary>
        /// Obtiene el total de ventas de un perfil en el ultimo periodo.
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        public decimal GetTotalSalesAmount(Profile profile)
        {
            decimal TotalSalesAmount = GetSalesbyProfile(profile).Sum((x => x.Total));
            return TotalSalesAmount;
        }

        /// <summary>
        /// Elimina un conjunto de ventas.
        /// </summary>
        /// <param name="SalesToDelete"></param>
        public void DeleteSales(List<Sale> SalesToDelete)
        {
            _context.Sales.RemoveRange(SalesToDelete);
            _context.SaveChanges();

        }
    }
}

        
