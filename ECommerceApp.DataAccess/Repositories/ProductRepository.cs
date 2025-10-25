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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<Product> _dbSet;

        public ProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<Product>();
        }
        public async Task<List<Product>> GetFilteredAsync(int page, int pageSize, bool? inStockOnly, string categoryName, string sortBy)
        {
            var query = _context.Products.Include(p => p.Category).AsQueryable();

            if (inStockOnly == true)
            {
                query = query.Where(p => p.InStock);
            }

            if (!string.IsNullOrEmpty(categoryName))
            {
                query = query.Where(p => p.Category.Name == categoryName);
                query = sortBy switch
                {

                    "priceAsc" => query.OrderBy(p => p.Price),
                    "priceDesc" => query.OrderByDescending(p => p.Price),
                    "newest" => query.OrderByDescending(p => p.Id),
                    _ => query


                };

            }
            return await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        }
    }
}
