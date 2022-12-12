using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sqlapp.models;
using sqlapp.services;

namespace sqlapp.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> products = new List<Product>();

        public void OnGet()
        {
            ProductService productService = new ProductService();
            products = productService.getProducts();
        }
    }
}