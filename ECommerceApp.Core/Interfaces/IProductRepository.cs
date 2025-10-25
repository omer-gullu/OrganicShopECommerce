using ECommerceApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Core.Interfaces
{
    public interface IProductRepository: IRepository<Product>
    {
        Task<List<Product>> GetFilteredAsync(
            int page,
            int pageSize,
            bool? inStockOnly,
            string categoryName,
            string sortBy


            );
    }
}
