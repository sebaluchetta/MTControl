    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
namespace MTControl.Models
{

    public class Image
    {
     public string src { get; set; }
        public string url { get; set; } 
        public string alt { get; set; }

    }

}
