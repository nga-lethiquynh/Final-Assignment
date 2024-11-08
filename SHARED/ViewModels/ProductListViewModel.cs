using System.Collections.Generic;

namespace ShoeStore.Shared.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<ProductDetailViewModel> Products { get; set; }
    }
}