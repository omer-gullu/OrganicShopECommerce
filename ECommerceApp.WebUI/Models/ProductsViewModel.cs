using ECommerceApp.Core.Entities;

namespace ECommerceApp.WebUI.Models
{
    public class ProductsViewModel
    {
        public List<Product> Products { get; set; } = new();
        public List<Category> Categories { get; set; } = new();
        public string? SelectedCategory { get; set; }
    }
}
