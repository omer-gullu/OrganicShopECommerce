using ECommerceApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Core.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<List<Order>> GetOrdersByUserIdAsync(int userId);
        Task GetBasketWithItemsAsync(int userId);
    }
}
