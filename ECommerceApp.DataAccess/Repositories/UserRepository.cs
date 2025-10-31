using ECommerceApp.Core.Entities;
using ECommerceApp.Core.Interfaces;
using ECommerceApp.DataAccess.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.DataAccess.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public Task GetBasketWithItemsAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetOrdersByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
