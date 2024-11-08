using Microsoft.AspNetCore.Mvc;
using ShoeStore.Shared.Dtos;
using ShoeStore.UI.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ShoeStore.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient _httpClient;

        public ProductController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> List(int categoryId)
        {
            var products = await _httpClient.GetFromJsonAsync<ProductDto[]>($"api/products?categoryId={categoryId}");
            return View(products);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _httpClient.GetFromJsonAsync<ProductDto>($"api/products/{id}");
            return View(product);
        }
    }
}
