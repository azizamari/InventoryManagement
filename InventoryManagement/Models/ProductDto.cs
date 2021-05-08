using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class ProductDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
    }
}
