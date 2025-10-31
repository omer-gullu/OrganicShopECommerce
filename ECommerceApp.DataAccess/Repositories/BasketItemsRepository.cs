using ECommerceApp.Core.Entities;
using ECommerceApp.Core.Interfaces;
using ECommerceApp.DataAccess.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.DataAccess.Repositories
{
    public class BasketItemsRepository : Repository<BasketItem>, IBasketItemRepository
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<BasketItem> _dbSet;
        public BasketItemsRepository(AppDbContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<BasketItem>();
        }

        public async Task<List<BasketItem>> GetItemsByBasketIdAsync(int basketId)
        {
            return await _dbSet.Include(p=>p.Product).Where(b => b.BasketId == basketId).ToListAsync();
        }
    }
}
