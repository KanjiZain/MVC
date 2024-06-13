using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.API.Models;

namespace Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> _products = new List<Product>()
        {
            new Product { Id = 1, Name="Mobile"},
            new Product { Id = 2, Name="PC"},
            new Product { Id = 3, Name="Books"},
        };

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _products;
        }
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            _products.Add(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }
    }
}
