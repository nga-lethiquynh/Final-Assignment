using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoeStore.Shared.Dtos;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ShoeStore.UI.Pages.Product
{
    public class DetailsModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public DetailsModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public ProductDto Product { get; set; }

        public async Task OnGetAsync(int id)
        {
            Product = await _httpClient.GetFromJsonAsync<ProductDto>($"api/products/{id}");
        }
    }
}