using ECommerceApp.Business.Interfaces;
using ECommerceApp.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public async Task <IActionResult> Index(string? categoryName, bool? inStockOnly, string? sortBy, int page = 1)
        {
            int pageSize = 12;

            var products = await _productService.GetFilteredProductsAsync(
                page, pageSize, inStockOnly, categoryName, sortBy
            );

            var categories = await _categoryService.GetAllAsync();

            var viewModel = new ProductsViewModel
            {
                Products = products,
                Categories = categories,
                SelectedCategory = categoryName
            };
            return View(viewModel);
        }
    }
}
