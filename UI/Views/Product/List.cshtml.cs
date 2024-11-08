using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoeStore.Shared.Dtos;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ShoeStore.UI.Pages.Product
{
    public class ListModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public ListModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IEnumerable<ProductDto> Products { get; set; }

        public async Task OnGetAsync(int categoryId)
        {
            Products = await _httpClient.GetFromJsonAsync<IEnumerable<ProductDto>>($"api/products?categoryId={categoryId}");
        }
    }
}
