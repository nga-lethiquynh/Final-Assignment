using Microsoft.AspNetCore.Mvc;
using ShoeStore.Shared.Dtos;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ShoeStore.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;

        public HomeController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _httpClient.GetFromJsonAsync<IEnumerable<CategoryDto>>("api/categories");
            ViewBag.Categories = categories;
            return View();
        }
    }
}
