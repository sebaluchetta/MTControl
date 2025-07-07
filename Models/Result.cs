using Microsoft.AspNetCore.Html;

using MTControl.DAO;

namespace MTControl.Models
{
    public class Result
    {
        public Profile Profile { get; set; }
        public HtmlString TopeCat { get; set; }
        public HtmlString TopeReg { get; set; }
        public HtmlString RelComprasVentas { get; set; }
    }

}
