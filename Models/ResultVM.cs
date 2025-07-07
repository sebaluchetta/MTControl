using Microsoft.AspNetCore.Html;

using MTControl.DAO;

namespace MTControl.Models
{
    public class ResultVM
    {
        Result _result { get; set; }
        
        public List<Result> _results { get; set; }
        public string controller { get; set; } = "Report";
        public string action { get; set; } = "Report";
        public Pager _pager { get; set; }
        public int _currentPage { get; set; }
       
    }
}
