using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Core.Entities
{
    public class Basket
    {
        [Key]
        public int BasketId { get; set; }

        // Kullanıcıya ait sepet
        public int UserId { get; set; }

        // Sepetteki ürünler
        public ICollection<BasketItem> Items { get; set; } = new List<BasketItem>();

        public decimal TotalPrice => Items.Sum(i => i.Quantity * i.UnitPrice);
    }
}
