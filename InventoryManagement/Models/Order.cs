using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }  
        [Required]
        public ICollection<ProductWithQuantity> Items { get; set; }
        [Required]
        public string BuyerName { get; set; }
        [Required]
        public string BuyerPhoneNumber { get; set; }
        [Required]
        public string Status { get; set; }
        // delivered - canceled - on going
    }
}
