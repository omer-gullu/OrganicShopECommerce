using ECommerceApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Core.Interfaces
{
    public interface IBasketItemRepository : IRepository<BasketItem>
    {
        Task<List<BasketItem>> GetItemsByBasketIdAsync(int basketId);
    }
}
