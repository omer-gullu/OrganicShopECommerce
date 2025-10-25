using ECommerceApp.Core.Interfaces;
using ECommerceApp.DataAccess.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _appDbContext;

        
        public IProductRepository Products { get; }

        public ICategoryRepository Categories {get; }

        public UnitOfWork(AppDbContext appDbContext, IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _appDbContext = appDbContext;
            Products = productRepository;
            Categories = categoryRepository;
        }

        public async Task<int> CompleteAsync()
        {
          return  await _appDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _appDbContext.Dispose();
        }
    }
}
