using System.Collections.Generic;

namespace ShoeStore.Shared.Dtos
{
    public class ProductListDto
    {
        public IEnumerable<ProductDetailDto> Products { get; set; }
    }
}