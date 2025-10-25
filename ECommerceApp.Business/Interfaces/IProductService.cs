using ECommerceApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Business.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetFilteredProductsAsync(
           int page,
           int pageSize,
           bool? inStockOnly,
           string? categoryName,
           string? sortBy);

        Task<Product?> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
    }
}
