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
        public int Id;
        [Required]
        public ICollection<(Product Product, int Quantity)> products;
        [Required]
        public string BuyerName;
        [Required]
        public string BuyerPhoneNumber;
        [Required]
        public string Status;
        // delivered - canceled - on going
    }
}
