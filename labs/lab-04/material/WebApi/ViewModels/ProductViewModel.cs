using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.ViewModels
{
    public class ProductViewModel
    {
        [Required]
        public string Name { get; set; }
        
        [Range(0,999)]
        public decimal Weight { get; set; }
        public object Category { get; set; }
        public decimal ListPrice { get; set; }

        public int Id { get; set; }
    }
}
