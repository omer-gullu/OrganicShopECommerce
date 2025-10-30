using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Core.Entities
{
        public class Order
        {
            [Key]
            public int Id { get; set; }

            public DateTime CreatedAt { get; set; } = DateTime.Now;

            public int UserId { get; set; }
            public User? User { get; set; }

            public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();

            public decimal TotalPrice => Items.Sum(i => i.Quantity * i.UnitPrice);
        }

    }


