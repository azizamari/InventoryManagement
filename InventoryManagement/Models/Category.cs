using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class Category
    {
        [Key]
        [Required]
        public string Name { get; set; }
    }
}
