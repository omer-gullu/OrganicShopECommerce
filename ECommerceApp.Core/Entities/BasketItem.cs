using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Core.Entities
{
    public class BasketItem
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }

        public int BasketId { get; set; }
        public Basket Basket { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
