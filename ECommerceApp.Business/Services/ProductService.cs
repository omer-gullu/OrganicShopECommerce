using ECommerceApp.Business.Interfaces;
using ECommerceApp.Core.Entities;
using ECommerceApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddAsync(Product product)
        {
             await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product != null)
            {
                await _unitOfWork.Products.DeleteAsync(product);
                await _unitOfWork.CompleteAsync();
            }
            
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _unitOfWork.Products.GetByIdAsync(id);
        }

        public async Task<List<Product>> GetFilteredProductsAsync(int page, int pageSize, bool? inStockOnly, string? categoryName, string? sortBy)
        {
            return await _unitOfWork.Products.GetFilteredAsync(page, pageSize, inStockOnly, categoryName, sortBy);
        }

        public async Task UpdateAsync(Product product)
        {
            await _unitOfWork.Products.UpdateAsync(product);
            await _unitOfWork.CompleteAsync();
        }
    }
}
