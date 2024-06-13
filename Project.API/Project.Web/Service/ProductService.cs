using Project.Web.Models;
using System.Text;
using System.Text.Json;

namespace Project.Web.Service
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:7267/api/product");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var product= JsonSerializer.Deserialize<IEnumerable<Product>>(content);
            return product;
        }


        public async Task PostProductAsync(Product product)
        {
            var productJson = JsonSerializer.Serialize(product);
            var content = new StringContent(productJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7267/api/product", content);
            response.EnsureSuccessStatusCode();
        }
    }
}
