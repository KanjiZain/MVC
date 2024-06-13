using Microsoft.AspNetCore.Mvc;
using Project.Web.Models;
using Project.Web.Service;

namespace Project.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProductsAsync();
            return View(products);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productService.PostProductAsync(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
    }
}
