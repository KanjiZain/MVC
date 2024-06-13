using System.Text;
using System.Text.Json;
using Newtonsoft.Json;
using Project.Web.Models;

namespace Project.Web.Service
{
    public class CategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:7267/api/Category");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Category>>(responseString);
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7267/api/Category/{id}");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Category>(responseString);
        }

        public async Task PostCategoryAsync(Category category)
        {
            var categoryJson = JsonConvert.SerializeObject(category);
            var content = new StringContent(categoryJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7267/api/Category", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task PutCategoryAsync(Category category)
        {
            var categoryJson = JsonConvert.SerializeObject(category);
            var content = new StringContent(categoryJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"https://localhost:7267/api/Category/{category.CategoryId}", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7267/api/Category/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
