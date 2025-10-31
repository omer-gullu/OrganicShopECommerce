using ECommerceApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Core.Interfaces
{
    public interface IBasketRepository : IRepository<Basket>
    {
        Task<Basket> GetBasketWithItemsAsync(int userId);
    }
}
